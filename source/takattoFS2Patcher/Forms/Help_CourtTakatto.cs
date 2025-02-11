using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using takattoFS2.Controls.Models;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class Help_CourtTakatto : Form
    {
        string URLz = null;
        bool isNews = false;
        bool isNewsAuto = false;

        public Help_CourtTakatto(string URL, bool _isNews, bool _isAuto)
        {
            InitializeComponent();

            isNews = _isNews;
            URLz = URL;
            isNewsAuto = _isAuto;
        }

        void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.FromHandle(new Bitmap(Properties.Resources.smolviocat).GetHicon());
            Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;
            errorConnect.Font = MemoryFonts.SetFont(0, errorConnect.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            lbPageConnecting.Font = MemoryFonts.SetFont(0, lbPageConnecting.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            CbNoShowPleaseTyBye.Font = MemoryFonts.SetFont(0, CbNoShowPleaseTyBye.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            this.Text = StringLoader.GetText("msgtitle_random1");
            errorConnect.Text = StringLoader.GetText("lb_connecting_to_server") + "\n"; ;
            lbPageConnecting.Text = StringLoader.GetText("lb_connecting");

            errorConnect.Visible = true;
            if (!isNews)
            {
                timer1.Enabled = true;
                return;
            }

            WebBrowser.MinimumSize = new Size(550, 500);
            pnLoading.Visible = true;
            try
            {
                Size = new Size((int)(MainForm.mf.Width * 3), (int)(MainForm.mf.Height * 1.5));
            }
            catch
            {
                Size = new Size(1150, 750);
            }

            Size screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2);


            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            ControlBox = true;
            Text = "OuO/";
            MaximizeBox = true;
            MinimizeBox = true;

            if (string.IsNullOrEmpty(URLz))
                WebBrowser.Url = new System.Uri(StringTheory.Universal.NewsUri, System.UriKind.Absolute);
            else
            {
                if (Uri.IsWellFormedUriString(URLz, UriKind.Absolute))
                    WebBrowser.Url = new System.Uri(URLz);
                else
                {
                    var uri = String.Format(Urls.NewsFormat, StringTheory.Universal.DisplaySiteRootUri, URLz);
                    WebBrowser.Url = new System.Uri(uri);
                }
            }

            WebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            WebBrowser.BringToFront();

            if (first)
            {
                pnLoading.BringToFront();
            }

            WebBrowser.Visible = true;

            if (isNews && isNewsAuto)
            {
                canClose = false;
                timerNews.Start();
                //CbNoShowPleaseTyBye.Visible = true;
                CbNoShowPleaseTyBye.Text = StringLoader.GetText("btn_news_skip");
                CbNoShowPleaseTyBye.BringToFront();
            }

            Show();
        }
        private void CourtHelpTakatto_Load(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        async void LoadImageAsync()
        {
            Image img = null;

            if (!URLz.Contains(".image"))
            {
                try
                {
                    string image = URLz;
                    byte[] imageData = await new WebClient().DownloadDataTaskAsync(image);
                    MemoryStream imgStream = new MemoryStream(imageData);
                    img = Image.FromStream(imgStream);
                }
                catch
                {
                    errorConnect.Visible = true;
                    errorConnect.Text = StringLoader.GetText("LB_404") + "\n";
                    //Size = new Size(408, 204);
                    return;
                }
            }
            else if (URLz.Contains(".image"))
            {
                byte[] imageData;
                try //try png
                {
                    //string image = "https://cdn.discordapp.com/attachments/804261769752608788/917959809943363615/unknown.png"; //test small img for scalling
                    string image = URLz.Replace(".image", ".png");
                    imageData = await new WebClient().DownloadDataTaskAsync(image);

                }
                catch
                {
                    try //try jpg
                    {
                        string image = URLz.Replace(".image", ".jpg");
                        imageData = await new WebClient().DownloadDataTaskAsync(image);
                    }
                    catch
                    {
                        try //try gif
                        {
                            string image = URLz.Replace(".image", ".gif");
                            imageData = await new WebClient().DownloadDataTaskAsync(image);
                        }
                        catch
                        {
                            try //try webp
                            {
                                string image = URLz.Replace(".image", ".webp");
                                imageData = await new WebClient().DownloadDataTaskAsync(image);
                            }
                            catch
                            {
                                try //try jpeg
                                {
                                    string image = URLz.Replace(".image", ".jpeg");
                                    imageData = await new WebClient().DownloadDataTaskAsync(image);
                                }
                                catch
                                {
                                    errorConnect.Visible = true;
                                    errorConnect.Text = StringLoader.GetText("LB_404") + "\n";
                                    return;
                                }
                            }
                        }
                    }
                }
                using (MemoryStream imgStream = new MemoryStream(imageData))
                {
                    img = Image.FromStream(imgStream);
                }
            }

            int w = img.Width;
            int h = img.Height;
            pictureBox1.Image = img;
            int titleHeight = 29;

            try { Rectangle screenRectangle = RectangleToScreen(ClientRectangle); titleHeight = screenRectangle.Top - Top; }
            catch { Close(); }
            try {
                if (w <= MainForm.mf.Width)
                {
                    float d = (MainForm.mf.Width + (MainForm.mf.Width / 2)) / w;
                    w = (int)(d * w);
                    h = (int)(h * d);
                }
            } catch { }

            Size = new Size(w, h + titleHeight);
            Size screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2);


            pictureBox1.BringToFront();

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            ControlBox = true;
            MaximizeBox = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadImageAsync();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            errorConnect.Text = errorConnect.Text.Replace(".", "..").Replace("。", "。。");
            errorConnect.Text = errorConnect.Text.Replace("...........", ".").Replace("。。。。。。。。。。。", "。");
            lbPageConnecting.Text = lbPageConnecting.Text.Replace(".", "..").Replace("。", "。。");
            lbPageConnecting.Text = lbPageConnecting.Text.Replace("...........", ".").Replace("。。。。。。。。。。。", "。");
        }

        bool first = true;
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try { Text = (string)WebBrowser.Document.Title; 
            } catch { }

            if (first)
            {
                first = false;
                return;
            }
            if (WebBrowser.Document != null)
                pnLoading.SendToBack();
        }

        private void Help_CourtTakatto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!canClose)
            {
                e.Cancel = true;
                return;
            }

            this.Dispose();
            WebBrowser = null;
            IntPtr pHandle = NativeMethods.GetCurrentProcess();
            NativeMethods.SetProcessWorkingSetSize(pHandle, -1, -1);
        }

        private void CbNoShowPleaseTyBye_CheckedChanged(object sender, EventArgs e)
        {
            if (CbNoShowPleaseTyBye.Checked)
            {
                CbNoShowPleaseTyBye.CheckState = CheckState.Indeterminate;
                UserSettings.NewsBlockList = URLz;
            }
            else
                UserSettings.NewsBlockList = null;
        }

        private void CbNoShowPleaseTyBye_Click(object sender, EventArgs e)
        {
            if (!CbNoShowPleaseTyBye.Checked)
                CbNoShowPleaseTyBye.CheckState = CheckState.Indeterminate;
            else
                CbNoShowPleaseTyBye.Checked = false;         
        }

        private void timerNews_Tick(object sender, EventArgs e)
        {
            timerNews.Stop();
            canClose = true;
            CbNoShowPleaseTyBye.Visible = true;
        }
        
        bool canClose = true;
       
    }
}
