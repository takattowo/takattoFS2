using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class MapTweakForm : Form
    {
        public MapTweakForm()
        {
            InitializeComponent();
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            int style2 = NativeMethods.GetWindowLong(panel2.Handle, NativeMethods.GWL_EXSTYLE);
            style2 |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel2.Handle, NativeMethods.GWL_EXSTYLE, style2);

        }

        static MapTweakForm _frmObj;
        public static MapTweakForm frmObj
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }
        
        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            UpdateForm();
        }

        void LoadControl()
        {
            oldH = panelEx5.Height;
            frmObj = this;
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

            radioButton9.Text = StringLoader.GetText("lb_tweak_choice_default");
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
        }

        bool everythingisDONE = false;
        private void courtTrainingTweakRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            cbDefaultCourtTweak.Enabled = defaultCourtmRad.Checked;
            var rb = (sender as RadioButton);
            if (rb.Checked && !rb.Enabled)
                defa.PerformClick();

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
            CheckCourtDLC(courtTrainingTweakRadioBtn, 1, Strings.KattoFileName.DLC1Training_Blue, Strings.KattoFileName.DLC1Training_Red, Strings.KattoFileName.DLC1Training_Dark);
            CheckCourtDLC(courtTakaTweakRadioBtn, 2, Strings.KattoFileName.DLC1Katto_Night, Strings.KattoFileName.DLC1Katto_Sunny);
            CheckCourtDLC(courtTournyTweakRadioBtn, 3, Strings.KattoFileName.DLC1Beach_Default, Strings.KattoFileName.DLC1Beach_New);
            CheckCourtDLC(courtHiddenTweakRadioBtn, 4, Strings.KattoFileName.DLC1Warehouse_Default , Strings.KattoFileName.DLC1Warehouse_New);
            CheckCourtDLC(courtCustom, 5, Strings.FolderName.Data, Strings.KattoFileName.DLC1Custom);
            btn_dlc1_custom.Visible = courtCustom.Enabled;
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
            }
            else
            {
                defaultCourtmRad.Enabled = false;
                defaultCourtmRad.Checked = false;
            }
        }


        void CheckCourtDLC(RadioButton rdBtn, int wi, params string[] _list)
        {
            bool isExisted = false;
            for (int i = 0; i < _list.Length; i++)
            {
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, _list[i])))
                {
                    isExisted = true;
                    rdBtn.Enabled = true;
                    if (MainForm.mf.CourtMap == wi)
                        rdBtn.PerformClick();

                    break;
                }
                else
                    isExisted = false;
            }
            if (!isExisted)
            {
                rdBtn.Enabled = false;
                rdBtn.Checked = false;
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

        void ShowCourt(string st)
        {
            ActiveControl = null;
            var uri = String.Format(Urls.PictureFormat, UniversalSettings._un.AssetRootUri, st);          
            Help_CourtTakatto helpCourtdemo = new Help_CourtTakatto(uri, false, false);
            helpCourtdemo.ShowDialog(this);
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
            panel2.Visible = false;
            panel2.SendToBack();
            checkInstalleDLC.Stop();
        }

        private void btn_gamekill_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            panel2.Visible = true;
            panel2.BringToFront();
            checkWhichMapInstellad();
            checkInstalleDLC.Start();
        }

        private void checkInstalleDLC_Tick(object sender, EventArgs e)
        {
            checkWhichMapInstellad();
        }

        private void checkWhichMapInstellad()
        {
            if (courtTrainingTweakRadioBtn.Enabled)
            {
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red)))
                    btn_dlc1_red.Text = "✔";
                else
                    btn_dlc1_red.Text = string.Empty;
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark)))
                    btn_dlc1_dark_katto.Text = "✔";
                else
                    btn_dlc1_dark_katto.Text = string.Empty;
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue)))
                    btn_dlc1_blue.Text = "✔";
                else
                    btn_dlc1_blue.Text = string.Empty;
            }
            else
            {
                btn_dlc1_red.Text = string.Empty;
                btn_dlc1_dark_katto.Text = string.Empty;
                btn_dlc1_blue.Text = string.Empty;
            }

            if (courtTakaTweakRadioBtn.Enabled)
            {
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Sunny)))
                    btn_dlc1_takatto_sunny.Text = "✔";
                else
                    btn_dlc1_takatto_sunny.Text = string.Empty;
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Night)))
                    btn_dlc1_takatto.Text = "✔";
                else
                    btn_dlc1_takatto.Text = string.Empty;
            }
            else
            {
                btn_dlc1_takatto_sunny.Text = string.Empty;
                btn_dlc1_takatto.Text = string.Empty;
            }

            if (courtTournyTweakRadioBtn.Enabled)
            {
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_New)))
                    btn_dlc1_tourny_new.Text = "✔";
                else
                    btn_dlc1_tourny_new.Text = string.Empty;
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_Default)))
                    btn_dlc1_tourny.Text = "✔";
                else
                    btn_dlc1_tourny.Text = string.Empty;
            }
            else
            {
                btn_dlc1_tourny_new.Text = string.Empty;
                btn_dlc1_tourny.Text = string.Empty;
            }

            if (courtHiddenTweakRadioBtn.Enabled)
            {
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_New)))
                    btn_dlc1_tourny_warehouse_new.Text = "✔";
                else
                    btn_dlc1_tourny_warehouse_new.Text = string.Empty;
                if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_Default)))
                    btn_dlc1_tourny_warehouse.Text = "✔";
                else
                    btn_dlc1_tourny_warehouse.Text = string.Empty;
            }
            else
            {
                btn_dlc1_tourny_warehouse.Text = string.Empty;
                btn_dlc1_tourny_warehouse_new.Text = string.Empty;
            }


            if (courtCustom.Enabled)
                btn_dlc1_custom.Text = "✔";
            else
                btn_dlc1_custom.Text = string.Empty;


            if (defaultCourtmRad.Enabled)
                btn_dlc1_def.Text = "✔";
            else
                btn_dlc1_def.Text = string.Empty;
        }

        private void btn_dlc1_blue_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training))
                && (
                File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark))
                || File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red))))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1TrainingCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue));
                    }
                    catch { }
                   
                    courtTrainingTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Training_Blue));
                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Training_Blue);
            try
            {
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red));
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark));
            }
            catch { }
        }

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training))
                && (
                File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue))
                || File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark))))
            {
                var confirmResult =  MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1TrainingCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red));
                    }
                    catch { }
                    
                    courtTrainingTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Training_Red));
                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Training_Red);
            try {
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue));
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark));
            }
            catch { }
            

        }
        private void btn_dlc1_dark_katto_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training)) 
                && (
                File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue))
                || File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red))))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1TrainingCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Dark));
                    }
                    catch { }
                    
                    courtTrainingTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Training_Dark));

                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Training_Dark);
            try {
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Blue));
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Training_Red));
            } 
            catch { }          
        }
        private void btn_dlc1_takatto_sunny_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Night)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Sunny)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1KattoCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Sunny));
                    }
                    catch { }
                    
                    courtTakaTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Katto_Sunny));
                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Takatto_Sunny);

            try { File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Night)); } catch { }      
        }
        private void btn_dlc1_takatto_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Sunny)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Night)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1KattoCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Night));
                    }
                    catch { }
                    courtTakaTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Katto_Night));
                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Takatto_Night);
            try { File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Katto_Sunny)); } 
            catch { }
        }

        private void btn_dlc1_tourny_new_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_Default)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }


            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_New)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1BeachCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_New));
                    }
                    catch { }
                    courtTournyTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Beach_New));
                    return;
                }
                else
                    return;
            }


            MainForm.mf.CourtDownload(Urls.DLC1Beach_New);
            try
            {
                File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_Default));
            }
            catch { }

        }
        private void btn_dlc1_tourny_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_New)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }


            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_Default)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1BeachCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_Default));
                    }
                    catch { }
                    courtTournyTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Beach_Default));
                    return;
                }
                else
                    return;
            }

            MainForm.mf.CourtDownload(Urls.DLC1Beach_Default);
            try { File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Beach_New)); }
            catch { }

        }
        private void btn_dlc1_tourny_warehouse_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_New)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_Default)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1WarehouseCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_Default));

                    }
                    catch { }
                    
                    courtHiddenTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Warehouse_Default));
                    return;
                }
                else
                    return;
            }
            MainForm.mf.CourtDownload(Urls.DLC1Warehouse_Default);
            try { File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_New)); }
            catch { }
        }

        private void btn_dlc1_tourny_warehouse_new_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_Default)))
            {
                var confirmResult = MsgBoxs.Dialog.CourtSwitch(MainForm.mf);
                if (confirmResult != DialogResult.Yes) { return; }
            }

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse)) && File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_New)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1WarehouseCN));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_New));

                    }
                    catch { }

                    courtHiddenTweakRadioBtn.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, nameof(Strings.KattoFileName.DLC1Warehouse_New));
                    return;
                }
                else
                    return;
            }
            MainForm.mf.CourtDownload(Urls.DLC1Warehouse_New); 
            try { File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Warehouse_Default)); }
            catch { }
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
                Methods.DownloadFile(Urls.DLC1DefaultCourt, Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, "DLC1DefaultCourt"), Methods.GetGameFolder());
            }
        }

        private void btn_dlc1_custom_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Custom)))
            {
                var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1Custom));
                        File.Delete(Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.DLC1CustomCN));
                    }
                    catch { }
                    courtCustom.Checked = false;
                    MsgBoxs.Information.Uninstalled(MainForm.mf, "DLC1Custom");
                    btn_dlc1_custom.Visible = false;
                    return;
                }
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
                        MainForm.mf.lbCourtHint.Text = StringLoader.GetText("lb_tweak_court_help_load_replay");
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
            if (panelEx5.Width >= MainForm.mf.pnMeasure4.Width)
            {
                timer2.Stop();
                timer3Delay.Start();
            }
        }

        private void timer3Delay_Tick(object sender, EventArgs e)
        {
            timer3Delay.Stop();
            timer1.Start();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(!Methods.IsGameRunning_Alt() && everythingisDONE)
            {
                CheckforDLC();
            }         
        }
    }
}