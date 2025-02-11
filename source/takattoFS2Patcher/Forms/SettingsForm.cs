using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();                   
        }

        void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            btnCleanup.Font = MemoryFonts.SetFont(0, btnCleanup.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_ok.Font = MemoryFonts.SetFont(0, btn_ok.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_viewlog.Font = MemoryFonts.SetFont(0, btn_viewlog.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            LoadText();


        }

        void LoadText()
        {
            this.Text = StringLoader.GetText("tooltip_button_setting");
            lb_lang.Text = StringLoader.GetText("lb_setting_language") + ":";
            lbLang.Text = StringLoader.GetText("lb_setting_language_help");
            lb_s1.Text = StringLoader.GetText("lb_setting_menu_position") + ":";
            lb_langhintwhy.Text = StringLoader.GetText("lb_setting_menu_position_help");
            lb_musi.Text = StringLoader.GetText("lb_setting_auto_play_music") + ":";
            lbmusi.Text = StringLoader.GetText("lb_setting_auto_play_music_help");
            lb_logging.Text = StringLoader.GetText("lb_setting_enable_logging") + ":";
            label1.Text = StringLoader.GetText("lb_setting_enable_logging_help");

            btn_viewlog.Text = StringLoader.GetText("btn_setting_see_log");
            btnCleanup.Text = StringLoader.GetText("btn_setting_clean_up");
            btn_ok.Text = StringLoader.GetText("btn_confirm");
        }
        
        private void Settings_Load(object sender, EventArgs e)
        {
            LoadControl();
            
            cbLang.SelectedIndex = cbLang.FindStringExact("EN-US");

            cbLang.SelectedIndex = LanguageCode(UserSettings.UILanguageCode);
            OldLanguage = cbLang.SelectedIndex;
            try
            {
                cbs1.SelectedIndex = UserSettings.PatcherMenuSetting;
            }
            catch { cbs1.SelectedIndex = 0; }
            cbMusi.SelectedIndex = UserSettings.PatcherMusicSetting ? 1: 0;
            cbLogging.SelectedIndex = UserSettings.LoggingSetting ? 1 : 0;
        }
        int OldLanguage;

        int LanguageCode(string st)
        {
            switch (st) {
                case "default":
                    return 0;
                case "en":
                    return 1;
                case "ko":
                    return 2;
                case "zh":
                    return 3;
                default:
                    return 0;
            }
        }

        string LanguageCode(int st)
        {
            switch (st)
            {
                case 0:
                    return "default";
                case 1:
                    return "en";
                case 2:
                    return "ko";
                case 3:
                    return "zh";
                default:
                    return "en";
            }
        }

        private void SveSettings_Click(object sender, EventArgs e)
        {
            if (cbs1.SelectedIndex == -1)
                return;

            UserSettings.PatcherMenuSetting = cbs1.SelectedIndex;
            UserSettings.PatcherMusicSetting = Convert.ToBoolean(cbMusi.SelectedIndex);
            UserSettings.LoggingSetting = Convert.ToBoolean(cbLogging.SelectedIndex);
            if (cbLogging.SelectedIndex == 1)
            {
                if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)))
                {
                    try
                    {
                        File.Create(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)).Close(); ;
                        Logger.Write("Logging service has enabled");
                    }
                    catch { } //eat it cuz y not
                }
            }

            MainForm.mf.Enable_LogCleaner();

            UserSettings.UILanguageCode = LanguageCode(cbLang.SelectedIndex);

            if (OldLanguage != cbLang.SelectedIndex)
            {
                LoadText();
                MainForm.mf.LoadUILanguage();
                
                if(MainForm.mf.frm != null)
                    MainForm.mf.frm.LoadUILanguage();
                
                MsgBoxs.Information.RestartRequired(this);
            }
                
       
            Close();
        }


        private void cbs1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbs1.SelectedIndex == -1)
                return;
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbs1.SelectedIndex == -1)
                return;
        }

        private void cbLang_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            lb_lang.Focus();
            var nb = Methods.CleanUp();        
            var nujmber = Math.Round((nb / 1024f) / 1024f);
            MsgBoxs.Information.CleannedUp(this, (int)nujmber);

            File.Create(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)).Close();
            Logger.Write("Logs cleanned");
            GC.Collect();
        }

        private void btn_viewlog_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if(!UserSettings.LoggingSetting)
            {
                var confirmResult = MsgBoxs.Dialog.EnableLogging(this);

                if (confirmResult == DialogResult.Yes)
                {
                    cbLogging.SelectedIndex = 1;
                    UserSettings.LoggingSetting = true;

                    if (!File.Exists(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)))
                    {
                        try
                        {
                            File.Create(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)).Close();
                            Logger.Write("Logging service has enabled");
                        }
                        catch (Exception msg)
                        {
                            MsgBoxs.Warning.Error(this, msg.ToString());
                        }
                    }
                }
                else
                    return;
            }

            try
            {
                Process.Start(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog));
            }
            catch (Exception msg)
            {
                MsgBoxs.Warning.Error(this, msg.ToString());
            }
        }
    }
}
