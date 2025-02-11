using System;
using System.Drawing;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();        
        }

        private void Help_Load(object sender, EventArgs e)
        {
            LoadControl();          
        }

        private void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            }
            btn_help1.Font = MemoryFonts.SetFont(0, btn_help1.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help2.Font = MemoryFonts.SetFont(0, btn_help2.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help3.Font = MemoryFonts.SetFont(0, btn_help3.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help4.Font = MemoryFonts.SetFont(0, btn_help4.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help5.Font = MemoryFonts.SetFont(0, btn_help5.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help6.Font = MemoryFonts.SetFont(0, btn_help6.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_help7.Font = MemoryFonts.SetFont(0, btn_help7.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            lb.Font = MemoryFonts.SetFont(0, lb.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);

            lb.Text = StringLoader.GetText("lb_help_select");
            this.Text = StringLoader.GetText("tooltip_button_help");
            btn_help1.Text = StringLoader.GetText("lb_help_categories").Split('|')[0];
            btn_help2.Text = StringLoader.GetText("lb_help_categories").Split('|')[1];
            btn_help3.Text = StringLoader.GetText("lb_help_categories").Split('|')[2];
            btn_help4.Text = StringLoader.GetText("lb_help_categories").Split('|')[3];
            btn_help5.Text = StringLoader.GetText("lb_help_categories").Split('|')[4];
            btn_help7.Text = StringLoader.GetText("lb_help_categories").Split('|')[5];
            btn_help6.Text = StringLoader.GetText("lb_help_categories").Split('|')[6];
        }

        private void btn_help1_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_patches");
        }

        private void btn_help2_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_tweaks");
        }

        private void btn_help3_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_voice_changer");
        }

        private void btn_help4_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_jukebox");
        }

        private void btn_help5_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_map");
        }

        private void btn_help7_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_crashes");
        }

        private void btn_help6_Click(object sender, EventArgs e)
        {
            lb.Text = StringLoader.GetText("lb_help_tips");
        }

    }
}
