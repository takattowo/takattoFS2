using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using takattoFS2.Forms.Sub_Forms.Camera_Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        static CameraForm _frmObj;
        public static CameraForm frmObj
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }

        public class OverrideItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            // 0 disabled
            // 1 basic
            // 2 high
            // 3 follow
            // 4 side
            // 5 sky
            // 6 close - redacted

            public override string ToString()
            {
                return Text;
            }
        }
        
        void AddItems()
        {
            cbOverride.Items.Clear();
            switch (cbCamera.SelectedIndex)
            {
                case 1: //basic
                    cbOverride.Items.Add(defaultcam);
                    cbOverride.Items.Add(high);
                    cbOverride.Items.Add(follow);
                    cbOverride.Items.Add(side);
                    cbOverride.Items.Add(sky);


                    if (!MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer1.Start();
                    break;
                case 2: //high
                    cbOverride.Items.Add(defaultcam);
                    cbOverride.Items.Add(basic);
                    cbOverride.Items.Add(follow);
                    cbOverride.Items.Add(side);
                    cbOverride.Items.Add(sky);


                    if (!MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer1.Start();
                    break;
                case 3: //follow
                    cbOverride.Items.Add(defaultcam);
                    cbOverride.Items.Add(basic);
                    cbOverride.Items.Add(high);
                    cbOverride.Items.Add(side);
                    cbOverride.Items.Add(sky);

                    if (!MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer1.Start();
                    break;
                case 4: //side
                    cbOverride.Items.Add(defaultcam);
                    cbOverride.Items.Add(basic);
                    cbOverride.Items.Add(high);
                    cbOverride.Items.Add(follow);
                    cbOverride.Items.Add(sky);

                    if (!MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer1.Start();
                    break;
                case 5: //sly
                    cbOverride.Items.Add(defaultcam);
                    cbOverride.Items.Add(basic);
                    cbOverride.Items.Add(high);
                    cbOverride.Items.Add(follow);
                    cbOverride.Items.Add(side);

                    if (!MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer1.Start();
                    break;
                default:
                    cbOverride.Items.Add(defaultcam);
                    if (MainForm.mf.frm.isExpanded)
                        MainForm.mf.frm.timer2.Start();
                    break;
            }
        }

        OverrideItem defaultcam = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_default"), Value = "0" };
        OverrideItem basic = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_basic"), Value = "1" };
        OverrideItem high = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_high"), Value = "2" };
        OverrideItem follow = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_follow"), Value = "3" };
        OverrideItem side = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_side"), Value = "4" };
        OverrideItem sky = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_sky"), Value = "5" };
        //OverrideItem close = new OverrideItem() { Text = StringLoader.GetText("cb_tweak_cam_close"), Value = "6" };


        internal void UpdateForm(CameraType type) 
        {
            txtVeloSpeed.removePlaceHolder(null, null);
            txtVeloSpeed.Text = CameraHelper.cam.cameraMoveSpeed.ToString();
            txtLookSpeed.removePlaceHolder(null, null);
            txtLookSpeed.Text = CameraHelper.cam.cameraLookAtSpeed.ToString();
            txtHiliFOV.removePlaceHolder(null, null);
            txtHiliFOV.Text = CameraHelper.cam.cameraReplayFOV.ToString();

            ignoreCBSave = true;
            if (type is null || type.overrideId == 0)
            {
                cbOverride.SelectedIndex = 0;
            }
            else
            {
                try
                {
                    //get Text from OverrideItem based on type.overrideId
                    cbOverride.SelectedItem = cbOverride.Items.Cast<OverrideItem>().FirstOrDefault(x => x.Value.ToString() == type.overrideId.ToString());
                }
                catch
                {
                    cbOverride.SelectedIndex = 0;
                }

            }
            ignoreCBSave = false;
            //switch (type.id) {
            //    case 1:

            //        break;
            //    case 2:
            //        break;
            //}
        }


        int oldH = 0;
        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            oldH = panelEx5.Height;
            panelEx5.Height = 0;
            LoadControl();


            frmObj = this;
            //UpdateForm(null);
            setSaved();
        }

        private void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }
            foreach (Control c in panel2.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }
            foreach (Control c in panelEx2.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Controls.UserControls.TextBoxEx) || c.GetType() == typeof(TextBox))
                    c.ContextMenu = new ContextMenu();
            }

            btnSave.Font = MemoryFonts.SetFont(0, btnSave.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);


            lbCam_hint.Text = StringLoader.GetText("lb_tweak_cam_hint") + ":";
            lbMoveVelo.Text = StringLoader.GetText("lb_tweak_cam_move_velocity");
            lbLookVelo.Text = StringLoader.GetText("lb_tweak_cam_look_velocity");
            lbHiFOV.Text = StringLoader.GetText("lb_tweak_cam_replay_fov");
            rdOverride.Text = StringLoader.GetText("lb_tweak_cam_override");
            btnSave.Text = StringLoader.GetText("btn_save");

            r1ToolStripMenuItem.Text = StringLoader.GetText("context_cam_reset_this");
            r2ToolStripMenuItem.Text = StringLoader.GetText("context_cam_reset_all");

            toolTip1.SetToolTip(btnExpand, StringLoader.GetText("btn_show"));
            toolTip1.SetToolTip(btnReset, StringLoader.GetText("tooltip_reset_settings"));
            toolTip1.SetToolTip(btnReset, StringLoader.GetText("tooltip_reset_settings"));
            toolTip1.SetToolTip(btnExport, StringLoader.GetText("tooltip_export_settings"));
            toolTip1.SetToolTip(btnImport, StringLoader.GetText("tooltip_import_settings"));
            toolTip1.SetToolTip(btnParameter, StringLoader.GetText("tooltip_camera_advanced_script"));
            toolTip1.SetToolTip(btnHelp, StringLoader.GetText("tooltip_button_help"));




            //toolTip1.SetToolTip(txtW, StringLoader.GetText("lb_tweak_task_interval_hint"));
            //toolTip1.SetToolTip(txtCommand, StringLoader.GetText("lb_tweak_task_cmd"));


            cbCamera.Items.AddRange(new object[] {
            StringLoader.GetText("cb_tweak_cam_select"),
            StringLoader.GetText("cb_tweak_cam_basic"),
            StringLoader.GetText("cb_tweak_cam_high"),
            StringLoader.GetText("cb_tweak_cam_follow"),
            StringLoader.GetText("cb_tweak_cam_side"),
            StringLoader.GetText("cb_tweak_cam_sky"),
            //StringLoader.GetText("cb_tweak_cam_close")
            });
            cbCamera.SelectedIndex = 0;

            cbOverride.MouseWheel += new MouseEventHandler(disableScroll);

        }
        void disableScroll(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        int previousSelectedIndex = 0;
        bool ignoreUpdate = false;
        int previousORSelectedIndex;
        internal bool collaspbyhuman = false;
        internal void cbGameGraphic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.mf.frm != null && MainForm.mf.frm.isChanged && !ignoreUpdate && !collaspbyhuman)
            {
                var confirmResult = MsgBoxs.Dialog.WantToDiscard(MainForm.mf);
                if (confirmResult != DialogResult.Yes)
                {
                    ignoreUpdate = true;
                    previousORSelectedIndex = cbOverride.SelectedIndex;
                    cbCamera.SelectedIndex = previousSelectedIndex;
                    return;
                }
                else if (confirmResult == DialogResult.Yes)
                {
                    ignoreUpdate = false;
                    if (MainForm.mf.frm != null)
                        MainForm.mf.frm.isChanged = false;
                }
            }
            
            if (expanded)
                AddItems();
           
            cam = CameraHelper.cam.cameraList.FirstOrDefault(x => x.id == cbCamera.SelectedIndex);
            if(!ignoreUpdate)
                UpdateForm(cam);
            else
            {
                if (cbOverride.Items.Count > 0)
                    cbOverride.SelectedIndex = previousORSelectedIndex;
                else
                    previousORSelectedIndex = 0;
            }
                
        
            if (cam != null && !ignoreUpdate)
                MainForm.mf.frm.UpdateValues(cam);
            
            
            ignoreUpdate = false;
            switch (cbCamera.SelectedIndex)
            {
                case 0:
                    btnExpand.Visible = false;
                    isOverrideVisible = false;
                    timerToVisibleOverride.Start();
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    isOverrideVisible = true;
                    timerToVisibleOverride.Start();

                    btnExpand.Visible = MainForm.mf.frm.isCollaspedByHuman;
                    break;
            }
            
            if(cbCamera.Items.Count > 0)
                previousSelectedIndex = cbCamera.SelectedIndex;

            collaspbyhuman = false;
        }
        
        private void cbGameGraphic_DropDownClosed(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        int i, maxh = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            maxh = cbCamera.Height;
            i += 2;
            cbCamera.Visible = true;
            txtHolder.Visible = false;
            MainForm.mf.CreateCamForm();
            //txtCommand.Location = new Point(txtCommand.Location.X, txtCommand.Location.Y + 2);
            //txtPoint.Location = txtCommand.Location;
            if (i >= maxh + 2)
            {
                expanded = true;

                cbGameGraphic_SelectedIndexChanged(null, null);
                timer1.Stop();
            }
        }
        bool expanded = false;
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3Delay.Start();

            //if (panel1.Width >= ((MainForm.mf.tableLayoutPanel2.Width) * 48) / 100)
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

        //private void btnOverride_Click(object sender, EventArgs e)
        //{
        //    if (isExpdoing || cbCamera.SelectedIndex == 6)
        //        return;
        
        //    if (!rdOverride.Checked)
        //        rdOverride.CheckState = CheckState.Indeterminate;
        //    else
        //        rdOverride.Checked = false;
        //}

        private void btnOverride_CheckedChanged(object sender, EventArgs e)
        {       
            //CameraHelper.CameraTweak();
            //if (!isExpdoing)
            //    timer11.Start();
        }

        bool isExpdoing = false;

        private void btnParameter_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            AdvancedScript advancedScriptFrm = new AdvancedScript(null);
            //advancedScriptFrm.ShowDialog(MainForm.mf);
            //advancedScriptFrm.Dispose();
            advancedScriptFrm.Owner = MainForm.mf;
            advancedScriptFrm.ShowInTaskbar = false;
            advancedScriptFrm.ShowDialog();
            advancedScriptFrm.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            contextReset.Show(Cursor.Position.X + btnReset.Width / 4, Cursor.Position.Y + btnReset.Height / 4);
        }

        private void contextReset_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbCamera.SelectedIndex <= 0)
            {
                r1ToolStripMenuItem.Visible = false;
            }
            else
            {
                r1ToolStripMenuItem.Visible = true;
            }
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {

        }

        private void txtVeloSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            setSave();
            TextBox textBox = sender as Controls.UserControls.TextBoxEx;
            // If the text already contains a negative sign, we need to make sure that 
            //    the user is not trying to enter a character at the start
            // If there is already a negative sign and the negative sign is not selected, the key press is not valid
            // This allows the user to highlight some of the text and replace it with a negative sign
            if ((textBox.Text.IndexOf('-') > -1) && textBox.SelectionStart == 0 && !textBox.SelectedText.Contains('-'))
            {
                e.Handled = true;
            }
            // Do not accept a character that is not included in the following
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            // Only allow one decimal point
            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            // The negative sign can only be at the start
            if ((e.KeyChar == '-'))
            {
                // If the cursor is not at the start of the text, the key press is not valid
                if (textBox.SelectionStart > 1)
                {
                    e.Handled = true;
                }
                // If there is already a negative sign and the negative sign is not selected, the key press is not valid
                // This allows the user to highlight some of the text and replace it with a negative sign
                if (textBox.Text.IndexOf('-') > -1 && !textBox.SelectedText.Contains('-'))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            try
            {
                Clipboard.SetText(UserSettings.CameraTweakSettingConfigs);
                MsgBoxs.Information.HasBeenCopiedToClipBoard(MainForm.mf, StringLoader.GetText("lb_tweak_cam_settings"));
            }
            catch (Exception msg)
            {
                MsgBoxs.Warning.Error(MainForm.mf, msg.ToString());
                return;
            }
        }

        bool isOverrideVisible = false;
        bool isOverridingVisible = false;
        private void timerToVisibleOverride_Tick(object sender, EventArgs e)
        {
            if (isOverrideVisible)
            {
                cbOverride.Enabled = true;
                cbOverride.Visible = true;
                panelEx5.Enabled = true;
                isOverridingVisible = true;
                panelEx5.Height += oldH / 8;
                if (panelEx5.Height >= oldH)
                {
                    isOverridingVisible = false;
                    panelEx5.Height = oldH;
                    timerToVisibleOverride.Stop();
                }
            }
            else if (!isOverrideVisible)
            {
                isOverridingVisible = true;
                panelEx5.Height -= oldH / 7;
                if (panelEx5.Height <= 0)
                {
                    panelEx5.Enabled = false;
                    isOverridingVisible = false;
                    panelEx5.Height = 0;
                    
                    cbOverride.Enabled = false;
                    cbOverride.Visible = false;
                    timerToVisibleOverride.Stop();
                }
            }
        }

        bool ignoreCBSave = false;
        private void cbOverride_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ignoreCBSave || cbCamera.SelectedIndex <= 0 || cbOverride.SelectedIndex < 0)
                return;

            MainForm.mf.frm.isChanged = true;
            setSave();
            //var id = int.Parse((cbOverride.SelectedItem as OverrideItem).Value.ToString());
            //var currentshit = CameraHelper.cam.cameraList.FirstOrDefault(x => x.id == cbCamera.SelectedIndex).overrideId = id;
            //CameraHelper.Save();
        }

        private void SaveSettings()
        {
            CameraHelper.Save();
        }

        private void txtVeloSpeed_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVeloSpeed.Text) || string.IsNullOrWhiteSpace(txtVeloSpeed.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtVeloSpeed.Text);
                if (myDouble <= 0)
                    goto Label1;
                
            }
            catch
            {
                goto Label1;
            }
            return;

            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtVeloSpeed.Focus();
                txtVeloSpeed.SelectionStart = txtVeloSpeed.Text.Length;
                txtVeloSpeed.SelectionLength = 0;
                validatd = false;

                //txtVeloSpeed.removePlaceHolder(null, null);
                //var a = CameraHelper.cam.cameraSpeed = CameraHelper.cam_default.cameraSpeed;
                //txtVeloSpeed.Text = a.ToString();
                //CameraHelper.Save();
            }
        }

        private void txtLookSpeed_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLookSpeed.Text) || string.IsNullOrWhiteSpace(txtLookSpeed.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtLookSpeed.Text);
                if (myDouble <= 0)
                    goto Label1;
            }
            catch
            {
                goto Label1;
            }
            return;

            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtLookSpeed.Focus();
                txtVeloSpeed.SelectionStart = txtVeloSpeed.Text.Length;
                txtVeloSpeed.SelectionLength = 0;
                validatd = false;
                //txtLookSpeed.removePlaceHolder(null, null);
                //var a = CameraHelper.cam.cameraLookAtSpeed = CameraHelper.cam_default.cameraLookAtSpeed;
                //txtLookSpeed.Text = a.ToString();
                //CameraHelper.Save();
            }
        }

        private void txtHiliFOV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHiliFOV.Text) || string.IsNullOrWhiteSpace(txtHiliFOV.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtHiliFOV.Text);
                if (myDouble <= 0)
                    goto Label1;
            }
            catch
            {
                goto Label1;
            }

            return;

            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtHiliFOV.Focus();
                txtVeloSpeed.SelectionStart = txtVeloSpeed.Text.Length;
                txtVeloSpeed.SelectionLength = 0;
                validatd = false;
                //txtHiliFOV.removePlaceHolder(null, null);
                //var a = CameraHelper.cam.replayFOV = CameraHelper.cam_default.replayFOV;
                //txtHiliFOV.Text = a.ToString();
                //CameraHelper.Save();
            }
        }

        CameraType cam;
        private void r1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var camtype_default = CameraHelper.cam_default.cameraList.FirstOrDefault(x => x.id == cbCamera.SelectedIndex);

            if (cam == null || camtype_default == null)
                return;
            
            //cam = camtype_default;
            UpdateForm(camtype_default);
            MainForm.mf.frm.UpdateValues(camtype_default);
            MainForm.mf.frm.isChanged = true;
            setSave();
        }

        private void r2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MsgBoxs.Dialog.WantToResetAllSetting(MainForm.mf);
            if (confirmResult == DialogResult.Yes)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(Camera.DefaultCameraInstance);
                CameraHelper.cam = Newtonsoft.Json.JsonConvert.DeserializeObject<Camera>(json);
                if (cbCamera.SelectedIndex > 0)
                    ignoreUpdate = true;
                
                MainForm.mf.frm.isChanged = false;
                Reset(); 
                SaveSettings();
                setSaved();
                json = null;
            }
        }

        internal void Reset()
        {
            cbCamera.SelectedIndex = 0;
            
            UpdateForm(cam);

            if (cam != null)
                MainForm.mf.frm.UpdateValues(cam);
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (!MainForm.mf.frm.isExpanded && cbCamera.SelectedIndex != 0)
            {
                MainForm.mf.frm.isCollaspedByHuman = false;
                MainForm.mf.frm.timer1.Start();

                cbGameGraphic_SelectedIndexChanged(null, null);
            }
        }

        private void cbOverride_DropDownClosed(object sender, EventArgs e)
        {
            setSave();
            ActiveControl = null;
            MainForm.mf.frm.isChanged = true;
            //CameraHelper.Save();

            if (cbOverride.SelectedIndex > 0 && cbCamera.SelectedIndex > 0)
            {
                var confirmResult = MsgBoxs.Dialog.WantToResetOverridedCamSetting(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    var id = int.Parse((cbOverride.SelectedItem as OverrideItem).Value.ToString());
                    var newCam = CameraHelper.cam_default.cameraList.FirstOrDefault(x => x.id == id);
                    if (MainForm.mf.frm != null)
                        MainForm.mf.frm.UpdateValues(newCam);
                }
            }
        }

        internal bool validatd = true;
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtVeloSpeed_Leave(null, null);
            if (!validatd)
            {
                validatd = true;
                return;
            }
            txtHiliFOV_Leave(null, null);
            if (!validatd)
            {
                validatd = true;
                return;
            }
            txtLookSpeed_Leave(null, null);
            if (!validatd)
            {
                validatd = true;
                return;
            }

            if(cbCamera.SelectedIndex != 0) { 
            MainForm.mf.frm.txtFOV_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookX_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookY_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookZ_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookX_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookY_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;
            }
            MainForm.mf.frm.txtLookZ_Leave(null, null);
            if (!MainForm.mf.frm.validatd)
            {
                MainForm.mf.frm.validatd = true;
                return;             
            }

                var id = int.Parse((cbOverride.SelectedItem as OverrideItem).Value.ToString());
                CameraHelper.cam.cameraList.FirstOrDefault(x => x.id == cbCamera.SelectedIndex).overrideId = id;
                
            }
            CameraHelper.cam.cameraReplayFOV = float.Parse(txtHiliFOV.Text);
            CameraHelper.cam.cameraLookAtSpeed = float.Parse(txtLookSpeed.Text);
            CameraHelper.cam.cameraMoveSpeed = float.Parse(txtVeloSpeed.Text);
            
            if (cam != null)
                MainForm.mf.frm.SaveValue(cam);

            MainForm.mf.frm.isChanged = false;

            SaveSettings();
            setSaved();
        }

        internal void setSaved()
        {
            btnSave.Text = StringLoader.GetText("btn_saved");
            btnSave.BackColor = Color.CornflowerBlue;
        }

        internal void setSave()
        {
            btnSave.Text = StringLoader.GetText("btn_save");
            btnSave.BackColor = Color.RoyalBlue;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            string Url = takattoFS2.Controls.Models.StringTheory.Universal.CameraGuideUri;

            if (string.IsNullOrEmpty(Url))
            {
                MsgBoxs.Warning.FailedToFetch(MainForm.mf);
                return;
            }

            System.Diagnostics.Process.Start(Url);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ImportForm imp = new ImportForm(true);
            //imp.ShowDialog(this);
            //imp.Dispose();
            imp.Owner = this;
            imp.ShowInTaskbar = false;
            imp.ShowDialog();
            imp.Dispose();
        }

        //private void timer11_Tick(object sender, EventArgs e)
        //{
        //    if (!isOverrideVisible)
        //    {
        //        cbOverride.Enabled = false;
        //        isExpdoing = false;
        //        timer11.Stop();
        //        return;
        //    }

        //    if (isOverridingVisible)
        //        return;

        //    if (rdOverride.Checked)
        //    {
        //        if (expanded)
        //        {
        //            isExpdoing = true;
        //            cbOverride.Enabled = true;
        //            cbOverride.Visible = true;
        //            panelEx5.Height += oldH / 8;
        //            if (panelEx5.Height >= oldH + maxh + maxh / 2 - 3)
        //            {
        //                isExpdoing = false;
        //                timer11.Stop();
        //            }
        //        }
        //    }
        //    else if (expanded)
        //    {
        //        isExpdoing = true;
        //        cbOverride.Enabled = false;
        //        panelEx5.Height -= oldH / 7;
        //        if (panelEx5.Height <= oldH)
        //        {
        //            isExpdoing = false;
        //            panelEx5.Height = oldH;
        //            cbOverride.Visible = false;
        //            timer11.Stop();
        //        }
        //    }
        //}
    }
}
