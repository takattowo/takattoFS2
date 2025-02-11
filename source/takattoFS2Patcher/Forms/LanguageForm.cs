using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class LanguageForm : Form
    {
        public LanguageForm()
        {
            InitializeComponent();
        }

        void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            btn_confirm.Font = MemoryFonts.SetFont(0, btn_confirm.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            nicetry.Font = MemoryFonts.SetFont(1, nicetry.Font.Size, PatcherSettings.fontOffset3, FontStyle.Regular);
            lb_langhintwhy.Font = MemoryFonts.SetFont(0, lb_langhintwhy.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            cbGameLanguage.Font = MemoryFonts.SetFont(0, cbGameLanguage.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            lb_langhint.Font = MemoryFonts.SetFont(1, lb_langhint.Font.Size, PatcherSettings.fontOffset3, FontStyle.Regular);

            TopMost = true;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            
            this.Text = StringLoader.GetText("tooltip_button_language");
            lb_langhint.Text = StringLoader.GetText("LB_language_hint") + ":";
            lb_langhintwhy.Text = StringLoader.GetText("lb_language_help");
            btn_confirm.Text = StringLoader.GetText("btn_confirm");
        }

        private void GameLanguageChangerForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            
            if (Methods.IsChinaClient())
                cbGameLanguage.Items[cbGameLanguage.FindStringExact("中國人")] = "中国人";

           
            string gameLanguage = UserSettings.GameLanguage;

            if(!string.IsNullOrEmpty(Methods.GetGameFolder()))
            {
                 if (File.Exists(Methods.GetFolder(Strings.FolderName.Language, Strings.KattoFileName.StringDataKatto)))
                    cbGameLanguage.Items.Add("CUSTOM");
            }

            if (!string.IsNullOrEmpty(gameLanguage))
            {
                cbGameLanguage.SelectedIndex = cbGameLanguage.FindStringExact(gameLanguage);
                if (Methods.IsChinaClient())
                {
                    if (gameLanguage == "中國人")
                        cbGameLanguage.SelectedIndex = cbGameLanguage.FindStringExact("中国人");
                }
                else
                {
                    if (gameLanguage == "中国人")
                        cbGameLanguage.SelectedIndex = cbGameLanguage.FindStringExact("中國人");
                }

                lb_langhint.Focus();

                if (cbGameLanguage.SelectedIndex == -1)
                {
                    cbGameLanguage.SelectedIndex = cbGameLanguage.FindStringExact("ENGLISH");
                    nicetry.Visible = true;
                    lb_langhint.Focus();
                }
            }
            else
            {
                cbGameLanguage.SelectedIndex = cbGameLanguage.FindStringExact("ENGLISH");
                lb_langhint.Focus();
            }
        }

        private void cbVoiceLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_langhint.Focus();
            if (cbGameLanguage.SelectedIndex == -1)
                return;
        }

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (cbGameLanguage.SelectedIndex == -1)
                return;
            
            string lang = cbGameLanguage.Text;
            //PatcherSettings.SetValue(PatcherSettings.takatto00003, lang);
            UserSettings.GameLanguage = lang;
            Close();
        }

        private void GameLanguageChangerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbGameLanguage.SelectedIndex == -1)
                return;
            string lang = cbGameLanguage.Text;
            //PatcherSettings.SetValue(PatcherSettings.takatto00003, lang);
            UserSettings.GameLanguage = lang;
            Logger.Write("Game language has updated - " +lang);
        }

        private void cbGameLanguage_DropDownClosed(object sender, EventArgs e)
        {
            lb_langhint.Focus();
        }
    }
}
