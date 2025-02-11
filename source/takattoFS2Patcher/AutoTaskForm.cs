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
    public partial class AutoTaskForm : Form
    {
        public AutoTaskForm()
        {
            InitializeComponent();
        }

        private void AutoTaskForm_Load(object sender, EventArgs e)
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

            txtW.Text = MainForm.frmObj.autoTaskmin.ToString();
            txtCommand.Text = MainForm.frmObj.autoTaskcommand;
            cbGameGraphic.SelectedIndex = MainForm.frmObj.autoTaske;
            UseThisOrRadbtn.Checked = MainForm.frmObj.autoTaskRepeat;

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

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            //MainForm.frmObj.autoTaske = cbGameGraphic.SelectedIndex;
            //MainForm.frmObj.autoTaskmin = Int32.Parse(txtW.Text);

            if (GetInt(txtW.Text))          
            {
                MessageBoxEx.Show(this, $"That one hella big numba! Maxium allowed is 2147483~", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Int32.Parse(txtW.Text) <= 0 || String.IsNullOrEmpty(txtW.Text))
            {
                MessageBoxEx.Show(this, "Eh, please check the timer value again!", "TwT`", MessageBoxButtons.OK);
                return;
            }

            if (String.IsNullOrEmpty(txtCommand.Text))
                txtCommand.Text = "";

            MainForm.frmObj.autoTaskCheck(cbGameGraphic.SelectedIndex, Int32.Parse(txtW.Text), txtCommand.Text, UseThisOrRadbtn.Checked);
            Logging.Write("Auto task has been initialized");

            this.Close();
        }

        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cbGameGraphic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGameGraphic.SelectedItem.ToString().Contains("command") || cbGameGraphic.SelectedIndex == 2 || cbGameGraphic.SelectedIndex == 3)
            {
                txtCommand.Enabled = true;
                UseThisOrRadbtn.Enabled = true;
            }
            else
            {
                txtCommand.Enabled = false;
                UseThisOrRadbtn.Enabled = false;
            }
        }

        private void UseThisOrRadbtn_Click(object sender, EventArgs e)
        {
            UseThisOrRadbtn.Checked = !UseThisOrRadbtn.Checked;
        }
    }
}
