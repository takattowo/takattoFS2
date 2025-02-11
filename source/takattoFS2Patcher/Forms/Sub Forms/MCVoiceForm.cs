using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class MCVoiceForm : Form
    {
        public MCVoiceForm()
        {
            InitializeComponent();         
        }

        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl();         
            UpdateForm();          
        }

        private void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }
            //foreach (Control c in panelEx2.Controls)
            //{
            //    if (c.GetType() != typeof(Button))
            //        c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            //    if (c.GetType() == typeof(Button))
            //        c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            //}
            foreach (Control c in panelEx1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            

            lbMcVoiceHint.Text = StringLoader.GetText("tooltip_tweak_mvcoice_hint") + ":";
            //rdDefault.Text = StringLoader.GetText("lb_tweak_choice_default") + " ["+ StringLoader.GetText("btn_disable") + "]";
            rdDefault.Text = StringLoader.GetText("btn_disable");
            rdVie.Text = StringLoader.GetText("btn_tweak_mcvoice_choice_vietnamese");
            rdChine.Text = StringLoader.GetText("lb_tweak_choice_china");
            rdKor.Text = StringLoader.GetText("lb_tweak_choice_korea");
            rdFA.Text = StringLoader.GetText("btn_tweak_mcvoice_focust_assist");
            rdEng.Text = StringLoader.GetText("lb_tweak_choice_english");
            rdKustom.Text = StringLoader.GetText("lb_tweak_choice_custom");
            lbVersion.Text = StringLoader.GetText("btn_reinstall") + ":";
            //checkBox2.Text = StringLoader.GetText("btn_tweak_mcvoice_smart_language");
            //toolTip1.SetToolTip(checkBox2, StringLoader.GetText("tooltip_tweak_mcvoice_smart_language"));
            toolTip1.SetToolTip(button1, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(button2, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(button3, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(button4, StringLoader.GetText("tooltip_sample"));
            toolTip1.SetToolTip(button5, StringLoader.GetText("tooltip_sample"));
        }

        public void UpdateForm()
        {
            var vi = Methods.IsMCVoiceInstalled("vi");
            rdVie.Enabled = vi;
            button1.Visible = vi;

            var cn = Methods.IsMCVoiceInstalled("cn");
            rdChine.Enabled = cn;
            button2.Visible = cn;

            var kr = Methods.IsMCVoiceInstalled("kr");
            rdKor.Enabled = kr;
            button3.Visible = kr;

            var fa = Methods.IsMCVoiceInstalled("fa");
            rdFA.Enabled = fa;
            button4.Visible = fa;

            var en = Methods.IsMCVoiceInstalled("en");
            rdEng.Enabled = en;
            button6.Visible = en;

            var customTweak = Methods.IsMCVoiceInstalled("kat");
            rdKustom.Enabled = customTweak;
            button5.Visible = customTweak;
            if (!customTweak && rdKustom.Checked)
            {
                rdDefault.Checked = true;
            }

            var voiceIndex = UserSettings.MCVoiceLanguage;

            switch (voiceIndex)
            {
                case 0:
                    rdDefault.Checked = true;
                    break;
                case 1:
                    if (rdVie.Enabled)
                        rdVie.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 2:
                    if (rdChine.Enabled)
                        rdChine.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 3:
                    if (rdKor.Enabled)
                        rdKor.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 4:
                    if (rdFA.Enabled)
                        rdFA.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 5:
                    if (rdKustom.Enabled)
                        rdKustom.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                case 6:
                    if (rdEng.Enabled)
                        rdEng.Checked = true;
                    else
                        rdDefault.Checked = true;
                    break;
                default:
                    rdDefault.Checked = true;
                    break;
            }
            }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 3;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 4;
        }


        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 5;
        }

        private void rdEng_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.MCVoiceLanguage = 6;
        }

        WMPLib.WindowsMediaPlayer Player1;
        WMPLib.WindowsMediaPlayer Player2;
        WMPLib.WindowsMediaPlayer Player3;
        WMPLib.WindowsMediaPlayer Player4;
        WMPLib.WindowsMediaPlayer Player5;
        WMPLib.WindowsMediaPlayer Player6;
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveControl = null; 
            Player1 = new WMPLib.WindowsMediaPlayer();
            Player1.StatusChange += Player1_StatusChange;
            Player1.URL = Methods.IsMCVoiceSampleInstalled("vi");

            if (string.IsNullOrEmpty(Player1.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button1.Enabled = false;
            button1.BackgroundImage = Properties.Resources.icons8_pause_25;
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
                button1.Enabled = true;
                button1.BackgroundImage = Properties.Resources.icons8_play_25;
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
            Player2.URL = Methods.IsMCVoiceSampleInstalled("cn");

            if (string.IsNullOrEmpty(Player2.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button2.Enabled = false;
            button2.BackgroundImage = Properties.Resources.icons8_pause_25;

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
                button2.Enabled = true;
                button2.BackgroundImage = Properties.Resources.icons8_play_25;
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
            Player3.URL = Methods.IsMCVoiceSampleInstalled("kr");

            if (string.IsNullOrEmpty(Player3.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button3.Enabled = false;
            button3.BackgroundImage = Properties.Resources.icons8_pause_25;
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
                button3.Enabled = true;
                button3.BackgroundImage = Properties.Resources.icons8_play_25;
                Player3.URL = null;
                Player3.close();
                Marshal.FinalReleaseComObject(Player3);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player4 = new WMPLib.WindowsMediaPlayer();
            Player4.StatusChange += Player4_StatusChange; ;
            Player4.URL = Methods.IsMCVoiceSampleInstalled("fa");

            if (string.IsNullOrEmpty(Player4.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button4.Enabled = false;
            button4.BackgroundImage = Properties.Resources.icons8_pause_25;

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
                button4.Enabled = true;
                button4.BackgroundImage = Properties.Resources.icons8_play_25;
                Player4.URL = null;
                Player4.close();
                Marshal.FinalReleaseComObject(Player4);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player5 = new WMPLib.WindowsMediaPlayer();
            Player5.StatusChange += Player5_StatusChange;
            Player5.URL = Methods.IsMCVoiceSampleInstalled("kat");

            if (string.IsNullOrEmpty(Player5.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button5.Enabled = false;
            button5.BackgroundImage = Properties.Resources.icons8_pause_25;

            try
            {
                Player5.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }
        private void Player5_StatusChange()
        {
            if (Player5.status == "Finished")
            {
                button5.Enabled = true;
                button5.BackgroundImage = Properties.Resources.icons8_play_25;
                Player5.URL = null;
                Player5.close();
                Marshal.FinalReleaseComObject(Player5);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            Player6 = new WMPLib.WindowsMediaPlayer();
            Player6.StatusChange += Player6_StatusChange;
            Player6.URL = Methods.IsMCVoiceSampleInstalled("en");

            if (string.IsNullOrEmpty(Player6.URL))
            {
                MsgBoxs.Warning.NoSampleSoundExist(MainForm.mf);
                return;
            }

            button6.Enabled = false;
            button6.BackgroundImage = Properties.Resources.icons8_pause_25;

            try
            {
                Player6.controls.play();
            }
            catch
            {
                MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
            }
        }

        private void Player6_StatusChange()
        {
            if (Player6.status == "Finished")
            {
                button6.Enabled = true;
                button6.BackgroundImage = Properties.Resources.icons8_play_25;
                Player6.URL = null;
                Player6.close();
                Marshal.FinalReleaseComObject(Player6);
            }
        }

        private void dlcCheck_Tick(object sender, EventArgs e)
        {
            if (!Methods.IsMCVoiceInstalled())
            {
                MainForm.mf.ClickButtonIfActiveOnTweak();
                MainForm.mf.CloseForm(MainForm.mcForm);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            var confirmResult = MsgBoxs.Dialog.Reinstall(MainForm.mf);
            if (confirmResult == DialogResult.Yes)
            {
                MainForm.mf.InstallDLC6();
            }
        }
    }
}
