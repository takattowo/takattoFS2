using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class MiscForm : Form
    {
        public MiscForm()
        {
            InitializeComponent(); 
        }
        
        
        public void CheckEnable()
        {
            glassyPanel1.Visible = !UserSettings.CustomSetting;
            if (!UserSettings.CustomSetting)
            {
                ActiveControl = lbMiscHint1;
                txtH.TabStop = false;
                txtW.TabStop = false;
            }
            else
            {
                txtH.TabStop = true;
                txtW.TabStop = true;
            }
        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            oldH = panelEx4.Height;
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            foreach (Control c in panelEx2.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            cbAFK.Checked = UserSettings.AKFTweakSetting;
            cbCleanLog.Checked = UserSettings.GameLogCleannerEnabled;
            cbCopy.Checked = UserSettings.Shortcut;

            lbMiscHint1.Checked = UserSettings.CustomSetting;

            lbMiscHint1.Text = StringLoader.GetText("tooltip_tweak_misc_hint1") + ":";
            lbMiscHint2.Text = StringLoader.GetText("tooltip_tweak_misc_hint2") + ":";
            txtW.PlaceHolderText = StringLoader.GetText("text_width");
            txtH.PlaceHolderText = StringLoader.GetText("text_height");

            cbCopy.Text = StringLoader.GetText("btn_tweak_mist_shortcut_enable");
            cbCleanLog.Text = StringLoader.GetText("btn_tweak_misc_log_clean");
            cbAFK.Text = StringLoader.GetText("btn_tweak_mist_afk_prevention");
            lbIntervalAFK.Text = StringLoader.GetText("lb_tweak_misc_afk_interval_hint") + ":";
            checkBox1.Text = StringLoader.GetText("btn_tweak_mcvoice_font");
            toolTip1.SetToolTip(checkBox1, StringLoader.GetText("tooltip_tweak_mcvoice_font"));
            toolTip1.SetToolTip(btnInterval, StringLoader.GetText("lb_tweak_misc_afk_interval_hint"));
            toolTip1.SetToolTip(txtT, StringLoader.GetText("tooltip_tweak_misc_afk_interval_hint"));
            toolTip1.SetToolTip(cbCleanLog, StringLoader.GetText("tooltip_tweak_misc_log_clean"));
            toolTip1.SetToolTip(cbAFK, StringLoader.GetText("tooltip_tweak_misc_afk_interval"));
            toolTip1.SetToolTip(cbCopy, StringLoader.GetText("tooltip_tweak_misc_shortcut"));

            txtW.removePlaceHolder(null, null);
            txtH.removePlaceHolder(null, null);
            txtT.removePlaceHolder(null, null);
            txtW.Text = UserSettings.GameWidth.ToString();
            txtH.Text = UserSettings.GameHeight.ToString();
            txtT.Text = UserSettings.AFKTweakInterval.ToString();

            txtW.TextChanged += new System.EventHandler(txtH_TextChanged);
            txtH.TextChanged += new System.EventHandler(txtH_TextChanged);

            txtW.SelectionStart = txtW.Text.Length;
            txtW.DeselectAll();
        }

        private void ResSettingForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            CheckEnable();
            txtH.ContextMenu = new ContextMenu();
            txtW.ContextMenu = new ContextMenu();
            txtT.ContextMenu = new ContextMenu();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
        //        HandleHotkey();
        //    base.WndProc(ref m);
        //}

        //private void HandleHotkey()
        //{
        //    var text = Clipboard.GetText();
        //    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessesByName(Strings.Misc.GameProcessName).FirstOrDefault();
        //    if (p != null)
        //    {
        //        IntPtr h = p.MainWindowHandle;
        //        NativeMethods.SetForegroundWindow(h);
        //        if(!string.IsNullOrEmpty(text))
        //        {
        //            try
        //            {
        //                SendKeys.SendWait("^v");
        //            }
        //            catch { }
        //        }              
        //    }
        //}

        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // && (e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        public void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtW.Text))
            {
                txtW.Text = "0";
                txtW.SelectionStart = txtW.Text.Length;
                txtW.SelectionLength = 0;
            }

            if (string.IsNullOrWhiteSpace(txtH.Text))
            {
                txtH.Text = "0";
                txtH.SelectionStart = txtH.Text.Length;
                txtH.SelectionLength = 0;
            }
            
            if (!Methods.CheckIfNumberValid(txtW.Text))
            {
                txtW.removePlaceHolder(null, null);
                txtW.Text = UserSettings.GameWidth.ToString();
                txtW.SelectionStart = txtW.Text.Length;
                txtW.SelectionLength = 0;
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                return;
            }

            if (!Methods.CheckIfNumberValid(txtH.Text))
            {
                txtH.removePlaceHolder(null, null);
                txtH.Text = UserSettings.GameHeight.ToString();
                txtH.SelectionStart = txtW.Text.Length;
                txtW.SelectionLength = 0;
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                return;
            }

            UserSettings.GameWidth = int.Parse(txtW.Text);
            UserSettings.GameHeight = int.Parse(txtH.Text);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (!cbAFK.Checked)
                cbAFK.CheckState = CheckState.Indeterminate;
            else
                cbAFK.Checked = false;

            UserSettings.AKFTweakSetting = cbAFK.Checked; 
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (!cbCleanLog.Checked)
                cbCleanLog.CheckState = CheckState.Indeterminate;
            else
                cbCleanLog.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAFK.Checked)
            {
                cbAFK.CheckState = CheckState.Indeterminate;
            }
            UserSettings.AKFTweakSetting = cbAFK.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleanLog.Checked)
            {
                cbCleanLog.CheckState = CheckState.Indeterminate;
            }

            UserSettings.GameLogCleannerEnabled = cbCleanLog.Checked;
        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {
            btn_dlc1_red_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isExpanding)
                return;

            if (isExpanded)
            {
                int newInterval = 40;
                try
                {
                    newInterval = Int32.Parse(txtT.Text);
                }
                catch
                {
                    newInterval = 40;
                    MsgBoxs.Warning.InvalidAFKTInterval(MainForm.mf);
                    return;
                }

                if (newInterval >= 10 && newInterval <= 55)
                {
                    UserSettings.AFKTweakInterval = newInterval;
                }
                else
                {
                    MsgBoxs.Warning.InvalidAFKTInterval(MainForm.mf);
                    return;
                }
            }

            isExpanding = true;
            timer1.Start();
        }

        bool isExpanding = false;
        bool isExpanded = false;
        int oldH;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int maxh = txtH.Height;
            if(isExpanding)
            {
                if (!isExpanded)
                {
                    panelEx4.Height += maxh / 8;
                    if (panelEx4.Height >= oldH + maxh + (maxh / 2))
                    {
                        isExpanding = false;
                        isExpanded = true;
                        txtT.Enabled = true;
                        btnInterval.BackgroundImage = Properties.Resources.icons8_repeat_35_r;
                        timer1.Stop();
                    }
                }
                else
                {
                    panelEx4.Height -= maxh / 8;
                    if (panelEx4.Height <= oldH)
                    {
                        panelEx4.Height = oldH; 
                        isExpanding = false;
                        isExpanded = false;
                        txtT.Enabled = false;
                        btnInterval.BackgroundImage = Properties.Resources.icons8_repeat_35_b;
                        timer1.Stop();
                    }
                }
            }         
        }

        private void txtT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&& (e.KeyChar != '.')
                e.Handled = true;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (!cbCopy.Checked)
                cbCopy.CheckState = CheckState.Indeterminate;
            else
                cbCopy.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCopy.Checked)
            {
                cbCopy.CheckState = CheckState.Indeterminate;
            }

            UserSettings.Shortcut = cbCopy.Checked;
            MainForm.mf.ShortcutEnabler();
        }

        private void checkBox1_Click_1(object sender, EventArgs e)
        {
            //CardViewerTweakRadioBtn.Checked = !CardViewerTweakRadioBtn.Checked;

            if (Methods.IsGameRunning_Alt())
                return;
            
            if (!checkBox1.Checked)
                checkBox1.CheckState = CheckState.Indeterminate;
            else
                checkBox1.Checked = false;

            UserSettings.GameFontSetting = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.CheckState = CheckState.Indeterminate;
            }
        }


        bool firstime = true;
        private void customFontCheck_Tick_1(object sender, EventArgs e)
        {
            if (firstime)
            {
                firstime = false;
                customFontCheck.Interval = 2000;
            }
            if (Methods.IsFontInstalled())
            {
                checkBox1.Checked = UserSettings.GameFontSetting;
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }
        }

        private void lbMiscHint1_Click(object sender, EventArgs e)
        {
            if (Methods.IsGameRunning_Alt())
                return;

            if (!lbMiscHint1.Checked)
                lbMiscHint1.CheckState = CheckState.Indeterminate;
            else
                lbMiscHint1.Checked = false;

            UserSettings.CustomSetting = lbMiscHint1.Checked;
            CheckEnable();
        }

        private void lbMiscHint1_CheckedChanged(object sender, EventArgs e)
        {
            if (lbMiscHint1.Checked)
            {
                lbMiscHint1.CheckState = CheckState.Indeterminate;
            }
        }
    }
}
