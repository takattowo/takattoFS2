using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using takattoFS2.Controls.Models;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;
using System.Text.RegularExpressions;

namespace takattoFS2.Forms
{
    public partial class ConnectingForm_New : Form 
    {
        static ConnectingForm_New _frmObj;
        public static ConnectingForm_New frmObj
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }

        async void LoadPic()
        {
            try
            {
                //pbLoader.ImageLocation = string.Format(Urls.Loading, new Random().Next(0, 6));
                //pbLoader.Load();
                if (UserSettings.LoadBGCount <= 0)
                    return;

                wc.DownloadFile(string.Format(Urls.Loading, new Random().Next(0, UserSettings.LoadBGCount)), Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AssetAppData, "loading"));

                //panel2.BackgroundImage = pbLoader.Image;
            }
            catch { }       
        }
        
        string state;
        public ConnectingForm_New(string state)
        {
            this.state = state;
            WebRequest.DefaultWebProxy = null;
            InitializeComponent();

            if (File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AssetAppData, "loading")))
            {
                try
                {
                    using (FileStream stream = new FileStream(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AssetAppData, "loading"), FileMode.Open, FileAccess.Read))
                    {
                        pbLoader.Image = Image.FromStream(stream);
                        panel2.BackgroundImage = pbLoader.Image;

                        stream.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            if (MainForm.mf.nDPI >= 168)
                Size = new Size(Width, Height + (int)(Height / 10));

            //int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            //style |= NativeMethods.WS_EX_COMPOSITED;
            //NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);

            frmObj = this;
            StartPosition = FormStartPosition.Manual;
            Rectangle screenRectangle = RectangleToScreen(ClientRectangle);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height + (screenRectangle.Top - Top - 2));

            if(this.state != "close")
                ServiceRegistration(); 
        }

        void ServiceRegistration() //handle network security error on windows7 or lower
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        private void ConnectingForm_New_Load(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            progressBar1.BackColor = Color.FromArgb(new Random().Next(0,256), new Random().Next(0,256), new Random().Next(0,256));

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormBorderStyle = FormBorderStyle.Sizable;
            Text = string.Empty;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ControlBox = false;
            ActiveControl = null;

            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;

            if (state == "close")
            {
                timer1.Enabled = true;
                lbSeeya.Visible = true;
                btnClose.Visible = false;
                pbStatus.Visible = false;
                progressBar1.Visible = false;
                CloseForm();
                return;
            }

            tima2 = new System.Timers.Timer(new Random().Next(1000,2000));
            tima2.Elapsed += OnTweakTimedEvent_tima2;
            tima2.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbSeeya.Text = lbSeeya.Text.Replace("-", "--");
            lbSeeya.Text = lbSeeya.Text.Replace("--------", "-");
        }

        private void OnTweakTimedEvent_tima2(object sender, ElapsedEventArgs e)
        {
            tima2.Enabled = false;
            Check();
        }

        readonly WebClient wc = new WebClient();
        private static StringTheory KAT = new StringTheory();

        private void CloseForm()
        {

            SoundPlayer nyannyan = new SoundPlayer(Properties.Resources.shizuku);
            nyannyan.Play();

            try
            {
                if (File.Exists(Methods.GetFolder("temp_", Strings.FileName.StageData)))
                    File.Delete(Methods.GetFolder("temp_", Strings.FileName.StageData));
            }
            catch { }
        }

        private async void Check()
        {
            string patchCheckedVersionS = null;
            //int patchCheckedVersion = 0;
            //int currentversion = Methods.GetInt(AssemblyAccessor.Version);
            string patchCheckVersionURL = Urls.Server + '/' + "version.txt";

            string patchCheckedVersionOg = null;
            //int patchCheckedVersionOG = 0;
            string strPattern = @"^\d+(\.\d+)*$"; // Matches x.x or x.x.x or x.x.x.x
            //string strpattern = @"^\d*[.]\d*[.]\d*[.]\d*$"; //0.0.0.0
            var regex = new System.Text.RegularExpressions.Regex(strPattern);
            bool isSeverDown = false;
            try
            {
                patchCheckedVersionS = wc.DownloadString(patchCheckVersionURL);

                //if (regex.Match(patchCheckedVersionS).Success)
                //    patchCheckedVersion = Methods.GetInt(patchCheckedVersionS);
                //else
                if (!regex.Match(patchCheckedVersionS).Success)
                {
                    pbStatus.Image = Properties.Resources.icons8_red_circle_35;
                    progressBar1.Value = 100;
                    MsgBoxs.Warning.ServerError();
                    Logger.Write("The server is not responding to any request. Kat-code: 404");
                    isSeverDown = true;
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                
                if (state != "close" && !MainForm.mf.firstTime)
                {
                    await Task.Run(() => LoadPic());              
                }

                pbStatus.Image = Properties.Resources.icons8_green_circle_35;
                await Task.Delay(100);
                progressBar1.Value = 20;
            }
            catch (Exception e)
            {
                Logger.Write("Could not fetch the version info. Kat-code: " + e.ToString());

                if (Urls.isCustomServerEnabled)
                {
                    MsgBoxs.Warning.ServerErrorCustom();
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                    return;
                }

                try
                {
                    using (var client = new WebClient())
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        pbStatus.Image = Properties.Resources.icons8_red_circle_35;
                        MsgBoxs.Warning.ServerError();
                        Logger.Write("The server is not responding to any request. Kat-code: 404");
                        isSeverDown = true;
                    }
                }
                catch
                {
                    pbStatus.Image = Properties.Resources.icons8_red_circle_35;
                    progressBar1.Value = 100;
                    MsgBoxs.Warning.UserIsOffline();
                    //Logger.Write("Starting program in offline mode. Kat-code: 404");
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
            } //eat it

            if (!isSeverDown)
            {
                if (patchCheckedVersionS.Equals("0"))
                {
                    MsgBoxs.Warning.ProgramIsDisabled();
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                    Close();
                }
                
                //if (patchCheckedVersion > currentversion)
                if(Methods.CompareVersions(AssemblyAccessor.Version, patchCheckedVersionS) == -1)
                {
                    new SoundPlayer(Properties.Resources.nyannyan_).Play();
                    progressBar1.ForeColor = Color.Lavender;
                    progressBar1.BackColor = Color.Blue;
                    progressBar1.Value = 100;

                    await Task.Delay(1029);
                    CleanUp();
                    return;
                }

                if (Urls.isCustomServerEnabled)
                {
                    MainForm.mf.TitleLabel.Text = "[Unofficial Server]";
                    
                    try
                    {
                        var patchCheckVersionURLOg = Urls.OriginalServer + '/' + "version.txt";
                        patchCheckedVersionOg = wc.DownloadString(patchCheckVersionURLOg);

                        if (regex.Match(patchCheckedVersionOg).Success)
                        {
                            if (Methods.CompareVersions(AssemblyAccessor.Version, patchCheckedVersionOg) == -1)
                            {
                                MsgBoxs.Information.NewProgramUpdateBase();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Write("Could not fetch the base version info from original server. Kat-code: " + e.ToString());
                    }
                }
            }

            string universalSettingsURL = Urls.ServerSettings;
            string universalServiceSettingsURL = Urls.ServerServiceSettings;
            string strMsgData = null;
            string universalSettings = null;
            byte[] flashPATH = null;
            string flashPATHUri = Urls.ServerFLASHPATH;
            string universalServiceSettings = null;

            if (!isSeverDown)
            {
                try
                {
                    await Task.Delay(100);
                    progressBar1.Value += new Random().Next(1, 5);
                    var htmlData3 = wc.DownloadData(universalSettingsURL);
                    universalSettings = KATEncryptor.Decrypt(Encoding.UTF8.GetString(htmlData3), 2);

                    //var htmlData4 = wc.DownloadData(universalServiceSettingsURL);
                    //universalServiceSettings = KATEncryptor.Decrypt(Encoding.UTF8.GetString(htmlData4), 2);


                    if (!string.IsNullOrEmpty(universalSettings))
                    {
                        KAT = JsonConvert.DeserializeObject<StringTheory>(universalSettings);
                        //KAT = JsonConvert.DeserializeObject<StringTheory>(universalServiceSettings);
                        progressBar1.Value += new Random().Next(15, 25);
                    }
                    else
                    {
                        await Task.Delay(500);
                        try { KAT = JsonConvert.DeserializeObject<StringTheory>(KATEncryptor.Decrypt(PatcherSettings.GetValue(PatcherSettings.takatto29kat),1)); progressBar1.Value += new Random().Next(25, 40); }
                        catch (Exception ew)
                        {
                            MsgBoxs.Warning.Error(ew.ToString());
                            Process.GetCurrentProcess().Kill();
                            Environment.Exit(0);
                        }
                    }

                    try
                    {
                        if (KAT != null && !string.IsNullOrEmpty(StringTheory.Sweet.messageDataUri))
                        {
                            var htmlDat3a3 = wc.DownloadData(flashPATHUri);
                            flashPATH = htmlDat3a3;
                        }
                    }
                    catch (Exception wwa) { Logger.Write("Error while downloading FLASH_PATH data. Kat-code: " + wwa.ToString()); }//eat it

                    try
                    {
                        if (KAT != null && !string.IsNullOrEmpty(StringTheory.Sweet.messageDataUri))
                        {
                            var htmlData2 = wc.DownloadData(Methods.BasedLanguageUri(StringTheory.Sweet.messageDataUri));
                            strMsgData = Encoding.UTF8.GetString(htmlData2);
                        }
                    }
                    catch (Exception wwa) { Logger.Write("Error while downloading sweet data. Kat-code: " + wwa.ToString()); }//eat it
                }
                catch (Exception wa)
                {
                    Logger.Write("Error while parsing. Kat-code: " + wa.ToString() + " Process to use lastest working local data if exists.");
                    try { KAT = JsonConvert.DeserializeObject<StringTheory>(KATEncryptor.Decrypt(PatcherSettings.GetValue(PatcherSettings.takatto29kat),1)); progressBar1.Value += new Random().Next(25, 40); }
                    catch (Exception ew)
                    {
                        MsgBoxs.Warning.Error(ew.ToString());
                        Process.GetCurrentProcess().Kill();
                        Environment.Exit(0);
                    }

                    MainForm.mf.TitleLabel.Text = Urls.isCustomServerEnabled? "[Unofficial Server - Offline Mode]" : "[Offline Mode]";
                    
                    Logger.Write("Local data has successfully loaded!");
                }

                try
                {
                    if (!string.IsNullOrEmpty(StringTheory.Universal.ServiceUri))
                    {
                        var htmlData4 = wc.DownloadData(StringTheory.Universal.ServiceUri);
                        universalServiceSettings = KATEncryptor.Decrypt(Encoding.UTF8.GetString(htmlData4), 2);

                        if (!string.IsNullOrEmpty(universalServiceSettings))
                        {
                            KAT = JsonConvert.DeserializeObject<StringTheory>(universalServiceSettings);
                            progressBar1.Value += new Random().Next(5, 10);
                        }
                    }
                    else
                    {
                        var htmlData4 = wc.DownloadData(universalServiceSettingsURL);
                        universalServiceSettings = KATEncryptor.Decrypt(Encoding.UTF8.GetString(htmlData4), 2);
                        KAT = JsonConvert.DeserializeObject<StringTheory>(universalServiceSettings);
                        progressBar1.Value += new Random().Next(5, 10);
                    }
                }
                catch (Exception ew)
                {
                    MainForm.mf.TitleLabel.Text = "[Service Error]";
                    Logger.Write(ew.ToString());
                }
                
            }
            else
            {
                Logger.Write("Starting offline mode.");
                MainForm.mf.TitleLabel.Text = Urls.isCustomServerEnabled ? "[Unofficial Server - Offline Mode]" : "[Offline Mode]";
                try { KAT = JsonConvert.DeserializeObject<StringTheory>(KATEncryptor.Decrypt(PatcherSettings.GetValue(PatcherSettings.takatto29kat),1)); progressBar1.Value += new Random().Next(25, 40); }
                catch (Exception e)
                {
                    MsgBoxs.Warning.Error(e.ToString());
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }

                Logger.Write("Local data has successfully loaded!");
            }

            UserSettings.LoadBGCount = StringTheory.Universal.LoadBGCount;                

            if (StringTheory.Sweet.isServerSideEnabled)
            {
                progressBar1.Value += new Random().Next(2, 3);
                if (StringTheory.Sweet.Hikari.isEnabled)
                    LoadImage(StringTheory.Sweet.Hikari);

                progressBar1.Value += new Random().Next(2, 3);
                if (StringTheory.Sweet.Yuzuki.isEnabled)
                    LoadImage(StringTheory.Sweet.Yuzuki);

                progressBar1.Value += new Random().Next(2, 3);
                if (StringTheory.Sweet.Nako.isEnabled)
                    LoadImage(StringTheory.Sweet.Nako);

                progressBar1.Value += new Random().Next(1, 2);
                if (StringTheory.Sweet.Hikari.noise!= null && StringTheory.Sweet.Hikari.noise.Any())
                    LoadNoise(StringTheory.Sweet.Hikari.noise[new Random().Next(StringTheory.Sweet.Hikari.noise.Count)],0);
                progressBar1.Value += new Random().Next(1, 2);
                if (StringTheory.Sweet.Yuzuki.noise != null && StringTheory.Sweet.Yuzuki.noise.Any())
                    LoadNoise(StringTheory.Sweet.Yuzuki.noise[new Random().Next(StringTheory.Sweet.Yuzuki.noise.Count)],1);
                progressBar1.Value += new Random().Next(1, 2);
                if (StringTheory.Sweet.Nako.noise != null && StringTheory.Sweet.Nako.noise.Any())
                    LoadNoise(StringTheory.Sweet.Nako.noise[new Random().Next(StringTheory.Sweet.Nako.noise.Count)],2);
            }

            if (!string.IsNullOrEmpty(StringTheory.Universal.CatPrefix) && StringTheory.Universal.CatPrefix != "cat")
            {
                for (int i = 0; i <= 6; i++)
                {
                    progressBar1.Value += new Random().Next(1, 2);
                    LoadCat(StringTheory.Universal.CatPrefix + i.ToString());             
                }              
            }

            MainForm.mf.GetCatBitmap();

            progressBar1.Value += new Random().Next(3, 5);
            if (!string.IsNullOrEmpty(universalSettings) && !string.IsNullOrWhiteSpace(universalSettings))
                PatcherSettings.SetValue(PatcherSettings.takatto29kat, KATEncryptor.Encrypt(universalSettings,1)); //WithoutCrypting

            if (!string.IsNullOrEmpty(universalSettings) && !string.IsNullOrWhiteSpace(universalSettings))
                PatcherSettings.SetValueWithoutCrypting(PatcherSettings.takatto12kat, flashPATH); //WithoutCrypting

            if (!string.IsNullOrEmpty(strMsgData) && !string.IsNullOrWhiteSpace(strMsgData))
            {
                parseSweetDataMSG(strMsgData);
                PatcherSettings.SetValue(PatcherSettings.takatto11000, KATEncryptor.Encrypt(strMsgData,1)); //WithoutCrypting
            }
            else
            {
                string msgLoveLetterData = KATEncryptor.Decrypt(PatcherSettings.GetValue(PatcherSettings.takatto11000),1); //WithoutCrypting
                if (string.IsNullOrEmpty(msgLoveLetterData))
                    msgLoveLetterData = Strings.Misc.LoveLetterMsgDefault;

                parseSweetDataMSG(msgLoveLetterData);
            }

            progressBar1.Value += new Random().Next(1, 2);
            //ToRemove();
            //ToChange();


            if (!string.IsNullOrEmpty(Methods.GetGameFolder()) && Methods.IsValidFS2Path(Methods.GetGameFolder()))
            {
                Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.Data));
                Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.Extension));
                Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.CustomPatch));
                Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.CustomTexture));
                Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.CustomUI));
            }

            progressBar1.Value = 94;

            EnableTimer3WhyDoIHaveToCreateAMeThodForDISSHIT();
        }

        public void LoadNoise(string st, int character)
        {
            if (string.IsNullOrEmpty(st)) return;
            using (WebClient client = new WebClient())
            {
                try
                {
                    var uri = String.Format(Urls.SweetNoiseFormat, st);
                    switch (character)
                    {
                        case 0:
                            MainForm.mf.anhong.SoundLocation = uri;
                            MainForm.mf.anhong.Load();
                            break;
                        case 1:
                            MainForm.mf.anhongYuzuki.SoundLocation = uri;
                            MainForm.mf.anhongYuzuki.Load();
                            break;
                        case 2:
                            MainForm.mf.anhongNako.SoundLocation = uri;
                            MainForm.mf.anhongNako.Load();
                            break;
                    }
                }
                catch (Exception e)
                {
                    client.CancelAsync();
                    Logger.Write("The asset " + st + " has failed to download. Kat-code: " + e.ToString());
                }
            }
        }

        public void ToRemove()
        {
            if (StringTheory.Universal.ToRemove.Any())
            {
                if (!string.IsNullOrEmpty(Methods.GetGameFolder()))
                {
                    for (int i = 0; i < StringTheory.Universal.ToRemove.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(StringTheory.Universal.ToRemove[i]))
                        {
                            if(progressBar1.Value < 100)
                                progressBar1.Value += 1;
                            var ed = KATEncryptor.Decrypt(StringTheory.Universal.ToRemove[i], 1);
                            var dee = Methods.GetFolder(ed.Replace("/", "\\"));
                            if (File.Exists(dee))
                                File.Delete(dee);
                        }
                    }
                }
            }
        }

        public void ToChange()
        {
            if (StringTheory.Universal.ToChange.Any())
            {
                if (!string.IsNullOrEmpty(Methods.GetGameFolder()))
                {
                    foreach (var tuplet in StringTheory.Universal.ToChange)
                    {                    
                        if(!string.IsNullOrEmpty(tuplet.Item1) && !string.IsNullOrEmpty(tuplet.Item2))
                        {
                            switch (tuplet.Item3)
                            {
                                case true:
                                    if (Directory.Exists(Methods.GetFolder(tuplet.Item1)))
                                    {
                                        try
                                        {
                                            if (Directory.Exists(Methods.GetFolder(tuplet.Item2)))
                                                Directory.Delete(Methods.GetFolder(tuplet.Item2));


                                            Directory.Move(Methods.GetFolder(tuplet.Item1), Methods.GetFolder(tuplet.Item2));
                                        }
                                        catch (Exception e)
                                        {
                                            Logger.Write("Could not rename the folder. Kat-code: " + e.ToString());
                                        }
                                    }

                                    break;
                                case false:
                                    Methods.MoveFile(Methods.GetFolder(tuplet.Item1), Methods.GetFolder(tuplet.Item2), false);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void parseSweetDataMSG(string msgLoveLetterData)
        {
            string hikariWelcome = msgLoveLetterData.Split('\\').ElementAt(0);
            string hikari = msgLoveLetterData.Split('\\').ElementAt(1);
            string yuzuki = msgLoveLetterData.Split('\\').ElementAt(2);
            string nako = msgLoveLetterData.Split('\\').ElementAt(3);
            string hikarilove = msgLoveLetterData.Split('\\').ElementAt(4);
            string yuzukilove = msgLoveLetterData.Split('\\').ElementAt(5);
            string nakolove = msgLoveLetterData.Split('\\').ElementAt(6);
            string hikariangry = msgLoveLetterData.Split('\\').ElementAt(7);
            string yuzukiangry = msgLoveLetterData.Split('\\').ElementAt(8);
            string nakoangry = msgLoveLetterData.Split('\\').ElementAt(9);
            string hikariloved = msgLoveLetterData.Split('\\').ElementAt(10);
            string yuzukiloved = msgLoveLetterData.Split('\\').ElementAt(11);
            string nakoloved = msgLoveLetterData.Split('\\').ElementAt(12);
            string nakowelcome = msgLoveLetterData.Split('\\').ElementAt(13);

            List<string> hikariWelcomeList = new List<string>();
            List<string> hikariList = new List<string>();
            List<string> yuzukiList = new List<string>();
            List<string> nakoList = new List<string>();
            List<string> hikariloveList = new List<string>();
            List<string> yuzukiloveList = new List<string>();
            List<string> nakoloveList = new List<string>();
            List<string> hikariangryList = new List<string>();
            List<string> yuzukiangryList = new List<string>();
            List<string> nakoangryList = new List<string>();
            List<string> hikarilovedList = new List<string>();
            List<string> yuzukilovedList = new List<string>();
            List<string> nakolovedList = new List<string>();
            List<string> nakowelcomeList = new List<string>();

            foreach (string msg in hikariWelcome.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    hikariWelcomeList.Add(msg);
            foreach (string msg in hikari.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    hikariList.Add(msg);
            foreach (string msg in yuzuki.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    yuzukiList.Add(msg);
            foreach (string msg in nako.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    nakoList.Add(msg);
            foreach (string msg in hikarilove.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    hikariloveList.Add(msg);
            foreach (string msg in yuzukilove.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    yuzukiloveList.Add(msg);
            foreach (string msg in nakolove.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    nakoloveList.Add(msg);
            foreach (string msg in hikariangry.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    hikariangryList.Add(msg);
            foreach (string msg in yuzukiangry.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    yuzukiangryList.Add(msg);
            foreach (string msg in nakoangry.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    nakoangryList.Add(msg);
            foreach (string msg in hikariloved.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    hikarilovedList.Add(msg);
            foreach (string msg in yuzukiloved.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    yuzukilovedList.Add(msg);
            foreach (string msg in nakoloved.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    nakolovedList.Add(msg);
            foreach (string msg in nakowelcome.Split('|'))
                if (!string.IsNullOrWhiteSpace(msg))
                    nakowelcomeList.Add(msg);

            PatcherSettings.msgStrHikariWelcome = hikariWelcomeList.ToArray();
            PatcherSettings.msgStrHikari = hikariList.ToArray();
            PatcherSettings.msgStrYuzuki = yuzukiList.ToArray();
            PatcherSettings.msgStrNako = nakoList.ToArray();
            PatcherSettings.msgStrHikariLove = hikariloveList.ToArray();
            PatcherSettings.msgStrYuzukiLove = yuzukiloveList.ToArray();
            PatcherSettings.msgStrNakoLove = nakoloveList.ToArray();
            PatcherSettings.msgStrHikariAngry = hikariangryList.ToArray();
            PatcherSettings.msgStrYuzukiAngry = yuzukiangryList.ToArray();
            PatcherSettings.msgStrNakoAngry = nakoangryList.ToArray();
            PatcherSettings.msgStrHikariLoved = hikarilovedList.ToArray();
            PatcherSettings.msgStrYuzukiLoved = yuzukilovedList.ToArray();
            PatcherSettings.msgStrNakoLoved = nakolovedList.ToArray();
            PatcherSettings.msgStrNakoWelcome = nakowelcomeList.ToArray();

            PatcherSettings.yuzukiName = StringTheory.Sweet.Yuzuki.isEnabled && StringTheory.Sweet.isServerSideEnabled ? ((!string.IsNullOrEmpty(StringTheory.Sweet.Yuzuki.altName)) ? StringTheory.Sweet.Yuzuki.altName : "Yuzuki") : "Yuzuki";
            PatcherSettings.nakoName = StringTheory.Sweet.Nako.isEnabled && StringTheory.Sweet.isServerSideEnabled ? ((!string.IsNullOrEmpty(StringTheory.Sweet.Nako.altName)) ? StringTheory.Sweet.Nako.altName : "Nakoruru") : "Nakoruru";
            PatcherSettings.hikariName = StringTheory.Sweet.Hikari.isEnabled && StringTheory.Sweet.isServerSideEnabled ? ((!string.IsNullOrEmpty(StringTheory.Sweet.Hikari.altName)) ? StringTheory.Sweet.Hikari.altName : "Hikari") : "Hikari";

        }

        public void LoadCat(string sthing)
        {
            if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.CatData, sthing)))
                Methods.DownloadSweetAsset(Urls.CatFormat, sthing, Strings.FolderName.CatData, true);
        }

        public void LoadImage(Cutie sthing)
        {
            if (!string.IsNullOrEmpty(sthing.normalState))
                if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, sthing.normalState)) || StringTheory.Sweet.isForceRedownload)
                    Methods.DownloadSweetAsset(Urls.SweetFormat, sthing.normalState, Strings.FolderName.SweetData, false);

            if (!string.IsNullOrEmpty(sthing.happiState))
                if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, sthing.happiState)) || StringTheory.Sweet.isForceRedownload)
                    Methods.DownloadSweetAsset(Urls.SweetFormat, sthing.happiState, Strings.FolderName.SweetData, false);

            if (!string.IsNullOrEmpty(sthing.angeriiiiiState))
                if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, sthing.angeriiiiiState)) || StringTheory.Sweet.isForceRedownload)
                    Methods.DownloadSweetAsset(Urls.SweetFormat, sthing.angeriiiiiState, Strings.FolderName.SweetData, false);

            if (!string.IsNullOrEmpty(sthing.background))
                if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, sthing.background)) || StringTheory.Sweet.isForceRedownload)
                    Methods.DownloadSweetAsset(Urls.SweetFormat, sthing.background, Strings.FolderName.SweetData, false);
        }

        public bool isUp2Date = false;
        public static System.Timers.Timer tima3;
        public static System.Timers.Timer tima2;
        public void EnableTimer3WhyDoIHaveToCreateAMeThodForDISSHIT()
        {
            tima3 = new System.Timers.Timer(200);
            tima3.Elapsed += OnTweakTimedEvent_tima;
            tima3.Enabled = true;
        }

        void CheckForBlacklist()
        {
            if (File.Exists(UserSettings.PatcherBlackListPath))
            {
                var ct =  UserSettings.PatcherBlackListContent;
                if (string.IsNullOrEmpty(ct))
                {
                    MainForm.mf.CheckForBlacklist();
                    return;
                }

                bool isBanned = false;
                if (StringTheory.Universal.BlockedUsers.Any())
                {
                    progressBar1.Value += 1;
                    for (int i = 0; i < StringTheory.Universal.BlockedUsers.Count; i++)
                    {
                        var user = KATEncryptor.Decrypt(StringTheory.Universal.BlockedUsers[i], 1);

                        if (ct.Contains(user))
                        {
                            MainForm.mf.Blacked(false, "");
                            isBanned = true;
                            break;
                        }
                            
                    }

                    if(!isBanned)
                        MainForm.mf.CheckForBlacklist();
                }
            }
            else 
                MainForm.mf.CheckForBlacklist();
        }
        
        void TheFinalTouch()
        {
            ToRemove();
            progressBar1.Value += 2;
            ToChange();
            progressBar1.Value += 2;
            CheckForBlacklist();
            progressBar1.Value = 100;
        }
        
        bool isGameRunning = true;
        private void OnTweakTimedEvent_tima(object sender, ElapsedEventArgs e)
        {
            if (!isGameRunning)
            {
                tima3.Enabled = false;
                TheFinalTouch();
                Close();
            }

            if (Methods.IsFreeStyle2Running())
            {
                if (!notified)
                {
                    notified = true;
                    MsgBoxs.Warning.CloseFS2InstanceFirst();
                }

                isGameRunning = true;
            }
            else
            {
                isGameRunning = false;
                isUp2Date = true;
            }
        }

        bool notified = false;
        public void CleanUp()
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder));
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            try
            {
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Strings.Misc.Installer));
                Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }
            catch
            {
                MsgBoxs.Information.NewProgramUpdate();
                //Process.Start(guideUrl);
                Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }

            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
            Close();
        }

        int count = 0;
        private void CheckIfStuck_Tick(object sender, EventArgs e)
        {
            if (count++ > 120)
            {
                if(isGameRunning)
                {
                    count = 0;
                }
                else
                    MainForm.mf.Enable_PatcherRestartTimer();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, (int)NativeMethods.WindowMessages.WM_NCLBUTTONDOWN, (int)NativeMethods.HitTestValues.HTCAPTION, 0);
            }
        }
    }
}
