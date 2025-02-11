using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class ResizeForm : Form
    {
        public ResizeForm()
        {
            InitializeComponent();
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }

            btnResize.Font = MemoryFonts.SetFont(0, btnResize.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btnClose.Font = MemoryFonts.SetFont(0, btnClose.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            this.Text = StringLoader.GetText("lb_game_resizer");

            btnResize.Text = StringLoader.GetText("btn_resize");
            btnClose.Text = StringLoader.GetText("btn_close");
            lbW.Text = StringLoader.GetText("text_width") + ":";
            lbH.Text = StringLoader.GetText("text_height") + ":";
            lbTip.Text = StringLoader.GetText("tooltip_resize_tip");
            lbCrash.Text = StringLoader.GetText("lb_resize_crash");

            var nationCheckeru = File.ReadAllText(Methods.GetFolder(Strings.FileName.Option));
            if (!string.IsNullOrEmpty(nationCheckeru))
            {
                txtW.Text = Regex.Match(nationCheckeru, @"VideoMode_Width=\d+").ToString().Replace("VideoMode_Width=", "");
                txtH.Text = Regex.Match(nationCheckeru, @"VideoMode_Height=\d+").ToString().Replace("VideoMode_Height=", "");
            }

            txtW.SelectionStart = txtW.Text.Length;
            txtW.DeselectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (string.IsNullOrEmpty(txtW.Text) || string.IsNullOrEmpty(txtH.Text) || !Methods.CheckIfNumberValid(txtW.Text) || !Methods.CheckIfNumberValid(txtH.Text))
            {
                MsgBoxs.Warning.InvalidValue(this);
                return;
            }

            if (Methods.IsGameFullScreen())
            {
                MsgBoxs.Warning.Error(this, "FullMode=1");
                return;
            }

            if (Methods.IsGameRunning_Alt())
            {
                var hWnd = Methods.ProcessHandler();
                NativeMethods.RECT Rect = new NativeMethods.RECT();
                int width = Methods.GetInt(txtW.Text);
                int height = Methods.GetInt(txtH.Text);
                if (NativeMethods.GetWindowRect(hWnd, ref Rect))
                {
                    NativeMethods.MoveWindow(hWnd, (Screen.PrimaryScreen.WorkingArea.Width - width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - height) / 2, width, height + Methods.GetTitlebarHeight(hWnd), true);
                }
            }
        }

        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtW_TextChanged(object sender, EventArgs e)
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
        }
    }
}
