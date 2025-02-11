using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class InstallerForm : Form
    {
        public InstallerForm()
        {
            InitializeComponent();
        }
        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            btn_close.Font = MemoryFonts.SetFont(0, btn_close.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_repair.Font = MemoryFonts.SetFont(0, btn_repair.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;

            ActiveControl = null;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MaximizeBox = false;

            label1.Text = StringLoader.GetText("lb_installer_repair");
            btn_close.Text = StringLoader.GetText("btn_cancel");
            btn_repair.Text = StringLoader.GetText("tooltip_button_repair");
            lb_captcha.Text = StringLoader.GetText("lb_installer_repair_step1");
        }

        bool first_run = false;
        bool quitFirstTimeInstaller = false;
        private void PatcherUninstallerForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            
            if (string.IsNullOrEmpty(PatcherSettings.GetValue(PatcherSettings.takatto00000)))
            {
                first_run = true;
                panel1.BackColor = Color.FromArgb(255, 250, 247);
                label1.BackColor = Color.FromArgb(255, 250, 247);
                lb_captcha.BackColor = Color.FromArgb(255, 250, 247);
            }

            if (first_run)
            {
                quitFirstTimeInstaller = true;
                pictureBox2.Visible = true;
                btn_close.Visible = true;
                label1.Text = StringLoader.GetText("lb_installer_welcome");

                lb_captcha.Text = StringLoader.GetText("lb_installer_welcome_step1");
                btn_repair.Text = StringLoader.GetText("btn_confirm");
            }
        }

        void ResetSettings()
        {
            PatcherSettings.DeleteValue(PatcherSettings.takatto00000);
            PatcherSettings.DeleteValue(PatcherSettings.takatto11000);
            PatcherSettings.DeleteValue(PatcherSettings.takatto29kat);

            Properties.Settings.Default.Reset();
            File.Delete(UserSettings.AppSettingPath);
            try
            {
                if (!first_run)
                {
                    MainForm.mf.Enable_PatcherRestartTimer();
                }
                else
                    MainForm.mf.enable_patcherClosingTimer();
            }
            catch { }
        }

        bool firstClick = false;
        bool secondClick = false;
        bool thirdClick = false;
        bool forthClick = false;
        bool fifthClick = false;
        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (!first_run)
            {
                if (!firstClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_repair_step2");
                    firstClick = true;
                    return;
                }
                if (!secondClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_welcome_step3");
                    secondClick = true;
                    return;
                }
                if (!thirdClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_repair_step3");
                    thirdClick = true;
                    return;
                }
                if (!forthClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_repair_step4");
                    forthClick = true;
                    return;
                }

                if (!fifthClick)
                {
                    btn_close.BackColor = Color.LightGray;
                    btn_close.Enabled = false;
                    lb_captcha.Text = StringLoader.GetText("lb_installer_repair_step5");
                    fifthClick = true; 

                    Methods.KillGame();

                    if (string.IsNullOrEmpty(UserSettings.GamePath))
                    {
                        ResetSettings();
                        return;
                    }

                    DirectoryInfo dieS3 = new DirectoryInfo(Methods.GetFolder(Strings.FolderName.Data));
                    if (dieS3.Exists)
                    {
                        foreach (FileInfo file in dieS3.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { };
                        }
                        foreach (DirectoryInfo dir in dieS3.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch { };
                        }
                    }

                    DirectoryInfo dieS = new DirectoryInfo(Methods.GetFolder(Strings.FolderName.Sound));
                    if (dieS.Exists)
                    {
                        foreach (FileInfo file in dieS.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { };
                        }
                        foreach (DirectoryInfo dir in dieS.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch { };
                        }
                    }
                   
                    DirectoryInfo dieS2 = new DirectoryInfo(Methods.GetFolder(Strings.FolderName.CustomPatch));
                    if (dieS2.Exists)
                    {
                        foreach (FileInfo file in dieS2.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { };
                        }
                        foreach (DirectoryInfo dir in dieS2.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch { };
                        }
                    }

                    DirectoryInfo dieS4 = new DirectoryInfo(Methods.GetFolder(Strings.FolderName.Extension));
                    if (dieS4.Exists)
                    {
                        foreach (FileInfo file in dieS4.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { };
                        }
                        foreach (DirectoryInfo dir in dieS4.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch { };
                        }
                    }


                    DirectoryInfo diaz = new DirectoryInfo(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder));
                    foreach (FileInfo file in diaz.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in diaz.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    ResetSettings();
                    return;
                }
            }
            else if (first_run)
            {
                if (!firstClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_welcome_step2");
                    firstClick = true;
                    return;
                }
                if (!secondClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_welcome_step3");
                    secondClick = true;
                    return;
                }
                if (!thirdClick)
                {
                    lb_captcha.Text = StringLoader.GetText("lb_installer_welcome_step4");
                    thirdClick = true;
                    return;
                }

                if (!forthClick)
                {
                    this.Hide();
                    SimpleDialogFrom nakoSawYou = new SimpleDialogFrom();
                    nakoSawYou.ShowDialog(this);
                    nakoSawYou.Dispose();



                    quitFirstTimeInstaller = false;
                    btn_close.BackColor = Color.LightGray;
                    btn_close.Enabled = false;
                    forthClick = true; 

                    Methods.KillGame();               
                    PatcherSettings.SetValue(PatcherSettings.takatto00000, "if");
                    PatcherSettings.DeleteValue(PatcherSettings.takatto11000);
                    PatcherSettings.DeleteValue(PatcherSettings.takatto29kat);
                    Properties.Settings.Default.Reset();
                    Close();
                    return;
                }
            }
        }

        
        private void install_dlc6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Help_PatcherUninstallerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (quitFirstTimeInstaller)
            {
                var res = MsgBoxs.Dialog.ClosePatcher(this, true);
                if (res != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
            }
        }
    }
}