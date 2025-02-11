using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    public partial class ResSettingForm : Form
    {
        public ResSettingForm()
        {
            InitializeComponent();
        }

        private void ResSettingForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size + 1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size, FontStyle.Regular);
            }


            this.TopMost = true;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            UseThisOrRadbtn.Checked = takattoFS2.Properties.Settings.Default.isCustomSettingApplied;
            txtW.Text = takattoFS2.Properties.Settings.Default.VideoMode_Width.ToString();
            txtH.Text = takattoFS2.Properties.Settings.Default.VideoMode_Height.ToString();
            cbGameGraphic.SelectedIndex = takattoFS2.Properties.Settings.Default.RenderQuality;

            this.txtW.SelectionStart = txtW.Text.Length;
            this.txtW.DeselectAll();
        }

        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtW.Text))
                txtW.Text = "0"; 
            if (string.IsNullOrEmpty(txtH.Text))
                txtH.Text = "0";

            if (GetInt(txtW.Text) || GetInt(txtH.Text))
            {
                MessageBoxEx.Show(this, $"That one hella big numba! Maxium allowed is 2147483~", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            takattoFS2.Properties.Settings.Default.isCustomSettingApplied = UseThisOrRadbtn.Checked;
            takattoFS2.Properties.Settings.Default.VideoMode_Width = int.Parse(txtW.Text);
            takattoFS2.Properties.Settings.Default.VideoMode_Height = int.Parse(txtH.Text);
            takattoFS2.Properties.Settings.Default.RenderQuality = cbGameGraphic.SelectedIndex;

            takattoFS2.Properties.Settings.Default.Save();

            this.Close();
        }

        private void btnUseThis_Click(object sender, EventArgs e)
        {
            UseThisOrRadbtn.Checked = !UseThisOrRadbtn.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
