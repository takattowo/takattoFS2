using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms.Camera_Forms
{
    public partial class AdvancedScript : Form
    {
        
        public AdvancedScript(CameraType type)
        {
            InitializeComponent();
            SetValue(type);

        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE); //int style = NativeMethods.GetWindowLong(pnHi.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }
            btnOke.Font = MemoryFonts.SetFont(0, btnOke.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btnClear.Font = MemoryFonts.SetFont(0, btnClear.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //ControlBox = false;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            this.Text = StringLoader.GetText("tooltip_camera_advanced_script");
            lbPlease.Text = StringLoader.GetText("lb_camera_advanced_script_warning");
            btnClear.Text = StringLoader.GetText("btn_clear");
            btnOke.Text = StringLoader.GetText("btn_confirm");
        }

        private void SimpleDialogFrom_Load(object sender, EventArgs e)
        {
            LoadControl();
            SetTabWidth(txtCode, 4);
            ActiveControl = lbPlease;
        }

        public static bool AreEqual(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return string.IsNullOrEmpty(b);
            }
            else
            {
                return string.Equals(a, b);
            }
        }

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (isGlobal)
            {
                CameraHelper.cam.cameraAdvancedScript = txtCode.Text;
                if(!AreEqual(txtCode.Text, oldTxt))
                {
                    CameraForm.frmObj.setSave();
                }
            }
            else
            {
                MainForm.mf.frm._cam.advancedScript = txtCode.Text;
                if (!AreEqual(txtCode.Text, oldTxt))
                {
                    MainForm.mf.frm.isChanged = true;
                    CameraForm.frmObj.setSave();
                }
            }

            canClose = true;
            Close();
        }
        
        bool isGlobal = false;
        string oldTxt;
        private void SetValue(CameraType _cam)
        {
            if(_cam != null)
            {
                txtCode.Text = oldTxt = _cam.advancedScript;
                lbID.Text = "ID: " + _cam.id;
            }
            else
            {
                isGlobal = true;          
                txtCode.Text = oldTxt = CameraHelper.cam.cameraAdvancedScript;
            }

            if (!string.IsNullOrEmpty(txtCode.Text) && !string.IsNullOrWhiteSpace(txtCode.Text))
                lbPlease_Click(null, null);
            
            isChanged = false;
        }

        private void lbPlease_Click(object sender, EventArgs e)
        {
            lbPlease.Visible = false;
            txtCode.ReadOnly = false;
            txtCode.SelectionLength = 0;
            txtCode.SelectionStart = txtCode.TextLength;

            btnOke.Enabled = true;
            btnOke.BackColor = Color.IndianRed;
            btnClear.Enabled = true;
            btnClear.BackColor = Color.DimGray;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtCode.Text = null;
            txtCode.Focus();
        }

        private const int EM_SETTABSTOPS = 0x00CB;

        public static void SetTabWidth(TextBox textbox, int tabWidth)
        {
            NativeMethods.SendMessage(textbox.Handle, EM_SETTABSTOPS, 1,
            new int[] { tabWidth * 4 });
        }

        bool isChanged = false;
        bool canClose = false;
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void AdvancedScript_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isChanged && !canClose)
            {
                var confirmResult = MsgBoxs.Dialog.WantToDiscard(MainForm.mf);
                if (confirmResult == DialogResult.Yes)
                {
                    isChanged = false;
                    Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
