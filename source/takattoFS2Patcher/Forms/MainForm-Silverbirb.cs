using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using takattoFS2.Controls;
using takattoFS2.Controls.Models;
using takattoFS2.Controls.UserControls;
using takattoFS2.Forms.SubForms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;
using WK.Libraries.BetterFolderBrowserNS;
using Timer = System.Timers.Timer;

namespace takattoFS2.Forms
{
    public partial class MainForm : FormBase
    {
        int mute = 1;
        private int defaultNation;
        private string defaultLanguage;
        readonly SoundPlayer cat = new SoundPlayer(Properties.Resources.meow2);
        readonly SoundPlayer nyannyan = new SoundPlayer(Properties.Resources.nyannyan_);
        readonly SoundPlayer ping = new SoundPlayer(Properties.Resources.UI_GG_COMPLETE);
        internal SoundPlayer anhong = new SoundPlayer(Properties.Resources.hi_ACT_GREET_01);
        internal SoundPlayer anhongYuzuki;
        internal SoundPlayer anhongNako = new SoundPlayer(Properties.Resources.nako_hi);

        private static MainForm _frmObj;
        public static MainForm mf
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }

        public static Timer heartGetEachHour2;

        public static Timer hideHint;
        private static Timer loadPatches;

        private static Timer patcherClosingTimer;
        private static Timer aTimer; //waiting for game and patch
        private static Timer checkingTweakDLC;
        private static Timer isGameRunningTimer;
        private static Timer tweakTimer;

        public static DownloadForm dForm = null;
        public static ProcessForm wForm = null;


        WebClient wc = new WebClient();

        private void setTimer()
        {
            Logger.Write("System services are being started");
            heartGetEachHour2 = new Timer(29 * 60 * 1000);//29 * 60 * 
            heartGetEachHour2.Elapsed += new ElapsedEventHandler(heartGetEachHourEvent);
            heartGetEachHour2.Enabled = true;

            hideHint = new System.Timers.Timer(5290);
            hideHint.Elapsed += OnTweakTimedEvent_hideHint;

            loadPatches = new System.Timers.Timer(20);
            loadPatches.Elapsed += OnTweakTimedEvent_loadPatches;

            checkingTweakDLC = new System.Timers.Timer(29);
            checkingTweakDLC.Elapsed += OnTweakTimedEvent_DLCChecking;
            checkingTweakDLC.Enabled = true;

            isGameRunningTimer = new System.Timers.Timer(1000);
            isGameRunningTimer.Elapsed += OnTimedEvent_isGameRunning;

            tweakTimer = new System.Timers.Timer(1920);
            tweakTimer.Elapsed += OnTweakTimedEvent;

            patcherClosingTimer = new System.Timers.Timer(3190);
            patcherClosingTimer.Elapsed += ClosingTimer;
        }


        internal void MCVoiceTweak()
        {
            string dlc6Language;
            switch (UserSettings.MCVoiceLanguage)
            {
                default:
                case 0:
                    dlc6Language = string.Empty;
                    languageValue = defaultNation;
                    break;
                case 1:
                    dlc6Language = "vi";
                    languageValue = defaultNation;
                    break;
                case 2:
                    dlc6Language = "cn";
                    languageValue = 0;
                    break;
                case 3:
                    dlc6Language = "kr";
                    languageValue = 0;
                    break;
                case 4:
                    dlc6Language = "fa";
                    languageValue = defaultNation;
                    break;
                case 5:
                    dlc6Language = "kat";
                    languageValue = defaultNation;
                    break;
            }

            Methods.Tweaks.DLC6Swap(dlc6Language, languageValue, defaultLanguage, defaultNation, overrideFont);
        }

        void CharVoiceTweak()
        {
            string dlc5Language;
            switch (UserSettings.CharVoiceLanguage)
            {
                default:
                case 0:
                    dlc5Language = string.Empty;
                    break;
                case 1:
                    dlc5Language = "en";
                    break;

                case 2:
                    dlc5Language = "kr";
                    break;

                case 3:
                    dlc5Language = "cn";
                    break;

                case 4:
                    dlc5Language = "jp";
                    break;
            }

            Methods.Tweaks.DLC5Swap(dlc5Language);
        }

        internal ComboBox cbDefaultCourtTweak = new ComboBox();

        internal void MapTweak()
        {
            var defaultMapName = cbDefaultCourtTweak.SelectedItem.ToString();
            switch (CourtMap)
            {
                case 1:
                    Methods.Tweaks.CourtSwap(Strings.KattoFileName.DLC1Training, Strings.KattoFileName.DLC1TrainingCN);
                    break;
                case 2:
                    Methods.Tweaks.CourtSwap(Strings.KattoFileName.DLC1Katto, Strings.KattoFileName.DLC1KattoCN);
                    break;
                case 3:
                    Methods.Tweaks.CourtSwap(Strings.KattoFileName.DLC1Beach, Strings.KattoFileName.DLC1BeachCN);
                    break;
                case 4:
                    Methods.Tweaks.CourtSwap(Strings.KattoFileName.DLC1Warehouse, Strings.KattoFileName.DLC1WarehouseCN);
                    break;
                case 5:
                    Methods.Tweaks.CourtSwap(Strings.KattoFileName.DLC1Custom, Strings.KattoFileName.DLC1CustomCN);
                    break;
                case 6:
                    if (string.IsNullOrEmpty(defaultMapName) || defaultMapName.ToLower() == "none")
                        return;

                    Methods.Tweaks.DefaultCourtSwap(defaultMapName);
                    break;

                default:
                    break;
            }
        }

        void JukeboxTweak()
        {
            Methods.Tweaks.JukeboxTweak();
        }

        void CustomPatchTweak()
        {
            Methods.Tweaks.CustomPatchTweak();
        }

        internal bool CustomPatchEnabled;
        internal void ApplyTweak()
        {
            Methods.Tweaks.WriteGameSettings();

            if (Methods.IsCharacterVoiceInstalled() && UserSettings.CharVoiceLanguage > 0)
                CharVoiceTweak();

            if (Methods.IsMCVoiceInstalled() && UserSettings.MCVoiceLanguage > 0)
                MCVoiceTweak();

            if (Methods.IsJukeBoxDLCinstalled() && UserSettings.JukeboxTweakSetting)
                JukeboxTweak();

            if (takService_card_viewer && isZaCardoUpdated && UserSettings.UITweakSetting)
                CardViewTweak();

            if (Methods.IsCustomPatchAvailable() && CustomPatchEnabled)
                CustomPatchTweak();

            if (CourtMap >= 1)
                MapTweak();
        }

        int afkCount = 0;
        IntPtr hWnd = (IntPtr)null;
        internal int CourtMap = 0; //0 is default, 1 is training, 2 katto, 3 beach, 4 warehouse, 5 custom, 6 defaultmaps
        private void OnTweakTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (UserSettings.AKFTweakSetting)
            {
                if (isGameRunning)
                {
                    afkCount += 2;
                    if (afkCount >= UserSettings.AFKTweakInterval + 1)
                    {
                        afkCount = 0;
                        hWnd = Methods.ProcessHandler();
                        if (hWnd != (IntPtr)null)
                        {
                            NativeMethods.SendMessage(hWnd, 0x204, 0, 0); //down
                            NativeMethods.SendMessage(hWnd, 0x205, 0, 0); //up
                        }
                    }
                }
            }
        }

        //titlebar
        private void InitializeTitleBar()
        {
            Activated += MainForm_Activated;
            Deactivate += MainForm_Deactivate;

            foreach (var control in new[] { SystemLabel, MinimizeLabel, CloseLabel })
            {
                control.MouseEnter += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Hover, ContainsFocus);
                control.MouseLeave += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, ContainsFocus);
                control.MouseDown += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Down, ContainsFocus);
            }

            TitleLabel.MouseDown += TitleLabel_MouseDown;
            TitleLabel.MouseUp += (s, e) => { if (e.Button == MouseButtons.Right && TitleLabel.ClientRectangle.Contains(e.Location)) ShowSystemMenu(MouseButtons); };
            //TitleLabel.Text = Text;
            TextChanged += (s, e) => TitleLabel.Text = Text;

            var marlett = new Font("Marlett", 8.5f);
            MinimizeLabel.Font = marlett;
            CloseLabel.Font = marlett;
            SystemLabel.Font = marlett;
            TitleLabel.Font = MemoryFonts.SetFont(0, TitleLabel.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);

            MinimizeLabel.MouseClick += (s, e) => { if (e.Button == MouseButtons.Left) WindowState = FormWindowState.Minimized; ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, !ContainsFocus); MainForm_Resize(null, null); };
            CloseLabel.MouseClick += (s, e) => { Close(e); ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, ContainsFocus); };
            SystemLabel.MouseClick += (s, e) => { contextLauncher.Show(Cursor.Position.X + SystemLabel.Width / 4, Cursor.Position.Y + SystemLabel.Height / 4); ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, ContainsFocus); };

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(1, 1, Width, Height, 10, 10));

            var shadow = new Dropshadow(this)
            {
                ShadowV = 4,
                ShadowBlur = 26,
                ShadowSpread = -8,
                ShadowColor = Color.FromArgb(99, 0, 0, 0)
            };

            shadow.RefreshShadow();
        }

        void Close(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Close();
        }

        void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (isGameRunning)
            {
                tweaklodPc.Enabled = false;
                servicelodPc.Enabled = false;
            }
            ColorEnum.SetBorderColor(ColorEnum.InactiveBorderColor, new List<Control> { TopBorderPanel, LeftBorderPanel, RightBorderPanel, BottomBorderPanel });
            ColorEnum.SetTextColor(ColorEnum.InactiveTextColor, new List<Control> { SystemLabel, TitleLabel, MinimizeLabel, CloseLabel });
        }
        void MainForm_Activated(object sender, EventArgs e)
        {
            tweaklodPc.Enabled = true;
            servicelodPc.Enabled = true;
            ColorEnum.SetBorderColor(ColorEnum.ActiveBorderColor, new List<Control> { TopBorderPanel, LeftBorderPanel, RightBorderPanel, BottomBorderPanel });
            ColorEnum.SetTextColor(ColorEnum.ActiveTextColor, new List<Control> { SystemLabel, TitleLabel, MinimizeLabel, CloseLabel });
        }

        private Point titleClickPosition = Point.Empty;
        void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                titleClickPosition = e.Location;
                DecorationMouseDown(NativeMethods.HitTestValues.HTCAPTION);
            }
        }
        //titlebar

        public MainForm()
        {
            mf = this;
            Logger.Write("Program started~");
            if (Process.GetProcesses().Count(p => p.ProcessName == Process.GetCurrentProcess().ProcessName) > 1)
                Environment.Exit(0);


            LoadFont();
            InitializeComponent();
            MakeSureFolderExists();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            var x = new Point(Methods.GetInt(UserSettings.WindowsLocation.Split(',').First()), Methods.GetInt(UserSettings.WindowsLocation.Split(',').Last()));
            if (!x.IsEmpty)
                Location = x;

            if (x.IsEmpty || !Methods.IsOnScreen(this))
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - ((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2),
                  (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);


            Hide();
            WindowState = FormWindowState.Minimized;

            InitializeTitleBar();
            LoadFontControl();
            GetSweetData();
            AutoUpdateCheck();

            if (string.IsNullOrEmpty(PatcherSettings.GetValue(PatcherSettings.takatto00000)))
            {
                InstallerForm patcherInstaller = new InstallerForm();
                patcherInstaller.ShowDialog(this);
                patcherInstaller.Dispose();
            }

            if (string.IsNullOrEmpty(UserSettings.GameLanguage))
            {
                LanguageForm gameLanguageChangeFormup = new LanguageForm();
                gameLanguageChangeFormup.ShowDialog(this);
                gameLanguageChangeFormup.Dispose();
                Logger.Write("Game language is missing");
            }

            if (UniversalSettings._un.isNewsAutoOpen && UserSettings.NewsBlockList != UniversalSettings._un.AutoNewsUri)
                News(UniversalSettings._un.AutoNewsUri, true, true);
        }

        bool isDataGenerated = false;
        public void AutoUpdateCheck()
        {
            ConnectingForm_New connectingcheckw = new ConnectingForm_New("open");
            connectingcheckw.ShowDialog(this);
            connectingcheckw.Dispose();

            if (!ConnectingForm_New.frmObj.isUp2Date)
            {
                Environment.Exit(0);
                return;
            }
            isDataGenerated = true;
            //notifyIcon.Visible = true;
        }


        public void disable_aTimer()
        {
            try
            {
                aTimer.Enabled = false;
                isMultiPatchDownloading = false;
                isMultiPatch = false;
            }
            catch { }
        }

        public void Enable_LogCleaner()
        {
            if (UserSettings.PatcherMenuSetting == 1)
            {
                tabControl1.TabLocation = Manina.Windows.Forms.TabLocation.BottomLeft;
                tab2.BackColor = Color.White;
                tab3.BackColor = Color.White;
                tab4.BackColor = Color.White;
                tab5.BackColor = Color.White;
            }
            else
            {
                tabControl1.TabLocation = Manina.Windows.Forms.TabLocation.TopLeft;
                tab2.BackColor = Color.FromArgb(246, 248, 250);
                tab3.BackColor = Color.FromArgb(246, 248, 250);
                tab4.BackColor = Color.FromArgb(246, 248, 250);
                tab5.BackColor = Color.FromArgb(246, 248, 250);
            }

            ShortcutEnabler();
        }


        public void enable_patcherClosingTimer()
        {
            patcherClosingTimer.Enabled = true;
        }

        public void Enable_PatcherRestartTimer()
        {
            isEmergencyExit = true;
            Application.Restart();
            Environment.Exit(0);
        }

        public void InvokeUI(Action a)
        {
            BeginInvoke(new MethodInvoker(a));
        }

        internal void DownloadFile(string downloadURL, string downloadedFile, string extractDirectory)
        {
            MainForm.dForm = new DownloadForm(downloadURL, downloadedFile, extractDirectory);
            MainForm.dForm.Location = new Point(0, 0);
            MainForm.dForm.Dock = DockStyle.Fill;
            MainForm.dForm.TopLevel = false;

            MainForm.dForm.TopMost = true;
            pnForm.Size = new Size(tabControl1.Width - 2, tabControl1.Height - 1);
            pnForm.Location = new Point(tabControl1.Location.X + 1, tabControl1.Location.Y);
            pnForm.Controls.Add(MainForm.dForm);

            MainForm.dForm.Show();
            MainForm.dForm.BringToFront();

        }

        private void pnForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnForm.Size = new Size(0, 0);
        }

        public bool cancelDownload = false;

        public async void DownloadComplete(string downloadedFile, string extractDirectory)
        {
            try
            {
                if (extractDirectory != null)
                {

                    if (!Directory.Exists(extractDirectory))
                        Directory.CreateDirectory(extractDirectory);

                    try
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(downloadedFile))
                        {
                            foreach (var entry in archive.Entries)
                            {
                                var entryPath = Path.Combine(extractDirectory, entry.FullName).Replace("/", "\\");

                                if (entryPath.EndsWith("\\"))
                                {
                                    if (!Directory.Exists(entryPath))
                                    {
                                        Directory.CreateDirectory(entryPath);
                                    }
                                }
                                else
                                {
                                    await Task.Run(() => entry.ExtractToFile(entryPath, true));
                                }
                            }
                        }

                        if (new FileInfo(downloadedFile).Length == 0)
                            DownloadForm.frmObj.lbDownloadProgress.Text = StringLoader.GetText("LB_download_has_failed");
                        else
                            DownloadForm.frmObj.lbDownloadProgress.Text = StringLoader.GetText("LB_download_has_completed");
                        
                        if (isTweakDownloading)
                        {
                            ClickButtonIfActiveOnTweak();
                            checkforuponalltweak = true;

                            if (isDLCServiceDownloading)
                            {
                                takService_card_viewer = false;
                                isTweakDownloading = false;
                                isDLCServiceDownloading = false;
                                MsgBoxs.Information.Installed(this, "S_DLC");
                                return;
                            }
                            if (isDefaMapDownloading)
                            {
                                isTweakDownloading = false;
                                isDefaMapDownloading = false;

                                PopulateDLC1Combobox();
                                MsgBoxs.Information.Installed(this, "DLC1Default");    
                                if (customMap.isSomething)
                                    MapTweakForm.frmObj.UpdateComboBox();

                                return;
                            }
                            if (isImportDownloading)
                            {
                                isTweakDownloading = false;
                                isImportDownloading = false;
                                MsgBoxs.Information.Installed(this, Path.GetFileNameWithoutExtension(downloadedFile));
                                return;
                            }

                            MsgBoxs.Information.Installed(this, Path.GetFileNameWithoutExtension(downloadedFile));
                            isSTDPatchDownloading = false;
                            isTweakDownloading = false;
                            isImportDownloading = false;
                            isDLCServiceDownloading = false;
                            isDefaMapDownloading = false;
                            return;
                        }
                        else
                        {
                            if (isSTDPatchDownloading)
                            {
                                ClickButtonIfActiveOnTweak();
                                CustomPatchEnabled = Methods.IsCustomPatchAvailable();
                            }

                            if (!isMinimized && !isMultiPatch)
                            {
                                if (isGameRunning)
                                {
                                    tempPatch.Add(Path.GetFileName(downloadedFile));
                                    if (tempPatch.FirstOrDefault(stringToCheck => stringToCheck.Contains("Font")) != null)
                                        if (defaultLanguage != "KAT")
                                            overrideFont = true;
                                }                                 
                            }

                            MsgBoxs.Information.Installed(this, Path.GetFileNameWithoutExtension(downloadedFile)); 
                            LoadPatchInfoAsync();

                            isSTDPatchDownloading = false;
                            isTweakDownloading = false;
                            isImportDownloading = false;
                            isDLCServiceDownloading = false;
                            isDefaMapDownloading = false;
                        }
                    }
                    catch (Exception e)
                    {
                        DownloadForm.frmObj.lbDownloadProgress.Text = StringLoader.GetText("LB_download_has_failed");
                        if (isImportDownloading)
                        {
                            MsgBoxs.Warning.Error(this, e.Message);
                            isImportDownloading = false;
                            isTweakDownloading = false;
                            return;
                        }

                        if (cancelDownload)
                        {
                            MsgBoxs.Information.DownloadCancelled(this);
                            if (isDLCServiceDownloading)
                                textBoxButWithEasterEgg.Text = StringLoader.GetText("msg_download_cancelled");                      
                        }

                        else //if (!isTweakDownloading)
                            MsgBoxs.Warning.Error(this, e.Message);

                        isSTDPatchDownloading = false;
                        isMultiPatchDownloading = false;
                        isMultiPatch = false;
                        cancelDownload = false;
                        isImportDownloading = false;
                        isTweakDownloading = false;
                        isDLCServiceDownloading = false;
                        return;
                    }
                }
                else
                {
                    Process.Start(downloadedFile);
                }

            }
            finally
            {
                if (isMultiPatchDownloading)
                {
                    isMultiPatchDownloading = false;
                    for (int i = 1; i < arrMultiPatches.Length; i++)
                    {
                        if (i == arrMultiPatches.Length - 1)
                            isMultiPatch = false;

                        string patchname = arrMultiPatches[i].ToString().Trim();

                        if (PATCHES.Patches != null)
                        {
                            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchname);
                            if (selecttedPatch != null)
                            {
                                var patchid = selecttedPatch.id;                             
                                string patchPackUrl2 = (selecttedPatch.isDownloadableViaDirectUri) ? (!string.IsNullOrEmpty(selecttedPatch.directURI) ? selecttedPatch.directURI : PATCHES.ServerUri.Replace("{id}", patchid)) : PATCHES.ServerUri.Replace("{id}", patchid);

                                string tempFilename2 = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, $"{patchid}");
                                MainForm.mf.InvokeUI(() =>
                                {
                                    MainForm.mf.DownloadFile(patchPackUrl2, tempFilename2, Methods.GetGameFolder());
                                });
                            }
                        }
                    }
                }

                CloseDownloadForm(dForm);
            }
        }

        bool checkforuponalltweak = false;
        List<string> tempPatch = new List<string>();

        bool isMultiPatch;
        bool isMultiPatchDownloading;


        private void btnGuide_Click(object sender, EventArgs e)
        {
            string guideUrl = UniversalSettings._un.GameGuideUri;

            if (string.IsNullOrEmpty(guideUrl))
            {
                MsgBoxs.Warning.FailedToFetch(this);
                return;
            }

            Process.Start(guideUrl);
        }

        bool isClickedMusicBtn = false;
        bool firstTimeLoadMusicAsyncBooleanWhyYes = true;

        private async void LoadMusicAsync()
        {
            if (firstTimeLoadMusicAsyncBooleanWhyYes)
            {
                firstTimeLoadMusicAsyncBooleanWhyYes = false;
                if (UniversalSettings._un.isMusicListEventEnabled)
                    UniversalSettings._un.MusicList = UniversalSettings._un.MusicListEvent;

                try
                {
                    loveStatusLoved.Image = Image.FromFile(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, "happi"));
                    loveStatusAngry.Image = Image.FromFile(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, "angeri"));
                }
                catch { }

                LoadMusicAsync();
                return;
            } 

            if (isSongLoading)
                return;

            if (!isSongLoaded) // && !isSongLoading
            {
                btn_MusicMute.BackgroundImage = Properties.Resources.icons8_more_25__1_;

                int indexRant = random.Next(UniversalSettings._un.MusicList.Count);
                string musicName = UniversalSettings._un.MusicList[indexRant];
                currenttsSong.Text = musicName;
                if (playerWelcome != null)
                    playerWelcome.Dispose();

                try
                {
                    isSongLoading = true;

                    WebClient client = new WebClient
                    {
                        Proxy = null
                    };

                    var uri = String.Format(Urls.MusicFormat, UniversalSettings._un.AssetRootUri, musicName);
                    audio = await client.DownloadDataTaskAsync(new Uri(uri));

                    saudio = new MemoryStream(audio);
                    playerWelcome = new SoundPlayer(saudio);

                    isSongLoading = false;
                    isSongLoaded = true;

                    if (isClickedMusicBtn && isSongLoaded)
                    {
                        isClickedMusicBtn = false;
                        button3_Click(null, null);
                    }

                    return;
                }
                catch { btn_MusicMute.BackgroundImage = Properties.Resources.icons8_mute_35; isSongLoading = false; isSongLoaded = false; return; }

            }

            if (isClickedMusicBtn && isSongLoaded)
            {
                isClickedMusicBtn = false;
                button3_Click(null, null);
            }
        }

        Stream saudio;
        byte[] audio;
        bool firstTimeLoadPatches = false;
        bool firstTimeLoadTweaks = false;
        bool isSweetLocked = false;
        private void setBackground(Cutie cutie)
        {
            switch (cutie.backgroundLayout)
            {
                case 0:
                    pnSweetBG.BackgroundImageLayout = ImageLayout.None;
                    break;
                case 1:
                    pnSweetBG.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 2:
                    pnSweetBG.BackgroundImageLayout = ImageLayout.Center;
                    break;
                case 3:
                    pnSweetBG.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    pnSweetBG.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                default:
                    break;
            }

            switch (cutie.stateLayout)
            {
                case 0:
                    pnSweet.BackgroundImageLayout = ImageLayout.None;
                    break;
                case 1:
                    pnSweet.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 2:
                    pnSweet.BackgroundImageLayout = ImageLayout.Center;
                    break;
                case 3:
                    pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    pnSweet.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                default:
                    break;
            }

            try
            {
                pnSweetBG.BackgroundImage = Image.FromFile(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, cutie.background));
            }
            catch (Exception e)
            {
                try { File.Delete(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, cutie.background)); } catch (Exception ww) { Logger.Write(ww.Message); }
                Logger.Write(cutie.background + " has failed to load. Kat-code: " + e.Message);
            }
        }

        private bool setSweetImageFromFolder(Cutie cutie, int _state)
        {
            //0 normal 1 happy 2 angery
            string state;
            if (_state == 0)
                state = cutie.normalState;
            else if (_state == 1)
                state = cutie.happiState;
            else if (_state == 2)
                state = cutie.angeriiiiiState;
            else
                state = cutie.normalState;

            try
            {
                if (SweetSettings._uwu.isServerSideEnabled && cutie.isEnabled && File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, cutie.normalState)))
                {
                    try
                    {
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Image.FromFile(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, state));
                        if (File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, cutie.background)))
                            setBackground(cutie);

                        return true;
                    }
                    catch (Exception e)
                    {
                        Logger.Write(state + " has failed to load. Kat-code: " + e.Message);
                        try { File.Delete(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData, state)); } catch (Exception ww) { Logger.Write(ww.Message); }

                        return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Logger.Write("Could not read data of takatto00121. Kat-code: " + e.Message);
                return false;
            }
        }



        private void setHikari()
        {
            setGirlStateHikari(0);
            loved.SendToBack();
            lbHeart.Text = HikariLove.ToString() + "%";
            loved.Visible = false;
            isHikari = true;
            isYuzuki = false;
            isNako = false;
            lbBaloon.ForeColor = Color.FromArgb(64, 0, 64);
        }

        private void setYuzuki()
        {
            setGirlStateYuzuki(0);
            loved.SendToBack();
            lbHeart.Text = YuzukiLove.ToString() + "%";
            loved.Visible = false;
            isHikari = false;
            isYuzuki = true;
            isNako = false;
            lbBaloon.ForeColor = Color.FromArgb(0, 0, 64);
        }

        private void setNako()
        {
            setGirlStateNako(0);
            loved.BringToFront();
            lbHeart.Text = NakoLove.ToString() + "%";
            loved.Visible = true;
            isHikari = false;
            isYuzuki = false;
            isNako = true;
            lbBaloon.ForeColor = Color.FromArgb(64, 0, 64);
        }

        private bool customizeqte = false;
        private bool isGivingLoveLetter = false;
        private bool isGivingLoveLettered = true;
        private bool isHikari = true;
        private bool isYuzuki = false;
        private bool isNako = false;
        private bool isCha = false;   
        private bool isAccepted = false;

        private void pnHi_Click(object sender, EventArgs e)
        {
            if (isCha || isGivingLoveLettered)
            {
                if (!skipthru)
                    skipthru = true;

                return;
            }

            lbBaloon.Text = "";
            isCha = true;
            isGivingLoveLettered = true;
            pnLaboon.BringToFront();

            int randomLessThan100 = random.Next(100);

            if (isGivingLoveLetter)
                randomLessThan100 = 0;

            if (isHikari && HikariLove >= 100 && !isLovedHikari)
            {
                isLovedHikari = true;
                randomLessThan100 = 3000;
            }
            if (isYuzuki && YuzukiLove >= 100 && !isLovedYuzuki)
            {
                isLovedYuzuki = true;
                randomLessThan100 = 3000;
            }
            if (isNako && NakoLove >= 100 && !isLovedNako)
            {
                isLovedNako = true;
                randomLessThan100 = 3000;
            }

            if (customizeqte)
            {
                var um = Strings.Misc.LoveLetterEventMsgDefault;
                customizeqte = false;
                if (isHikari)
                    message = string.IsNullOrEmpty(SweetSettings._uwu.Hikari.eventMessage) ? um : SweetSettings._uwu.Hikari.eventMessage;
                else if (isYuzuki)
                    message = string.IsNullOrEmpty(SweetSettings._uwu.Yuzuki.eventMessage) ? um : SweetSettings._uwu.Yuzuki.eventMessage;
                else if (isNako)
                    message = string.IsNullOrEmpty(SweetSettings._uwu.Nako.eventMessage) ? um : SweetSettings._uwu.Nako.eventMessage;
                else
                    message = um;
            }
            else if (randomLessThan100 < 90)
            {
                if (isHikari)
                {
                    if (!isGivingLoveLetter)
                    {
                        int indexRant = random.Next(PatcherSettings.msgStrHikari.Length);
                        message = PatcherSettings.msgStrHikari[indexRant];
                    }
                    else
                    {
                        int randomLessThan10 = random.Next(10);
                        int chance = (SweetSettings._uwu.isUsingServerBaseLoveChance) ? ((SweetSettings._uwu.Hikari.baseLoveChance != 0) ? SweetSettings._uwu.Hikari.baseLoveChance : 5) : 5;

                        if (HikariLove < 20)
                            chance++;
                        else if (HikariLove > 20 && HikariLove <= 35)
                            chance--;
                        else if (HikariLove > 35 && HikariLove <= 60)
                            chance++;
                        else if (HikariLove > 60 && HikariLove <= 70)
                            chance++;
                        else if (HikariLove > 70 && HikariLove <= 95)
                            chance += 2;
                        else if (HikariLove > 95 && NakoLove < 100)
                            chance = 10;

                        if (chance > 10)
                            chance = 10;

                        if (randomLessThan10 <= chance)
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrHikariLove.Length);
                            message = PatcherSettings.msgStrHikariLove[indexRant];

                            setGirlStateHikari(1);

                            isAccepted = true;
                            loveStatusLoved.BringToFront();
                        }
                        else
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrHikariAngry.Length);
                            message = PatcherSettings.msgStrHikariAngry[indexRant];

                            setGirlStateHikari(2);

                            isAccepted = false;
                            loveStatusAngry.BringToFront();
                        }
                    }
                }
                else if (isYuzuki)
                {
                    if (!isGivingLoveLetter)
                    {
                        int indexRant = random.Next(PatcherSettings.msgStrYuzuki.Length);
                        message = PatcherSettings.msgStrYuzuki[indexRant];
                    }
                    else
                    {
                        int chance = (SweetSettings._uwu.isUsingServerBaseLoveChance) ? ((SweetSettings._uwu.Yuzuki.baseLoveChance != 0) ? SweetSettings._uwu.Yuzuki.baseLoveChance : 4) : 4;

                        if (YuzukiLove < 20)
                            chance++;
                        else if (YuzukiLove > 20 && YuzukiLove <= 35)
                            chance--;
                        else if (YuzukiLove > 35 && YuzukiLove <= 60)
                            chance++;
                        else if (YuzukiLove > 60 && YuzukiLove <= 70)
                            chance++;
                        else if (YuzukiLove > 70 && YuzukiLove <= 95)
                            chance += 2;
                        else if (YuzukiLove > 95 && NakoLove < 100)
                            chance = 10;

                        if (chance > 10)
                            chance = 10;

                        int randomLessThan10 = random.Next(10);
                        if (randomLessThan10 <= chance)
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrYuzukiLove.Length);
                            message = PatcherSettings.msgStrYuzukiLove[indexRant];

                            setGirlStateYuzuki(1);

                            isAccepted = true;
                            loveStatusLoved.BringToFront();
                        }
                        else
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrYuzukiAngry.Length);
                            message = PatcherSettings.msgStrYuzukiAngry[indexRant];

                            setGirlStateYuzuki(2);

                            isAccepted = false;
                            loveStatusAngry.BringToFront();
                        }
                    }
                }
                else if (isNako)
                {
                    if (!isGivingLoveLetter)
                    {
                        int indexRant = random.Next(PatcherSettings.msgStrNako.Length);
                        message = PatcherSettings.msgStrNako[indexRant];
                    }
                    else
                    {
                        int chance = (SweetSettings._uwu.isUsingServerBaseLoveChance) ? ((SweetSettings._uwu.Nako.baseLoveChance != 0) ? SweetSettings._uwu.Nako.baseLoveChance : 5) : 5;

                        if (NakoLove < 20)
                            chance++;
                        else if (NakoLove > 20 && NakoLove <= 35)
                            chance--;
                        else if (NakoLove > 35 && NakoLove <= 60)
                            chance++;
                        else if (NakoLove > 60 && NakoLove <= 70)
                            chance++;
                        else if (NakoLove > 70 && NakoLove <= 95)
                            chance += 2;
                        else if (NakoLove > 95 && NakoLove < 100)
                            chance = 10;

                        if (chance > 10)
                            chance = 10;

                        int randomLessThan10;

                        if (HikariLove >= 100 && YuzukiLove >= 100)
                            randomLessThan10 = random.Next(10);
                        else
                            randomLessThan10 = 999;

                        if (randomLessThan10 <= chance)
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrNakoLove.Length);
                            message = PatcherSettings.msgStrNakoLove[indexRant];

                            setGirlStateNako(1);

                            isAccepted = true;
                            loveStatusLoved.BringToFront();
                        }
                        else
                        {
                            int indexRant = random.Next(PatcherSettings.msgStrNakoAngry.Length);
                            message = PatcherSettings.msgStrNakoAngry[indexRant];

                            setGirlStateNako(2);

                            isAccepted = false;
                            loveStatusAngry.BringToFront();
                        }
                    }

                }
            }
            else if (randomLessThan100 >= (100 - SweetSettings._uwu.universalMessageProcChance) && randomLessThan100 <= 100)
                message = SweetSettings._uwu.universalMessage.Any() ? SweetSettings._uwu.universalMessage[random.Next(SweetSettings._uwu.universalMessage.Count)] : helloworld;
            else
            {
                if (isHikari)
                {
                    int indexRant = random.Next(PatcherSettings.msgStrHikariLoved.Length);
                    message = PatcherSettings.msgStrHikariLoved[indexRant];
                }
                else if (isYuzuki)
                {
                    int indexRant = random.Next(PatcherSettings.msgStrYuzukiLoved.Length);
                    message = PatcherSettings.msgStrYuzukiLoved[indexRant];
                }
                else if (isNako)
                {
                    pnHeart.BackgroundImage = Properties.Resources.heart_golden;
                    pnLaboon.BackgroundImage = Properties.Resources.baloon3;
                    int indexRant = random.Next(PatcherSettings.msgStrNakoLoved.Length);
                    message = PatcherSettings.msgStrNakoLoved[indexRant];
                    firstTimeLoadTweaks = false;
                }
            }
            balomCount = 0; letterCount = 0;
            balooon.Enabled = true;
        }

        bool isCheated = false;
        bool isDataCorrupted = false;

        private void News(string content, bool isNews, bool isNewsAuto)
        {
            ActiveControl = null;
            Help_CourtTakatto helpCourtdemo = new Help_CourtTakatto(content, isNews, isNewsAuto);
            helpCourtdemo.ShowDialog(this);
            helpCourtdemo.Dispose();
        }

        int letterCount = 0;
        int balomCount = 0;
        bool skipthru = false;
        string message;

        private void btnLoveLetter_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (isCha || isGivingLoveLetter)
            {
                if (!skipthru)
                    skipthru = true;

                return;
            }

            if (loveLetter > 0)
            {
                if (HikariLove >= YuzukiLove && YuzukiLove >= NakoLove && NakoLove >= 999)
                    btnLoveLetter.Text = " ∞";
                else
                {
                    loveLetter--;
                    btnLoveLetter.Text = "x" + loveLetter.ToString();
                }


                isGivingLoveLetter = true;
                pnHi_Click(sender, new EventArgs());
            }
        }

        int pnHeartXdef;
        int pnHeartX;
        int countY = 0;

        FileStream fs;
        FileStream fs_patch;
        private string currentGameFolder = Methods.GetGameFolder();
        bool lockedPathInterface = false;
        bool isTweakLoadingGlassyPanel = false;
        bool isTweakLoadingGlassyPanel2 = false;

        public void LockPatchInterface()
        {
            lockedPathInterface = true;
            isGameRunningTimer.Enabled = false;
            tweakTimer.Enabled = false;
            SystemLabel.Visible = false;
            currentGameFolder = null;
            if (txtAboutBackupbutOnce)
                textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");

            isTweakLoadingGlassyPanel = false;
            isTweakLoadingGlassyPanel2 = false; 
            ServiceUnlocked(false); 
            TweakUnlocked(false);
            NotZacarDO();

            glassyPanel1.Visible = true;
            glassyPanel2.Visible = true;

            btnFolder.BackgroundImage = Properties.Resources.icons8_folder_35;

            try
            {
                fs.Close();
            }
            catch { }

            takService_card_viewer = false;

            btnLanguage.Text = StringLoader.GetText("btn_language");
            cbDefaultCourtTweak.Items.Clear();
            cbDefaultCourtTweak.Items.Add("NONE");
            cbDefaultCourtTweak.SelectedIndex = 0;
            CourtMap = 0;

            tab3.Text = StringLoader.GetText("tab3");
            tab4.Text = StringLoader.GetText("tab4");

            launcherToolStripMenuItem.Enabled = false;
            steamLauncherToolStripMenuItem.Enabled = false;
            nexonToolStripMenuItem.Enabled = false;
            openFolderToolStripMenuItem.Enabled = false;

            isZaCardoSV = null;
            TweakReset(StringLoader.GetText("LB_select_a_tweak"), "", false, false, false, false, 0);
            PNServicesMod(StringLoader.GetText("LB_nyan"), "", false, false, 0);
        }

        public void TweakReset(string _lbTweak, string _tbnTweak, bool _isTweakbtnVisible, bool _isRefreshVisible, bool _isrequiredExpandong, bool allowcat, int cat)
        {
            PNTweaksMod(_lbTweak, _tbnTweak, _isTweakbtnVisible, _isRefreshVisible, _isrequiredExpandong, allowcat, cat);
            
            SetEnableOneButDisableElse(disable);
            SetEnableOneButDisableElseService(disable);
            CloseForm(jForm);
            CloseForm(aForm);
            CloseForm(mcForm);
            CloseForm(cvForm);
            CloseForm(mtForm);
            CloseForm(rForm);
            CloseForm(ctForm);
            CloseForm(eForm);
        }

        public void UnlockPatchInterface()
        {
            lockedPathInterface = false;
            isGameRunningTimer.Enabled = true;
            SystemLabel.Visible = true;
            currentGameFolder = Methods.GetGameFolder();

            btnFolder.BackgroundImage = Properties.Resources.icons8_folder_change_35;

            var takattoLock = Methods.GetFolder(Strings.KattoFileName.Takatto);
            if (!File.Exists(takattoLock))
            {
                try { File.Create(takattoLock).Close(); }
                catch (Exception msg)
                {
                    MsgBoxs.Warning.Error(this, msg.Message);
                    LockPatchInterface();
                    return;
                }
            }

            fs = File.Open(takattoLock, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //dlc3 update check
            takService_card_viewer_lock_once_release = false;

            isTiancityClient = Methods.IsTiancityFS2();
            Methods.TweakRestore();

            launcherToolStripMenuItem.Enabled = true;
            steamLauncherToolStripMenuItem.Enabled = true;
            nexonToolStripMenuItem.Enabled = true;
            openFolderToolStripMenuItem.Enabled = true;

            PopulateDLC1Combobox();
            CustomPatchEnabled = Methods.IsCustomPatchAvailable();
        }

        uint nDPI;
        private void PopulateDLC1Combobox()
        {
            cbDefaultCourtTweak.Items.Clear();
            cbDefaultCourtTweak.Items.AddRange(Methods.PopulateDLC1Combobox().Items.Cast<Object>().ToArray());
            cbDefaultCourtTweak.SelectedIndex = 0;
        }

        void MakeSureFolderExists()
        {
            Methods.MakeSureFolderExists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder));
            Methods.MakeSureFolderExists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.SweetData));          
        }


        public void LoadFont()
        {         
            MemoryFonts.AddMemoryFont(Properties.Resources.Ambit_Regular_ttf);
            MemoryFonts.AddMemoryFont(Properties.Resources.font_taka);
            Logger.Write("Font has loaded");

            nDPI = NativeMethods.GetDpiForWindow(Handle);

            //bellow was an auto scaling problem fixes, although its shit but hey as long as it works,
            //just took sometime to set the value til perfection
            //if (nDPI == 120)
            //{
            //    PatcherSettings.fontOffset1 = -(float)1.25;
            //    PatcherSettings.fontOffset2 = -2;
            //    PatcherSettings.fontOffset3 = (float)-3.25;
            //    PatcherSettings.fontOffset4 = (float)-5.25;
            //    PatcherSettings.fontOffsetWidth = 0;
            //}
            //else if (nDPI == 144)
            //{
            //    PatcherSettings.fontOffset1 = (float)-3.25;
            //    PatcherSettings.fontOffset2 = (float)-3;
            //    PatcherSettings.fontOffset3 = (float)-5.5;
            //    PatcherSettings.fontOffset4 = (float)-8.5;
            //    PatcherSettings.fontOffsetWidth = 0;
            //}
            //else if (nDPI == 168)
            //{
            //    PatcherSettings.fontOffset1 = (float)-4;
            //    PatcherSettings.fontOffset2 = (float)-4.5;
            //    PatcherSettings.fontOffset3 = (float)-8.25;
            //    PatcherSettings.fontOffset4 = (float)-11.75;
            //    PatcherSettings.fontOffsetWidth = 0;
            //}
        }


        public void LoadFontControl()
        {
            float fontOffset1 = PatcherSettings.fontOffset1;
            float fontOffset2 = PatcherSettings.fontOffset2;
            float fontOffset3 = PatcherSettings.fontOffset3;
            float fontOffset4 = PatcherSettings.fontOffset3;
            int fontOffsetWidth = PatcherSettings.fontOffsetWidth;

            //bellow was an auto scaling problem fixes, although its shit but hey as long as it works,
            //just took sometime to set the value til perfection
            /*
            if (nDPI == 120)
            {
                lbType.Font = new Font(lbType.Font.FontFamily, lbType.Font.Size + 2, FontStyle.Regular);
                label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size - (float)0.25, FontStyle.Regular);
                label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size - (float)0.25, FontStyle.Regular);
                label3.Font = new Font(label3.Font.FontFamily, label3.Font.Size - (float)0.25, FontStyle.Regular);
                lbRepo.Font = new Font(lbRepo.Font.FontFamily, lbRepo.Font.Size - (float)0.25, FontStyle.Regular);
                tbPatchURI.Font = new Font(tbPatchURI.Font.FontFamily, tbPatchURI.Font.Size + (float)0.25, FontStyle.Regular);

            }
            if (nDPI == 144)
            {
                lbType.Font = new Font(lbType.Font.FontFamily, lbType.Font.Size + 3, FontStyle.Regular);
                lbHeart.Font = new Font(lbHeart.Font.FontFamily, lbHeart.Font.Size + 2, FontStyle.Regular);
                btnLoveLetter.Font = new Font(btnLoveLetter.Font.FontFamily, btnLoveLetter.Font.Size + 2, FontStyle.Regular);
                //
                TitleLabel.Font = new Font(TitleLabel.Font.FontFamily, TitleLabel.Font.Size + 1, FontStyle.Regular);
                tabControl1.Font = new Font(tabControl1.Font.FontFamily, tabControl1.Font.Size + 1, FontStyle.Regular);
                lbPatch.Font = new Font(lbPatch.Font.FontFamily, lbPatch.Font.Size + 1, FontStyle.Regular);
                lbPatchesHelp.Font = new Font(lbPatchesHelp.Font.FontFamily, lbPatchesHelp.Font.Size + 1, FontStyle.Regular);
                lbPatchDescription.Font = new Font(lbPatchDescription.Font.FontFamily, lbPatchDescription.Font.Size + 1, FontStyle.Regular);
                lbPatchNote.Font = new Font(lbPatchNote.Font.FontFamily, lbPatchNote.Font.Size + 1, FontStyle.Regular);
                lbPatchStatus.Font = new Font(lbPatchStatus.Font.FontFamily, lbPatchNote.Font.Size + (float)0, FontStyle.Regular);
                lbPatches.Font = new Font(lbPatches.Font.FontFamily, lbPatches.Font.Size + 1, FontStyle.Regular);
                lbTweaksHelp.Font = new Font(lbTweaksHelp.Font.FontFamily, lbTweaksHelp.Font.Size + 1, FontStyle.Regular);
                label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size - (float)0.5, FontStyle.Regular);
                label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size - (float)0.5, FontStyle.Regular);
                label3.Font = new Font(label3.Font.FontFamily, label3.Font.Size - (float)0.5, FontStyle.Regular);
                lbRepo.Font = new Font(lbRepo.Font.FontFamily, lbRepo.Font.Size - (float)0.5, FontStyle.Regular);
                tbPatchURI.Font = new Font(tbPatchURI.Font.FontFamily, tbPatchURI.Font.Size - (float)0.25, FontStyle.Regular);
                lb_courttweakhint.Font = new Font(lb_courttweakhint.Font.FontFamily, lb_courttweakhint.Font.Size + 1, FontStyle.Regular);
                lbServiceHelp.Font = new Font(lbServiceHelp.Font.FontFamily, lbServiceHelp.Font.Size + 1, FontStyle.Regular);
                lbVersion.Font = new Font(lbVersion.Font.FontFamily, lbVersion.Font.Size + 1, FontStyle.Regular);
                lbDonator.Font = new Font(lbDonator.Font.FontFamily, lbDonator.Font.Size + 1, FontStyle.Regular);
            }
            if (nDPI == 168)
            {
                LBCopiRite.Font = new Font(LBCopiRite.Font.FontFamily, LBCopiRite.Font.Size + (float)2.5, FontStyle.Regular);
                //LBTakatto.Font = new Font(LBTakatto.Font.FontFamily, LBTakatto.Font.Size - (float)1.75, FontStyle.Regular);
                //LBWelcome.Font = new Font(LBWelcome.Font.FontFamily, LBWelcome.Font.Size - (float)1.75, FontStyle.Regular);
                LBWe.Font = new Font(LBWe.Font.FontFamily, LBWe.Font.Size + (float)2.5, FontStyle.Regular);
               //
                lbType.Font = new Font(lbType.Font.FontFamily, lbType.Font.Size + (float)4.5, FontStyle.Regular);
                lbHeart.Font = new Font(lbHeart.Font.FontFamily, lbHeart.Font.Size + (float)3.5, FontStyle.Regular);
                btnLoveLetter.Font = new Font(btnLoveLetter.Font.FontFamily, btnLoveLetter.Font.Size + (float)3.5, FontStyle.Regular);
                //
                TitleLabel.Font = new Font(TitleLabel.Font.FontFamily, TitleLabel.Font.Size + 1, FontStyle.Regular);
                tabControl1.Font = new Font(tabControl1.Font.FontFamily, tabControl1.Font.Size + 1, FontStyle.Regular);
                lbPatch.Font = new Font(lbPatch.Font.FontFamily, lbPatch.Font.Size + 1, FontStyle.Regular);
                lbPatchesHelp.Font = new Font(lbPatchesHelp.Font.FontFamily, lbPatchesHelp.Font.Size + 1, FontStyle.Regular);
                lbPatchDescription.Font = new Font(lbPatchDescription.Font.FontFamily, lbPatchDescription.Font.Size + 1, FontStyle.Regular);
                lbPatchNote.Font = new Font(lbPatchNote.Font.FontFamily, lbPatchNote.Font.Size + 1, FontStyle.Regular);
                //lbPatchStatus.Font = new Font(lbPatchStatus.Font.FontFamily, lbPatchNote.Font.Size + 1, FontStyle.Regular);
                lbPatches.Font = new Font(lbPatches.Font.FontFamily, lbPatches.Font.Size + 1, FontStyle.Regular);
                lbTweaksHelp.Font = new Font(lbTweaksHelp.Font.FontFamily, lbTweaksHelp.Font.Size + 1, FontStyle.Regular);
                label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size - (float)0.5, FontStyle.Regular);
                label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size - (float)0.5, FontStyle.Regular);
                label3.Font = new Font(label3.Font.FontFamily, label3.Font.Size - (float)0.5, FontStyle.Regular);
                lbRepo.Font = new Font(lbRepo.Font.FontFamily, lbRepo.Font.Size - (float)0.5, FontStyle.Regular);
                tbPatchURI.Font = new Font(tbPatchURI.Font.FontFamily, tbPatchURI.Font.Size + (float)-.5, FontStyle.Regular);
                lb_courttweakhint.Font = new Font(lb_courttweakhint.Font.FontFamily, lb_courttweakhint.Font.Size + 1, FontStyle.Regular);
                lbServiceHelp.Font = new Font(lbServiceHelp.Font.FontFamily, lbServiceHelp.Font.Size + 1, FontStyle.Regular);
                lbVersion.Font = new Font(lbVersion.Font.FontFamily, lbVersion.Font.Size + 1, FontStyle.Regular);
                lbDonator.Font = new Font(lbDonator.Font.FontFamily, lbDonator.Font.Size + 1, FontStyle.Regular);
            }
            */

            int style = NativeMethods.GetWindowLong(tab1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(tab1.Handle, NativeMethods.GWL_EXSTYLE, style);

            int style2 = NativeMethods.GetWindowLong(tab2.Handle, NativeMethods.GWL_EXSTYLE);
            NativeMethods.SetWindowLong(tab2.Handle, NativeMethods.GWL_EXSTYLE, style2);

            int style3 = NativeMethods.GetWindowLong(tab3.Handle, NativeMethods.GWL_EXSTYLE);
            style3 |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(tab3.Handle, NativeMethods.GWL_EXSTYLE, style3);

            int style4 = NativeMethods.GetWindowLong(tab4.Handle, NativeMethods.GWL_EXSTYLE);
            style4 |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(tab4.Handle, NativeMethods.GWL_EXSTYLE, style4);

            int style5 = NativeMethods.GetWindowLong(tab5.Handle, NativeMethods.GWL_EXSTYLE);
            style5 |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(tab5.Handle, NativeMethods.GWL_EXSTYLE, style5);
            setTimer();

            tabControl1.TabPadding = new System.Windows.Forms.Padding(3, TitleLabel.Height / 6, 0, TitleLabel.Height / 6);
            lbPatches.ItemHeight = lbPatchStatus.Height + (lbPatchStatus.Height / 5);

            cbDefaultCourtTweak.Region = new Region(new Rectangle(1, 1, cbDefaultCourtTweak.Width - 2, cbDefaultCourtTweak.Height - 2));
            btnLoveLetter.Region = new Region(new Rectangle(2, 2, btnLoveLetter.Width - 4, btnLoveLetter.Height - 4));

            lbCourtHint.Font = MemoryFonts.SetFont(0, lbCourtHint.Font.Size, fontOffset1, FontStyle.Regular);
            lbPatchInfo.Font = MemoryFonts.SetFont(0, lbPatchInfo.Font.Size, fontOffset1, FontStyle.Regular);
            cbTranslation.Font = MemoryFonts.SetFont(0, cbTranslation.Font.Size, fontOffset1, FontStyle.Regular);

            lbRefreshTwea.Font = MemoryFonts.SetFont(0, lbRefreshTwea.Font.Size, fontOffset1, FontStyle.Regular);


            tab1.Font = MemoryFonts.SetFont(0, tab1.Font.Size, fontOffset1, FontStyle.Regular);
            tab2.Font = MemoryFonts.SetFont(0, tab2.Font.Size, fontOffset1, FontStyle.Regular);
            tab3.Font = MemoryFonts.SetFont(0, tab3.Font.Size, fontOffset1, FontStyle.Regular);
            tab4.Font = MemoryFonts.SetFont(0, tab4.Font.Size, fontOffset1, FontStyle.Regular);
            tab5.Font = MemoryFonts.SetFont(0, tab5.Font.Size, fontOffset1, FontStyle.Regular);
            lbBaloon.Font = MemoryFonts.SetFont(0, lbBaloon.Font.Size, fontOffset1, FontStyle.Regular);
            btnSwLock.Font = MemoryFonts.SetFont(0, btnSwLock.Font.Size, fontOffset2, FontStyle.Regular);
            btnInstallPatch.Font = MemoryFonts.SetFont(0, btnInstallPatch.Font.Size, fontOffset2, FontStyle.Regular);
            tbPatchURI.Font = MemoryFonts.SetFont(0, tbPatchURI.Font.Size, fontOffset1, FontStyle.Regular);

            lbServiceLocker.Font = MemoryFonts.SetFont(0, lbServiceLocker.Font.Size, fontOffset1, FontStyle.Regular);

            lbServiceHeader.Font = MemoryFonts.SetFont(0, lbServiceHeader.Font.Size, fontOffset1, FontStyle.Regular);
            lbPatchHeader.Font = MemoryFonts.SetFont(0, lbPatchHeader.Font.Size, fontOffset1, FontStyle.Regular);
            lbTweakHeader.Font = MemoryFonts.SetFont(0, lbTweakHeader.Font.Size, fontOffset1, FontStyle.Regular);
            lbRepo.Font = MemoryFonts.SetFont(0, lbRepo.Font.Size, fontOffset1, FontStyle.Regular);

            lbVersion.Font = MemoryFonts.SetFont(0, lbVersion.Font.Size, fontOffset1, FontStyle.Regular);
            lbPatchesHelp.Font = MemoryFonts.SetFont(0, lbPatchesHelp.Font.Size, fontOffset1, FontStyle.Regular);
            btnGameLaunch.Font = MemoryFonts.SetFont(0, btnGameLaunch.Font.Size, fontOffset2, FontStyle.Regular);
            lbPatchStatus.Font = MemoryFonts.SetFont(0, lbPatchStatus.Font.Size, fontOffset1, FontStyle.Regular);
            lbPatchDescription.Font = MemoryFonts.SetFont(0, lbPatchDescription.Font.Size, fontOffset1, FontStyle.Regular);
            lbPatchNote.Font = MemoryFonts.SetFont(0, lbPatchNote.Font.Size, fontOffset1, FontStyle.Regular);

            btnTweakForEverything.Font = MemoryFonts.SetFont(0, btnTweakForEverything.Font.Size, fontOffset2, FontStyle.Regular);
            btnServiceForEverything.Font = MemoryFonts.SetFont(0, btnServiceForEverything.Font.Size, fontOffset2, FontStyle.Regular);
            btnLanguage.Font = MemoryFonts.SetFont(0, btnLanguage.Font.Size, fontOffset2, FontStyle.Regular);
            btnGameSetting.Font = MemoryFonts.SetFont(0, btnGameSetting.Font.Size, fontOffset2, FontStyle.Regular);
            lbTweaksInfo.Font = MemoryFonts.SetFont(0, lbTweaksInfo.Font.Size, fontOffset1, FontStyle.Regular);
            lbServiceInfo.Font = MemoryFonts.SetFont(0, lbServiceInfo.Font.Size, fontOffset1, FontStyle.Regular);
            btnServiceRequest.Font = MemoryFonts.SetFont(0, btnServiceRequest.Font.Size, fontOffset2, FontStyle.Regular);
            lbServiceDec.Font = MemoryFonts.SetFont(0, lbServiceDec.Font.Size, fontOffset1, FontStyle.Regular);
            lbDonator.Font = MemoryFonts.SetFont(0, lbDonator.Font.Size, fontOffset1, FontStyle.Regular);
            textBoxButWithEasterEgg.Font = MemoryFonts.SetFont(0, textBoxButWithEasterEgg.Font.Size, fontOffset1, FontStyle.Regular);


            lbPatches.Font = MemoryFonts.SetFont(0, lbPatches.Font.Size, fontOffset1, FontStyle.Regular);
            foreach (Control c in pnTweakButtonList.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(1, c.Font.Size, fontOffset1, FontStyle.Regular);
            }
            foreach (Control c in pnServiceButtonList.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(1, c.Font.Size, fontOffset1, FontStyle.Regular);
            }

            LBWelcome.Font = MemoryFonts.SetFont(1, LBWelcome.Font.Size, fontOffset4, FontStyle.Regular);
            LBTakatto.Font = MemoryFonts.SetFont(1, LBTakatto.Font.Size, fontOffset4, FontStyle.Regular);


            lbError.Font = MemoryFonts.SetFont(1, lbError.Font.Size, fontOffset3, FontStyle.Regular);
            lbTweakti.Font = MemoryFonts.SetFont(1, lbTweakti.Font.Size, fontOffset3, FontStyle.Regular);
            lbServiceti.Font = MemoryFonts.SetFont(1, lbServiceti.Font.Size, fontOffset3, FontStyle.Regular);
            LBWe.Font = MemoryFonts.SetFont(1, LBWe.Font.Size, fontOffset3, FontStyle.Regular);
            LBCopiRite.Font = MemoryFonts.SetFont(1, LBCopiRite.Font.Size, fontOffset3, FontStyle.Regular);
            lbHeart.Font = MemoryFonts.SetFont(1, lbHeart.Font.Size, fontOffset3, FontStyle.Regular);
            btnLoveLetter.Font = MemoryFonts.SetFont(1, btnLoveLetter.Font.Size, fontOffset3, FontStyle.Regular);
            lbAddOne.Font = MemoryFonts.SetFont(1, lbAddOne.Font.Size, fontOffset3, FontStyle.Regular);
            lbType.Font = MemoryFonts.SetFont(1, lbType.Font.Size, fontOffset3, FontStyle.Regular);
                  
            Logger.Write("Font controls have loaded");

            btnURIconFirM.Height = tbPatchURI.Height - 2;
            btnURIconFirM.Parent = tbPatchURI;
            btnURIconFirM.Location = new Point(tbPatchURI.Width - btnURIconFirM.Width, tbPatchURI.Height - btnURIconFirM.Height - 2);

            PopulateComboBox(cbTranslation);

            FrameDimension dimension = new FrameDimension(Properties.Resources.catKawaii.FrameDimensionsList[0]);
            numberOfFrames = Properties.Resources.catKawaii.GetFrameCount(dimension);

            glassyPanel1.Dock = DockStyle.Fill;
            glassyPanel2.Dock = DockStyle.Fill;
            pictureBox1.Width = pnTweakContent.Width;
            pictureBox1.Height = pnTweakContent.Height;
            pictureBox4.Height = pnTweakContent.Height;
            pictureBox4.Width = pnTweakContent.Width;

            var locker = Path.Combine(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData), Strings.KattoFileName.TakattoLock);
            if (!File.Exists(locker))
                File.Create(locker).Close();
            fs_patch = File.Open(locker, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            glassyTimer2.Interval = new Random().Next(1229, 1529);
            glassyTimer1.Interval = new Random().Next(1229, 1529);
        }

        public bool isImportDownloading = false;
        public bool isTweakDownloading = false;
        public bool isSTDPatchDownloading = false;
        public bool isDLCServiceDownloading = false;
        public bool isDefaMapDownloading = false;


        public bool isChinaClient = false;
        public bool isTiancityClient = false;

        public bool txtAboutBackupbutOnce = false;
        private string helloworld = "Hello world!";

        private int loveLetter = 0;
        private int HikariLove = 0;
        private int YuzukiLove = 0;
        private int NakoLove = 0;
        private int totalLoveLetterCount = 0;
        private bool isLovedHikari = false;
        private bool isLovedYuzuki = false;
        private bool isLovedNako = false;


        public void GetSweetData()
        {
            string loveLetterData = PatcherSettings.GetValue(PatcherSettings.takatto29022);
            if (string.IsNullOrEmpty(loveLetterData))
                loveLetterData = Strings.Misc.LoveLetterDataDefault;

            //MessageBox.Show(loveLetterData);

            try
            {
                loveLetter = GetLoveLetterInt(loveLetterData.Split('|').ElementAt(0));
                HikariLove = GetLoveLetterInt(loveLetterData.Split('|').ElementAt(1));
                YuzukiLove = GetLoveLetterInt(loveLetterData.Split('|').ElementAt(2));
                NakoLove = GetLoveLetterInt(loveLetterData.Split('|').ElementAt(3));
                totalLoveLetterCount = GetLoveLetterInt(loveLetterData.Split('|').ElementAt(4));
                isLovedHikari = bool.Parse(loveLetterData.Split('|').ElementAt(5));
                isLovedYuzuki = bool.Parse(loveLetterData.Split('|').ElementAt(6));
                isLovedNako = bool.Parse(loveLetterData.Split('|').ElementAt(7));

            }
            catch
            {
                isDataCorrupted = true;

                loveLetter = 10;
                HikariLove = 0;
                YuzukiLove = 0;
                NakoLove = 0;
                totalLoveLetterCount = 10;
                isLovedHikari = false;
                isLovedYuzuki = false;
                isLovedNako = false;
            }
        }

        public void GetDLCwebVersion()
        {
            Logger.Write("Fetched data is being loaded");     

            if (!string.IsNullOrEmpty(SweetSettings._uwu.justAboutMessage))
                lbDonator.Text = SweetSettings._uwu.justAboutMessage.Replace("<br/>", "\n").Replace("<br>", "\n");

            if (!string.IsNullOrEmpty(SweetSettings._uwu.patchTabMessage))
                lbPatchInfo.Text = SweetSettings._uwu.patchTabMessage.Replace("<br/>", "\n").Replace("<br>", "\n");

            if (!string.IsNullOrEmpty(SweetSettings._uwu.tweakTabMessage))
                lbTweaksInfo.Text = SweetSettings._uwu.tweakTabMessage.Replace("<br/>", "\n").Replace("<br>", "\n");

            if (!string.IsNullOrEmpty(SweetSettings._uwu.serviceTabMessage))
                lbServiceInfo.Text = SweetSettings._uwu.serviceTabMessage.Replace("<br/>", "\n").Replace("<br>", "\n");

            if (isDataCorrupted)
            {
                if (HikariLove >= 100 && YuzukiLove >= 100)
                {
                    setNako();
                    setTabBckground();
                }
                else
                {
                    setHikari();
                    setTabBckground();
                }
            }

            if (HikariLove >= 100 && NakoLove < 100)
                HikariLove = 100;
            if (YuzukiLove >= 100 && NakoLove < 100)
                YuzukiLove = 100;

            if (HikariLove >= YuzukiLove && YuzukiLove >= NakoLove && NakoLove >= 999)
                btnLoveLetter.Text = " ∞";
            else
                btnLoveLetter.Text = "x" + loveLetter.ToString();

            if (HikariLove >= 100 && YuzukiLove >= 100)
            {
                if (NakoLove >= 100)
                {
                    pnHeart.BackgroundImage = Properties.Resources.heart_golden;
                    pnLaboon.BackgroundImage = Properties.Resources.baloon3;
                    if (!SweetSettings._uwu.isHikariAlwaysMain)
                    {
                        setNako();
                        setTabBckground();
                    }
                    else
                    {
                        setHikari();
                        setTabBckground();
                    }

                }
                else
                {
                    pnLaboon.BackgroundImage = Properties.Resources.baloon2;
                    if (!SweetSettings._uwu.isHikariAlwaysMain)
                    {
                        setNako();
                        setTabBckground();
                    }
                    else
                    {
                        setHikari();
                        setTabBckground();
                    }
                }
            }
            else
            {
                setHikari();
                lbHeart.Text = HikariLove.ToString() + "%";
            }

            if (totalLoveLetterCount < loveLetter || totalLoveLetterCount <= (HikariLove + YuzukiLove + NakoLove))
            {
                isCheated = true;
                loveStatusAngry.BringToFront();
                if (isNako)
                    setNako();
                else
                    setHikari();

                loveLetter = 10;
                HikariLove = 0;
                YuzukiLove = 0;
                NakoLove = 0;
                totalLoveLetterCount = 10;
            }

            pnHeartXdef = pnHeartX = lbAddOne.Location.X;

            if (!txtAboutBackupbutOnce)
                balooonDelay.Enabled = true;
        }

        public int GetLoveLetterInt(string strRawData)
        {
            int numba = Int32.Parse(Regex.Replace(strRawData, "[^0-9]", ""));
            if (numba >= loveletterOffset)
                numba -= loveletterOffset;
            return numba;
        }

        private void SetChar()
        {
            setTabBckground();
            var time = DateTime.Now.Hour;
            if (time >= 5 && time < 12)
                LBWelcome.Text = "Ohayou gozaimasu!";
            else if (time >= 12 && time < 17)
                LBWelcome.Text = "Konnichiwa!";
            else if (time >= 17 && time < 21)
                LBWelcome.Text = "Konbanwa!";
            else
                LBWelcome.Text = "Oyasumi!";

            if (isHikari)
            {
                if (HikariLove >= 0 && HikariLove < 10)
                    LBWe.Text = $"{PatcherSettings.hikariName} (*OwO)b";
                else if (HikariLove >= 10 && HikariLove < 30)
                    LBWe.Text = $"{PatcherSettings.hikariName} (*^A^)b";
                else if (HikariLove >= 30 && HikariLove < 50)
                    LBWe.Text = $"{PatcherSettings.hikariName} (*≧w≦)b";
                else if (HikariLove >= 50 && HikariLove < 80)
                    LBWe.Text = $"{PatcherSettings.hikariName} (⁄⁄> ⁄▽⁄ <⁄⁄)";
                else if (HikariLove >= 80 && HikariLove < 100)
                    LBWe.Text = $"{PatcherSettings.hikariName} (つ≧▽≦)つ";
                else if (HikariLove >= 100)
                    LBWe.Text = $"{PatcherSettings.hikariName} (❤ω❤)";
            }
            else if (isYuzuki)
            {
                if (YuzukiLove >= 0 && YuzukiLove < 10)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} (￣▽￣)/";
                else if (YuzukiLove >= 10 && YuzukiLove < 30)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} (〃￣w￣〃)/";
                else if (YuzukiLove >= 30 && YuzukiLove < 50)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} ♡ (￣З￣)";
                else if (YuzukiLove >= 50 && YuzukiLove < 80)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} 	(*¯ ³¯*) ♡";
                else if (YuzukiLove >= 80 && YuzukiLove < 100)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} (≧◡≦) ♡";
                else if (YuzukiLove >= 100)
                    LBWe.Text = $"{PatcherSettings.yuzukiName} (´ ω `♡)";
            }
            else if (isNako)
            {
                if (NakoLove >= 0 && NakoLove < 10)
                    LBWe.Text = $"{PatcherSettings.nakoName} (*≧ω≦)b";
                else if (NakoLove >= 10 && NakoLove < 30)
                    LBWe.Text = $"{PatcherSettings.nakoName} (*≧▽≦)b";
                else if (NakoLove >= 30 && NakoLove < 50)
                    LBWe.Text = $"{PatcherSettings.nakoName} o(*≧▽≦*)o";
                else if (NakoLove >= 50 && NakoLove < 80)
                    LBWe.Text = $"{PatcherSettings.nakoName} (´• ω •`) ♡";
                else if (NakoLove >= 80 && NakoLove < 100)
                    LBWe.Text = $"{PatcherSettings.nakoName} (つ≧▽≦)つ ♡";
                else if (NakoLove >= 100)
                    LBWe.Text = $@"{PatcherSettings.nakoName} ☆⌒\(*'w^*)";
            }
        }

        private bool whatuseeiswhatuget = false;

        private void CheckForBlacklist()
        {
            if (UniversalSettings._un.BlockedUsers.Any())
            {
                if (!lockedPathInterface)
                {
                    for (int i = 0; i < UniversalSettings._un.BlockedUsers.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(UniversalSettings._un.BlockedUsers[i]))
                        {
                            var files = Directory.GetFiles(currentGameFolder, UniversalSettings._un.BlockedUsers[i] + ".*");
                            if (files.Length > 0)
                            {
                                whatuseeiswhatuget = true;
                                tabControl1.SelectedTab = tab1;
                                tabControl1.Tabs.Remove(tab2);
                                tabControl1.Tabs.Remove(tab3);
                                tabControl1.Tabs.Remove(tab4);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
            LoadUILanguage();
            notifyIcon.Icon = this.Icon;
            pbTitle.Image = Properties.Resources.appicon60;
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            GetDLCwebVersion();
            if (nDPI >= 120)
                btnLoveLetter.Padding = new Padding(0, 0, 0, 2);
            if (nDPI >= 144)
                btnLoveLetter.Padding = new Padding(0, 0, 0, 4);
            if (nDPI >= 168)
                btnLoveLetter.Padding = new Padding(0, 0, 0, 5);
            if (nDPI >= 169)
                btnLoveLetter.Padding = new Padding(0, 0, 0, 6);

            if (!lockedPathInterface)
                CheckForBlacklist();

            pingMeNibba();

            //Restores the last opened tab
            string lastTab = UserSettings.PatchLastTab;
            if (lastTab != null)
            {
                var tab = tabControl1.Tabs.OfType<Manina.Windows.Forms.Tab>().FirstOrDefault(o => o.Text == lastTab);
                if (tab == tab2)
                {
                    tabControl1.SelectedTab = tab1;
                    return;
                }

                if (tab != null)
                    tabControl1.SelectedTab = tab1; //should be tab, but i want it always stay at tab1
            }
            else
                tabControl1.SelectedTab = tab1;
        }


        public void bringMePatchEs()
        {
            tabControl1.SelectedTab = tab2;
        }

        bool isAutoTaskRunning = false;
        
        public void BrowseGameDirectory_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (Methods.IsFreeStyle2Running())
            {
                MsgBoxs.Warning.CloseGameFirst(this);
                return;
            }

            BetterFolderBrowser betterFolderBrowser1 = new BetterFolderBrowser
            {
                Title = StringLoader.GetText("msgtitle_select_game_folder"),
                RootFolder = string.IsNullOrEmpty(currentGameFolder) ? Strings.FolderName.MyComputer : (Directory.Exists(currentGameFolder) ? currentGameFolder : Strings.FolderName.MyComputer),
                Multiselect = false
            };

            if (betterFolderBrowser1.ShowDialog() == DialogResult.OK)
            {
                string foldered = betterFolderBrowser1.SelectedPath;
                SetGameFolder(foldered, true);
                betterFolderBrowser1.Dispose();
            }
        }

        public void SetGameFolder(string folder, bool messageBoxOn)
        {
            if (folder == Methods.GetFolder())
                return;

            if (!Methods.IsValidFS2Path(folder))
            {
                if (messageBoxOn)
                    MsgBoxs.Warning.InvalidFolder(this);

                if (!lockedPathInterface)
                    return;

                //PatcherSettings.DeleteValue(PatcherSettings.takatto00001);
                UserSettings.GamePath = null;
                LockPatchInterface();
                return;
            }

            //PatcherSettings.SetValue(PatcherSettings.takatto00001, folder);
            UserSettings.GamePath = folder;
            LockPatchInterface();
            UnlockPatchInterface();
            CheckForBlacklist();
        }

        int languageValue;
        bool failedListPatches = false;
        bool skipAnimationPatchLoad = false;
        private void btnRefreshAvailablePatches_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (!isPatchListLoading && currentFrame == 0)
            {
                btnPatchUninstall.Visible = false;
                btnPatchImage.Visible = false;
                lbPatches.Items.Clear();
                lbRepo.Text = StringLoader.GetText("lb_status_empty");
                lbType.Text = "";
                pbRepo.Image = Properties.Resources.icons8_cat_profile_35;
                toolTip1.SetToolTip(pbRepo, "");

                lbPatchDescription.Text = StringLoader.GetText("lb_patch_desc");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_note");
                lbPatchesHelp.Text = StringLoader.GetText("lb_patch_help");

                SetPatchStatus(StringLoader.GetText("lb_patch_status"), Color.FromArgb(192, 199, 226));

                isPatchListLoading = true;
                if (!skipAnimationPatchLoad)
                {
                    pnErorCat.Image = null;
                    pnErorCat.Enabled = false;
                    pn404.Visible = false;
                    lbPatches.Visible = false;
                    lbPatches.Height = 0;
                    currentFrame = 0;
                    pbCatLoading.Image = Properties.Resources.catKawaii;
                    pbCatLoading.Enabled = true;
                }
                LoadPatchesListAsync();
            }
            if (!isOpenningRepo && isOpenningRepoOpenned)
                btnURIconFirM_Click(null, null);
        }


        void LoadUILanguage()
        {
            tab1.Text = StringLoader.GetText("tab1");
            tab2.Text = StringLoader.GetText("tab2");
            tab3.Text = StringLoader.GetText("tab3");
            tab4.Text = StringLoader.GetText("tab4");
            tab5.Text = StringLoader.GetText("tab5");

            lbServiceLocker.Text = StringLoader.GetText("lb_patch_not_installed");

            lbPatchDescription.Text = StringLoader.GetText("lb_patch_desc");
            lbPatchNote.Text = StringLoader.GetText("lb_patch_note");
            lbPatchesHelp.Text = StringLoader.GetText("lb_patch_help");
            lbPatchInfo.Text = StringLoader.GetText("lb_patch_info");
            btnGameLaunch.Text = StringLoader.GetText("btn_launch");
            lbPatchHeader.Text = StringLoader.GetText("lb_patch_list");
            lbRefresh5.Text = StringLoader.GetText("btn_click_to_reset");
            btnInstallPatch.Text = StringLoader.GetText("btn_patch_it");
            tbPatchURI.Text = StringLoader.GetText("txt_enter_url");
            tbPatchURI.PlaceHolderText = StringLoader.GetText("txt_enter_url");

            notifyIcon.Text = StringLoader.GetText("notify_tray_tip");
            //context
            closeGameToolStripMenuItem.Text = StringLoader.GetText("tooltip_close_game");
            launcherToolStripMenuItem.Text = StringLoader.GetText("context_launch_launcher");
            steamLauncherToolStripMenuItem.Text = StringLoader.GetText("context_launch_steam");
            nexonToolStripMenuItem.Text = StringLoader.GetText("context_launch_web");
            openFolderToolStripMenuItem.Text = StringLoader.GetText("context_open_game_foler");
            openPatchFolderToolStripMenuItem.Text = StringLoader.GetText("context_open_patcher_foler");
            showToolStripMenuItem.Text = StringLoader.GetText("btn_show");
            hideToolStripMenuItem.Text = StringLoader.GetText("btn_hide");
            closeToolStripMenuItem.Text = StringLoader.GetText("btn_exit");
            currenttsSong.Text = StringLoader.GetText("context_song_current", "null");
            loadARandomMusicToolStripMenuItem.Text = StringLoader.GetText("context_song_load_random");
            refreshToolStripMenuItem.Text = StringLoader.GetText("lb_reset");
            importToolStripMenuItem.Text = StringLoader.GetText("btn_import");
            loadCustomRepoToolStripMenuItem.Text = StringLoader.GetText("context_custom_repo");
            toolStripMenuCloseLauncherStatus.Text = StringLoader.GetText("context_close_launcher");
            //context

            toolTip1.SetToolTip(btnFolder, StringLoader.GetText("tooltip_button_select_folder"));
            toolTip1.SetToolTip(btnTranslate, StringLoader.GetText("tooltip_button_translate"));
            toolTip1.SetToolTip(btnPatchImage, StringLoader.GetText("tooltip_button_demo"));
            toolTip1.SetToolTip(btnPatchUninstall, StringLoader.GetText("tooltip_button_uninstall"));
            toolTip1.SetToolTip(btnGameLaunch, StringLoader.GetText("tooltip_launch_game"));
            toolTip1.SetToolTip(btnKillGame, StringLoader.GetText("tooltip_close_game"));
            toolTip1.SetToolTip(btnSwLock, StringLoader.GetText("tooltip_sweet_lock"));
            toolTip1.SetToolTip(newsbtn, StringLoader.GetText("tooltip_sweet_news"));
            toolTip1.SetToolTip(btn_MusicMute, StringLoader.GetText("tooltip_sweet_music"));
            toolTip1.SetToolTip(btn_sweetletter_news, StringLoader.GetText("tooltip_sweet_news"));
            toolTip1.SetToolTip(btnTutorial, StringLoader.GetText("tooltip_sweet_tutorial"));
            toolTip1.SetToolTip(btnDonate, StringLoader.GetText("tooltip_sweet_donate"));
            toolTip1.SetToolTip(btnSetImageTest, StringLoader.GetText("tooltip_sweet_image"));
            toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "Default"));
            toolTip1.SetToolTip(btnSetBackgroundImageTest, StringLoader.GetText("tooltip_sweet_image"));
            toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "Default"));


            lbTweaksInfo.Text = StringLoader.GetText("lb_tweak_info");
            lbCourtHint.Text = StringLoader.GetText("lb_tweak_help");
            lbRefreshTwea.Text = StringLoader.GetText("btn_click_to_reset");
            lbTweakHeader.Text = StringLoader.GetText("lb_tweak_list");
            
            btnSV_JukeBox.Text = "♦ " + StringLoader.GetText("btn_tweak_jukebox");
            btnSV_MCVoice.Text = "♦ " + StringLoader.GetText("btn_tweak_mcvoice");
            btnSV_CharVoice.Text = "♦ " + StringLoader.GetText("btn_tweak_charactervoice");
            btnSV_Texture.Text = "♦ " + StringLoader.GetText("btn_tweak_texture");
            btnSV_Task.Text = "♦ " + StringLoader.GetText("btn_tweak_timedtask");
            btnSV_Map.Text = "♦ " + StringLoader.GetText("btn_tweak_court");
            btnSV_Misc.Text = "♦ " + StringLoader.GetText("btn_tweak_misc");
            btnSV_Extension.Text = "♦ " + StringLoader.GetText("btn_tweak_extension");

            toolTip1.SetToolTip(btnLanguage, StringLoader.GetText("tooltip_button_language"));
            toolTip1.SetToolTip(btnCatSeal, StringLoader.GetText("tooltip_button_cat_seal"));
            toolTip1.SetToolTip(btnGameSetting, StringLoader.GetText("tooltip_button_game_resizer"));

            lbServiceInfo.Text = StringLoader.GetText("lb_service_info");
            lbServiceDec.Text = StringLoader.GetText("lb_service_help");
            lbServiceHeader.Text = StringLoader.GetText("lb_service_list");

            toolTip1.SetToolTip(btnServiceRequest, StringLoader.GetText("msgtitle_random1"));

            lbVersion.Text = StringLoader.GetText("lb_about_version", AssemblyAccessor.Version);
            textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");

            toolTip1.SetToolTip(btnDiscord, StringLoader.GetText("tooltip_button_discord"));
            toolTip1.SetToolTip(btnSettings, StringLoader.GetText("tooltip_button_setting"));
            toolTip1.SetToolTip(btnQuestion, StringLoader.GetText("tooltip_button_help"));
            toolTip1.SetToolTip(btnRepair, StringLoader.GetText("tooltip_button_repair"));
        }

        private void btnPatchImage_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            string patchname = lbPatches.SelectedItem.ToString().Trim();
            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchname);

            if (selecttedPatch == null)
            {
                MsgBoxs.Warning.IncorrectParametter(this); return;
            }

            string picURL = (!string.IsNullOrEmpty(selecttedPatch.directPictureURI) ? selecttedPatch.directPictureURI : PATCHES.ServerUri.Replace("{id}", selecttedPatch.id).Replace(".dat", ".image"));

            Help_CourtTakatto demo = new Help_CourtTakatto(picURL, false, false);
            demo.ShowDialog(this);
            demo.Dispose();
        }

        private void btnPatchUninstall_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(this))
                return;

            if (PATCHES.Patches == null || !PATCHES.Patches.Any())
            {
                MsgBoxs.Warning.IncorrectParametter(this); 
                return;
            }

            string patchname = lbPatches.SelectedItem.ToString().Trim();
            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchname);

            if (selecttedPatch == null)
            {
                MsgBoxs.Warning.IncorrectParametter(this);
                return;
            }

            var _patchid = selecttedPatch.id;
            var _patchname = selecttedPatch.name;

            var path = selecttedPatch.isExtension ? Strings.FolderName.Extension : Strings.FolderName.Data;

            if (File.Exists(Methods.GetFolder(path, $"{_patchid}.txt")))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(this, _patchname);
                if (confirmResult == DialogResult.Yes)
                {
                    var path2 = selecttedPatch.isExtension ? Strings.FolderName.Extension : string.Empty;
                    string patch_json = File.ReadAllText(Methods.GetFolder(path, $"{_patchid}.txt"));
                    if (!string.IsNullOrEmpty(patch_json))
                    {
                        var result = @patch_json.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();

                        if (result != null && result.Length > 1)
                        {
                            for (int i = 1; i < result.Length; i++) //skip version
                            {
                                if (!string.IsNullOrWhiteSpace(result[i]))
                                {
                                    if (Directory.Exists(Methods.GetFolder(path2, result[i])))
                                    {
                                        try
                                        {
                                            Directory.Delete(Methods.GetFolder(path2, result[i]), true);
                                        }
                                        catch (Exception ew)
                                        {
                                            Logger.Write(result[i] + " could not be deleted. Kat-code: " + ew.Message);
                                        }
                                    }
                                    else if (File.Exists(Methods.GetFolder(path2, result[i])))
                                    {
                                        try
                                        {
                                            File.Delete(Methods.GetFolder(path2, result[i]));
                                        }
                                        catch (Exception ew)
                                        {
                                            Logger.Write(result[i] + " could not be deleted. Kat-code: " + ew.Message);
                                        }
                                    }
                                }
                            }

                            try { File.Delete(Methods.GetFolder(path, $"{_patchid}.txt")); } catch { }

                            MsgBoxs.Information.Uninstalled(this, _patchname);
                            LoadPatchInfoAsync();
                            return;
                        }
                    }

                    MsgBoxs.Warning.PatchFailedToUninstall(this, _patchname);
                    return;
                }
                return;
            }

            MsgBoxs.Warning.IncorrectParametter(this);
        }

        void SetPatchStatus(string st, Color color)
        {
            lbPatchStatus.Text = st;
            lbPatchStatus.BackColor = color;
            panelExNote.BorderColor = color;
        }

        private void LoadPatchInfoAsync()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                lbPatchDescription.Text = StringLoader.GetText("lb_patch_multi_mode");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_multi_mode_note");
                lbPatchesHelp.Text = StringLoader.GetText("lb_patch_multi_mode_help");

                SetPatchStatus(StringLoader.GetText("lb_patch_multi_mode_status"), Color.FromArgb(192, 199, 226));
                btnPatchImage.Visible = false;
                btnPatchUninstall.Visible = false;
                return;
            }

            if (PATCHES.Patches == null || !PATCHES.Patches.Any())
            {
                lbPatchDescription.Text = StringLoader.GetText("lb_patch_failed_to_load");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_failed_to_load_note");
                lbPatchStatus.Text = StringLoader.GetText("lb_status_empty");
                return;
            }

            string patchname = lbPatches.SelectedItem.ToString().Trim();
            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchname);

            string patchid = "";

            if (selecttedPatch != null)
            {
                patchid = selecttedPatch.id;
                patchname = selecttedPatch.name;
            }
            else
            {
                lbPatchDescription.Text = StringLoader.GetText("lb_patch_failed_to_load");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_failed_to_fetch");
                lbPatchStatus.Text = StringLoader.GetText("lb_status_empty");
                return;
            }

            var path = selecttedPatch.isExtension ? Strings.FolderName.Extension : Strings.FolderName.Data;

            lbType.Text = (selecttedPatch.isStandalone) ? ((selecttedPatch.isExtension) ? "EXT" : "STD") : ((selecttedPatch.isObsolete) ? "OB" : (selecttedPatch.isWorkingInProcess) ? "WIP" : "NL");

            btnPatchImage.Visible = selecttedPatch.isHavingPicture;

            SetPatchStatus(StringLoader.GetText("lb_patch_not_installed"), Color.FromArgb(192, 199, 226));
            btnPatchUninstall.Visible = false;

            if (!lockedPathInterface)
            {
                if (!selecttedPatch.isExtension)
                {
                    if (File.Exists(Methods.GetFolder(path, $"{patchid}.txt")))
                    {
                        btnPatchUninstall.Visible = true;
                        SetPatchStatus(StringLoader.GetText("lb_patch_installed"), Color.FromArgb(222, 212, 245));
                        string patch_ver = File.ReadAllText(Methods.GetFolder(path, $"{patchid}.txt"));
                        if (!string.IsNullOrEmpty(patch_ver))
                        {
                            var result = @patch_ver.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();
                            if (result != null && result.Length > 0)
                            {
                                SetPatchStatus(!string.IsNullOrEmpty(result.First()) ? StringLoader.GetText("lb_patch_installed_version", result.First()) : StringLoader.GetText("lb_patch_installed"), Color.FromArgb(222, 212, 245));
                            }
                        }
                    }
                    else if (tempPatch.FirstOrDefault(stringToCheck => stringToCheck.Contains(patchname)) != null)
                    {
                        SetPatchStatus(StringLoader.GetText("lb_patch_sessionly_applied"), Color.MistyRose);
                    }
                }

                else if (selecttedPatch.isExtension)
                {
                    if (File.Exists(Methods.GetFolder(path, $"{patchid}.txt")))
                    {
                        string patch_ver = File.ReadAllText(Methods.GetFolder(path, $"{patchid}.txt"));
                        if (!string.IsNullOrEmpty(patch_ver))
                        {
                            var result = @patch_ver.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();

                            if (result != null && result.Length >= 1)
                            {
                                if (File.Exists(Methods.GetFolder(path, result.Last())))
                                {
                                    btnPatchUninstall.Visible = true;
                                    SetPatchStatus(!string.IsNullOrEmpty(result.First()) ? StringLoader.GetText("lb_patch_extension_installed_version", result.First()) : StringLoader.GetText("lb_patch_extension_installed"), Color.MistyRose);
                                }
                            }
                        }
                    }
                }
            }


            if (lbPatches.SelectedIndices.Count == 1) // I'd use to group all of your multi-selection cases
            {
                lbPatchDescription.Text = StringLoader.GetText("lb_patch_connecting");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_connecting");
                var vern = string.IsNullOrEmpty(selecttedPatch.version) ? "null" : selecttedPatch.version;
                var daten = string.IsNullOrEmpty(selecttedPatch.updatedAt) ? ((string.IsNullOrEmpty(selecttedPatch.createdAt) ? "null" : selecttedPatch.createdAt)) : selecttedPatch.updatedAt;
                lbPatchesHelp.Text = StringLoader.GetText("lb_patch_info_version", vern, daten);
                if (cbTranslation.SelectedIndex < 0)
                    cbTranslation.SelectedIndex = cbTranslation.FindStringExact("Default");

                TranslateTextAsync((cbTranslation.SelectedItem as Language).Value, selecttedPatch.description, selecttedPatch.note);
            }
        }
          
        string[] arrMultiPatches;
        private void lbPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPatches.SelectedIndex == -1)
                return;

            if (lbPatches.SelectedIndices.Count > 1) // I'd use to group all of your multi-selection cases
            {
                lbPatchDescription.Text = StringLoader.GetText("lb_patch_multi_mode_status");
                lbPatchNote.Text = StringLoader.GetText("lb_patch_multi_mode_note");
                lbPatchesHelp.Text = StringLoader.GetText("lb_patch_multi_mode_help");
                lbType.Text = "";
                btnPatchImage.Visible = false;
                btnPatchUninstall.Visible = false;
                SetPatchStatus(StringLoader.GetText("lb_patch_multi_mode_status"), Color.FromArgb(192, 199, 226));

                foreach (int i in lbPatches.SelectedIndices)
                {
                    //var sthing = UniversalSettings._un.Patches.FirstOrDefault(x => x.name == lbPatches.Items[i].ToString().Trim());
                    var sthing = PATCHES.Patches.FirstOrDefault(x => x.name == lbPatches.Items[i].ToString().Trim());
                    if (sthing == null)
                    {
                        lbPatches.SelectedIndex = -1;
                        lbPatchDescription.Text = StringLoader.GetText("lb_patch_error");
                        lbPatchNote.Text = StringLoader.GetText("lb_patch_error_not_found");
                        lbPatchesHelp.Text = StringLoader.GetText("lb_patch_error_not_found_help");
                        return;
                    }
                    if (sthing.isExtension)
                    {
                        lbPatches.SelectedIndex = -1;
                        lbPatchDescription.Text = StringLoader.GetText("lb_patch_error");
                        lbPatchNote.Text = StringLoader.GetText("lb_patch_error_ext_not_supported");
                        lbPatchesHelp.Text = StringLoader.GetText("lb_patch_error_ext_not_supported_help");
                    }
                    else if (sthing.isStandalone)
                    {
                        lbPatches.SelectedIndex = -1;
                        lbPatchDescription.Text = StringLoader.GetText("lb_patch_error");
                        lbPatchNote.Text = StringLoader.GetText("lb_patch_error_std_not_supported");
                        lbPatchesHelp.Text = StringLoader.GetText("lb_patch_error_std_not_supported_help");
                    }
                    else if (sthing.isWorkingInProcess)
                    {
                        lbPatches.SelectedIndex = -1;
                        lbPatchDescription.Text = StringLoader.GetText("lb_patch_error");
                        lbPatchNote.Text = StringLoader.GetText("lb_patch_error_wip_not_supported");
                        lbPatchesHelp.Text = StringLoader.GetText("lb_patch_error_wip_not_supported_help");
                    }
                }
                return;
            }

            lbPatchDescription.Text = StringLoader.GetText("lb_patch_connecting");
            lbPatchNote.Text = StringLoader.GetText("lb_patch_connecting");
            lbPatchStatus.Text = StringLoader.GetText("lb_status_empty");
            lbType.Text = "";
            LoadPatchInfoAsync();
        }

        bool useitanyway = false;
        int useitanywey = 0;
        private void btnInstallPatch_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfFS2FolderIsMissing(this))
                return;

            if (lbPatches.SelectedIndex == -1 || PATCHES.Patches == null || !PATCHES.Patches.Any())
            {
                MsgBoxs.Information.NoItemSelected(this);
                return;
            }

            string patchname = lbPatches.GetItemText(lbPatches.SelectedItem).Trim();

            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchname);
            if (selecttedPatch == null)
            {
                MsgBoxs.Warning.IncorrectParametter(this);
                return;
            }

            var _patchname = selecttedPatch.name;
            var _patchid = selecttedPatch.id;

            var path = selecttedPatch.isExtension ? Strings.FolderName.Extension : Strings.FolderName.Data;

            if (lbPatches.SelectedIndices.Count > 1) // I'd use to group all of your multi-selection cases
            {
                if (lbPatches.SelectedIndices.Count > 2)
                {
                    MsgBoxs.Warning.MaximumItemsSelected(this, 2);
                    return;
                }

                isMultiPatchDownloading = true;
                isMultiPatch = true;
                arrMultiPatches = (from string s in lbPatches.SelectedItems select s).ToArray();
            }


            /* check if installed */
            if (isGameRunning && !selecttedPatch.isExtension && tempPatch.FirstOrDefault(stringToCheck => stringToCheck.Contains(_patchid)) != null)
            {
                MsgBoxs.Information.PatchHasBeenApplied(this, _patchname);
                return;
            }

            if (selecttedPatch.isStandalone && !selecttedPatch.isExtension)
            {
                if (Methods.AlertIfGameIsRunning(this))
                    return;

                if (File.Exists(Methods.GetFolder(path, $"{_patchid}.txt")))
                {
                    var confirmResult = MsgBoxs.Dialog.Reinstall(this);
                    if (confirmResult == DialogResult.No)
                        return;
                }
            }
            else if (selecttedPatch.isStandalone && selecttedPatch.isExtension)
            {
                if (File.Exists(Methods.GetFolder(path, $"{_patchid}.txt")))
                {
                    string patch_ver = File.ReadAllText(Methods.GetFolder(path, $"{_patchid}.txt"));
                    var result = @patch_ver.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();
                    if (result != null && result.Length >= 1)
                    {
                        if (File.Exists(Methods.GetFolder(path, result.Last())))
                        {
                            var confirmResult = MsgBoxs.Dialog.Reinstall(this);
                            if (confirmResult == DialogResult.No)
                                return;
                        }
                    }
                }
            }


            if (selecttedPatch.isWorkingInProcess)
            {
                MessageBoxEx.Show(this, (!string.IsNullOrEmpty(selecttedPatch.workingInProcessNote) ? selecttedPatch.workingInProcessNote : StringLoader.GetText("msg_patch_wip")), StringLoader.GetText("msgtitle_rawk"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (patchname.Contains(StringLoader.GetText("lb_connecting")) || patchname.Contains(StringLoader.GetText("lb_failed_to_connect")))
                return;

            if (selecttedPatch.isObsolete)
            {
                if (!useitanyway)
                {
                    var confirmResult = MessageBoxEx.Show(this, (!string.IsNullOrEmpty(selecttedPatch.obsoleteNote) 
                        ? selecttedPatch.obsoleteNote : StringLoader.GetText("msgdiag_patch_obselete")), StringLoader.GetText("msgtitle_rawk"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        useitanywey += 1;
                        if (useitanywey == 99)
                        {
                            useitanyway = true;
                        }
                    }
                    else
                        return;
                }
            }

            MainForm.wForm = new ProcessForm
            {
                TopLevel = false,
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,

                TopMost = true
            };

            string patchPackUrl = (selecttedPatch.isDownloadableViaDirectUri) ? (!string.IsNullOrEmpty(selecttedPatch.directURI) 
                ? selecttedPatch.directURI : PATCHES.ServerUri.Replace("{id}", _patchid)) : PATCHES.ServerUri.Replace("{id}", _patchid);
            string tempFilename = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, $"{_patchid}.dat");


            aTimer = new System.Timers.Timer(200);

            aTimer.Elapsed += OnTimed_WaitingForProcessThenPatchEvent;

            if (isGameRunning)
                DownloadFile(patchPackUrl, tempFilename, currentGameFolder);
            else
            {
                if (selecttedPatch.isStandalone || selecttedPatch.isExtension)
                {
                    isSTDPatchDownloading = true;
                    DownloadFile(patchPackUrl, tempFilename, currentGameFolder);
                    return;
                }

                pnForm.Size = new Size(tabControl1.Width - 2, tabControl1.Height - 1);
                pnForm.Location = new Point(tabControl1.Location.X + 1, tabControl1.Location.Y);
                pnForm.Controls.Add(MainForm.wForm);
                MainForm.wForm.Show();
                MainForm.wForm.BringToFront();

                aTimer.Enabled = true;
            }
        }


        public void OnTimed_WaitingForProcessThenPatchEvent(Object source, ElapsedEventArgs e)
        {
            string patchnameTemp = "";
            if (lbPatches.InvokeRequired)
            {
                lbPatches.Invoke(new MethodInvoker(delegate { patchnameTemp = lbPatches.SelectedItem.ToString().Trim(); }));
            }
            var selecttedPatch = PATCHES.Patches.FirstOrDefault(x => x.name == patchnameTemp);
            string _patchname = "";
            string _patchid = "";
            if (selecttedPatch != null)
            {
                _patchname = selecttedPatch.name;
                _patchid = selecttedPatch.id;
            }

            string patchPackUrl2 = (selecttedPatch.isDownloadableViaDirectUri) ? (!string.IsNullOrEmpty(selecttedPatch.directURI) ? selecttedPatch.directURI : PATCHES.ServerUri.Replace("{id}", _patchid)) : PATCHES.ServerUri.Replace("{id}", _patchid);
            string tempFilename2 = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, $"{_patchid}.dat");


            if (isGameRunning)
            {
                aTimer.Enabled = false;
                CloseForm(wForm);
                InvokeUI(() =>
                {
                   DownloadFile(patchPackUrl2, tempFilename2, currentGameFolder);
                });
            }
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            string Url = UniversalSettings._un.DiscordUri;

            if (string.IsNullOrEmpty(Url))
            {
                MsgBoxs.Warning.FailedToFetch(this);
                return;
            }

            Process.Start(Url);
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            string takapp = UniversalSettings._un.DonateUri;

            if (string.IsNullOrEmpty(takapp))
            {
                MsgBoxs.Warning.FailedToFetch(this);
                return;
            }

            Process.Start(takapp);
        }

        void RunGame(int type)
        {
            ActiveControl = null;
            if (lockedPathInterface || isGameRunning)
                return;

            switch (type)
            {
                case 0:
                    try
                    {
                        Methods.RunAsUser(Methods.GetFolder(Strings.FileName.LauncherExe));
                    }
                    catch
                    {
                        MsgBoxs.Warning.FailedToFetch(this);
                    }
                    break;

                case 1:
                    if (!File.Exists(Methods.GetFolder(Strings.FileName.LauncherSteamExe)))
                    {
                        MsgBoxs.Warning.FailedToFetch(this);
                        break;
                    }
                    try
                    {
                        Process.Start(Urls.SteamGameUri);
                    }
                    catch { RunGame(0); }
                    break;

                case 2:
                    if (Methods.IsKoreaClient())
                    {
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.GetType() == typeof(BrowserForm))
                            {
                                form.Activate();
                                return;
                            }
                        }

                        BrowserForm frm = new BrowserForm();
                        frm.Show();
                        break;
                    }

                    var confirmResult = MsgBoxs.Dialog.ForceRunningBrowserLauncher(this);
                    if (confirmResult == DialogResult.Yes)
                    {
                        ActiveControl = null;
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.GetType() == typeof(BrowserForm))
                            {
                                form.Activate();
                                return;
                            }
                        }

                        BrowserForm frm = new BrowserForm();
                        frm.Show();
                    }
                    break;
            }
        }

        private void launcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettings.ForceSteamLauncher = false;
            RunGame(0);
        }

        private void steamLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettings.ForceSteamLauncher = true;
            RunGame(1);        
        }

        private void nexonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunGame(2);
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockedPathInterface)
                return;

            try { Process.Start(currentGameFolder); } catch { }
        }

        private void btn_launch_dropdown_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            contextLauncher.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void btn_launch_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (isGameRunning || lockedPathInterface)
            {
                if (Methods.AlertIfFS2FolderIsMissing(this))
                    return;

                else if (isGameRunning)
                    if (mute != 0)
                        nyannyan.Play();

                return;
            }

            if (Methods.IsKoreaClient())
            {
                RunGame(2);
                return;
            }

            if (Methods.IsTiancityFS2() || !UserSettings.ForceSteamLauncher || !File.Exists(Methods.GetFolder(Strings.FileName.LauncherSteamExe)))
            {
                RunGame(0);
                return;
            }

            RunGame(1);
        }

        private void closeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGameRunning)
                Methods.KillGame();
        }
        
        bool customeMeze = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (isGameRunning)
                Methods.KillGame();

            if(UserSettings.CloseLauncher)
                Methods.KillLauncher();
        }

        bool isSongLoaded = false;
        SoundPlayer playerWelcome = null;
        private void button3_Click(object sender, EventArgs e)
        {
            if (isSongLoading)
                return;

            if (!isSongLoaded)
            {
                isClickedMusicBtn = true;
                LoadMusicAsync();
                return;
            }

            if (mute == 0)
            {
                mute = 1;

                if (UniversalSettings._un.isMusicListEventEnabled)
                {
                    if (!customeMeze)
                    {
                        if (!string.IsNullOrEmpty(UniversalSettings._un.MusicListEventMessage))
                        {
                            MessageBoxEx.Show(this, UniversalSettings._un.MusicListEventMessage);
                            customeMeze = true;
                            customizeqte = true;
                            pnHi_Click(sender, new EventArgs());
                        }
                    }
                }

                btn_MusicMute.BackgroundImage = Properties.Resources.icons8_mute_35;
                playerWelcome.Stop();
            }
            else if (mute == 1)
            {
                mute = 0;
                btn_MusicMute.BackgroundImage = Properties.Resources.icons8_voice_35;
                try
                {
                    playerWelcome.PlayLooping();
                }
                catch (Exception ew)
                {
                    MsgBoxs.Warning.Error(this, ew.Message);
                }
            }
        }


        private void btnDiscordSever_Click(object sender, EventArgs e)
        {
            string Url = UniversalSettings._un.DiscordUri;

            if (string.IsNullOrEmpty(Url))
            {
                MsgBoxs.Warning.FailedToFetch(this);
                return;
            }

            Process.Start(Url);
            ActiveControl = null;
        }

       
        String[] codeStr;
        private void loadSecretKeys()
        {
            if (UniversalSettings._un.Services.Any())
            {
                List<string> list = new List<string>();
                foreach (var code in UniversalSettings._un.Services)
                {
                    code.id = KATEncryptor.Decrypt(code.id,1);
                    code.name = KATEncryptor.Decrypt(code.name, 1);
                    code.toDo = KATEncryptor.Decrypt(code.toDo, 1);
                    code.message = KATEncryptor.Decrypt(code.message, 1);
                    code.condition = KATEncryptor.Decrypt(code.condition, 1);
                    list.Add(code.id);
                }
                codeStr = list.ToArray();
            }
        }

        private void mtextBoxButWithEasterEgg_TextChanged(object sender, EventArgs e)
        {
            if (lockedPathInterface || whatuseeiswhatuget)
            {
                textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");
                return;
            }

            if (textBoxButWithEasterEgg.Text.Contains("givmorloveletter"))
            {
                loveLetter += 100;
                btnLoveLetter.Text = "x" + loveLetter.ToString();
                textBoxButWithEasterEgg.Text = "Love letters + 100.";
                Logger.Write("Love letter cheat code has been used");
            }

            if (textBoxButWithEasterEgg.Text.Contains("givmorletteroffset"))
            {
                totalLoveLetterCount += 100;
                textBoxButWithEasterEgg.Text = "Love letters offset + 100.";
                Logger.Write("Love letter cheat code has been used");
            }

            if (textBoxButWithEasterEgg.Text.Contains("givluv"))
            {
                if (NakoLove >= 100)
                {
                    textBoxButWithEasterEgg.Text = "Don't be greedy! ヽ( `д´*)ノ";
                    Logger.Write("Love letter cheat code has been used but could not apply the cheat~");
                    return;
                }

                HikariLove = 100;
                YuzukiLove = 100;
                textBoxButWithEasterEgg.Text = "Hikari && Yuzuki love = 100.";
                Logger.Write("Love letter cheat code has been used");
            }

            if (textBoxButWithEasterEgg.Text.Contains("sweettestmode"))
            {
                textBoxButWithEasterEgg.Text = "Sweet letter test mode enabled~";
                btnSetBackgroundImageTest.Visible = true;
                btnSetBackgroundImageLayoutTest.Visible = true;
                btnSetImageLayoutTest.Visible = true;
                btnSetImageTest.Visible = true;
            }

            if (codeStr == null)
                return;

            if (codeStr.Any(ca => textBoxButWithEasterEgg.Text.Contains(ca))) //textBoxButWithEasterEgg.Text.Contains(resultSecretKey)
            {
                if (isGameRunning)
                {
                    textBoxButWithEasterEgg.Text = StringLoader.GetText("msg_close_game_first");
                    return;
                }

                foreach (string item in codeStr)
                {

                    if (textBoxButWithEasterEgg.Text.Contains(item))
                    {
                        var chosenOne = UniversalSettings._un.Services.FirstOrDefault(x => x.id == item);
                        if (!string.IsNullOrEmpty(chosenOne.message))
                            textBoxButWithEasterEgg.Text = chosenOne.message;


                        string dlcPackUrl = chosenOne.toDo;
                        string tempDLCname = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, Strings.KattoFileName.DLCExtra);
                        if (!string.IsNullOrEmpty(dlcPackUrl))
                        {
                            isTweakDownloading = true;
                            isDLCServiceDownloading = true;
                            DownloadFile(dlcPackUrl, tempDLCname, currentGameFolder);
                        }
                    }
                }
            }
        }

        bool takService_card_viewer = false;
        bool takService_card_viewer_lock_once_release = false;
        bool isLocated = false;

        private void StuffLang()
        {
            if (lockedPathInterface)
            {
                btnLanguage.Text = StringLoader.GetText("btn_language");
                return;
            }

            string gameLang = UserSettings.GameLanguage;

            switch (gameLang)
            {
                case "ENGLISH":
                    defaultNation = 3;
                    defaultLanguage = "ENG";
                    btnLanguage.Text = "English";
                    break;
                case "GERMAN":
                    defaultNation = 5;
                    defaultLanguage = "GER";
                    btnLanguage.Text = "Deutsch";
                    break;
                case "FRENCH":
                    defaultNation = 6;
                    defaultLanguage = "FRA";
                    btnLanguage.Text = "Française";
                    break;
                case "THAI":
                    defaultNation = 7;
                    defaultLanguage = "THI";
                    btnLanguage.Text = "ภาษาไทย";
                    break;
                case "中國人":
                    if (isChinaClient && isTiancityClient)
                    {
                        defaultNation = 1;
                        defaultLanguage = "CHN"; //CHN
                        btnLanguage.Text = "中国人";
                        break;
                    }
                    else if (isChinaClient)
                    {
                        defaultNation = 2; //1
                        defaultLanguage = "CHN"; //CHN
                        btnLanguage.Text = "中国人";
                        break;
                    }
                    else
                    {
                        defaultNation = 2;
                        defaultLanguage = "TWN";
                        btnLanguage.Text = "中國人";
                        break;
                    }
                case "中国人":
                    if (isChinaClient && isTiancityClient)
                    {
                        defaultNation = 1;
                        defaultLanguage = "CHN"; //CHN
                        btnLanguage.Text = "中国人";
                        break;
                    }
                    else if (isChinaClient)
                    {
                        defaultNation = 2; //1
                        defaultLanguage = "CHN"; //CHN
                        btnLanguage.Text = "中国人";
                        break;
                    }
                    else
                    {
                        defaultNation = 2;
                        defaultLanguage = "TWN";
                        btnLanguage.Text = "中國人";
                        break;
                    }
                case "日本語":
                    defaultNation = 8;
                    defaultLanguage = "JPN";
                    btnLanguage.Text = "日本語";
                    break;
                case "한국어":
                    defaultNation = 0;
                    defaultLanguage = "KOR";
                    btnLanguage.Text = "한국어";
                    break;
                case "CUSTOM":
                    if (Methods.IsCustomLanguageInstalled())
                    {
                        defaultNation = 3;
                        defaultLanguage = "KAT";
                        btnLanguage.Text = "o ㅅ o";
                        break;
                    }
                    else
                    {
                        defaultNation = 3;
                        defaultLanguage = "ENG";
                        btnLanguage.Text = "English";
                        break;
                    }
                default:
                    defaultNation = 3;
                    defaultLanguage = "ENG";
                    btnLanguage.Text = "English";
                    break;
            }
        }

        Service isZaCardoSV = null;
        public string current_zacardo_version = null;
        bool isZaCardoUpdated = false;
        public void OnTweakTimedEvent_DLCChecking(Object source, ElapsedEventArgs e)
        {
            if (!isLocated)
            {
                isLocated = true;
                checkingTweakDLC.Interval = 1290;

                if (!Methods.IsValidFS2Path(currentGameFolder))
                {
                    UserSettings.GamePath = null;
                    LockPatchInterface();
                    return;
                }

                UnlockPatchInterface();
            }

            if (lockedPathInterface)
                return;

            if (!Methods.IsValidFS2Path(currentGameFolder))
            {
                UserSettings.GamePath = null;
                LockPatchInterface();
                if (isDataGenerated && tabControl1.SelectedTab != tab1)
                    tabControl1_PageChanged(null, null);

                return;
            }

            isTiancityClient = Methods.IsTiancityFS2();

            StuffLang();

            if (checkforuponalltweak)
            {
                checkforuponalltweak = false;
                ClickButtonIfActiveOnTweak();
            }

            if (isDataGenerated)
            {
                if (UniversalSettings._un.Services != null && UniversalSettings._un.Services.Any())
                {                              
                    if (Methods.IsUIInstalled()) //zawa updates
                    {
                        if (takService_card_viewer)
                            return;       

                        string encrypted = File.ReadAllText(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.UIManifest));

                        if (string.IsNullOrEmpty(encrypted))
                            return;

                        var decryptted = KATEncryptor.Decrypt(encrypted, 2);
                        if (decryptted.Split('|').ToArray().Length < 1)
                            return;

                        var version = decryptted.Split('|').First();
                        var id = decryptted.Split('|').Last();

                        isZaCardoSV = UniversalSettings._un.Services.FirstOrDefault(x => x.id == id);
                        if (isZaCardoSV != null)
                        {
                            ZaCardODetected();

                            current_zacardo_version = version;
                            if (Methods.GetInt(current_zacardo_version) != Methods.GetInt(isZaCardoSV.version))
                            {
                                DisplayTweakButtonService(zawaCardo, StringLoader.GetText("btn_tweak_update", isZaCardoSV.name));
                                zawaCardo.isNeedToDownload = true;
                                tab4.Text = "▲ " + StringLoader.GetText("tab4");
                                isZaCardoUpdated = false;
                                return;
                            }
                        }

                        zawaCardo.isNeedToDownload = false;
                        isZaCardoUpdated = true;
                        tab4.Text = StringLoader.GetText("tab4");    
                    }
                    else
                    {
                        if (takService_card_viewer_lock_once_release)
                            return;
                        takService_card_viewer_lock_once_release = true;

                        NotZacarDO();
                    }
                }
            }
        }


        void ZaCardODetected()
        {
            takService_card_viewer = true;
            lbServiceLocker.Visible = false;
            btnSV_ZaWaCardo.Text = "♦ " + isZaCardoSV.name;
            btnSV_CustomPatch.Text = "♦ " + StringLoader.GetText("btn_service_custompatch");
            
            lbServiceDec.Text = StringLoader.GetText("lb_service_help2");
        }

        void NotZacarDO()
        {
            takService_card_viewer = false;
            isZaCardoUpdated = false;
            lbServiceLocker.Visible = true;
            lbServiceDec.Text = StringLoader.GetText("lb_service_help3");

            isTweakLoadingGlassyPanel2 = false;
            ServiceUnlocked(false);
            glassyPanel2.Visible = true;
            SetEnableOneButDisableElseService(disable);
        }

        bool isGameRunning = false;
        bool pingu = false;
        public void OnTimedEvent_isGameRunning(Object source, ElapsedEventArgs e)
        {
            if (!isDataGenerated || lockedPathInterface || whatuseeiswhatuget)
                return;
            
            if (Methods.IsGameRunning())
            {
                isGameRunning = true;
                if (!pingu)
                {
                    pingu = true;
                    if (mute == 0)
                    {
                        mute = 1;
                        playerWelcome.Stop();
                        btn_MusicMute.BackgroundImage = Properties.Resources.icons8_mute_35;
                    }
                    ping.Play();

                    tweakTimer.Enabled = true;
                    checkingTweakDLC.Enabled = false;
                    btnGameSetting.BackColor = System.Drawing.Color.FromArgb(198, 69, 96);       

                    SetPreSymbolForTweakBtn("🔒");
                    TweakReset(StringLoader.GetText("LB_tweaks_applied"), "", false, false, false, true, 6);
                    if (takService_card_viewer)
                    {
                        if (tabControl1.SelectedTab != tab4)
                        {
                            if (!isTweakLoadingGlassyPanel2)
                            {
                                isTweakLoadingGlassyPanel2 = true;
                                ServiceUnlocked(true);
                            }
                        }
                        PNServicesMod(StringLoader.GetText("LB_tweaks_applied"), "", false, true, 6);
                    }

                    if (tabControl1.SelectedTab != tab3)
                    {
                        if (!isTweakLoadingGlassyPanel)
                        {
                            isTweakLoadingGlassyPanel = true;
                            TweakUnlocked(true);
                        }
                    }


                    try
                    {
                        if (CustomJukeboxForm.frmObj.isplaying)
                            CustomJukeboxForm.frmObj.DisableMusic();
                    }
                    catch { }

                    btnKillGame.BackColor = Color.Crimson;
                    contextLauncher.Items[0].Visible = true;
                    contextLauncher.Items[1].Visible = false;
                    contextLauncher.Items[2].Visible = false;
                    contextLauncher.Items[3].Visible = false;


                    ApplyTweak();
                }

                return;
            }

            isGameRunning = false;
            if (pingu)
            {
                pingu = false;
                CloseGame();
            }
        }

        void CloseGame()
        {
            Help_Wait remindDialog = new Help_Wait
            {
                TopMost = true
            };
            remindDialog.ShowDialog(this);
            remindDialog.Dispose();
            checkingTweakDLC.Enabled = true;

            tweakTimer.Enabled = false;

            btnGameSetting.BackColor = ColorEnum.MainColor;

            tempPatch.Clear();
            overrideFont = false;

            skipAnimationPatchLoad = true;
            btnRefreshAvailablePatches_Click(null, null);
            skipAnimationPatchLoad = false;

            btnKillGame.BackColor = ColorEnum.MainColor;
            Logger.Write("Game process has exited");

            var text = SweetSettings._uwu.cutieMessage.Any() 
                ? SweetSettings._uwu.cutieMessage[random.Next(SweetSettings._uwu.cutieMessage.Count)] : StringLoader.GetText("LB_did_you_have_fun");

            PNServicesMod(text, "", false, true, 5);
            TweakReset(text, "", false, false, false, true, 5);
            SetPreSymbolForTweakBtn("🔒");

            contextLauncher.Items[0].Visible = false;
            contextLauncher.Items[1].Visible = true;
            contextLauncher.Items[2].Visible = true;
            contextLauncher.Items[3].Visible = true;

            textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");
        }

        private Random random = new Random();

        private void heartGetEachHourEvent(object sender, ElapsedEventArgs e)
        {
            int randomlove = random.Next(1, 10);
            int love = 0;
            if (isGameRunning)
                love = 1;
            if (randomlove <= 7)
                love+= 1;
            else
                love+= 2;

            loveLetter += love;
            totalLoveLetterCount += love + 1;
            btnLoveLetter.Text = "x" + loveLetter.ToString();
            saveLove();
        }
        
        private readonly int loveletterOffset = 69;

        private void saveLove()
        {
            int random1 = random.Next(2);
            int random2 = random.Next(2);
            int random3 = random.Next(2);
            int random4 = random.Next(2);
            int data1 = loveLetter + loveletterOffset;
            int data2 = HikariLove + loveletterOffset;
            int data3 = YuzukiLove + loveletterOffset;
            int data4 = NakoLove + loveletterOffset;
            int data5 = totalLoveLetterCount + loveletterOffset;
            PatcherSettings.SetValue(PatcherSettings.takatto29022, Methods.GenerateStringWithoutNumber(random1) + data1 
                + Methods.GenerateStringWithoutNumber(random2) + "|" + Methods.GenerateStringWithoutNumber(random3) 
                + data2 + Methods.GenerateStringWithoutNumber(random1) + "|" + Methods.GenerateStringWithoutNumber(random4) 
                + data3 + Methods.GenerateStringWithoutNumber(random2) + "|" + Methods.GenerateStringWithoutNumber(random3) + data4 
                + Methods.GenerateStringWithoutNumber(random4) + "|" + Methods.GenerateStringWithoutNumber(random1) + data5 
                + Methods.GenerateStringWithoutNumber(random4) + "|" + isLovedHikari.ToString() + "|" + isLovedYuzuki.ToString() 
                + "|" + isLovedNako.ToString() + "|I don't want to set|The world|on|fire|23783|34" + loveLetter 
                + currentGameFolder + "|" + totalLoveLetterCount + "|not a rick roll|" + "uwu" + "|" + defaultLanguage + "|" + Environment.UserName);
        }


        bool isSongLoading = false;
        public void OnTweakTimedEvent_loadPatches(Object source, ElapsedEventArgs e)
        {
            loadPatches.Enabled = false;
            //Thread.Sleep(100);
            btnRefreshAvailablePatches_Click(null, null);
        }

        bool isPatchListLoading = false;
        private static NobodyLoveYou PATCHES = NobodyLoveYou.PATCHESInstance;

        private async void LoadPatchesListAsync()
        {
            string downloadUrl = string.IsNullOrWhiteSpace(tbPatchURI.Text) ? UniversalSettings._un.PatchRootUri : tbPatchURI.Text;

            try
            {
                //WebClient wc = new WebClient();
                //string patchlist = wc.DownloadString(downloadUrl);
                var htmlData = await wc.DownloadDataTaskAsync(downloadUrl);
                string patchlist = Encoding.UTF8.GetString(htmlData);
                PATCHES = JsonConvert.DeserializeObject<NobodyLoveYou>(patchlist);

                //UniversalSettings._un.Patches = nobodyLoveYou.Patches;
                //nobodyLoveYou = null;

                lbPatches.Items.Clear();

                if (!string.IsNullOrWhiteSpace(PATCHES.GithubId))
                    toolTip1.SetToolTip(pbRepo, PATCHES.GithubId.Trim());

                lbRepo.Text = StringLoader.GetText("lb_repo", PATCHES.ServerName);

                lbRepo.ForeColor = Color.FromArgb(64, 64, 64);//FromArgb(53, 92, 204);

                foreach (var item in PATCHES.Patches)
                    if (!string.IsNullOrEmpty(" " + item.name))
                    {
                        lbPatches.Items.Add(" " + item.name);
                    }

                isPatchListLoading = false;
            }
            catch
            {
                if (!failedListPatches)
                    failedListPatches = true;

                lbRepo.Text = StringLoader.GetText("lb_repo", "null");
                lbRepo.ForeColor = Color.Teal;
                lbPatches.Items.Clear();
                isPatchListLoading = false;
                tbPatchURI.Text = "";
                tbPatchURI.setPlaceholder(null, null);
                return;
            }

            try
            {
                pbRepo.LoadAsync(@"https://avatars.githubusercontent.com/" + (!string.IsNullOrWhiteSpace(PATCHES.GithubId) ? PATCHES.GithubId.Trim() : "github"));
            } catch { }
        }

        public void ClosingTimer(Object source, ElapsedEventArgs e)
        {
            //Process.GetCurrentProcess().Kill();

            try
            {
                fs_patch.Close();
                File.Delete(Path.Combine(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData), Strings.KattoFileName.TakattoLock));
            }
            catch { }
            Environment.Exit(0);
        }

        void CloseForm(bool showClosingWindows)
        {
            if (WindowState == FormWindowState.Normal)
                UserSettings.WindowsLocation = Location.ToString();
            else
                UserSettings.WindowsLocation = RestoreBounds.Location.ToString();

            Hide();
            patcherClosingTimer.Enabled = true;
            notifyIcon.Visible = false;        

            if (showClosingWindows)
            {
                ConnectingForm_New closingFormw = new ConnectingForm_New("close");
                closingFormw.Show(this);
            }
        }

        public bool isEmergencyExit = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isEmergencyExit)
            {
                tabControl1.Focus();
                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    CloseForm(true);
                    return;
                }

                DialogResult confirmResult;
                if (isExitFromContext)
                    confirmResult = MsgBoxs.Dialog.ClosePatcher(this, isExitFromContext = false);
                else
                    confirmResult = MsgBoxs.Dialog.ClosePatcher(this, true);

                if (confirmResult == DialogResult.Yes) { e.Cancel = true; }
                else
                {
                    e.Cancel = true;
                    return;
                }

                if (CourtMap >= 1 || (isZaCardoUpdated && UserSettings.UITweakSetting) || (Methods.IsJukeBoxDLCinstalled() && UserSettings.JukeboxTweakSetting)
                    || UserSettings.CharVoiceLanguage >= 1 || UserSettings.MCVoiceLanguage >= 1)
                {
                    if (Methods.AlertIfGameIsRunning(this))
                        return;
                }

                CloseForm(true);
            }
        }

        private void OnTweakTimedEvent_hideHint(object sender, ElapsedEventArgs e)
        {
            hideHint.Enabled = false;
            if(customMap.isSomething)
                lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help");
        }

        public void InstallDLC5()
        {
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (string.IsNullOrEmpty(UniversalSettings._un.DLC5InstallationCode))
            {
                MsgBoxs.Warning.IncorrectParametter(this);
                return;

            }

            TweakReset(StringLoader.GetText("LB_select_a_tweak"), "", false, false, false, false, 0);
            textBoxButWithEasterEgg.Text = KATEncryptor.Decrypt(UniversalSettings._un.DLC5InstallationCode, 3);
            textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");
        }

        private void install_dlc5_Click(object sender, EventArgs e)
        {
            InstallDLC5();
        }

        private void UpdateZawacardo(object sender, EventArgs e)
        {
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (!Methods.IsUIInstalled())
            {
                MsgBoxs.Warning.IncorrectParametter(this);
                return;
            }

            if (isZaCardoSV != null)
            {
                textBoxButWithEasterEgg.Text = isZaCardoSV.id;
                textBoxButWithEasterEgg.Text = StringLoader.GetText("text_about");
                tabControl1.SelectedTab = tab5;
            }
            else
                MsgBoxs.Warning.IncorrectParametter(this);
        }

        public void InstallDLC6()
        {
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            TweakReset(StringLoader.GetText("LB_select_a_tweak"), "", false, false, false, false, 0);
            isSTDPatchDownloading = true; //disable using temp patch
            isTweakDownloading = true;
            string patchname = "takatto_tweak_dlc6";
            string tempDLCname = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, $"{patchname}.dat");

            DownloadFile(Urls.DLC6, tempDLCname, currentGameFolder);      
        }

        private void installdlc6_Click(object sender, EventArgs e)
        {
            InstallDLC6();
        }

        public void CourtDownload(string uri)
        {
            isTweakDownloading = true;
            DownloadFile(uri, new Uri(uri).Segments.Last(), currentGameFolder);
        }

        private void btn_langchange_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (isGameRunning)
                return;

            LanguageForm gameLanguageChangeFormup = new LanguageForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            gameLanguageChangeFormup.ShowDialog(this);
            gameLanguageChangeFormup.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (isGameRunning)
            {
                MsgBoxs.Warning.CloseGameFirst(this);
                return;
            }

            InstallerForm patcherRepair = new InstallerForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            patcherRepair.ShowDialog(this);
            patcherRepair.Dispose();
        }

        void CardViewTweak()
        {
            Methods.Tweaks.CardViewTweak(UserSettings.CustomTexture);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                if (!isMinimized && !isTweakDownloading && !isDLCServiceDownloading && !isImportDownloading && isGameRunning)
                    hideMeNibba();
        }

        bool isMinimized = false;

        internal void pingMeNibba()
        {
            if (isMinimized)
            {
                WindowState = FormWindowState.Minimized;
                Show();
            }

            TopMost = true;
            WindowState = FormWindowState.Normal;

            notifyIcon.Visible = true;
            isMinimized = false;
            TopMost = false;
            contextNotifyIcon.Items[2].Visible = false;
            contextNotifyIcon.Items[3].Visible = true;
        }

        int numbaPetted = 0;
        private void cat1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            numbaPetted++;
            if (mute == 0 || numbaPetted > 50 && numbaPetted < 60)
                return;

            cat.Play();

            if (numbaPetted == 50)
                nyannyan.Play();
        }

        internal void InstallJukebox()
        {
            ActiveControl = null;
            if (Methods.AlertIfFS2FolderIsMissing(this))
                return;

            TweakReset(StringLoader.GetText("LB_select_a_tweak"), "", false, false, false, false, 0);
            isTweakDownloading = true;

            string patchname = "takatto_tweak_dlc3";
            string tempDLCname = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, $"{patchname}.dat");

            DownloadFile(Urls.DLC3, tempDLCname, currentGameFolder);
        }
       
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            SettingsForm settengs = new SettingsForm();
            settengs.ShowDialog(this);

            settengs.Dispose();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isMinimized)
                pingMeNibba();
            else if (!isMinimized && !isTweakDownloading && !isDLCServiceDownloading && !isImportDownloading)
                hideMeNibba();
        }

        private void btnAskNako_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Help help = new Help();
            help.ShowDialog(this);
            help.Dispose();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pingMeNibba();
        }

        bool isExitFromContext = false;
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isExitFromContext = true;
            Close();
        }

        private async void hideMeNibba()
        {
            WindowState = FormWindowState.Minimized;
            await Task.Delay(100);
            Hide();
            isMinimized = true;
            contextNotifyIcon.Items[2].Visible = true;
            contextNotifyIcon.Items[3].Visible = false;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isMinimized && !isTweakDownloading && !isDLCServiceDownloading && !isImportDownloading)
                hideMeNibba();
        }

        bool isTranslating = false;

        private void animatingTimer_Tick(object sender, EventArgs e)
        {
            if (isOpenningRepo)
            {
                if (!isOpenningRepoOpenned)
                {
                    pnRepo.Height += 5;
                    if (pnRepo.Height >= tbPatchURI.Height + 1)
                    {
                        pnRepo.Height = tbPatchURI.Height + 1;

                        isOpenningRepo = false;
                        isOpenningRepoOpenned = true;

                        ActiveControl = tbPatchURI;
                        tbPatchURI.SelectionStart = tbPatchURI.Text.Length;
                        tbPatchURI.SelectionLength = 0;
                        
                        if(!isTranslating)
                            animatingTimer.Enabled = false;
                    }
                }
                else if (isOpenningRepoOpenned)
                {
                    pnRepo.Height -= 5;
                    if (pnRepo.Height <= 0)
                    {
                        pnRepo.Height = 0;
                        isOpenningRepo = false;
                        isOpenningRepoOpenned = false;

                        if (!isTranslating)
                            animatingTimer.Enabled = false;
                    }
                }
            }

            if (isTranslating)
            {
                if (!isTranslatecomboboxOpenned)
                {
                    pnTranslateC.BringToFront();
                    cbTranslation.Width += btnTranslate.Width;
                    if (cbTranslation.Width >= pnTranslateC.Width)
                    {
                        cbTranslation.Width = pnTranslateC.Width;
                        isTranslatecomboboxOpenned = true;
                        isTranslating = false;

                        if (!isOpenningRepo)
                            animatingTimer.Enabled = false;
                    }
                }
                else if (isTranslatecomboboxOpenned)
                {
                    cbTranslation.Width = cbTranslation.Width -= btnTranslate.Width;
                    if (cbTranslation.Width <= 0)
                    {
                        cbTranslation.Width = 0;
                        isTranslatecomboboxOpenned = false;
                        pnTranslateC.SendToBack();
                        isTranslating = false;

                        if (!isOpenningRepo)
                            animatingTimer.Enabled = false;
                    }
                }
            }
        }

        bool overrideFont = false;

        private void loadARandomMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSongLoading)
                return;

            if (mute == 0)
            {
                mute = 1;
                playerWelcome.Stop();
            }
            isClickedMusicBtn = true;
            isSongLoaded = false;
            LoadMusicAsync();
            //loadMusic.Enabled = true;
        }

        private void btn_gamesetting_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (isGameRunning)
            {
                ResizeForm resizeForm = new ResizeForm();
                resizeForm.ShowDialog(this);
                resizeForm.Dispose();
            }
        }

        bool isPnHideDocked = false;
        private void lbHeart_Click(object sender, EventArgs e)
        {
            isPnHideDocked = true;
            pnHideButtons.Visible = true;
            pnHi.BackgroundImage = null;
        }

        private void pnHideButtons_Click(object sender, EventArgs e)
        {
            isPnHideDocked = false;
            pnHideButtons.Visible = false;
            pnHi.BackgroundImage = Properties.Resources.back_wc_transparent_darker;
        }

        public int autoTaske = 0;
        public bool autoTaskRepeat = false;
        public int autoTaskmin = 60;

        internal GlobalHotkey CtrlV;
        internal void ShortcutEnabler()
        {
            if (UserSettings.Shortcut)
            {
                CtrlV = new GlobalHotkey(Constants.CTRL + Constants.SHIFT, Keys.V, this);
                CtrlV.Register();
                return;
            }

            try
            {
                CtrlV = null;
                CtrlV.Unregiser();
            } 
            catch { }
        }

        private GlobalHotkey ghk;
        internal void AutoTaskCheck(int task, int min, bool isautotaskrpeat)
        {
            autoTaske = task;
            autoTaskmin = min;
            autoTaskRepeat = isautotaskrpeat;
            isAutoTaskRunning = true;
            var id = Guid.NewGuid();
            currentTask = id;
            CreateTask(id);
            autoTask.isApplied = true;
            PNTweaksMod(StringLoader.GetText("LB_task_running"), StringLoader.GetText("btn_tweak_task_cancel_running_task"), true, false, false, true, 4);
            ghk = new GlobalHotkey(Constants.NOMOD, Keys.F4, this);
            ghk.Register();
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                switch (GetKey(m.LParam))
                {
                    case Keys.F4:
                        HandleHotkeyF4();
                        break;
                    case Keys.V:
                        HandleHotkeyCtrlV();
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        private void HandleHotkeyCtrlV()
        {
            if (!UserSettings.AKFTweakSetting)
                hWnd = Methods.ProcessHandler();

            if (hWnd != (IntPtr)null)
            {
                NativeMethods.SetForegroundWindow(hWnd);
                if (!string.IsNullOrEmpty(Clipboard.GetText().ToString()))
                {
                    try
                    {
                        SendKeys.SendWait(Clipboard.GetText().ToString());
                    }
                    catch { }
                }
            }
        }

        private async void HandleHotkeyF4()
        {
            if (isAutoTaskRunning)
            {
                ghk.Unregiser();
                pingMeNibba();
                if (tweakPanelTimer.Enabled)
                    await Task.Delay(500);

                isAutoTaskRunning = false;
                currentTask = Guid.NewGuid();
                autoTask.isApplied = false;
                if(autoTask.isSomething)
                {
                    DisplayTweakButton(autoTask, StringLoader.GetText("btn_tweak_task_start"));
                    btnSV_Task_Click(null, null);
                }
            }
        }

        Guid currentTask;

        private List<TaskTimer> _taskTimers = new List<TaskTimer>();
        public void CreateTask(Guid _id)
        {
            TaskTimer taskTimer = new TaskTimer
            {
                taskID = _id,
                Interval = autoTaskmin * 1000
            };
            taskTimer.Elapsed += new ElapsedEventHandler(OnTweakTimedEvent_autoTask);
            taskTimer.Enabled = true;
            _taskTimers.Add(taskTimer);
        }

        private void autoTaskcb_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (isAutoTaskRunning)
            {
                var confirmResult = MsgBoxs.Dialog.CancelTask(this);
                if (confirmResult == DialogResult.Yes)
                {
                    isAutoTaskRunning = false;
                    currentTask = Guid.NewGuid();
                }
            }
        }

        private void newsbtn_Click(object sender, EventArgs e)
        {
            News(null, true, false);
        }

        private void btnServiceRequest_Click(object sender, EventArgs e)
        {
            News("index_service_news", true, false);
        }

        private void sweetletter_newsbtn_Click(object sender, EventArgs e)
        {
            News("index_sweet_letter_news", true, false);
        }

        private void tbGameDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                if (e.KeyChar != 'V' || e.KeyChar != 'C')
                    e.Handled = false;
                else
                    e.Handled = true;
            else
                e.Handled = true;
        }

        private void btnSwLock_Click(object sender, EventArgs e)
        {
            isSweetLocked = !isSweetLocked;
            if (isSweetLocked)
                btnSwLock.BackgroundImage = Properties.Resources.icons8_heart_plus_35;
            else
                btnSwLock.BackgroundImage = Properties.Resources.icons8_heart_share_35;
        }

        private void textBoxButWithEasterEgg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lockedPathInterface || whatuseeiswhatuget)
                e.Handled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InstallDLC5();
        }

        int secondCount = 0;
        private void glassyTimer1_Tick(object sender, EventArgs e)
        {
            if (secondCount == 0)
            {
                //tweakCheckForUpdate_zacardo.Enabled = true;
            }
            secondCount++;
            if (secondCount >= 2)
            {
                TweakUnlocked(true);
                glassyTimer1.Enabled = false;
            }
        }

        void TweakUnlocked(bool _value)
        {
            glassyPanel1.Visible = !_value;
            secondCount = 0;
            btnSV_CharVoice.TabStop = _value;
            btnSV_JukeBox.TabStop = _value;
            btnSV_Map.TabStop = _value;
            btnSV_MCVoice.TabStop = _value;
            btnSV_Misc.TabStop = _value;
            btnSV_Task.TabStop = _value;
            btnSV_Texture.TabStop = _value;
        }

        void ServiceUnlocked(bool _value)
        {
            glassyPanel2.Visible = !_value;
            secondCount2 = 0;
            btnSV_ZaWaCardo.TabStop = _value;
            btnSV_CustomPatch.TabStop = _value;
        }

        int secondCount2 = 0;
        private void glassyTimer2_Tick(object sender, EventArgs e)
        {
            if (secondCount2 == 0)
            {
                //tweakCheckForUpdate_zacardo.Enabled = true;
            }
            secondCount2++;
            if (secondCount2 >= 2)
            {
                if (takService_card_viewer)
                {
                    ServiceUnlocked(true);
                    glassyTimer2.Enabled = false;
                }
                if (secondCount2 >= 60)
                {
                    secondCount2 = 0;
                    glassyTimer2.Enabled = false;
                }
            }
        }

        int checkBugCount = 0;
        private void checkForBugOnTabPage_Tick(object sender, EventArgs e)
        {
            checkBugCount++;
            if (tab5.Height >= tabControl1.Height - (TitleLabel.Height / 6) * 2 || tab4.Height >= tabControl1.Height - (TitleLabel.Height / 6) * 2 || tab3.Height >= tabControl1.Height - (TitleLabel.Height / 6) * 2 || tab2.Height >= tabControl1.Height - (TitleLabel.Height / 6) * 2 || tab1.Height >= tabControl1.Height - (TitleLabel.Height / 6) * 2)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                Show();
                TopMost = true;
                WindowState = FormWindowState.Normal;
                TopMost = false;
                checkForBugOnTabPage.Enabled = false;
            }
            if (checkBugCount > 4)
            {
                checkBugCount = 0;
                checkForBugOnTabPage.Enabled = false;
            }
        }

        private async void tabControl1_PageChanged(object sender, Manina.Windows.Forms.PageChangedEventArgs e)
        {
            //(sender as TabControl).SelectedTab.Focus();
            //save last tab
            var tab = tabControl1.SelectedTab;
            UserSettings.PatchLastTab = tab.Text;

            if (checkBugCount == 0)
            {
                checkBugCount = 1;
                checkForBugOnTabPage.Enabled = true;
            }

            if (tab == tab2)
            {
                if (pn404.Visible)
                {
                    if (!lbRepo.Text.ToUpper().Contains(StringLoader.GetText("lb_repo", "null").ToUpper()))
                    {
                        btnRefreshAvailablePatches_Click(null, null);
                    }
                }

                if (!firstTimeLoadPatches)
                {
                    firstTimeLoadPatches = true;
                    loadPatches.Enabled = true;
                }

                if (lbPatches.SelectedIndex != -1)
                    lbPatches_SelectedIndexChanged(null, null);
            }
            else
            {
                if (currentFrame > 0 && currentFrame <= 54)
                {
                    currentFrame = 69;
                    lbPatches.Visible = true;
                    await Task.Delay(729);
                    catPatchLoadTimer.Enabled = true;
                }
                if (!isOpenningRepo && isOpenningRepoOpenned)
                {
                    pnRepo.Height = 0;
                    isOpenningRepo = false;
                    isOpenningRepoOpenned = false;
                }
                if (isTranslatecomboboxOpenned)
                {
                    isTranslatecomboboxOpenned = false;
                    cbTranslation.Width = 0;
                    pnTranslateC.SendToBack();
                }
            }

            if (tab != tab1)
            {
                tab1.BackColor = Color.White;
            }


            if (tab == tab4)
            {
                if (!isTweakLoadingGlassyPanel2)
                {
                    isTweakLoadingGlassyPanel2 = true;
                    glassyTimer2.Enabled = true;
                }
            }

            if (tab == tab3)
            {
                if (!isTweakLoadingGlassyPanel)
                {
                    isTweakLoadingGlassyPanel = true;
                    glassyTimer1.Enabled = true;
                }

                if (!firstTimeLoadTweaks)
                {
                    firstTimeLoadTweaks = true;
                    if (NakoLove >= 100)
                    {
                        lbTweaksInfo.Text = StringLoader.GetText("lb_tweak_thankie");
                        btnSV_Texture.Visible = true;
                        lbTweaksInfo.ForeColor = Color.FromArgb(78, 109, 156);
                        animatingTimer.Enabled = true;
                        return;
                    }
                }
            }

            if (tab == tab1)
            {
                if (isCha || isSweetLocked)
                {
                    setTabBckground();
                    return;
                }


                //loadMusic.Enabled = true;
                int randomLessThan100 = random.Next(100);
                if (HikariLove >= 100 && YuzukiLove >= 100)
                {
                    if (isYuzuki)
                    {
                        if (randomLessThan100 <= 50)
                        {
                            setHikari();
                            if (randomLessThan100 < 15)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                        else
                        {
                            setNako();
                            if (randomLessThan100 > 85)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                    }
                    else if (isHikari)
                    {
                        if (randomLessThan100 <= 50)
                        {
                            setYuzuki();
                            if (randomLessThan100 < 15)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                        else
                        {
                            setNako();
                            if (randomLessThan100 > 85)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                    }
                    else if (isNako)
                    {
                        if (randomLessThan100 <= 50)
                        {
                            setHikari();
                            if (randomLessThan100 < 15)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                        else
                        {
                            setYuzuki();
                            if (randomLessThan100 > 85)
                                if (!isPnHideDocked)
                                    balooonDelay.Enabled = true;
                        }
                    }
                }

                else
                {
                    if (isYuzuki)
                    {
                        setHikari();
                        if (randomLessThan100 <= 25)
                            if (!isPnHideDocked)
                                balooonDelay.Enabled = true;
                    }
                    else if (isHikari)
                    {
                        setYuzuki();
                        if (randomLessThan100 > 75)
                            if (!isPnHideDocked)
                                balooonDelay.Enabled = true;
                    }
                }
                SetChar();
            }
        }

        void setTabBckground()
        {
            if (SweetSettings._uwu.isServerSideEnabled)
            {
                if (isHikari)
                {
                    if (SweetSettings._uwu.Hikari.isEnabled)
                    {
                        try
                        {
                            var color = System.Drawing.ColorTranslator.FromHtml(SweetSettings._uwu.Hikari.dominantColor);
                            tab1.BackColor = color;
                        }
                        catch { }
                    }
                    else
                        tab1.BackColor = Color.FromArgb(251, 250, 250);
                }
                else if (isYuzuki)
                {
                    if (SweetSettings._uwu.Yuzuki.isEnabled)
                    {
                        try
                        {
                            var color = System.Drawing.ColorTranslator.FromHtml(SweetSettings._uwu.Yuzuki.dominantColor);
                            tab1.BackColor = color;
                        }
                        catch { }
                    }
                    else
                        tab1.BackColor = Color.FromArgb(251, 250, 250);
                }
                else if (isNako)
                {
                    if (SweetSettings._uwu.Nako.isEnabled)
                    {
                        try
                        {
                            var color = System.Drawing.ColorTranslator.FromHtml(SweetSettings._uwu.Nako.dominantColor);
                            tab1.BackColor = color;
                        }
                        catch { }
                    }
                    else
                        tab1.BackColor = Color.FromArgb(255, 235, 239);
                }
            }
            else
            {
                if (isHikari)
                    tab1.BackColor = Color.FromArgb(251, 250, 250);
                else if (isYuzuki)
                    tab1.BackColor = Color.FromArgb(251, 250, 250);
                else if (isNako)
                    tab1.BackColor = Color.FromArgb(255, 235, 239);
            }
            //tab1.PerformLayout();
        }

        class Language
        {
            private string Name { get; set; }
            public string Value { get; set; }
            public Language(string text, string value)
            {
                if (text.Length > 1)
                    text = text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
                Name = text;
                Value = value;
            }
            public override string ToString() { return Name; }
        }

        public static void PopulateComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add(new Language("Default", "default"));
            comboBox.Items.Add(new Language("翻译成中文", "zh-CN"));
            comboBox.Items.Add(new Language("翻譯成中文", "zh-TW"));
            comboBox.Items.Add(new Language("日本語に翻訳", "ja"));
            comboBox.Items.Add(new Language("한국어로 번역", "ko"));
            comboBox.Items.Add(new Language("Isalin sa Filipino", "fil"));
            comboBox.Items.Add(new Language("Kääntää suomeksi", "fi"));
            comboBox.Items.Add(new Language("Vers le français", "fr"));
            comboBox.Items.Add(new Language("Auf Deutsch", "de"));
            comboBox.Items.Add(new Language("Ke Indonesia", "id"));
            comboBox.Items.Add(new Language("In italiano", "it"));
            comboBox.Items.Add(new Language("Zaatakuj Polskę", "pl"));
            comboBox.Items.Add(new Language("На русский", "ru"));
            comboBox.Items.Add(new Language("Al español", "es"));
            comboBox.Items.Add(new Language("Till svenska", "sv"));
            comboBox.Items.Add(new Language("แปลเป็นไทย", "th"));
            comboBox.Items.Add(new Language("Türkçeye çevir", "tr"));
            comboBox.Items.Add(new Language("Sang tiếng Việt", "vi"));

            comboBox.SelectedIndex = comboBox.FindStringExact("Default");
        }

        public async void TranslateTextAsync(string languageCode, string _desc, string _note)
        {
            string input = _desc + " $ " + _note;
            string translation = "";
            string url = String.Format(Urls.GoogleTranslateApi, languageCode, Uri.EscapeUriString(input));

            if (languageCode != "default")
            {
                try
                {
                    WebClient client = new WebClient
                    {
                        Proxy = null,
                        Encoding = Encoding.UTF8
                    };
                    string downloadString = await @client.DownloadStringTaskAsync(url);

                    var jsonData = JsonConvert.DeserializeObject<List<dynamic>>(downloadString);

                    var translationItems = jsonData[0];
                    foreach (object item in translationItems)
                    {
                        IEnumerable translationLineObject = item as IEnumerable;
                        IEnumerator translationLineString = translationLineObject.GetEnumerator();
                        translationLineString.MoveNext();
                        translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
                    }
                    if (translation.Length > 1) { translation = translation.Substring(1); };


                }
                catch (Exception e)
                {
                    lbPatchDescription.Text = StringLoader.GetText("lb_patch_error_api_failed");
                    lbPatchNote.Text = ("[" + e.Message + "]").Replace(".]", "]");
                    return;
                }
            }
            else
                translation = input;

            try
            {

                lbPatchDescription.Text = translation.Split('$')[0].Trim();
                lbPatchNote.Text = translation.Split('$')[1].Trim();
            }
            catch { }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try { Process.Start(UserSettings.PatcherPath); } catch { }
        }

        private void balooon_Tick(object sender, EventArgs e)
        {
            lbBaloon.Text = message.Substring(0, letterCount++);
            if (skipthru)
            {
                letterCount = message.Length;
                skipthru = false;
                lbBaloon.Text = message;
                balooon.Enabled = false;
                balooonClose.Enabled = true;
            }
            else if (letterCount > message.Length - 1) // stop the timer once the message finishes to avoid getting an error
            {
                //letterCount = 0;
                balooon.Enabled = false; // use this to stop after once
                lbBaloon.Text = message;
                balooonClose.Enabled = true;
            }
        }

        private void balooonClose_Tick(object sender, EventArgs e)
        {
            balomCount++;
            if (balomCount == 3)
            {
                balomCount = 0; isCha = false;
                balooonClose.Enabled = false;
                //pnLaboon.Height = 0;
                pnLaboon.SendToBack();
                if (isGivingLoveLetter)
                {
                    isGivingLoveLettered = true;
                    heartAnimation.Enabled = true;

                    if (isAccepted)
                    {
                        if (YuzukiLove >= 100 && HikariLove >= 100 && NakoLove >= 100)
                        {
                            if (YuzukiLove >= 999 || HikariLove >= 999 || NakoLove >= 999)
                                lbAddOne.Text = "full!";
                            else
                                lbAddOne.Text = "+1";

                            lbAddOne.ForeColor = Color.FromArgb(230, 60, 60);
                        }
                        else if (isHikari)
                        {
                            if (HikariLove < 100)
                                lbAddOne.Text = "+1";
                            else //if (HikariLove >= 100 && NakoLove < 100)
                                lbAddOne.Text = "full!";

                            lbAddOne.ForeColor = Color.Crimson;
                        }
                        else if (isYuzuki)
                        {
                            if (YuzukiLove < 100)
                                lbAddOne.Text = "+1";
                            else //if (YuzukiLove >= 100 && NakoLove < 10)
                                lbAddOne.Text = "full!";

                            lbAddOne.ForeColor = Color.Crimson;
                        }
                        else if (isNako)
                        {
                            lbAddOne.Text = "+1";
                            lbAddOne.ForeColor = Color.Crimson;
                        }
                        //else if (isNako && NakoLove >= 100 && NakoLove < 100)
                        //{
                        //    lbAddOne.Text = "full!";
                        //    lbAddOne.ForeColor = Color.Crimson;
                        //}
                    }
                    else
                    {
                        lbAddOne.Text = "+0";
                        lbAddOne.ForeColor = Color.FromArgb(64, 64, 64);
                    }
                }
                else
                {
                    isGivingLoveLettered = false;
                    EmptyLove.BringToFront();
                    skipthru = false;

                    if (isWelcome)
                    {
                        isWelcome = false;
                        if (isNako)
                            setGirlStateNako(0);
                        else if (isHikari)
                            setGirlStateHikari(0);
                        else if (isYuzuki)
                            setGirlStateYuzuki(0);
                    }
                }
            }
        }

        async void Anhong()
        {
            await Task.Run(() => {
                if (isNako)
                    anhongNako.PlaySync();
                else if (isYuzuki)
                    anhongYuzuki.PlaySync();
                else
                    anhong.PlaySync();
            });

            if ((UserSettings.PatcherMusicSetting && mute == 1)
                || (UniversalSettings._un.isMusicListEventEnabled && UniversalSettings._un.MusicListEvent.Any() && mute == 1))
            {
                isClickedMusicBtn = true;
                LoadMusicAsync();
            }

            try
            {
                anhong.Dispose();
                anhongNako.Dispose();
                anhongYuzuki.Dispose();
            }
            catch { }
        }

        bool isWelcome = true;
        private void balooonDelay_Tick(object sender, EventArgs e)
        {
            balooonDelay.Enabled = false;

            if (!txtAboutBackupbutOnce)
            {
                txtAboutBackupbutOnce = true;
                Anhong();

                SetChar();

                lbBaloon.Text = "";
                isCha = true;
                //pnLaboon.Visible = true;
                if (isCheated)
                {
                    btnLoveLetter.Text = "x" + loveLetter.ToString();
                    if (isNako)
                    {
                        message = StringLoader.GetText("chat_nako_cheat_detected", PatcherSettings.nakoName);
                        setNako(); setGirlStateNako(2);
                    }
                    else if (isHikari)
                    {
                        message = StringLoader.GetText("chat_hikari_cheat_detected", PatcherSettings.hikariName);
                        setHikari(); setGirlStateHikari(2);
                    }
                    else if (isYuzuki)
                    {
                        message = PatcherSettings.yuzukiName + " " + KATEncryptor.Encrypt("love you and hate you.",1);
                        setYuzuki(); setGirlStateYuzuki(2);
                    }
                }
                else if (isDataCorrupted)
                {
                    if (isNako)
                    {
                        message = StringLoader.GetText("chat_nako_corrupt_data_fixed", PatcherSettings.nakoName);
                        setNako(); setGirlStateNako(1);
                    }
                    else if (isHikari)
                    {
                        message = StringLoader.GetText("chat_hikari_corrupt_data_fixed", PatcherSettings.nakoName);
                        setHikari(); setGirlStateHikari(1);
                    }
                    else if (isYuzuki)
                    {
                        message = PatcherSettings.yuzukiName + " " + KATEncryptor.Encrypt("has fixed the corrupted data for chu!",1);
                        setYuzuki(); setGirlStateYuzuki(1);
                    }
                }
                else
                {
                    if (isNako)
                    {
                        setGirlStateNako(1);
                        int indexRant = random.Next(PatcherSettings.msgStrNakoWelcome.Length);
                        message = PatcherSettings.msgStrNakoWelcome[indexRant];
                    }
                    else if (isHikari)
                    {
                        setGirlStateHikari(1);
                        int indexRant = random.Next(PatcherSettings.msgStrHikariWelcome.Length);
                        message = PatcherSettings.msgStrHikariWelcome[indexRant];
                    }
                    else if (isYuzuki)
                    {
                        setGirlStateYuzuki(2);
                        int indexRant = random.Next(PatcherSettings.msgStrHikariWelcome.Length);
                        message = KATEncryptor.Encrypt(PatcherSettings.msgStrHikariWelcome[indexRant],1);
                    }
                }

                //pnLaboon.Height = lbBaloonHeight; 
                pnLaboon.BringToFront();
                balooon.Enabled = true;
                Enable_LogCleaner();
                loadSecretKeys();
                return;
            }

            pnHi_Click(sender, new EventArgs());
        }

        void setGirlStateHikari(int _state)
        {
            if (!setSweetImageFromFolder(SweetSettings._uwu.Hikari, _state))
            {
                switch (_state)
                {
                    case 0:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc2;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 1:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc2_happi;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 2:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc2_angery;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    default:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc2;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                }
            }
        }

        void setGirlStateYuzuki(int _state)
        {
            if (!setSweetImageFromFolder(SweetSettings._uwu.Yuzuki, _state))
            {
                switch (_state)
                {
                    case 0:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc1;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 1:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc1_happi;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 2:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc1_angery;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    default:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc1;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                }
            }
        }

        void setGirlStateNako(int _state)
        {
            if (!setSweetImageFromFolder(SweetSettings._uwu.Nako, _state))
            {
                switch (_state)
                {
                    case 0:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc3;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 1:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc3;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case 2:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc3;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    default:
                        pnSweet.BackgroundImage.Dispose();
                        pnSweet.BackgroundImage = Properties.Resources.back_wc3;
                        pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                }
            }
        }

        private void heartAnimation_Tick(object sender, EventArgs e)
        {
            if (countY <= 5)
            {
                countY++;
                pnHeartX += pnHeart.Width / 8;
                lbAddOne.Location = new Point(pnHeartX, lbAddOne.Location.Y);
            }
            else if (countY > 5 && countY <= 10)
            {
                countY++;
                pnHeartX++;
                lbAddOne.Location = new Point(pnHeartX, lbAddOne.Location.Y);
            }
            else if (countY > 10 && countY <= 15)
            {
                countY++;
                EmptyLove.BringToFront();
                //loveStatusAngry.Height = 0;
                //loveStatusLoved.Height = 0;
            }
            else if (countY > 15)
            {
                //totalLoveLetterCount++;
                isGivingLoveLetter = false;
                heartAnimation.Enabled = false; isGivingLoveLettered = false;
                countY = 0;
                lbAddOne.Text = "";
                pnHeartX = pnHeartXdef;
                if (isAccepted)
                {
                    if (isHikari)
                    {
                        if ((HikariLove < 100 && NakoLove < 100) || (HikariLove >= 100 && NakoLove >= 100))
                            HikariLove++;

                        lbHeart.Text = HikariLove.ToString() + "%";
                        if (HikariLove >= 100)// && !isLovedHikari)
                        {
                            if (!isLovedHikari)
                            {
                                HikariLove = 100;
                                pnHi_Click(sender, new EventArgs());
                            }
                            if (HikariLove >= 999)
                                HikariLove = 999;
                        }


                        setGirlStateHikari(0);

                    }
                    else if (isYuzuki)
                    {
                        if ((YuzukiLove < 100 && NakoLove < 100) || (YuzukiLove >= 100 && NakoLove >= 100))
                            YuzukiLove++;
                        lbHeart.Text = YuzukiLove.ToString() + "%";

                        if (YuzukiLove >= 100)// && !isLovedYuzuki)
                        {
                            if (!isLovedYuzuki)
                            {
                                YuzukiLove = 100;
                                pnHi_Click(sender, new EventArgs());
                            }
                            if (YuzukiLove >= 999)
                                YuzukiLove = 999;
                        }

                        setGirlStateYuzuki(0);
                    }
                    else if (isNako)
                    {
                        NakoLove++;
                        lbHeart.Text = NakoLove.ToString() + "%";

                        if (NakoLove >= 100)// && !isLovedNako)
                        {
                            if (!isLovedNako)
                            {
                                NakoLove = 100;
                                pnHi_Click(sender, new EventArgs());
                            }
                            if (NakoLove >= 999)
                                NakoLove = 999;
                        }

                        setGirlStateNako(0);
                    }
                }
                else
                {
                    if (isHikari)
                        setGirlStateHikari(0);
                    if (isYuzuki)
                        setGirlStateYuzuki(0);
                    if (isNako)
                        setGirlStateNako(0);
                }
                //PatcherSettings.SetValue(PatcherSettings.takatto29022, loveLetter + "|" + HikariLove + "|" + YuzukiLove + "|" + NakoLove + "|" + totalLoveLetterCount + "|" + isLovedHikari.ToString() + "|" + isLovedYuzuki.ToString() + "|" + isLovedNako.ToString() + "|");
                saveLove();
                lbAddOne.Location = new Point(pnHeartXdef, lbAddOne.Location.Y);
                skipthru = false;
            }
        }

        bool justOnceCUSTK = false;
        private void textureModBtn_Click(object sender, EventArgs e)
        {
            if (!takService_card_viewer)
            {
                SimpleDialogFrom nakoSawYou = new SimpleDialogFrom();
                nakoSawYou.ShowDialog(this);
                nakoSawYou.Dispose();
                return;
            }

            if (Methods.AlertIfGameIsRunning(this))
                return;

            UserSettings.CustomTexture = !UserSettings.CustomTexture;
            Btn_CheckedChanged(null, null);

            if (!UserSettings.CustomTexture)
            {
                if (!UserSettings.UITweakSetting)
                {
                    if (!justOnceCUSTK)
                    {
                        if (isZaCardoSV == null)
                        {
                            MsgBoxs.Warning.IncorrectParametter(this);
                            UserSettings.CustomTexture = false;
                            Btn_CheckedChanged(null, null);
                            return;
                        }
                        justOnceCUSTK = true;
                        MsgBoxs.Information.RequiredToWork(this, isZaCardoSV.name);                     
                    }
                }
            }


            if (customTexture.isSomething)
            {
                try
                {
                    CustomTextureForm.frmObj.btnConfirm_Click(null, null);
                }
                catch { }
            }
        }

        void DisplayTweakButtonService(TweaksItIs tweaksItIs, string _text)
        {
            if (tweaksItIs.Name != _text)
                tweaksItIs.Name = _text;
            if (tweaksItIs.isSomething)
            {
                if (btnServiceForEverything.Text == tweaksItIs.Name)
                    return;
                btnServiceForEverything.Text = tweaksItIs.Name;
            }
        }
        void DisplayTweakButton(TweaksItIs tweaksItIs, string _text)
        {
            if (tweaksItIs.Name != _text)
                tweaksItIs.Name = _text;
            if (tweaksItIs.isSomething)
            {
                if (btnTweakForEverything.Text == tweaksItIs.Name)
                    return;
                btnTweakForEverything.Text = tweaksItIs.Name;
            }
        }

        private void Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (UserSettings.CustomTexture)
            {
                customTexture.isApplied = true;
                DisplayTweakButton(customTexture, StringLoader.GetText("btn_tweak_applied"));
            }
            else if (!UserSettings.CustomTexture)
            {
                customTexture.isApplied = false;
                DisplayTweakButton(customTexture, StringLoader.GetText("btn_apply")); 
            }       

            if (UserSettings.JukeboxTweakSetting)
            {
                if (Methods.IsJukeBoxDLCinstalled())
                {
                    customJukeBox.isApplied = true; 
                    DisplayTweakButton(customJukeBox, StringLoader.GetText("btn_tweak_applied"));
                }
                    
            }
            else if (!UserSettings.JukeboxTweakSetting)
            {
                customJukeBox.isApplied = false;
                if (Methods.IsJukeBoxDLCinstalled())
                    DisplayTweakButton(customJukeBox, StringLoader.GetText("btn_apply"));
            }

            if (UserSettings.CustomSetting)
            {
                miscSettings.isApplied = true;
                DisplayTweakButton(miscSettings, StringLoader.GetText("btn_tweak_applied"));
            }
            else if (!UserSettings.CustomSetting)
            {
                miscSettings.isApplied = false;
                DisplayTweakButton(miscSettings, StringLoader.GetText("btn_apply"));
            }

            if (UserSettings.UITweakSetting)
            {
                if (takService_card_viewer)
                    if (!zawaCardo.isNeedToDownload)
                    {
                        zawaCardo.isApplied = true;
                        DisplayTweakButtonService(zawaCardo, StringLoader.GetText("btn_tweak_applied"));
                    }
                        
            }
            else if (!UserSettings.UITweakSetting)
            {
                zawaCardo.isApplied = false;
                if (takService_card_viewer)
                    if (!zawaCardo.isNeedToDownload)
                    {
                        DisplayTweakButtonService(zawaCardo, StringLoader.GetText("btn_apply"));
                    }  
            }

            if (CustomPatchEnabled)
            {
                if (takService_card_viewer)
                {
                    customPatch.isApplied = true;
                    DisplayTweakButtonService(customPatch, StringLoader.GetText("btn_tweak_applied"));
                }                  
            }
            else if (!CustomPatchEnabled)
            {
                customPatch.isApplied = false;
                if (takService_card_viewer)
                {
                    DisplayTweakButtonService(customPatch, StringLoader.GetText("btn_apply"));
                }         
            }
        }

        private void OnTweakTimedEvent_autoTask(object sender, ElapsedEventArgs e)
        {
            if (currentTask != (sender as TaskTimer).taskID)
            {
                (sender as TaskTimer).Enabled = false;
                return;
            }
            string strCmdText = "/C " + UserSettings.Command.Split('•').First();
            string strPoint = UserSettings.Command.Split('•').Last();
            var x = Methods.GetInt(strPoint.Split(',').First());
            var y = Methods.GetInt(strPoint.Split(',').Last()); 
            var pt2 = (uint)NativeMethods.MAKELPARAM(x, y);
            switch (autoTaske)
            {
                case 0:
                    Methods.KillGame();
                    autoTask.isApplied = isAutoTaskRunning = false;
                    (sender as TaskTimer).Enabled = false;
                    if (autoTask.isSomething)
                        PNTweaksMod(StringLoader.GetText("LB_task_finished"), "", false, false, false, true, 5);
                    break;
                case 1:
                    Methods.KillGame();
                    autoTask.isApplied = isAutoTaskRunning = false;
                    (sender as TaskTimer).Enabled = false;
                    Process.Start("CMD.exe", "shutdown -s -f -t 5");
                    patcherClosingTimer.Enabled = true;
                    if (autoTask.isSomething)
                        PNTweaksMod(StringLoader.GetText("LB_task_finished"), "", false, false, false, true, 5);
                    break;
                case 2:
                    Methods.KillGame();
                    Process.Start("CMD.exe", strCmdText);
                    if (!autoTaskRepeat)
                    {
                        autoTask.isApplied = isAutoTaskRunning = false;
                        (sender as TaskTimer).Enabled = false;

                        if (autoTask.isSomething)
                            PNTweaksMod(StringLoader.GetText("LB_task_finished"), "", false, false, false, true, 5);
                    }
                    break;
                case 3:
                    Process.Start("CMD.exe", strCmdText);
                    if (!autoTaskRepeat)
                    {
                        autoTask.isApplied = isAutoTaskRunning = false;
                        (sender as TaskTimer).Enabled = false;

                        if (autoTask.isSomething)
                            PNTweaksMod(StringLoader.GetText("LB_task_finished"), "", false, false, false, true, 5);
                    }
                    break;
                case 4:              
                    if (!UserSettings.AKFTweakSetting)
                            hWnd = Methods.ProcessHandler();

                    if (hWnd != (IntPtr)null)
                    {
                        NativeMethods.SendMessage(hWnd, 0x201, 0, (int)pt2); //down
                        NativeMethods.SendMessage(hWnd, 0x202, 0, (int)pt2); //up
                    }

                    if (!autoTaskRepeat)
                    {
                        autoTask.isApplied = isAutoTaskRunning = false;
                        (sender as TaskTimer).Enabled = false;

                        if (autoTask.isSomething)
                            PNTweaksMod(StringLoader.GetText("LB_task_finished"), "", false, false, false, true, 5);
                    }
                    break;
            }
        }

        bool isTranslatecomboboxOpenned = false;
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            isTranslating = true;
            animatingTimer.Enabled = true;
        }

        private void cbTranslation_DropDownClosed(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (cbTranslation.SelectedIndex < 0)
                cbTranslation.SelectedIndex = cbTranslation.FindStringExact("Default");

            if (cbTranslation.SelectedIndex == cbTranslation.FindStringExact("Default"))
            {
                if (lbPatches.SelectedIndex != -1)
                    lbPatches_SelectedIndexChanged(null, null); return;
            }

            TranslateTextAsync((cbTranslation.SelectedItem as Language).Value, lbPatchDescription.Text, lbPatchNote.Text);
        }

        int numberOfFrames = 0;
        int currentFrame = 0;
        private void pbCatLoading_Paint(object sender, PaintEventArgs e)
        {
            if (pbCatLoading.Image == null || pn404.Visible)
            {
                currentFrame = 0; return;
            }

            if (currentFrame == numberOfFrames - 2)
            {
                catPatchLoadTimer.Enabled = true;
                lbPatches.Visible = true;
            }
            currentFrame++;
        }

        private async void CatPatchLoadTimer_Tick(object sender, EventArgs e)
        {        
            if (lbPatches.Items.Count <= 0)
            {
                lbError.Text = $"{StringLoader.GetText("LB_404")}\n(￣ω￣)";
                if (!lbRepo.Text.ToUpper().Contains(StringLoader.GetText("lb_repo", "null").ToUpper()))
                    lbError.Text = $"{StringLoader.GetText("LB_something_wrong")}\n(￣ω￣)";

                await Task.Delay(140);
                pn404.Visible = true;
                pnErorCat.Image = Properties.Resources.errorcat;
                pnErorCat.Enabled = true;
                pbCatLoading.Image = null;
                lbPatches.Visible = false;
                lbPatches.Height = 0;
                catPatchLoadTimer.Enabled = false;
                currentFrame = 0;
                return;
            }

            lbPatches.Height += lbPatches.ItemHeight;
            if (lbPatches.Height >= pnListPatch.Height)
            {
                lbPatches.Height = pnListPatch.Height;
                pbCatLoading.Image = null;
                catPatchLoadTimer.Enabled = false;
                currentFrame = 0;
            }
        }

        private void btnURIconFirM_Click(object sender, EventArgs e)
        {
            isOpenningRepo = true;
            animatingTimer.Enabled = true;
            if (!string.IsNullOrWhiteSpace(tbPatchURI.Text))
                btnRefreshAvailablePatches_Click(null, null);
        }

        private void lbRepo_Click(object sender, EventArgs e)
        {
            if (!isPatchListLoading && currentFrame == 0)
            {
                isOpenningRepo = true;
                animatingTimer.Enabled = true;
            }
        }

        bool isOpenningRepo = false;
        bool isOpenningRepoOpenned = false;
        private void tweakPanelTimer_Tick(object sender, EventArgs e)
        {
            if (!isExpandedWidthTable)
            {
                tableLayoutPanel2.ColumnStyles[0].Width -= (int)tableLayoutPanel1.ColumnStyles[0].Width / 34;
                if (tableLayoutPanel2.ColumnStyles[0].Width <= pnMeasure3.Width)
                {
                    tableLayoutPanel2.ColumnStyles[0].Width = pnMeasure3.Width;

                    isExpandedWidthTable = true;
                    tweakPanelTimer.Enabled = false;
                }
            }

            if (isExpandedWidthTable)
            {
                tableLayoutPanel2.ColumnStyles[0].Width += (int)tableLayoutPanel1.ColumnStyles[0].Width / 33;
                if (tableLayoutPanel2.ColumnStyles[0].Width >= (int)tableLayoutPanel1.ColumnStyles[0].Width)
                {
                    tableLayoutPanel2.ColumnStyles[0].Width = (int)tableLayoutPanel1.ColumnStyles[0].Width;

                    isExpandedWidthTable = false;
                    tweakPanelTimer.Enabled = false;
                }
            }
        }

        Bitmap GetCat(int cat)
        {
            switch (cat)
            {
                case 0:
                    return Properties.Resources.catsleep;
                default:
                case 1:
                case 2:
                case 3:
                    return Properties.Resources.catdancing;
                case 4:
                    return Properties.Resources.errorcat;
                case 5:
                    return Properties.Resources.catuwu;
                case 6:
                    return Properties.Resources.cat_runningaround;
            }
        }

        void PNServicesMod(string _lbTweak, string _tbnTweak, bool _isTweakbtnVisible, bool allowcat, int cat)
        {
            pnServicesLoading.BringToFront();
            pnServicesLoading.Visible = true;

            lbServiceti.Text = _lbTweak;
            btnServiceForEverything.Text = _tbnTweak;
            btnServiceForEverything.Visible = _isTweakbtnVisible;

            if (!allowcat)
                cat = new Random().Next(0, 4);

            servicelodPc.Image = GetCat(cat);      
        }

        void PNTweaksMod(string _lbTweak, string _tbnTweak, bool _isTweakbtnVisible, bool _isRefreshVisible, bool _isrequiredExpandong, bool allowcat, int cat)
        {
            pnTweaksLoading.BringToFront();
            pnTweaksLoading.Visible = true;

            if ((!_isrequiredExpandong && isExpandedWidthTable) || (_isrequiredExpandong && !isExpandedWidthTable))
            {
                if (tableLayoutPanel2.InvokeRequired)
                {
                    tableLayoutPanel2.Invoke((MethodInvoker)delegate
                    {
                        PNTweaksMod(_lbTweak, _tbnTweak, _isTweakbtnVisible, _isRefreshVisible, _isrequiredExpandong, allowcat, cat);
                        return;
                    });
                }

                tweakPanelTimer.Enabled = true;
            }

            lbTweakti.Text = _lbTweak;
            btnTweakForEverything.Text = _tbnTweak;
            btnTweakForEverything.Visible = _isTweakbtnVisible;
            lbRefreshTwea.Visible = _isRefreshVisible;

            if (!allowcat)
                cat = new Random().Next(0, 4);

            tweaklodPc.Image = GetCat(cat);          
        }

        void AddFormToService(string _st, TweaksItIs _itisTweak, bool _isTweakbtnVisible)
        {
            btnServiceForEverything.Text = string.IsNullOrEmpty(_itisTweak.Name) ? StringLoader.GetText("lb_status_empty") : _itisTweak.Name;
            PNServicesMod(_st, btnServiceForEverything.Text, _isTweakbtnVisible, false, 5);
        }

        void AddFormToTweak(Form _stuff, TweaksItIs _itisTweak, bool _isTweakbtnVisible, bool _isrequiredExpandong)
        {
            CloseFormTweaks(_stuff);
            pnTweaksLoading.Visible = false;

            _stuff.Dock = DockStyle.None;
            _stuff.Height = 0;

            if ((!_isrequiredExpandong && isExpandedWidthTable) || (_isrequiredExpandong && !isExpandedWidthTable))
            {
                if (tableLayoutPanel2.InvokeRequired)
                {
                    tableLayoutPanel2.Invoke((MethodInvoker)delegate
                    {
                        AddFormToTweak(_stuff, _itisTweak, _isTweakbtnVisible, _isrequiredExpandong);
                        return;
                    });
                }
                else
                    tweakPanelTimer.Enabled = true;
            }

            btnTweakForEverything.Text = string.IsNullOrEmpty(_itisTweak.Name) ? StringLoader.GetText("lb_status_empty") : _itisTweak.Name;

            btnTweakForEverything.Visible = _isTweakbtnVisible;

            _stuff.FormBorderStyle = FormBorderStyle.None;
            _stuff.TopLevel = false;
            _stuff.Location = new Point(0, 0);
            _stuff.Dock = DockStyle.Fill;

            _stuff.TopMost = true;
            pnSubTweak.Controls.Add(_stuff);
            _stuff.Show();
            _stuff.BringToFront();
        }


        bool isExpandedWidthTable = false;

        public async void CloseDownloadForm(Form _form)
        {
            DownloadForm.frmObj.lbDownloadProgress.Text = StringLoader.GetText("LB_download_clean_up");
            await Task.Delay(new Random().Next(429, 1129));
            CloseForm(_form);
        }

        public async void CloseForm(Form _form)
        {
            if (_form != null)
            {
                await Task.Run(() => {
                    _form.Close();
                    _form.Dispose();
                });
            }
        }

        void SetEnableOneButDisableElseService(TweaksItIs tweaksItIs)
        {
            disable.isSomething = (disable.Id == tweaksItIs.Id);
            zawaCardo.isSomething = (zawaCardo.Id == tweaksItIs.Id);
            customPatch.isSomething = (customPatch.Id == tweaksItIs.Id);
            if(disable.isSomething)
                lbServiceDec.Text = StringLoader.GetText("lb_service_help");

            if (!zawaCardo.isSomething)
            {
                btnSV_ZaWaCardo.BackColor = ColorEnum.NormalBtnBg;
                btnSV_ZaWaCardo.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_ZaWaCardo.Text = btnSV_ZaWaCardo.Text.Trim();
            }
            else
            {
                btnSV_ZaWaCardo.BackColor = Color.FromArgb(253, 245, 244);
                btnSV_ZaWaCardo.ForeColor = Color.PaleVioletRed;
                btnSV_ZaWaCardo.Text = " " + btnSV_ZaWaCardo.Text.Trim();
            }


            if (!customPatch.isSomething)
            {
                btnSV_CustomPatch.BackColor = ColorEnum.NormalBtnBg;
                btnSV_CustomPatch.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_CustomPatch.Text = btnSV_CustomPatch.Text.Trim();
            }
            else
            {
                btnSV_CustomPatch.BackColor = Color.FromArgb(253, 245, 244);
                btnSV_CustomPatch.ForeColor = Color.PaleVioletRed;
                btnSV_CustomPatch.Text = " " + btnSV_CustomPatch.Text.Trim();
            }
        }

        void SetPreSymbolForTweakBtn(string _sb)
        {
            if (isGameRunning)
            {
                btnSV_JukeBox.Text = btnSV_JukeBox.Text.Replace("♦", _sb).Trim();
                btnSV_MCVoice.Text = btnSV_MCVoice.Text.Replace("♦", _sb).Trim();
                btnSV_CharVoice.Text = btnSV_CharVoice.Text.Replace("♦", _sb).Trim();
                btnSV_Texture.Text = btnSV_Texture.Text.Replace("♦", _sb).Trim();

                if(takService_card_viewer)
                {
                    btnSV_ZaWaCardo.Text = btnSV_ZaWaCardo.Text.Replace("♦", _sb).Trim();
                    btnSV_CustomPatch.Text = btnSV_CustomPatch.Text.Replace("♦", _sb).Trim();
                }
            }
            else
            {
                btnSV_JukeBox.Text = btnSV_JukeBox.Text.Replace(_sb, "♦").Trim();
                btnSV_MCVoice.Text = btnSV_MCVoice.Text.Replace(_sb, "♦").Trim();
                btnSV_CharVoice.Text = btnSV_CharVoice.Text.Replace(_sb, "♦").Trim();
                btnSV_Texture.Text = btnSV_Texture.Text.Replace(_sb, "♦").Trim();
                
                if (takService_card_viewer)
                {
                    btnSV_ZaWaCardo.Text = btnSV_ZaWaCardo.Text.Replace(_sb, "♦").Trim();
                    btnSV_CustomPatch.Text = btnSV_CustomPatch.Text.Replace(_sb, "♦").Trim();
                }                   
            }
        }

        void SetEnableOneButDisableElse(TweaksItIs tweaksItIs)
        {
            disable.isSomething = (disable.Id == tweaksItIs.Id);
            customJukeBox.isSomething = (customJukeBox.Id == tweaksItIs.Id);
            mcVoice.isSomething = (mcVoice.Id == tweaksItIs.Id);
            charVoice.isSomething = (charVoice.Id == tweaksItIs.Id);
            autoTask.isSomething = (autoTask.Id == tweaksItIs.Id);
            customTexture.isSomething = (customTexture.Id == tweaksItIs.Id);
            customMap.isSomething = (customMap.Id == tweaksItIs.Id);
            miscSettings.isSomething = (miscSettings.Id == tweaksItIs.Id);
            extensionTw.isSomething = (extensionTw.Id == tweaksItIs.Id);
            if(disable.isSomething)
                lbCourtHint.Text = StringLoader.GetText("lb_tweak_help");

            if (!customJukeBox.isSomething)
            {
                btnSV_JukeBox.BackColor = ColorEnum.NormalBtnBg;
                btnSV_JukeBox.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_JukeBox.Text = btnSV_JukeBox.Text.Trim();
            }
            else
            {
                btnSV_JukeBox.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_JukeBox.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_JukeBox.Text = " " + btnSV_JukeBox.Text.Trim();
            }


            if (!mcVoice.isSomething)
            {
                btnSV_MCVoice.BackColor = ColorEnum.NormalBtnBg;
                btnSV_MCVoice.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_MCVoice.Text = btnSV_MCVoice.Text.Trim();
            }
            else
            {
                btnSV_MCVoice.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_MCVoice.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_MCVoice.Text = " " + btnSV_MCVoice.Text.Trim();
            }

            if (!charVoice.isSomething)
            {
                btnSV_CharVoice.BackColor = ColorEnum.NormalBtnBg;
                btnSV_CharVoice.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_CharVoice.Text = btnSV_CharVoice.Text.Trim();
            }
            else
            {
                btnSV_CharVoice.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_CharVoice.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_CharVoice.Text = " " + btnSV_CharVoice.Text.Trim();
            }

            if (!autoTask.isSomething)
            {
                btnSV_Task.BackColor = ColorEnum.NormalBtnBg;
                btnSV_Task.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_Task.Text = btnSV_Task.Text.Trim();
            }
            else
            {
                btnSV_Task.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_Task.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_Task.Text = " " + btnSV_Task.Text.Trim();
            }

            if (!customTexture.isSomething)
            {
                btnSV_Texture.BackColor = ColorEnum.NormalBtnBg;
                btnSV_Texture.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_Texture.Text = btnSV_Texture.Text.Trim();
            }
            else
            {
                btnSV_Texture.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_Texture.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_Texture.Text = " " + btnSV_Texture.Text.Trim();
            }

            if (!customMap.isSomething)
            {
                btnSV_Map.BackColor = ColorEnum.NormalBtnBg;
                btnSV_Map.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_Map.Text = btnSV_Map.Text.Trim();
            }
            else
            {
                btnSV_Map.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_Map.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_Map.Text = " " + btnSV_Map.Text.Trim();
            }

            if (!miscSettings.isSomething)
            {
                btnSV_Misc.BackColor = ColorEnum.NormalBtnBg;
                btnSV_Misc.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_Misc.Text = btnSV_Misc.Text.Trim();
            }
            else
            {
                btnSV_Misc.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_Misc.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_Misc.Text = " " + btnSV_Misc.Text.Trim();
            }

            if (!extensionTw.isSomething)
            {
                btnSV_Extension.BackColor = ColorEnum.NormalBtnBg;
                btnSV_Extension.ForeColor = ColorEnum.NormalBtnForce;
                btnSV_Extension.Text = btnSV_Extension.Text.Trim();
            }
            else
            {
                btnSV_Extension.BackColor = ColorEnum.FocuseBtnBg;
                btnSV_Extension.ForeColor = ColorEnum.FocusedBtnForce;
                btnSV_Extension.Text = " " + btnSV_Extension.Text.Trim();
            }
        }

        public void ClickButtonIfActiveOnTweak()
        {
            if (customJukeBox.isSomething)
            {
                btnSV_JukeBox_Click(null, null);
            }
            else if (mcVoice.isSomething)
            {
                btnSV_MCVoice_Click(null, null);
            }
            else if (charVoice.isSomething)
            {
                btnSV_CharVoice_Click(null, null);
            }
            else if (autoTask.isSomething)
            {
                btnSV_Task_Click(null, null);
            }
            else if (customTexture.isSomething)
            {
                btnSV_Texture_Click(null, null);
            }
            else if (customMap.isSomething)
            {
                btnSV_Map_Click(null, null);
            }
            else if (miscSettings.isSomething)
            {
                btnSV_Misc_Click(null, null);
            }
            else if (extensionTw.isSomething)
            {
                btnSV_Macro_Click(null, null);
            }
            else if (zawaCardo.isSomething)
            {
                btnSV_ZaWaCardo_Click(null, null);
            }
        }

        internal TweaksItIs zawaCardo = new TweaksItIs();
        internal TweaksItIs customPatch = new TweaksItIs();
        internal TweaksItIs customJukeBox = new TweaksItIs();
        internal TweaksItIs mcVoice = new TweaksItIs();
        internal TweaksItIs charVoice = new TweaksItIs();
        internal TweaksItIs autoTask = new TweaksItIs();
        internal TweaksItIs customTexture = new TweaksItIs();
        internal TweaksItIs customMap = new TweaksItIs();
        internal TweaksItIs miscSettings = new TweaksItIs();
        internal TweaksItIs extensionTw = new TweaksItIs();
        internal TweaksItIs disable = new TweaksItIs();

        public static CustomJukeboxForm jForm = null;
        public static MyForm disabledForm = new MyForm();
        private void btnSV_JukeBox_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_jukebox_help");
            //closeForm(new List<Form> { mcForm, cvForm, aForm, mtForm, ctForm, rForm, eForm });
            SetEnableOneButDisableElse(customJukeBox);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (!Methods.IsJukeBoxDLCinstalled())
            {
                PNTweaksMod(StringLoader.GetText("LB_item_not_installed", StringLoader.GetText("btn_tweak_jukebox")), 
                    StringLoader.GetText("btn_tweak_jukebox_install"), true, true, false, false, 0);

                CloseFormTweaks(disabledForm);
                return;
            }

            if (isGameRunning)
            {
                SetIsGameRunningSate(UserSettings.JukeboxTweakSetting, customJukeBox, StringLoader.GetText("LB_item_applied", StringLoader.GetText("btn_tweak_jukebox")),
                    StringLoader.GetText("LB_item_not_applied", StringLoader.GetText("btn_tweak_jukebox")));

                CloseFormTweaks(disabledForm);
                return;
            }

            if (jForm == null || jForm.IsDisposed)
            {
                jForm = new CustomJukeboxForm();
            }

            AddFormToTweak(jForm, customJukeBox, true, true);
        }


        public static AutoTaskForm aForm = null;
        private void btnSV_Task_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_task_help");

            SetEnableOneButDisableElse(autoTask);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (isAutoTaskRunning)
            {
                PNTweaksMod(StringLoader.GetText("LB_task_running"), StringLoader.GetText("btn_tweak_task_cancel_running_task"), 
                    true, false, false, true, 4);

                CloseFormTweaks(disabledForm);
                return;
            }
            else
                DisplayTweakButton(autoTask, StringLoader.GetText("btn_tweak_task_start"));

            if (aForm == null || aForm.IsDisposed)
            {
                aForm = new AutoTaskForm();
            }

            AddFormToTweak(aForm, autoTask, true, true);
        }

        private void btnTweakForEverything_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (customJukeBox.isSomething)
            {
                if (!Methods.IsJukeBoxDLCinstalled())
                    InstallJukebox();
                else
                {
                    UserSettings.JukeboxTweakSetting = !UserSettings.JukeboxTweakSetting;
                    Btn_CheckedChanged(null, null);
                }                 
            }
            if (mcVoice.isSomething)
            {
                if (!Methods.IsMCVoiceInstalled())
                    InstallDLC6();
            }
            if (charVoice.isSomething)
            {
                if (!Methods.IsCharacterVoiceInstalled())
                    InstallDLC5();
            }
            if (autoTask.isSomething)
            {
                if (tweakPanelTimer.Enabled)
                    return;

                if (isAutoTaskRunning)
                {
                    isAutoTaskRunning = false;
                    currentTask = Guid.NewGuid();
                    autoTask.isApplied = false;
                    DisplayTweakButton(autoTask, StringLoader.GetText("btn_tweak_task_start"));
                    btnSV_Task_Click(sender, e);
                    return;
                }
                try
                {
                    AutoTaskForm.frmObj.CheckFields();
                }
                catch { }
            }
            if (miscSettings.isSomething)
            {
                if (isGameRunning)
                    return;

                UserSettings.CustomSetting = !UserSettings.CustomSetting;
                Btn_CheckedChanged(null, null);
                try { MiscForm.frmObj.btn_dlc1_red_Click(null, null); } 
                catch { }
            }
            if (customTexture.isSomething)
            {
                if (isGameRunning)
                    return;

                textureModBtn_Click(sender, e);
            }
            if (extensionTw.isSomething)
            {
                if (ExtensionsForm.frmObj.lbExtensions.SelectedIndex == -1)
                {
                    MsgBoxs.Information.NoItemSelected(this);
                    return;
                }

                var credt = "takanekowo";
                if (!string.IsNullOrEmpty(UserSettings.ExtensionCredential))
                    credt = UserSettings.ExtensionCredential.Trim();

                var process = Methods.GetFolder(Strings.FolderName.Extension, ExtensionsForm.frmObj.lbExtensions.SelectedItem.ToString().Trim() + ".exe");
                var agru = KATEncryptor.Decrypt(UniversalSettings._un.KatCode.Substring(1, UniversalSettings._un.KatCode.Length - 2), 1) + "|" + credt;
                try 
                { 
                    Methods.Run(process, agru);
                }
                catch
                {
                    MsgBoxs.Warning.IncorrectParametter(this);
                }
            }
        }

        private void btnTweakForEverything_VisibleChanged(object sender, EventArgs e)
        {
            Btn_CheckedChanged(sender, e);
        }

        void SetIsGameRunningSate(bool _timer, TweaksItIs isItTteak, string _message1, string _message2)
        {
            if (_timer)
            {
                if (isItTteak.isSomething)
                {
                    PNTweaksMod(_message1, "", false, false, false, true, 4);
                }
                return;
            }

            if (isItTteak.isSomething)
            {
                PNTweaksMod(_message2, "", false, false, false, false, 0);
            }
        }

        void setIsGameRunningSateService(bool _timer, TweaksItIs isItTteak, string _message1, string _message2)
        {
            if (_timer)
            {
                if (isItTteak.isSomething)
                {
                    PNServicesMod(_message1, "", false, true, 4);
                }
                return;
            }
            if (isItTteak.isSomething)
            {
                PNServicesMod(_message2, "", false, false, 0);
            }
        }

        public static MCVoiceForm mcForm = null;
        private void btnSV_MCVoice_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_mcvoice_help");
           
            SetEnableOneButDisableElse(mcVoice);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (!Methods.IsMCVoiceInstalled())
            {
                PNTweaksMod(StringLoader.GetText("LB_item_not_installed", StringLoader.GetText("btn_tweak_mcvoice")),
                      StringLoader.GetText("btn_tweak_mcvoice_install"), true, true, false, false, 0);
                CloseFormTweaks(disabledForm);
                return;
            }
            else
            {
                if (isGameRunning)
                {
                    SetIsGameRunningSate((UserSettings.MCVoiceLanguage > 0), mcVoice, StringLoader.GetText("LB_item_applied", StringLoader.GetText("btn_tweak_mcvoice")),
                        StringLoader.GetText("LB_item_not_applied", StringLoader.GetText("btn_tweak_mcvoice")));

                    CloseFormTweaks(disabledForm);
                    return;
                }

                if (mcForm == null || mcForm.IsDisposed)
                {
                    mcForm = new MCVoiceForm();
                }

                AddFormToTweak(mcForm, mcVoice, false, true);
            }
        }

        public static CharVoiceForm cvForm = null;
        private void btnSV_CharVoice_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_charvoice_help");
            
            SetEnableOneButDisableElse(charVoice);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (!Methods.IsCharacterVoiceInstalled())
            {
                PNTweaksMod(StringLoader.GetText("LB_item_not_installed", StringLoader.GetText("btn_tweak_charactervoice")), 
                    StringLoader.GetText("btn_tweak_charvoice_install"), true, true, false, false, 0);
                CloseFormTweaks(disabledForm);
                return;
            }
            else
            {
                if (isGameRunning)
                {
                    SetIsGameRunningSate((UserSettings.CharVoiceLanguage > 0), charVoice, StringLoader.GetText("LB_item_applied", StringLoader.GetText("btn_tweak_charactervoice")),
                        StringLoader.GetText("LB_item_not_applied", StringLoader.GetText("btn_tweak_charactervoice")));

                    CloseFormTweaks(disabledForm);
                    return;
                }

                if (cvForm == null || cvForm.IsDisposed)
                {
                    cvForm = new CharVoiceForm();
                }

                AddFormToTweak(cvForm, charVoice, false, true);
            }
        }

        private void btnTweakForEverything_TextChanged(object sender, EventArgs e)
        {
            if ((customJukeBox.isSomething && customJukeBox.isApplied && Methods.IsJukeBoxDLCinstalled())
               || (customTexture.isSomething && customTexture.isApplied)
               || (autoTask.isSomething && autoTask.isApplied)
               || (miscSettings.isSomething && miscSettings.isApplied)
               || (charVoice.isSomething && charVoice.isApplied)
               || (mcVoice.isSomething && mcVoice.isApplied)
               || (customMap.isSomething && customMap.isApplied))
            {
                btnTweakForEverything.BackColor = Color.FromArgb(78, 109, 156);
            }
            else
            {
                btnTweakForEverything.BackColor = Color.FromArgb(3, 102, 214);
            }
        }

        private void btnServiceForEverything_TextChanged(object sender, EventArgs e)
        {
            ActiveControl = null;
            if((zawaCardo.isSomething && zawaCardo.isApplied) 
                || (customPatch.isSomething && customPatch.isApplied))
            {
                btnServiceForEverything.BackColor = Color.FromArgb(78, 109, 156);
            }
            else
            {
                btnServiceForEverything.BackColor = Color.Crimson;
            }
        }

        public static MapTweakForm mtForm = null;
        private void btnSV_Map_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help");       

            SetEnableOneButDisableElse(customMap);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (mtForm == null || mtForm.IsDisposed)
            {
                mtForm = new MapTweakForm();
            }

            AddFormToTweak(mtForm, customMap, false, true);
        }

        public static ExtensionsForm eForm = null;
        private void btnSV_Macro_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_extension_help");

            SetEnableOneButDisableElse(extensionTw);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            DisplayTweakButton(extensionTw, StringLoader.GetText("btn_tweak_extension_launch"));
            if (eForm == null || eForm.IsDisposed)
            {
                eForm = new ExtensionsForm();
            }

            AddFormToTweak(eForm, extensionTw, true, true);
        }

        public static MiscForm rForm = null;
        private void btnSV_Misc_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_misc_help");

            SetEnableOneButDisableElse(miscSettings);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }

            if (rForm == null || rForm.IsDisposed)
            {
                rForm = new MiscForm();
            }

            AddFormToTweak(rForm, miscSettings, true, true);
        }

        private void btnServiceForEverything_Click(object sender, EventArgs e)
        {
            if (zawaCardo.isSomething && takService_card_viewer)
            {
                if (zawaCardo.isNeedToDownload)
                {
                    UpdateZawacardo(sender, e);
                    return;
                }

                zawaCardo.isApplied = UserSettings.UITweakSetting = !UserSettings.UITweakSetting;
                Btn_CheckedChanged(null, null);     
            }

            if (customPatch.isSomething)
            {
                if (takService_card_viewer)
                    customPatch.isApplied = CustomPatchEnabled = !CustomPatchEnabled;
            }

            Btn_CheckedChanged(null, null);
        }

        private void btnSV_ZaWaCardo_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            lbServiceDec.Text = StringLoader.GetText("lb_tweak_ui_help");
            SetEnableOneButDisableElseService(zawaCardo);
            if (lockedPathInterface)
            {
                PNServicesMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, false, 0);
                return;
            }

            var name = btnSV_ZaWaCardo.Text.Replace(btnSV_ZaWaCardo.Text.Trim()[0].ToString(), string.Empty).Trim();
            if (isGameRunning)
            {          
                setIsGameRunningSateService((takService_card_viewer && isZaCardoUpdated && UserSettings.UITweakSetting), zawaCardo, 
                    StringLoader.GetText("LB_item_applied", name), StringLoader.GetText("LB_item_not_applied", name));
                return;
            }

            AddFormToService(name, zawaCardo, true);
        }

        private void btnSV_CustomPatch_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            lbServiceDec.Text = StringLoader.GetText("lb_tweak_custompatch_help");
            SetEnableOneButDisableElseService(customPatch);
            if (lockedPathInterface)
            {
                PNServicesMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, false, 0);
                return;
            }

            var name = btnSV_CustomPatch.Text.Replace(btnSV_CustomPatch.Text.Trim()[0].ToString(), string.Empty).Trim();
            if (isGameRunning)
            {
                setIsGameRunningSateService(CustomPatchEnabled, customPatch,
                    StringLoader.GetText("LB_item_applied", name), StringLoader.GetText("LB_item_not_applied", name));
                return;
            }

            AddFormToService(name, customPatch, true);
        }

        void CloseForm(params Form[] form)
        {
            for (int i = 0; i < form.Length; i++)
                CloseForm(form[i]);
        }

        void CloseFormTweaks(Form form)
        {
            if(form!= jForm)
            {
                if(CustomJukeboxForm.frmObj != null)
                    if (!CustomJukeboxForm.frmObj.isplaying)
                        CloseForm(jForm);
            }
            if (form != mcForm)
                CloseForm(mcForm);
            if (form != cvForm)
                CloseForm(cvForm); 
            if (form != aForm)
                CloseForm(aForm); 
            if (form != mtForm)
                CloseForm(mtForm);
            if (form != rForm)
                CloseForm(rForm);
            if (form != eForm)
                CloseForm(eForm);
            if (form != ctForm)
                CloseForm(ctForm);
        }

        public static CustomTextureForm ctForm = null;
        private void btnSV_Texture_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (tweakPanelTimer.Enabled)
                return;

            lbCourtHint.Text = StringLoader.GetText("lb_tweak_customtexture_help");

            SetEnableOneButDisableElse(customTexture);
            if (lockedPathInterface)
            {
                PNTweaksMod(StringLoader.GetText("LB_game_folder_not_selected"), "", false, true, false, false, 0);
                return;
            }
            if (isGameRunning)
            {
                SetIsGameRunningSate(UserSettings.CustomTexture, customTexture, 
                    StringLoader.GetText("LB_item_applied", StringLoader.GetText("btn_tweak_texture")),
                        StringLoader.GetText("LB_item_not_applied", StringLoader.GetText("btn_tweak_texture")));
                CloseFormTweaks(disabledForm);
                return;
            }

            if (ctForm == null || ctForm.IsDisposed)
            {
                ctForm = new CustomTextureForm();
            }

            AddFormToTweak(ctForm, customTexture, true, true);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Methods.AlertIfFS2FolderIsMissing(this))
                return;

            ImportForm imp = new ImportForm();
            imp.ShowDialog(this);
            imp.Dispose();
        }

        private void btnMenutab2_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            //contextLauncher.Show(Cursor.Position.X, Cursor.Position.Y); 
            contextMenuPatch.Show(Cursor.Position.X - btnMenutab2.Width / 2, Cursor.Position.Y - btnMenutab2.Height / 2);
        }

        private void btnSetImageTest_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pnSweet.BackgroundImage = new Bitmap(openFileDialog.FileName);
                    openFileDialog.Dispose();
                }
                catch (Exception ze)
                {
                    MsgBoxs.Warning.Error(this, ze.Message);
                }
            }
        }

        int bgl = 0;
        private void btnSetImageLayoutTest_Click(object sender, EventArgs e)
        {
            bgl++;
            if (bgl == 0)
            {
                toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "None"));

                pnSweet.BackgroundImageLayout = ImageLayout.None;
            }
            if (bgl == 1)
            {
                toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "Tile"));

                pnSweet.BackgroundImageLayout = ImageLayout.Tile;
            }
            if (bgl == 2)
            {
                toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "Center"));

                pnSweet.BackgroundImageLayout = ImageLayout.Center;
            }
            if (bgl == 3)
            {
                toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "Stretch"));

                pnSweet.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (bgl == 4)
            {
                toolTip1.SetToolTip(btnSetImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_layout", "Zoom"));

                pnSweet.BackgroundImageLayout = ImageLayout.Zoom;
            }
            if (bgl >= 4)
                bgl = -1;
        }

        private void btnSetBackgroundImageTest_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pnSweetBG.BackgroundImage = new Bitmap(openFileDialog.FileName);
                    openFileDialog.Dispose();
                }
                catch (Exception ze)
                {
                    MsgBoxs.Warning.Error(this, ze.Message);
                }
            }
        }

        int bglm = 0;
        private void btnSetBackgroundImageLayoutTest_Click(object sender, EventArgs e)
        {
            bglm++;
            if (bglm == 0)
            {
                toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "None"));

                pnSweetBG.BackgroundImageLayout = ImageLayout.None;
            }
            if (bglm == 1)
            {
                toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "Tile"));

                pnSweetBG.BackgroundImageLayout = ImageLayout.Tile;
            }
            if (bglm == 2)
            {
                toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "Center"));

                pnSweetBG.BackgroundImageLayout = ImageLayout.Center;
            }
            if (bglm == 3)
            {
                toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "Stretch"));

                pnSweetBG.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (bglm == 4)
            {
                toolTip1.SetToolTip(btnSetBackgroundImageLayoutTest, StringLoader.GetText("tooltip_sweet_image_background_layout", "Zoom"));

                pnSweetBG.BackgroundImageLayout = ImageLayout.Zoom;
            }
            if (bglm >= 4)
                bglm = -1;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClickButtonIfActiveOnTweak();
        }

        private void lb_courttweakhint_TextChanged(object sender, EventArgs e)
        {
            var twx = sender as Label;
            var txt = StringLoader.GetText("lb_tweak_court_help_load_replay");
            if (lbCourtHint.Text == txt)
                hideHint.Enabled = true;
        }

        private void toolStripMenuCloseLauncherStatus_Click(object sender, EventArgs e)
        {
            UserSettings.CloseLauncher = !UserSettings.CloseLauncher;
        }

        private void contextMenuClose_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuLauncherCloseStatus.Text = StringLoader.GetText("lb_status", (UserSettings.CloseLauncher ? "enabled" : "disabled"));
        }
    }
}