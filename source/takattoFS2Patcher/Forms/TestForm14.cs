using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class TestForm14 : Form
    {
        int test_coded = 0;
        public TestForm14(int test_code)
        {
            test_coded = test_code;
            InitializeComponent();          
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {
            switch (test_coded)
            {
                case 1345794:
                    btna.Text = "Bean it";
                    btnb.Text = "Reverse bean it";
                    Text = "Bean maker [Test 14]";
                    btnb.Click += new EventHandler(btnReverseBean_Click);
                    btna.Click += new EventHandler(btnBean_Click);
                    break;
                case 934571:
                    btna.Text = "Katcrypt";
                    btnb.Text = "Reverse katcrypt";
                    Text = "Katcryptor [Test 1]";
                    btnb.Click += new EventHandler(btnReverseKat_Click);
                    btna.Click += new EventHandler(btnKat_Click);
                    break;
                case 0:
                default:
                    Close();
                    break;
            }

            btnb.Click += new EventHandler(btn_Click);
            btna.Click += new EventHandler(btn_Click);
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

            btna.Font = MemoryFonts.SetFont(0, btna.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btnb.Font = MemoryFonts.SetFont(0, btnb.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            //ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Close();
        }

        private void btnKat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inp.Text))
            {
                MessageBoxEx.Show(this, "Please enter valid value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inp.Focus();
                return;
            }

            try
            {
                outp.Text = KATEncryptor.Encrypt(inp.Text, 1);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void btnReverseKat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(outp.Text))
            {
                MessageBoxEx.Show(this, "Please enter valid value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                outp.Focus();
                return;
            }
            
            try
            {
                inp.Text = KATEncryptor.Decrypt(outp.Text, 1);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBean_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inp.Text) || string.IsNullOrEmpty(outp.Text))
            {
                MessageBoxEx.Show(this,"Please enter valid paths!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                KATEncryptor.ConvertB(inp.Text, outp.Text);
                MessageBoxEx.Show(this, "Conveted successfully.","Yeppy!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReverseBean_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inp.Text) || string.IsNullOrEmpty(outp.Text))
            {
                MessageBoxEx.Show(this, "Please enter valid paths!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                KATEncryptor.ConvertB(outp.Text, inp.Text);
                MessageBoxEx.Show(this, "Conveted successfully.", "Yeppy!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}
