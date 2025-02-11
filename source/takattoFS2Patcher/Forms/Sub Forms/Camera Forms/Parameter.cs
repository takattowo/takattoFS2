using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms.Camera_Forms
{
    public partial class Parameter : Form
    {
        public Parameter()
        {
            InitializeComponent();


        }
        
        //static Parameter _frmObj;
        //public static Parameter frmObj
        //{
        //    get { return _frmObj; }
        //    set { _frmObj = value; }
        //}
        internal CameraType _cam;
        internal void UpdateValues(CameraType _cameratype)
        {
            if (_cameratype == null)
                return;

            _cam = _cameratype;
            isChanged = false;
            
            txtFOV.removePlaceHolder(null, null);
            txtFOV.Text = _cameratype.fov.ToString();
            txtPosX.removePlaceHolder(null, null);
            txtPosX.Text = _cameratype.posX.ToString();
            txtPosY.removePlaceHolder(null, null);
            txtPosY.Text = _cameratype.posY.ToString();
            txtPosZ.removePlaceHolder(null, null);
            txtPosZ.Text = _cameratype.posZ.ToString();

            txtLookX.removePlaceHolder(null, null);
            txtLookX.Text = _cameratype.lookAtX.ToString();
            txtLookY.removePlaceHolder(null, null);
            txtLookY.Text = _cameratype.lookAtY.ToString();
            txtLookZ.removePlaceHolder(null, null);
            txtLookZ.Text = _cameratype.lookAtZ.ToString();

            rdIgnoreBall.Checked = _cameratype.ignoreAiringBall;
            rdAbsolte.Checked = _cameratype.absolutelyValue;
            if (rdAbsolte.Checked)
            {
                stoppu = true;
            }
            
            if (_cameratype.overrideId > 0)
                ColorLabel(_cameratype.overrideId);
            else
                ColorLabel(_cameratype.id);
        }

        bool stoppu = false;
        void ColorLabel(int id)
        {
            goto Label1;

            Label2:
            {
                switch (id)
                {
                    case 1:
                        lbPX.ForeColor = Color.Teal;
                        lbPZ.ForeColor = Color.Teal;
                        lbLZ.ForeColor = Color.Teal;
                        break;
                    case 2:
                        lbPX.ForeColor = Color.Teal;
                        lbPZ.ForeColor = Color.Teal;
                        lbLZ.ForeColor = Color.Teal;
                        lbLY.ForeColor = Color.Teal;
                        break;
                    case 3:
                        lbPX.ForeColor = Color.Teal;
                        lbPZ.ForeColor = Color.Teal;
                        lbLZ.ForeColor = Color.Teal;
                        break;
                    case 4:
                        lbPZ.ForeColor = Color.Teal;
                        lbLX.ForeColor = Color.Teal;
                        lbLZ.ForeColor = Color.Teal;
                        break;
                    case 5:
                        lbPX.ForeColor = Color.Teal;
                        lbPZ.ForeColor = Color.Teal;
                        lbLZ.ForeColor = Color.Teal;
                        break;
                    default:
                        stoppu = true;
                        goto Label1;
                }
            }

            return;

            Label1:
            {
                lbPX.ForeColor = Color.FromArgb(64, 64, 64);
                lbPY.ForeColor = Color.FromArgb(64, 64, 64);
                lbPZ.ForeColor = Color.FromArgb(64, 64, 64);
                lbLX.ForeColor = Color.FromArgb(64, 64, 64);
                lbLY.ForeColor = Color.FromArgb(64, 64, 64);
                lbLZ.ForeColor = Color.FromArgb(64, 64, 64);
                if (stoppu)
                {
                    stoppu = false;
                    return;
                }
            }
            goto Label2;

        }

        internal void SaveValue(CameraType _cameratype)
        {
            if (_cameratype == null)
                return;
            isChanged = false;

            _cameratype.fov = float.Parse(txtFOV.Text);
            _cameratype.posX = float.Parse(txtPosX.Text);
            _cameratype.posY = float.Parse(txtPosY.Text);
            _cameratype.posZ = float.Parse(txtPosZ.Text);
            _cameratype.lookAtX = float.Parse(txtLookX.Text);
            _cameratype.lookAtY = float.Parse(txtLookY.Text);
            _cameratype.lookAtZ = float.Parse(txtLookZ.Text);
            _cameratype.ignoreAiringBall = rdIgnoreBall.Checked;
            _cameratype.absolutelyValue = rdAbsolte.Checked;

            _cameratype.advancedScript = _cam.advancedScript;
        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE); //int style = NativeMethods.GetWindowLong(pnHi.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);

            //frmObj = this;
            //this.Width = 0;
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                if (c.GetType() == typeof(Controls.UserControls.TextBoxEx) || c.GetType() == typeof(TextBox))
                    c.ContextMenu = new ContextMenu();
            }

            btnAScript.Font = MemoryFonts.SetFont(0, btnAScript.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            lbCam_hint.Font = MemoryFonts.SetFont(0, lbCam_hint.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            //btnOke.Font = MemoryFonts.SetFont(0, btnOke.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            //btnClear.Font = MemoryFonts.SetFont(0, btnClear.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //ControlBox = false;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            LoadUILanguage();
        }

        internal void LoadUILanguage()
        {
            this.Text = StringLoader.GetText("tooltip_camera_advanced_script");
            toolTip1.SetToolTip(btnHide, StringLoader.GetText("btn_hide"));
            lbCam_hint.Text = StringLoader.GetText("lb_tweak_cam_parameter") + ":";
            rdAbsolte.Text = StringLoader.GetText("lb_tweak_cam_absolute_value");
            rdIgnoreBall.Text = StringLoader.GetText("lb_tweak_cam_ignore_ball_tracking");
            btnAScript.Text = StringLoader.GetText("btn_tweak_cam_script");
            toolTip1.SetToolTip(rdAbsolte, StringLoader.GetText("tooltip_tweak_cam_absolutely"));
            toolTip1.SetToolTip(rdIgnoreBall, StringLoader.GetText("tooltip_tweak_cam_ball_ignore"));
        }

        private void SimpleDialogFrom_Load(object sender, EventArgs e)
        {
            LoadControl();
            try
            {
                //txtCode.Text = CameraHelper.cam.cameraAdvancedScript;
            }
            catch
            {
                //txtCode.Text = null;
            }
        }

        internal bool validatd = true;
        internal bool isExpanded = false;
        internal bool isCollaspedByHuman = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollaspedByHuman)
            {
                isExpanded = false;
                MainForm.mf.panel3_2.Enabled = false;
                MainForm.mf.panel3_2.Width = 0;
                timer1.Stop();

                ActiveControl = null;
                return;
            }
            
            if (MainForm.mf.panel3_2.Width >= MainForm.mf.left3_1.Width)
                return;

            

            MainForm.mf.panel3_2.Enabled = true;
            var num = MainForm.mf.left3_1.Width / 5;
            //this.Size = new Size(this.Width += num, this.Height);
            MainForm.mf.panel3_2.Width += num;

            if (MainForm.mf.panel3_2.Width >= MainForm.mf.left3_1.Width)
            {
                isExpanded = true;
                MainForm.mf.panel3_2.Width = MainForm.mf.left3_1.Width;

                ActiveControl = null;
                timer1.Stop();

                UpdateValues(_cam);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (MainForm.mf.panel3_2.Width <= 0)
                return;

            var num = MainForm.mf.left3_1.Width / 6;
            //this.Size = new Size(this.Width -= num, this.Height);
            MainForm.mf.panel3_2.Width -= num;
            if (MainForm.mf.panel3_2.Width <= 0)
            {
                isExpanded = false;
                MainForm.mf.panel3_2.Enabled = false;
                MainForm.mf.panel3_2.Width = 0;

                ActiveControl = null;
                if (isCollaspedByHuman)
                {
                    try
                    {
                        CameraForm.frmObj.collaspbyhuman = true;
                        CameraForm.frmObj.cbGameGraphic_SelectedIndexChanged(null, null);
                    }
                    catch { }
                }
                    

                timer2.Stop();
            }
            

            //if (this.Width <= 0)
            //{
            //    isExpanded = false;
            //    this.Size = new Size(0, this.Height);
            //    timer2.Stop();
            //}
        }

        internal bool isChanged = false;
        private void txtFOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            isChanged = true;
            CameraForm.frmObj.setSave();
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

        private void rdIgnoreBall_Click(object sender, EventArgs e)
        {
            isChanged = true;
            CameraForm.frmObj.setSave();
            if (!rdIgnoreBall.Checked)
                rdIgnoreBall.CheckState = CheckState.Indeterminate;
            else
                rdIgnoreBall.Checked = false;
        }

        private void rdAbsolte_Click(object sender, EventArgs e)
        {
            isChanged = true;
            CameraForm.frmObj.setSave();
            if (!rdAbsolte.Checked)
                rdAbsolte.CheckState = CheckState.Indeterminate;
            else
                rdAbsolte.Checked = false;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            isCollaspedByHuman = true;
            if (isExpanded) 
                timer2.Start();
        }

        private void timer22_Tick(object sender, EventArgs e)
        {
            if (MainForm.mf.panel3_2.Width <= 0)
                goto Label1;

            var num = MainForm.mf.left3_1.Width / 2;
            //this.Size = new Size(this.Width -= num, this.Height);
            MainForm.mf.panel3_2.Width -= num;
            if (MainForm.mf.panel3_2.Width <= 0)
            {
                goto Label1;
            }
            return;
            Label1:
            {
                isExpanded = false;
                isChanged = false;
                MainForm.mf.panel3_2.Enabled = false;
                MainForm.mf.panel3_2.Width = 0;

                ActiveControl = null;
                timer22.Stop();
            }

        }

        internal void txtFOV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFOV.Text) || string.IsNullOrWhiteSpace(txtFOV.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtFOV.Text);
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
                txtFOV.Focus();

                txtFOV.SelectionStart = txtFOV.Text.Length;
                txtFOV.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtPosX_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPosX.Text) || string.IsNullOrWhiteSpace(txtPosX.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtPosX.Text);
            }
            catch
            {
                goto Label1;
            }
            return;
            
            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtPosX.Focus();
                txtPosX.SelectionStart = txtPosX.Text.Length;
                txtPosX.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtPosY_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPosY.Text) || string.IsNullOrWhiteSpace(txtPosY.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtPosY.Text);
            }
            catch
            {
                goto Label1;
            }
            return;

            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtPosY.Focus();
                txtPosY.SelectionStart = txtPosY.Text.Length;
                txtPosY.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtPosZ_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPosZ.Text) || string.IsNullOrWhiteSpace(txtPosZ.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtPosZ.Text);
            }
            catch
            {
                goto Label1;
            }
            return;

            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtPosZ.Focus();
                txtPosZ.SelectionStart = txtPosZ.Text.Length;
                txtPosZ.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtLookX_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLookX.Text) || string.IsNullOrWhiteSpace(txtLookX.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtLookX.Text);
            }
            catch
            {
                goto Label1;
            }
            return;
            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtLookX.Focus();
                txtLookX.SelectionStart = txtLookX.Text.Length;
                txtLookX.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtLookY_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLookY.Text) || string.IsNullOrWhiteSpace(txtLookY.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtLookY.Text);
            }
            catch
            {
                goto Label1;
            }
            return;
            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtLookY.Focus();
                txtLookY.SelectionStart = txtLookY.Text.Length;
                txtLookY.SelectionLength = 0;
                validatd = false;
            }
        }

        internal void txtLookZ_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLookZ.Text) || string.IsNullOrWhiteSpace(txtLookZ.Text))
                goto Label1;

            try
            {
                var myDouble = double.Parse(txtLookZ.Text);

            }
            catch
            {
                goto Label1;
            }
            return;
            Label1:
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                txtLookZ.Focus();
                txtLookZ.SelectionStart = txtLookZ.Text.Length;
                txtLookZ.SelectionLength = 0;
                validatd = false;
            }
        }

        private void rdIgnoreBall_CheckedChanged(object sender, EventArgs e)
        {
            CameraForm.frmObj.setSave();
        }

        private void rdAbsolte_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAbsolte.Checked)
                ColorLabel(69);
            else if(_cam.overrideId > 0)
                ColorLabel(_cam.overrideId);
            else
                ColorLabel(_cam.id);
        }

        private void btnc1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            AdvancedScript advancedScriptFrm = new AdvancedScript(_cam);
            //advancedScriptFrm.ShowDialog(MainForm.mf);
            //advancedScriptFrm.Dispose();
            advancedScriptFrm.Owner = MainForm.mf;
            advancedScriptFrm.ShowInTaskbar = false;
            advancedScriptFrm.ShowDialog();
            advancedScriptFrm.Dispose();
        }
    }
}
