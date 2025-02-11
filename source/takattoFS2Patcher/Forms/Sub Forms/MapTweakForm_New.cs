using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;
using takattoFS2.Controls.Models;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class MapTweakForm_New : Form
    {
        public MapTweakForm_New()
        {
            InitializeComponent();
        }
        
        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            GetCourtSetting(); 
            SetSelect();

            SetSelectCustom();
            UpdateForm();
        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            int style2 = NativeMethods.GetWindowLong(panel2.Handle, NativeMethods.GWL_EXSTYLE);
            style2 |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel2.Handle, NativeMethods.GWL_EXSTYLE, style2);
            
            oldH = panelEx5.Height;
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }
            foreach (Control c in panelEx1.Controls)
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
            foreach (Control c in panelEx3.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }
            foreach (Control c in panelEx4.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);

                c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }
            foreach (Control c in panel2.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            btnBack.Font = MemoryFonts.SetFont(0, btnBack.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btnConfig.Font = MemoryFonts.SetFont(0, btnConfig.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            btnBack.Text = StringLoader.GetText("btn_back");
            toolTip1.SetToolTip(btnBack, StringLoader.GetText("tooltip_tweak_map_back"));
            btnConfig.Text = StringLoader.GetText("btn_config");
            toolTip1.SetToolTip(btnConfig, StringLoader.GetText("tooltip_tweak_map_config"));
            lbMapHint.Text = StringLoader.GetText("tooltip_tweak_map_hint") + ":";

            radioButton9.Text = StringLoader.GetText("btn_disable");
            //radioButton9.Text = StringLoader.GetText("lb_tweak_choice_default") + " [" + StringLoader.GetText("btn_disable") + "]";
            defa.Text = radioButton9.Text;
            toolTip1.SetToolTip(defa, StringLoader.GetText("tooltip_disable"));

            courtTrainingTweakRadioBtn.Text = StringLoader.GetText("btn_tweak_map_choice_training");
            radioButton10.Text = courtTrainingTweakRadioBtn.Text;
            toolTip1.SetToolTip(courtTrainingTweakRadioBtn, StringLoader.GetText("tooltip_tweak_map_choice_training"));
            
            radioButton12.Text = StringLoader.GetText("btn_tweak_map_choice_katto");
            courtTakaTweakRadioBtn.Text = radioButton12.Text;
            toolTip1.SetToolTip(courtTakaTweakRadioBtn, StringLoader.GetText("tooltip_tweak_map_choice_katto"));
            
            courtTournyTweakRadioBtn.Text = StringLoader.GetText("btn_tweak_map_choice_beach");
            radioButton14.Text = courtTournyTweakRadioBtn.Text;
            toolTip1.SetToolTip(courtTournyTweakRadioBtn, StringLoader.GetText("tooltip_tweak_map_choice_beach"));

            radioButton13.Text = StringLoader.GetText("btn_tweak_map_choice_warehouse");
            courtHiddenTweakRadioBtn.Text = radioButton13.Text;
            toolTip1.SetToolTip(courtHiddenTweakRadioBtn, StringLoader.GetText("tooltip_tweak_map_choice_warehouse"));
            
            courtCustom.Text = StringLoader.GetText("lb_tweak_choice_custom");
            radioButton11.Text = courtCustom.Text;
            toolTip1.SetToolTip(courtCustom, StringLoader.GetText("tooltip_tweak_map_choice_custom"));
            
            radioButton8.Text = StringLoader.GetText("btn_tweak_map_choice_default_map");
            defaultCourtmRad.Text = radioButton8.Text; 
            toolTip1.SetToolTip(defaultCourtmRad, StringLoader.GetText("tooltip_tweak_map_choice_default_map"));

            stage00install.Text = StringLoader.GetText("btn_install");
            stage06install.Text = StringLoader.GetText("btn_install");
            stage12install.Text = StringLoader.GetText("btn_install");
            stage13install.Text = StringLoader.GetText("btn_install");
            defaultinstall.Text = StringLoader.GetText("btn_install");
        }

        bool everythingisDONE = false;
        private void courtTrainingTweakRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            cbDefaultCourtTweak.Enabled = defaultCourtmRad.Checked;
            var rb = (sender as RadioButton);
            if (rb != null && rb.Checked && !rb.Enabled)
                defa_Click(null, null);//defa.PerformClick();

            if (defa.Checked)
                MainForm.mf.CourtMap = 0;
            if (courtTrainingTweakRadioBtn.Checked)
                MainForm.mf.CourtMap = 1;
            if (courtTakaTweakRadioBtn.Checked)
                MainForm.mf.CourtMap = 2;
            if (courtTournyTweakRadioBtn.Checked)
                MainForm.mf.CourtMap = 3;
            if (courtHiddenTweakRadioBtn.Checked)
                MainForm.mf.CourtMap = 4;
            if (courtCustom.Checked)
                MainForm.mf.CourtMap = 5;
            if (defaultCourtmRad.Checked)
                MainForm.mf.CourtMap = 6;

            if (MainForm.mf.CourtMap >= 1)
            {
                if (!Methods.IsGameRunning_Alt())
                {
                    if(!File.Exists(Methods.GetFolder("temp_" + Strings.FileName.StageData)))
                        if (File.Exists(Methods.GetFolder(Strings.FileName.StageData)))
                            File.Copy(Methods.GetFolder(Strings.FileName.StageData), Methods.GetFolder("temp_" + Strings.FileName.StageData), true);
                }
            }
            else
            {
                try
                {
                    File.Copy(Methods.GetFolder("temp_" + Strings.FileName.StageData), Methods.GetFolder(Strings.FileName.StageData), true);
                }
                catch { }
            }

            if (Methods.IsGameRunning_Alt() && everythingisDONE)
            {
                MainForm.mf.lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help_load_replay");
                MainForm.mf.MapTweak();
            }
                
            if (!defa.Checked && !courtCustom.Checked && !courtTrainingTweakRadioBtn.Checked && !courtTakaTweakRadioBtn.Checked && !courtTournyTweakRadioBtn.Checked && !courtHiddenTweakRadioBtn.Checked && !defaultCourtmRad.Checked)
                defa.Checked = true;
        }

        void CheckforDLC()
        {
            CheckCourtDLC_New(courtTrainingTweakRadioBtn, 1, Strings.KattoFileName.DLC1Training_Blue, Strings.KattoFileName.DLC1Training_Red, Strings.KattoFileName.DLC1Training_Dark, Strings.KattoFileName.DLC1Training_Green);
            CheckCourtDLC_New(courtTakaTweakRadioBtn, 2, Strings.KattoFileName.DLC1Katto_Night, Strings.KattoFileName.DLC1Katto_Sunny);
            CheckCourtDLC_New(courtTournyTweakRadioBtn, 3, Strings.KattoFileName.DLC1Beach_Default, Strings.KattoFileName.DLC1Beach_New);
            CheckCourtDLC_New(courtHiddenTweakRadioBtn, 4, Strings.KattoFileName.DLC1Warehouse_Default);
            //CheckCourtDLC_New(courtCustom, 5, Strings.KattoFileName.DLC1Custom);

            CheckCourtDLC_Custom_New(btn_dlc1_custom0, 100, String.Format(Strings.KattoFileName.DLC1Custom, 0));
            CheckCourtDLC_Custom_New(btn_dlc1_custom1, 101, String.Format(Strings.KattoFileName.DLC1Custom, 1));
            CheckCourtDLC_Custom_New(btn_dlc1_custom2, 102, String.Format(Strings.KattoFileName.DLC1Custom, 2));
            CheckCourtDLC_Custom_New(btn_dlc1_custom3, 103, String.Format(Strings.KattoFileName.DLC1Custom, 3));
            CheckCourtDLC_Custom_New(btn_dlc1_custom4, 104, String.Format(Strings.KattoFileName.DLC1Custom, 4));
            if (btn_dlc1_custom0.Enabled || btn_dlc1_custom1.Enabled || btn_dlc1_custom2.Enabled || btn_dlc1_custom3.Enabled || btn_dlc1_custom4.Enabled)
            {
                courtCustom.Enabled = true;
                if (MainForm.mf.CourtMap == 5)
                    if(!courtCustom.Checked)
                        courtCustom.PerformClick();
            }
            else
            {
                MainForm.mf.stage_custom = 100;
                courtCustom.Enabled = false;
                if (MainForm.mf.CourtMap == 5)
                    if (!defa.Checked)
                        defa_Click(null, null);//defa.PerformClick();
            }

        }

        public void UpdateComboBox()
        {
            cbDefaultCourtTweak.Items.Clear();
            cbDefaultCourtTweak.Items.AddRange(Methods.PopulateDLC1Combobox().Items.Cast<Object>().ToArray());
            cbDefaultCourtTweak.SelectedIndex = 0;

            if (cbDefaultCourtTweak.Items.Count >= 2)            
            {
                defaultCourtmRad.Enabled = true;
                if (MainForm.mf.CourtMap == 6)
                    defaultCourtmRad.PerformClick();

                if (MainForm.mf != null)
                    cbDefaultCourtTweak.SelectedIndex = MainForm.mf.cbDefaultCourtTweak.SelectedIndex;

                defaultinstall.Visible = false;
            }
            else
            {
                defaultCourtmRad.Enabled = false;
                defaultCourtmRad.Checked = false;

                defaultinstall.Visible = true;
            }
        }

        void CheckCourtDLC_Custom_New(Button btn, int wi, params string[] _list)
        {
            for (int i = 0; i < _list.Length; i++)
            {
                if (!File.Exists(Methods.GetFolder(Strings.FolderName.DLC1, _list[i])))
                {
                    btn.Enabled = false;
                    btn.Visible = false;
                    return;
                }
            }

            btn.Enabled = true;
            btn.Visible = true;
        }

        void CheckCourtDLC_New(RadioButton rdBtn, int wi, params string[] _list)
        {
            for (int i = 0; i < _list.Length; i++)
            {
                if (!File.Exists(Methods.GetFolder(Strings.FolderName.DLC1, _list[i])))
                {
                    SetVisible(wi, false);
                    rdBtn.Enabled = false;
                    rdBtn.Checked = false;
                    return;
                }
            }

            rdBtn.Enabled = true;
            SetVisible(wi, true);
            
            if (MainForm.mf.CourtMap == wi)
                if (!rdBtn.Checked)
                {
                    //MessageBox.Show(rdBtn.Text);
                    rdBtn.PerformClick();
                }
        }

        void SetVisible(int id, bool visible)
        {
            switch (id)
            {
                case 1:
                    stage00install.Visible = !visible;
                    btn_dlc1_00dark.Visible = visible;
                    btn_dlc1_00blue.Visible = visible;
                    btn_dlc1_00green.Visible = visible;
                    btn_dlc1_00red.Visible = visible;
                    break;
                case 2:
                    stage12install.Visible = !visible;
                    btn_dlc1_12sunny.Visible =  visible;
                    btn_dlc1_12night.Visible =   visible; 
                    break;
                case 3:
                    stage13install.Visible = !visible;
                    btn_dlc1_13default.Visible = visible;
                    btn_dlc1_13s3x3.Visible = visible;
                    break;
                case 4:
                    stage06install.Visible = !visible;
                    btn_dlc1_06default.Visible = visible;
                    break;
                case 5:
                    btn_dlc1_custom0.Visible = visible;
                    break;
            }
        }
        
        public void UpdateForm()
        {
            CheckforDLC();
            UpdateComboBox();

            if (!defa.Checked && !courtCustom.Checked 
                && !courtTrainingTweakRadioBtn.Checked 
                && !courtTakaTweakRadioBtn.Checked 
                && !courtTournyTweakRadioBtn.Checked 
                && !courtHiddenTweakRadioBtn.Checked 
                && !defaultCourtmRad.Checked)
                defa.Checked = true;

            everythingisDONE = true;
            
            if (cbDefaultCourtTweak.Items.Count >= 2)
            {
                if(MainForm.mf != null)
                    cbDefaultCourtTweak.SelectedIndex = MainForm.mf.cbDefaultCourtTweak.SelectedIndex;
            }
        }

        void GetCourtSetting()
        {
            MainForm.mf.MapSetting();
        }

        void ShowCourt(string st)
        {
            ActiveControl = null;
            var uri = string.Format(Urls.PictureFormat, StringTheory.Universal.AssetRootUri, st);          
            Help_CourtTakatto helpCourtdemo = new Help_CourtTakatto(uri, false, false);
            //helpCourtdemo.ShowDialog(this);
            //helpCourtdemo.Dispose();

            helpCourtdemo.Owner = this;
            helpCourtdemo.ShowInTaskbar = false;
            helpCourtdemo.ShowDialog();
            helpCourtdemo.Dispose();
        }

        private void lbQuestionMarkCourtTraining_Click(object sender, EventArgs e)
        {
            ShowCourt(Strings.KattoFileName.DLC1TrainingIMG);
        }

        private void lbQuestionMarkCourtTakatto_Click(object sender, EventArgs e)
        {
            ShowCourt(Strings.KattoFileName.DLC1KattoIMG);
        }

        private void lbQuestionMarkCourtTourny_Click(object sender, EventArgs e)
        {
            ShowCourt(Strings.KattoFileName.DLC1BeachIMG);
        }

        private void lbdefaultCourtmRad_Click(object sender, EventArgs e)
        {
            ShowCourt(Strings.KattoFileName.DLC1DefaultIMG);
        }

        private void lbQuestionMarkCourtHidden_Click(object sender, EventArgs e)
        {
            ShowCourt(Strings.KattoFileName.DLC1WarehousehIMG);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            //panel2.Enabled = false;
            //panel2.SendToBack();
            //panel1.Enabled = true;
            //panel2.BringToFront();
            ////checkInstalleDLC.Stop();
            ///
            panel2.Visible = false;
            panel2.SendToBack();
        }

        private void btn_gamekill_Click(object sender, EventArgs e)
        {
            //ActiveControl = null; 
            //panel1.Enabled = false;
            //panel1.SendToBack();
            //panel2.Enabled = true;
            //panel2.BringToFront();
            //checkWhichMapInstellad();
            //CheckWhichSelectedMap();
            //checkInstalleDLC.Start();

            ActiveControl = null;
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void checkInstalleDLC_Tick(object sender, EventArgs e)
        {
            timeOutSkipCheck.Stop();
            justCheckPlease = false;
        }

        private void btn_dlc1_def_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            var confirmResult = MsgBoxs.Dialog.Reinstall(MainForm.mf);
            if (confirmResult == DialogResult.Yes)
            {
                MainForm.mf.isTweakDownloading = true;
                MainForm.mf.isDefaMapDownloading = true;
                Methods.DownloadFile(Urls.DLC1DefaultCourt, Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, "DLC1_Default"), Methods.GetGameFolder());
            }
        }

        private void cbDefaultCourtTweak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(everythingisDONE)
            {
                if(MainForm.mf != null)
                {
                    MainForm.mf.cbDefaultCourtTweak.SelectedIndex = cbDefaultCourtTweak.SelectedIndex;
                    if (Methods.IsGameRunning_Alt())
                    {
                        MainForm.mf.lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help_load_replay");
                        MainForm.mf.MapTweak();
                    }                        
                }              
            }             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int maxh = cbDefaultCourtTweak.Height;
            cbDefaultCourtTweak.Visible = true;
            panelEx5.Height += 2;
            if (panelEx5.Height >= oldH + maxh + (maxh/2))
            {
                timer1.Stop();
            }
        }

        int oldH = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3Delay.Start();
            //if (panelEx5.Width >= ((MainForm.mf.tableLayoutPanel2.Width) * 48) / 100)
            //{
            //    timer2.Stop();
            //    timer3Delay.Start();
            //}
        }

        private void timer3Delay_Tick(object sender, EventArgs e)
        {
            timer3Delay.Stop();
            timer1.Start();
        }

        private void defa_Click(object sender, EventArgs e)
        {
            //if (everythingisDONE)
            //    MessageBox.Show(sender.ToString());

            if (!defa.Enabled)
                return;

            defa.Checked = true;
            courtTrainingTweakRadioBtn.Checked = false;
            courtTakaTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false;
            courtHiddenTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            courtCustom.Checked = false; //added
        }

        private void courtTrainingTweakRadioBtn_Click(object sender, EventArgs e)
        {
            if (!courtTrainingTweakRadioBtn.Enabled)
                return;

            courtTrainingTweakRadioBtn.Checked = true;
            courtTakaTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false;
            courtHiddenTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            defa.Checked = false;
            courtCustom.Checked = false;
        }

        private void courtTakaTweakRadioBtn_Click(object sender, EventArgs e)
        {
            if (!courtTakaTweakRadioBtn.Enabled)
                return;

            courtTakaTweakRadioBtn.Checked = true;
            courtTrainingTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false;
            courtHiddenTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            defa.Checked = false;
            courtCustom.Checked = false;
        }

        private void courtTournyTweakRadioBtn_Click(object sender, EventArgs e)
        {
            if (!courtTournyTweakRadioBtn.Enabled)
                return;

            courtTournyTweakRadioBtn.Checked = true;
            courtTakaTweakRadioBtn.Checked = false;
            courtTrainingTweakRadioBtn.Checked = false;
            courtHiddenTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            defa.Checked = false;
            courtCustom.Checked = false;
        }

        private void courtHiddenTweakRadioBtn_Click(object sender, EventArgs e)
        {
            if (!courtHiddenTweakRadioBtn.Enabled)
                return;

            courtHiddenTweakRadioBtn.Checked = true;
            courtTakaTweakRadioBtn.Checked = false;
            courtTrainingTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            defa.Checked = false;
            courtCustom.Checked = false;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            if (!courtCustom.Enabled)
                return;

            courtCustom.Checked = true;
            courtTrainingTweakRadioBtn.Checked = false;
            courtTakaTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false;
            courtHiddenTweakRadioBtn.Checked = false; //added
            defaultCourtmRad.Checked = false; //added
            defa.Checked = false; //added
        }

        private void defaultCourtmRad_Click(object sender, EventArgs e)
        {
            if (!defaultCourtmRad.Enabled)
                return;

            MainForm.mf.CourtMap = 6;
            defaultCourtmRad.Checked = true;
            courtTakaTweakRadioBtn.Checked = false;
            courtTrainingTweakRadioBtn.Checked = false;
            courtTournyTweakRadioBtn.Checked = false; //added
            courtHiddenTweakRadioBtn.Checked = false; //added
            defa.Checked = false;
            courtCustom.Checked = false;
        }

        private void cbDefaultCourtTweak_DropDownClosed(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        bool justCheckPlease = false;
        
        internal void ForceUpdate()
        {
            justCheckPlease = true;
            timeOutSkipCheck.Start();
        }

        //bool ay; //temporary fix for the bug lmao
        private void timer3_Tick(object sender, EventArgs e)
        {
            if(!Methods.IsGameRunning_Alt() && everythingisDONE)
            {
                CheckforDLC();
            }         
            else if(Methods.IsGameRunning_Alt() && justCheckPlease) { CheckforDLC(); }

            //if (!ay)
            //{
            //    ay = true;
            //    //this.defa.Click += new System.EventHandler(this.defa_Click);
            //}
            
        }
        private void stage0install_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            MainForm.mf.CourtDownload(Urls.DLC1Stage00);
        }

        private void stage12install_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            //if (Methods.AlertIfGameIsRunning(MainForm.mf))
            //    return;

            MainForm.mf.CourtDownload(Urls.DLC1Stage12);
        }

        private void stage13install_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            //if (Methods.AlertIfGameIsRunning(MainForm.mf))
            //    return;

            MainForm.mf.CourtDownload(Urls.DLC1Stage13);
        }

        private void stage06install_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            //if (Methods.AlertIfGameIsRunning(MainForm.mf))
            //    return;

            MainForm.mf.CourtDownload(Urls.DLC1Stage06);
        }

        void TweakIt()
        {
            MainForm.mf.lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help_load_replay");
            MainForm.mf.MapTweak();
        }

        string tick = "✔";
       

        public void SetSelect()
        {
            btn_dlc1_00green.Text = MainForm.mf.stage00_green ? tick : string.Empty;
            btn_dlc1_00blue.Text = MainForm.mf.stage00_blue ? tick : string.Empty;
            btn_dlc1_00red.Text = MainForm.mf.stage00_red ? tick : string.Empty;
            btn_dlc1_00dark.Text = MainForm.mf.stage00_dark ? tick : string.Empty;

            btn_dlc1_12sunny.Text = MainForm.mf.stage12_sunny ? tick : string.Empty;
            btn_dlc1_12night.Text = MainForm.mf.stage12_night ? tick : string.Empty;

            btn_dlc1_13default.Text = MainForm.mf.stage13_default ? tick : string.Empty;
            btn_dlc1_13s3x3.Text = MainForm.mf.stage13_3x3 ? tick : string.Empty;

            btn_dlc1_06default.Text = MainForm.mf.stage06_default ? tick : string.Empty;
            btn_dlc1_06new.Text = MainForm.mf.stage06_new ? tick : string.Empty;     
        }

        public void SetSelectCustom()
        {
            switch (MainForm.mf.stage_custom)
            {
                case 100:
                    btn_dlc1_custom0.Text = tick;
                    btn_dlc1_custom1.Text = string.Empty;
                    btn_dlc1_custom2.Text = string.Empty;
                    btn_dlc1_custom3.Text = string.Empty;
                    btn_dlc1_custom4.Text = string.Empty;
                    break;
                case 101:
                    if (btn_dlc1_custom1.Enabled)
                    {
                        btn_dlc1_custom0.Text = string.Empty;
                        btn_dlc1_custom1.Text = tick;
                        btn_dlc1_custom2.Text = string.Empty;
                        btn_dlc1_custom3.Text = string.Empty;
                        btn_dlc1_custom4.Text = string.Empty;
                    }
                    else
                    {
                        MainForm.mf.stage_custom = 100;
                        SetSelectCustom();
                    }
                    
                    break;
                case 102:
                    if (btn_dlc1_custom2.Enabled)
                    {
                        btn_dlc1_custom0.Text = string.Empty;
                        btn_dlc1_custom1.Text = string.Empty;
                        btn_dlc1_custom2.Text = tick;
                        btn_dlc1_custom3.Text = string.Empty;
                        btn_dlc1_custom4.Text = string.Empty;
                    }
                    else
                    {
                        MainForm.mf.stage_custom = 100;
                        SetSelectCustom();
                    }
                    break;
                case 103:
                    if (btn_dlc1_custom3.Enabled)
                    {
                        btn_dlc1_custom0.Text = string.Empty;
                        btn_dlc1_custom1.Text = string.Empty;
                        btn_dlc1_custom2.Text = string.Empty;
                        btn_dlc1_custom3.Text = tick;
                        btn_dlc1_custom4.Text = string.Empty;
                    }
                    else
                    {
                        MainForm.mf.stage_custom = 100;
                        SetSelectCustom();
                    }
                    break;
                case 104:
                    if (btn_dlc1_custom4.Enabled)
                    {
                        btn_dlc1_custom0.Text = string.Empty;
                        btn_dlc1_custom1.Text = string.Empty;
                        btn_dlc1_custom2.Text = string.Empty;
                        btn_dlc1_custom3.Text = string.Empty;
                        btn_dlc1_custom4.Text = tick;
                    }
                    else
                    {
                        MainForm.mf.stage_custom = 100;
                        SetSelectCustom();
                    }
                    break;
            }
        }

        private void btn_dlc1_00green_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage00_green = true;

            MainForm.mf.stage00_blue = false;

            MainForm.mf.stage00_red = false;

            MainForm.mf.stage00_dark = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();

            if (courtTrainingTweakRadioBtn.Enabled)
            {
                if (!courtTrainingTweakRadioBtn.Checked)
                    courtTrainingTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTrainingTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_00blue_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage00_green = false;

            MainForm.mf.stage00_blue = true;

            MainForm.mf.stage00_red = false;

            MainForm.mf.stage00_dark = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();

            if (courtTrainingTweakRadioBtn.Enabled)
            {
                if (!courtTrainingTweakRadioBtn.Checked)
                    courtTrainingTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTrainingTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_00red_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage00_green = false;

            MainForm.mf.stage00_blue = false;

            MainForm.mf.stage00_red = true;

            MainForm.mf.stage00_dark = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();


            if (courtTrainingTweakRadioBtn.Enabled)
            {
                if (!courtTrainingTweakRadioBtn.Checked)
                    courtTrainingTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTrainingTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_00dark_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage00_green = false;

            MainForm.mf.stage00_blue = false;

            MainForm.mf.stage00_red = false;

            MainForm.mf.stage00_dark = true;

            SetSelect();
            MainForm.mf.SaveCourtSettings();
            
            if (courtTrainingTweakRadioBtn.Enabled)
            {
                if (!courtTrainingTweakRadioBtn.Checked)
                    courtTrainingTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTrainingTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_12sunny_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage12_sunny = true;

            MainForm.mf.stage12_night = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();
            
            if (courtTakaTweakRadioBtn.Enabled)
            {
                if (!courtTakaTweakRadioBtn.Checked)
                    courtTakaTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTakaTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_12night_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage12_sunny = false;

            MainForm.mf.stage12_night = true;

            SetSelect();
            MainForm.mf.SaveCourtSettings();

            if (courtTakaTweakRadioBtn.Enabled)
            {
                if (!courtTakaTweakRadioBtn.Checked)
                    courtTakaTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTakaTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_13tourny_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage13_default = true;

            MainForm.mf.stage13_3x3 = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();
            
            if (courtTournyTweakRadioBtn.Enabled)
            {
                if (!courtTournyTweakRadioBtn.Checked)
                    courtTournyTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTournyTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_13s3x3_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage13_default = false;

            MainForm.mf.stage13_3x3 = true;

            SetSelect();
            MainForm.mf.SaveCourtSettings();
            
            if(courtTournyTweakRadioBtn.Enabled)
            {
                if (!courtTournyTweakRadioBtn.Checked)
                    courtTournyTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtTournyTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_06new_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage06_new = true;

            MainForm.mf.stage06_default = false;

            SetSelect();
            MainForm.mf.SaveCourtSettings();

            if (courtHiddenTweakRadioBtn.Enabled)
            {
                if (!courtHiddenTweakRadioBtn.Checked)
                    courtHiddenTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtHiddenTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_06default_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage06_new = false;

            MainForm.mf.stage06_default = true;

            SetSelect();
            MainForm.mf.SaveCourtSettings();

            if (courtHiddenTweakRadioBtn.Enabled)
            {
                if (!courtHiddenTweakRadioBtn.Checked)
                    courtHiddenTweakRadioBtn.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
            //if (courtHiddenTweakRadioBtn.Checked && Methods.IsGameRunning_Alt() && everythingisDONE) TweakIt();
        }

        private void btn_dlc1_custom_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage_custom = 100;

            SetSelectCustom();

            if (courtCustom.Enabled)
            {
                if (!courtCustom.Checked)
                    courtCustom.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
        }

        private void btn_dlc1_custom1_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage_custom = 101;

            SetSelectCustom();

            if (courtCustom.Enabled)
            {
                if (!courtCustom.Checked)
                    courtCustom.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
        }

        private void btn_dlc1_custom2_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage_custom = 102;

            SetSelectCustom();

            if (courtCustom.Enabled)
            {
                if (!courtCustom.Checked)
                    courtCustom.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
        }

        private void btn_dlc1_custom3_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage_custom = 103;

            SetSelectCustom();

            if (courtCustom.Enabled)
            {
                if (!courtCustom.Checked)
                    courtCustom.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
        }

        private void btn_dlc1_custom4_Click(object sender, EventArgs e)
        {
            MainForm.mf.stage_custom = 104;

            SetSelectCustom();

            if (courtCustom.Enabled)
            {
                if (!courtCustom.Checked)
                    courtCustom.PerformClick();
                else
                    courtTrainingTweakRadioBtn_CheckedChanged(null, null);
            }
        }

        bool furstCliek = false;
        private void defa_Click_1(object sender, EventArgs e)
        {
            if (!furstCliek)
            {
                furstCliek = true;
                this.defa.Click += new System.EventHandler(this.defa_Click);
            }
        }
    }
}