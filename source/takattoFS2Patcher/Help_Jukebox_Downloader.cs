using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    public partial class Help_Jukebox_Downloader : Form
    {
        public Help_Jukebox_Downloader()
        {

            InitializeComponent();
        }

        bool isJukeboxTweaked = MainForm.frmObj.isJukeBoxDLCinstalled;
        bool isDLC3installed = MainForm.frmObj.isDLC3installed;


        private void Help_Jukebox_Downloader_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size, FontStyle.Regular);
            }

            lb_ask.Font = MemoryFonts.GetFont(1, lb_ask.Font.Size, FontStyle.Regular);
            nicetry.Font = MemoryFonts.GetFont(0, nicetry.Font.Size + 1, FontStyle.Regular);

            if (isJukeboxTweaked && isDLC3installed)
            {
                btn_dlc1_red.Text = "Reinstall";
            }
            else
            {
                btn_dlc1_red.Text = "Install";
            }

        }

        private void btn_dlc1_red_Click(object sender, EventArgs e)
        {
            if (MainForm.frmObj.isGameRunning)
            {
                MessageBoxEx.Show(this, $"Anou... please close the game before installing this.", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirmResult = DialogResult;
            if (String.Equals(btn_dlc1_red.Text, "Reinstall"))
            {
                confirmResult = MessageBoxEx.Show(this, $"Eh, reinstall will delete all changes you made to the Jukebox, are chu sure?", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                confirmResult = MessageBoxEx.Show(this, $"Install this DLC3? You will love it~", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
                MainForm.frmObj.isTweakDownloading = true;
                string patchname = "takatto_tweak_dlc3";
                string dlcPackUrl = $"{PatcherSettings.GetValue(PatcherSettings.PATCH_SERVER_PATCHES)}/takatto_mods/takatto_tweak_dlc/{patchname}.dat";
                string tempDLCname = Path.Combine(PatcherSettings.TempDir, $"{patchname}.dat");
                string fs2Folder = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001));

                MainForm.frmObj.DownloadFile(dlcPackUrl, tempDLCname, fs2Folder);
                try
                {
                    File.Move(Path.Combine(fs2Folder, "Sound/BGMSoundResource.bml"), Path.Combine(fs2Folder, "Sound/BGMSoundResource_Kat.bml"));
                }
                catch
                {
                    return;
                };
                return;
            }
            else
            {
                return;
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            if (String.Equals(btn_dlc1_red.Text, "Install"))
            {
                MessageBoxEx.Show(this, $"Anou... please install the DLC3 first!", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var confirmResult = MessageBoxEx.Show(this, $"Anou, if your game is muted except Jukebox and you are using Global (Steam/Gamekiss) version, please install this!", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
                MainForm.frmObj.isTweakDownloading = true;
                string patchname = "takatto_tweak_dlc3_global_fixes";
                string dlcPackUrl = $"{PatcherSettings.GetValue(PatcherSettings.PATCH_SERVER_PATCHES)}/takatto_mods/takatto_tweak_dlc/DLC3_Extra/{patchname}.dat";
                string tempDLCname = Path.Combine(PatcherSettings.TempDir, $"{patchname}.dat");
                string fs2Folder = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001));

                MainForm.frmObj.DownloadFile(dlcPackUrl, tempDLCname, fs2Folder);
                try
                {
                    File.Move(Path.Combine(fs2Folder, "Sound/BGMSoundResource.bml"), Path.Combine(fs2Folder, "Sound/BGMSoundResource_Kat.bml"));
                }
                catch
                {
                    return;
                };
                return;
            }
            else
            {
                return;
            }
        }

        private void btnKorea_Click(object sender, EventArgs e)
        {
            if (String.Equals(btn_dlc1_red.Text, "Install"))
            {
                MessageBoxEx.Show(this, $"Anou... please install the DLC3 first!", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var confirmResult = MessageBoxEx.Show(this, $"Anou, if your game is muted except Jukebox and you are using Korea (Joycity/Nexon) version, please install this!", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
                MainForm.frmObj.isTweakDownloading = true;
                string patchname = "takatto_tweak_dlc3_kr_fixes";
                string dlcPackUrl = $"{PatcherSettings.GetValue(PatcherSettings.PATCH_SERVER_PATCHES)}/takatto_mods/takatto_tweak_dlc/DLC3_Extra/{patchname}.dat";
                string tempDLCname = Path.Combine(PatcherSettings.TempDir, $"{patchname}.dat");
                string fs2Folder = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001));

                MainForm.frmObj.DownloadFile(dlcPackUrl, tempDLCname, fs2Folder);
                try
                {
                    File.Move(Path.Combine(fs2Folder, "Sound/BGMSoundResource.bml"), Path.Combine(fs2Folder, "Sound/BGMSoundResource_Kat.bml"));
                }
                catch
                {
                    return;
                };
                return;
            }
            else
            {
                return;
            }
        }

        private void btnChina_Click(object sender, EventArgs e)
        {
            if (String.Equals(btn_dlc1_red.Text, "Install"))
            {
                MessageBoxEx.Show(this, $"Anou... please install the DLC3 first!", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var confirmResult = MessageBoxEx.Show(this, $"Anou, if your game is muted except Jukebox and you are using China (Tiancity) version, please install this!", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
                MainForm.frmObj.isTweakDownloading = true;
                string patchname = "takatto_tweak_dlc3_chn_fixes";
                string dlcPackUrl = $"{PatcherSettings.GetValue(PatcherSettings.PATCH_SERVER_PATCHES)}/takatto_mods/takatto_tweak_dlc/DLC3_Extra/{patchname}.dat";
                string tempDLCname = Path.Combine(PatcherSettings.TempDir, $"{patchname}.dat");
                string fs2Folder = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001));

                MainForm.frmObj.DownloadFile(dlcPackUrl, tempDLCname, fs2Folder);
                try
                {
                    File.Move(Path.Combine(fs2Folder, "Sound/BGMSoundResource.bml"), Path.Combine(fs2Folder, "Sound/BGMSoundResource_Kat.bml"));
                }
                catch
                {
                    return;
                };
                return;
            }
            else
            {
                return;
            }
        }
    }
}
