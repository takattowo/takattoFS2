using System;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class CustomTextureForm : Form
    {
        public CustomTextureForm()
        {
            InitializeComponent(); 
        }
        
        private void Help_Jukebox_Downloader_Load(object sender, EventArgs e)
        {
            LoadControl();
            Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto));
            
            //var vern = string.IsNullOrEmpty(MainForm.mf.current_zacardo_version) ? StringLoader.GetText("lb_patch_not_installed") : MainForm.mf.current_zacardo_version;
            //lbVersion.Text = StringLoader.GetText("lb_tweak_charvoice_version", vern);
            lbVersion.Text = string.Empty;
            
            loader = new System.Timers.Timer(322);
            loader.Elapsed += OnTweakTimedEvent_loadShit;
            loader.Enabled = true;
        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            foreach (Control c in tabPage1.Controls)
            {
                c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            foreach (Control c in tabPage2.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

                c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            foreach (Control c in tabPage3.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

                c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            tabControl1.Font = MemoryFonts.SetFont(0, tabControl1.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            
            btnSelect.Font = MemoryFonts.SetFont(0, btnSelect.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            lbUIHint.Text = StringLoader.GetText("lb_tweak_interface_hint") + ":";
            tabPage1.Text = StringLoader.GetText("game_loading_screen");
            tabPage2.Text = StringLoader.GetText("game_cards");
            tabPage3.Text = StringLoader.GetText("addon");
            lbLoading.Text = StringLoader.GetText("lb_tweak_texture_loading") + "~ (*￣▽￣)b";
            lbWait.Text = StringLoader.GetText("lb_tweak_texture_developing") + "\n(´.• ω •.`)";
            lbWait2.Text = StringLoader.GetText("lb_tweak_texture_developing") + "\n(´.• ω •.`)";
            btnSelect.Text = StringLoader.GetText("btn_select");
            toolTip1.SetToolTip(btnSelect, StringLoader.GetText("tooltip_tweak_extension_select"));
        }

        private void OnTweakTimedEvent_loadShit(object sender, ElapsedEventArgs e)
        {
            loader.Enabled = false;

            if (File.Exists(Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto, Strings.KattoFileName.KattoLoadingPNG)))
            {
                try
                {
                    using (FileStream stream = new FileStream(Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto, Strings.KattoFileName.KattoLoadingPNG), FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = Image.FromStream(stream);
                        stream.Close();
                    }
                    panel2.SendToBack();
                }
                catch (Exception ew)
                {
                    Logger.Write("Error parsign image. Kat-code: " + ew.ToString());
                    panel2.SendToBack();
                }
            }
            else
            {
                try
                {
                    pictureBox1.Image.Save(@Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto, Strings.KattoFileName.KattoLoadingPNG), System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ew)
                {
                    Logger.Write("Error saving image. Kat-code: " + ew.ToString());
                }

                panel2.SendToBack();
            }
                
            
            ActiveControl = null;
        }

        public static System.Timers.Timer loader;

        public void btnConfirm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            try
            {
                if(!string.IsNullOrEmpty(imgPath))
                    File.Copy(imgPath, Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto, Strings.KattoFileName.KattoLoadingPNG), true);
            }
            catch (Exception ew)
            {
                MsgBoxs.Warning.Error(MainForm.mf, ew.ToString());
            }
        }
        
        string imgPath = null;  
        private void btnListen_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = StringLoader.GetText("tooltip_tweak_extension_select"),
                Filter = "PNG uwu`|*.png",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                        stream.Close();
                    }
                    imgPath = openFileDialog.FileName;
                    try
                    {
                        if (!string.IsNullOrEmpty(imgPath))
                            File.Copy(imgPath, Methods.GetFolder(Strings.FolderName.Image, Strings.FolderName.Katto, Strings.KattoFileName.KattoLoadingPNG), true);
                    }
                    catch (Exception ew)
                    {
                        MsgBoxs.Warning.Error(MainForm.mf, ew.ToString());
                    }
                }
                catch (Exception ew)
                {
                    MsgBoxs.Warning.Error(MainForm.mf, ew.ToString());
                }
            }
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            (sender as TabControl).SelectedTab.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 2:
                    lbUIHint.Visible = true;
                    btnSelect.Visible = false;
                    lbPNG.Visible = false;
                    break;
                case 1:
                case 0:
                    Methods.ExtractKatAddon(Methods.GetFolder(Strings.FolderName.CustomTexture));
                    lbUIHint.Visible = false;
                    btnSelect.Visible = true;
                    lbPNG.Visible = true;
                    break;
            }
        }
    }
}
