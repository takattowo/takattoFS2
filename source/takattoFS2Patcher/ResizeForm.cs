using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    public partial class ResizeForm : Form
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        public ResizeForm()
        {
            InitializeComponent();
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size + 1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size, FontStyle.Regular);
            }

            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var nationCheckeru = File.ReadAllText(Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "option.ini"));
            if (!string.IsNullOrEmpty(nationCheckeru))
            {
                txtW.Text = Regex.Match(nationCheckeru, @"VideoMode_Width=\d+").ToString().Replace("VideoMode_Width=", "");
                txtH.Text = Regex.Match(nationCheckeru, @"VideoMode_Height=\d+").ToString().Replace("VideoMode_Height=", "");
            }

            this.txtW.SelectionStart = txtW.Text.Length;
            this.txtW.DeselectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool GetInt(string strRawData)
        {
            try
            {
                int numba = Int32.Parse(Regex.Replace(strRawData, "[^0-9]", ""));
                return false;
            }
            catch
            {
                return true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtW.Text) || string.IsNullOrEmpty(txtH.Text))
            {
                MessageBoxEx.Show(this, $"Invalid parametter, please check the width and height!", "QwO", MessageBoxButtons.OK);
                return;
            }

            Process[] processes = Process.GetProcessesByName("FreeStyle2");
            foreach (Process p in processes)
            {
                IntPtr handle = p.MainWindowHandle;
                RECT Rect = new RECT();
                if (GetInt(txtW.Text) || GetInt(txtH.Text))
                {
                    MessageBoxEx.Show(this, $"That one hella big numba! Maxium allowed is 2147483~", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int width = Int32.Parse(txtW.Text);
                int height = Int32.Parse(txtH.Text);
                if (GetWindowRect(handle, ref Rect))
                {
                    MoveWindow(handle, (Screen.PrimaryScreen.WorkingArea.Width - width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - height) / 2, width, height, true);
                    return;
                }
            }

            MessageBoxEx.Show(this, $"There is no FS2 running~", "QwO", MessageBoxButtons.OK);
        }


        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
