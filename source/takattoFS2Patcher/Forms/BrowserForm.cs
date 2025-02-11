using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
#pragma warning restore IDE1006 // Naming Styles

    public partial class BrowserForm : MyForm
    {
        public BrowserForm()
        {
            Size = new Size((int)(MainForm.mf.Width * 2.9), (int)(MainForm.mf.Height * 1.75));
            InitializeComponent();

            modeComboBox.SelectedIndex = UserSettings.WebLoginSetting;

            WebBrowser.Focus();

            string pass = UserSettings.GamePw;

            if (!string.IsNullOrWhiteSpace(pass))
                tbRememberPassword.Text = pass;
        }

        public void showForm()
        {
            Show();
        }
       
        private void lbRememberPassword_TextChanged(object sender, EventArgs e)
        {
            UserSettings.GamePw = tbRememberPassword.Text;
        }

        private void btnSendPassword_Click(object sender, EventArgs e)
        {
            timerPw.Enabled = true;
            WebBrowser.Focus();
            try
            {
                if (modeComboBox.SelectedItem.ToString() == "Nexon")
                {
                    var passwordBox = WebBrowser.Document.GetElementById("txtPWD");
                    var passwordBoxC = WebBrowser.Document.GetElementById("txtCPWD");
                    var usernameBox = WebBrowser.Document.GetElementById("txtNexonID");
                    if (passwordBox != null)
                    {
                        passwordBox.Focus();
                        passwordBox.InnerText = tbRememberPassword.Text;
                        usernameBox.Focus();
                    }
                    if (passwordBoxC != null)
                    {
                        passwordBoxC.Focus();
                        passwordBoxC.InnerText = tbRememberPassword.Text;
                        usernameBox.Focus();
                    }
                }
                else if (modeComboBox.SelectedItem.ToString() == "Joycity")
                {
                    var passwordBox = WebBrowser.Document.GetElementById("password");
                    var usernameBox = WebBrowser.Document.GetElementById("userID");
                    if (passwordBox != null && usernameBox != null)
                    {
                        passwordBox.Focus();
                        passwordBox.InnerText = tbRememberPassword.Text;
                        usernameBox.Focus();
                    }
                }
            }
            catch { }
        }


        private void ModeToolStripComboBox_DropDownClosed(object sender, EventArgs e)
        {
            WebBrowser.Focus();
        }

        bool ol = true;
        private void ModeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ol)
            {
                WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted_1);
                pnLoading.BringToFront();
            }

            timerPw.Enabled = true;

            if (modeComboBox.SelectedItem.ToString() == "Nexon")
            {
                pnLoading.BringToFront();
                WebBrowser.Url = new System.Uri(Urls.DirectLoginNexonUri, System.UriKind.Absolute);


                string pass = UserSettings.GamePw;

                if (!string.IsNullOrWhiteSpace(pass))
                    tbRememberPassword.Text = pass;
            }
            else if (modeComboBox.SelectedItem.ToString() == "Joycity")
            {
                pnLoading.BringToFront();
                WebBrowser.Url = new System.Uri(Urls.DirectLoginJoyCityUri, System.UriKind.Absolute);

                string pass = UserSettings.GamePw;

                if (!string.IsNullOrWhiteSpace(pass))
                    tbRememberPassword.Text = pass;
            }


            UserSettings.WebLoginSetting = modeComboBox.SelectedIndex;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const string PROCESSNAME = Strings.Misc.LauncherKrProcessName;

            if (Process.GetProcessesByName(PROCESSNAME).Length == 1)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }

        private void timerJoy_Tick(object sender, EventArgs e)
        {
            timerJoy.Interval = 999999;
            pnLoading.BringToFront();
            WebBrowser.Url = new System.Uri(Urls.JoyCityUri);
            timerJoy.Enabled = false;
        }


        private void WebBrowser_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (ol)
            {
                ol = false;
                return;
            }

            timerJoy.Interval = 100;

            if (WebBrowser.Document != null)
            {
                pnLoading.SendToBack();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser.Focus();
            try
            {
                var linksw = WebBrowser.Document.GetElementsByTagName("a");
                foreach (HtmlElement links in linksw)
                {
                    if (links.GetAttribute("className") == "game_s_t")
                    {
                        links.Focus();
                        WebBrowser.Navigate("javascript: document.activeElement.click();"); break;
                    }
                    if (links.GetAttribute("className") == "btn_nowDownload game_start")
                    {
                        links.Focus();
                        WebBrowser.Navigate("javascript: document.activeElement.click();"); break;
                    }
                    if (links.GetAttribute("className") == "startBtn animated-button")
                    {
                        links.Focus();
                        WebBrowser.Navigate("javascript: document.activeElement.click();"); break;
                    }
                }
            } 
            catch { } //eat it                     
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (modeComboBox.SelectedItem.ToString() == "Nexon")
                {
                    var passwordBox = WebBrowser.Document.GetElementById("txtPWD");
                    var usernameBox = WebBrowser.Document.GetElementById("txtNexonID");
                    if (passwordBox != null && usernameBox != null) //&& usernameCheckBox != null
                    {
                        timerPw.Enabled = false;
                        //usernameCheckBox.InvokeMember("Click");
                        passwordBox.Focus();
                        passwordBox.InnerText = tbRememberPassword.Text;
                        usernameBox.Focus();
                    }
                }
                else if (modeComboBox.SelectedItem.ToString() == "Joycity")
                {
                    var passwordBox = WebBrowser.Document.GetElementById("password");
                    var usernameBox = WebBrowser.Document.GetElementById("userID");
                    if (passwordBox != null && usernameBox != null) // && usernameCheckBox != null
                    {
                        timerPw.Enabled = false;
                        //usernameCheckBox.InvokeMember("Click");
                        passwordBox.Focus();
                        passwordBox.InnerText = tbRememberPassword.Text;
                        usernameBox.Focus();
                    }
                }
            }
            catch { } //eat it   

        }

        private void LoginPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrowser.Refresh();
            timerPw.Enabled = true;
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            WebBrowser.Dispose();
            WebBrowser = null;
            IntPtr pHandle = NativeMethods.GetCurrentProcess();
            NativeMethods.SetProcessWorkingSetSize(pHandle, -1, -1);
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                var linksw = WebBrowser.Document.GetElementsByTagName("p");
                foreach (HtmlElement links in linksw)
                {
                    if (links.GetAttribute("className") == "user_name")
                    {
                        if (links.InnerText.Contains("조이시티에 오신 것을 환영합니다"))
                        {
                            timerJoy.Enabled = true;
                        }
                    }
                }
            }
            catch { } //eat it   
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;

            modeComboBox.Font = MemoryFonts.SetFont(0, modeComboBox.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            tbRememberPassword.Font = MemoryFonts.SetFont(0, tbRememberPassword.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);

            foreach (Control c in MenuStrip.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            btnLaunch.Font = MemoryFonts.SetFont(0, btnLaunch.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            lbPassword.Font = MemoryFonts.SetFont(0, lbPassword.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            lbConnecting.Font = MemoryFonts.SetFont(0, lbConnecting.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            btnSendPassword.Font = MemoryFonts.SetFont(0, btnSendPassword.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btnSendPassword.Height = tbRememberPassword.Height;
            btnLaunch.Height = modeComboBox.Height;

            lbPassword.Text = StringLoader.GetText("lb_remember_password") + ":";
            btnLaunch.Text = StringLoader.GetText("tooltip_launch_game");
            lbConnecting.Text = StringLoader.GetText("lb_connecting");
        }

        private void timer3loading_Tick(object sender, EventArgs e)
        {
            lbConnecting.Text = lbConnecting.Text.Replace(".", "..");
            lbConnecting.Text = lbConnecting.Text.Replace("...........", ".");
        }
    }
}
