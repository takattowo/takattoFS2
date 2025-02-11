using System;
using System.Drawing;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class SimpleDialogFrom : Form
    {
        public SimpleDialogFrom()
        {
            InitializeComponent();

  
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
            btnCopy.Font = MemoryFonts.SetFont(0, btnCopy.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            lbAnko.Text = StringLoader.GetText("lb_tweak_texture_nako_unlock");
            //btnCopy.Text = StringLoader.GetText("btn_tweak_texture_nako_copy");
            btnCopy.Text = StringLoader.GetText("btn_cancel");
            btnOke.Text = StringLoader.GetText("btn_tweak_texture_nako_ok");
            txtLicense.Text = StringLoader.GetText("txt_license");
        }

        private void SimpleDialogFrom_Load(object sender, EventArgs e)
        {
            LoadControl();
            //try
            //{
            //    txtCode.Text = KATEncryptor.Encrypt(PatcherSettings.GetValue(PatcherSettings.takatto29022),1);
            //}
            //catch
            //{
            //    MsgBoxs.Warning.IncorrectParametter(this);
            //    Close();
            //}

            ActiveControl = lbAnko;
        }

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
            
            this.Close();
            //if(!string.IsNullOrEmpty(txtCode.Text))
            //{
            //    Clipboard.SetText(txtCode.Text);
            //    lbCopied.Visible = true;
            //}           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            btnOke.BackColor = Color.IndianRed;
            btnOke.Enabled = true;
        }
    }
}
