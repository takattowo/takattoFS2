using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using takattoFS2.Controls.Models;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class CharVoiceForm : Form
    {
        public CharVoiceForm()
        {
            InitializeComponent();          
        }

        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            UpdateFields();
            CheckForUpdate();
        }

        private void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }
            foreach (Control c in panelEx1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            lbCharvoice_hint.Text = StringLoader.GetText("lb_tweak_charvoice_hint") + ":";
            rdDefault.Text = StringLoader.GetText("btn_disable");

            //rdDefault.Text = StringLoader.GetText("lb_tweak_choice_default") + " [" + StringLoader.GetText("btn_disable") + "]";
            rdEnglish.Text = StringLoader.GetText("lb_tweak_choice_english");
            rdChinese.Text = StringLoader.GetText("lb_tweak_choice_china");
            rdKorean.Text = StringLoader.GetText("lb_tweak_choice_korea");
            rdKustom.Text = StringLoader.GetText("lb_tweak_choice_custom");
            lbNote.Text = StringLoader.GetText("lb_tweak_charvoice_hint2");

            toolTip1.SetToolTip(lbNote, StringLoader.GetText("tooltip_tweak_charvoice_hint2"));
            toolTip1.SetToolTip(btnUpdate, StringLoader.GetText("lb_tweak_charvoice_version_newer"));
            toolTip1.SetToolTip(btnES, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(btnCnS, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(btnKorS, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(btnCustomS, StringLoader.GetText("tooltip_sample"));
        }

        public void UpdateFields()
        {
            var eng = Methods.IsCharacterVoiceInstalled("en");
            rdEnglish.Enabled = eng;
            btnES.Visible = eng;

            var cn = Methods.IsCharacterVoiceInstalled("cn");
            rdChinese.Enabled = cn;
            btnCnS.Visible = cn;

            var kr = Methods.IsCharacterVoiceInstalled("kr");
            rdKorean.Enabled = kr;
            btnKorS.Visible = kr;

            var ja = Methods.IsCharacterVoiceInstalled("kat");
            rdKustom.Enabled = ja;
            btnCustomS.Visible = ja;

            var voiceIndex = UserSettings.CharVoiceLanguage;

            switch (voiceIndex)
            {
                case 0:                   
                    rdDefault.Checked = true;
                    break;
                case 1:
                    if (rdEnglish.Enabled)
                        rdEnglish.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 2:
                    if (rdKorean.Enabled)
                        rdKorean.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 3:
                    if (rdChinese.Enabled)
                        rdChinese.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 4:
                    if (rdKustom.Enabled)
                        rdKustom.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                default:
                    rdDefault.Checked = true;
                    break;
            }
        }

        private string dlc5_version;
        bool isNewUpdateAvailable = false;
        void CheckForUpdate()
        {
            var encrypted = File.ReadAllText(Methods.GetFolder(Strings.FolderName.DLC5, Strings.KattoFileName.DLC5Manifest));

            if (string.IsNullOrEmpty(encrypted))
                return;

            var decryptted = KATEncryptor.Decrypt(encrypted, 2);
            var version = decryptted.Split('|').First();
            var id = decryptted.Split('|').Last();
            if(StringTheory.Universal.Services != null)
            {
                var isCharVoiceSV = StringTheory.Universal.Services.FirstOrDefault(x => x.id.Contains(id));
                if (isCharVoiceSV != null)
                {
                    dlc5_version = isCharVoiceSV.version;
                    if (Methods.GetInt(version) < Methods.GetInt(isCharVoiceSV.version))
                    {
                        isNewUpdateAvailable = true;
                        lbVersion.Text = StringLoader.GetText("lb_tweak_charvoice_version_newer");
                        lbVersion.ForeColor = Color.Crimson;
                        btnUpdate.Visible = true;
                        return;
                    }
                }
            }           

            var vern = string.IsNullOrEmpty(dlc5_version) ? StringLoader.GetText("lb_patch_not_installed") : dlc5_version;
            lbVersion.Text = StringLoader.GetText("lb_tweak_charvoice_version", vern);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.CharVoiceLanguage = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.CharVoiceLanguage = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.CharVoiceLanguage = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.CharVoiceLanguage = 2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.CharVoiceLanguage = 4;
        }

        WMPLib.WindowsMediaPlayer Player1;
        WMPLib.WindowsMediaPlayer Player2;
        WMPLib.WindowsMediaPlayer Player3;
        WMPLib.WindowsMediaPlayer Player4;
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player1 = new WMPLib.WindowsMediaPlayer();
            Player1.StatusChange += Player1_StatusChange;
            Player1.URL = Methods.IsCharacterVoiceSampleInstalled("en");

            if (string.IsNullOrEmpty(Player1.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            btnES.Enabled = false;
            btnES.BackgroundImage = Properties.Resources.icons8_pause_25;

            try
            {
                Player1.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }

        private void Player1_StatusChange()
        {
            if (Player1.status == "Finished")
            {
                btnES.Enabled = true;
                btnES.BackgroundImage = Properties.Resources.icons8_play_25;
                Player1.URL = null;
                Player1.close();
                Marshal.FinalReleaseComObject(Player1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player2 = new WMPLib.WindowsMediaPlayer();
            Player2.StatusChange += Player2_StatusChange;
            Player2.URL = Methods.IsCharacterVoiceSampleInstalled("cn");

            if (string.IsNullOrEmpty(Player2.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            btnCnS.Enabled = false;
            btnCnS.BackgroundImage = Properties.Resources.icons8_pause_25;     

            try
            {
                Player2.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }
        private void Player2_StatusChange()
        {
            if (Player2.status == "Finished")
            {
                btnCnS.Enabled = true;
                btnCnS.BackgroundImage = Properties.Resources.icons8_play_25;
                Player2.URL = null;
                Player2.close();
                Marshal.FinalReleaseComObject(Player2);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player3 = new WMPLib.WindowsMediaPlayer();
            Player3.StatusChange += Player3_StatusChange;
            Player3.URL = Methods.IsCharacterVoiceSampleInstalled("kr");

            if (string.IsNullOrEmpty(Player3.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            btnKorS.Enabled = false;
            btnKorS.BackgroundImage = Properties.Resources.icons8_pause_25;

            try
            {
                Player3.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }
        private void Player3_StatusChange()
        {
            if (Player3.status == "Finished")
            {
                btnKorS.Enabled = true;
                btnKorS.BackgroundImage = Properties.Resources.icons8_play_25;
                Player3.URL = null;
                Player3.close();
                Marshal.FinalReleaseComObject(Player3);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player4 = new WMPLib.WindowsMediaPlayer();
            Player4.StatusChange += Player4_StatusChange;
            Player4.URL = Methods.IsCharacterVoiceSampleInstalled("jp");

            if (string.IsNullOrEmpty(Player4.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            btnCustomS.Enabled = false;
            btnCustomS.BackgroundImage = Properties.Resources.icons8_pause_25;

            try
            {
                Player4.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }
        private void Player4_StatusChange()
        {
            if (Player4.status == "Finished")
            {
                btnCustomS.Enabled = true;
                btnCustomS.BackgroundImage = Properties.Resources.icons8_play_25;
                Player4.URL = null;
                Player4.close();
                Marshal.FinalReleaseComObject(Player4);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            //if (!isNewUpdateAvailable)
            //    return;

            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;
            
            if (isNewUpdateAvailable)
            {
                var confirmResult = MsgBoxs.Dialog.UpdateDLC5(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    //MainForm.mf.overrwiteDownload = false;
                    MainForm.mf.InstallDLC5();
                }
            }
            else
            {
                var confirmResult = MsgBoxs.Dialog.Reinstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    MainForm.mf.InstallDLC5();
                }
            }
           
        }

        private void checkDLC_Tick(object sender, EventArgs e)
        {
            if (!Methods.IsCharacterVoiceInstalled())
            {
                MainForm.mf.ClickButtonIfActiveOnTweak();
                MainForm.mf.CloseForm(MainForm.cvForm);
            }                
        }

    }
}
