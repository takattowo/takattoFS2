using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static takattoFS2.MainForm;

namespace takattoFS2
{
    public partial class CustomJukeboxForm : Form
    {
        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        public CustomJukeboxForm()
        {
            InitializeComponent();

            int style = NativeWinAPI.GetWindowLong(panel1.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(panel1.Handle, NativeWinAPI.GWL_EXSTYLE, style);

            LoadMusic();
        }

        int totalSong;

        public void LoadMusic()
        {
            try
            {
                string filePath = @Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound/BGMSoundResource.xml");
                DataSet dataSet = new DataSet();
                //Read xml to dataset and pass file path as parameter 
                dataSet.ReadXml(filePath);
                dataGridView1.DataSource = dataSet.Tables[2];
                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                totalSong = dataGridView1.Rows.Count;
            }
            catch (Exception e)
            { 
                MainForm.frmObj.JukeBoxError(e.Message);
                //MessageBoxEx.Show(this, "Could not load the Jukebox dataset, the data must be corrupted. Please reinstall the DLC or contact me for help~ ｏ(＞＜)○", ">..<", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CustomJukeboxForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.GetFont(0, c.Font.Size, FontStyle.Regular);

            }
            dataGridView1.Font = MemoryFonts.GetFont(0, dataGridView1.Font.Size + 1, FontStyle.Regular);
            lbSongPath.Font = MemoryFonts.GetFont(0, lbSongPath.Font.Size + 1, FontStyle.Regular);
            txtSinger.Font = MemoryFonts.GetFont(0, txtSinger.Font.Size + 1, FontStyle.Regular);
            txtSongName.Font = MemoryFonts.GetFont(0, txtSongName.Font.Size + 1, FontStyle.Regular);

            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //dataGridView1.ClearSelection();
            lb_customJukeboxhint.Font = MemoryFonts.GetFont(1, lb_customJukeboxhint.Font.Size, FontStyle.Regular);
            lbSongName.Font = MemoryFonts.GetFont(1, lbSongName.Font.Size, FontStyle.Regular);
            lbSinger.Font = MemoryFonts.GetFont(1, lbSinger.Font.Size, FontStyle.Regular);
            try
            {
                dataGridView1.Columns["Sound_Name"].Width = (int)(dataGridView1.Width * 0.5);
                dataGridView1.Columns["Sound_Name"].HeaderText = "Sound name";
                dataGridView1.Columns["Sound_Name"].HeaderCell.Style.Font = MemoryFonts.GetFont(1, 11, FontStyle.Regular);
                dataGridView1.Columns["Sound_Singer"].Width = (int)(dataGridView1.Width * 0.5);
                dataGridView1.Columns["Sound_Singer"].HeaderText = "Artist(s)";
                dataGridView1.Columns["Sound_Singer"].HeaderCell.Style.Font = MemoryFonts.GetFont(1, 11, FontStyle.Regular);
                dataGridView1.Columns["Sound_Path"].Visible = false;
            }
            catch
            {
                this.Close();
            }
        }

        private void btn_gamekill_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select a mp3 song~";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "mp3 file only uwu`|*.mp3*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                String artist = "";
                String title = "";
                try
                {
                    TagLib.File tagFile = TagLib.File.Create(fdlg.FileName);
                    artist = tagFile.Tag.FirstPerformer;
                    title = tagFile.Tag.Title;
                }
                catch { }

                txtSongName.ReadOnly = false;
                txtSinger.ReadOnly = false;
                if (!string.IsNullOrEmpty(artist))
                {
                    txtSinger.Text = artist;
                }
                else
                {
                    txtSinger.Text = "Unknown";
                }
                if (!string.IsNullOrEmpty(title))
                {
                    txtSongName.Text = title;
                }
                else
                {

                    txtSongName.Text = System.IO.Path.GetFileName(fdlg.FileName).Replace(".mp3", "");
                }
                lbSongPath.Text = fdlg.FileName;
                //Player.URL = lbSongPath.Text;
                //textBox1.Text = fdlg.FileName;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Player.currentPlaylist.clear();
            }
            catch { }
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ImportForm importform = new ImportForm();
            importform.StartPosition = FormStartPosition.CenterParent;
            importform.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSongName.ReadOnly = true;
            txtSinger.ReadOnly = true;
            txtSongName.Text = "";
            txtSinger.Text = "";
            lbSongPath.Text = "[Song Path]";

            LoadMusic();
            //dataGridView1.ClearSelection();
        }

        private void txtSongName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSongName.Text))
            {
                btnAdd.Enabled = false;
                btnAdd.BackColor = Color.LightGray;
            }
            else
            {
                btnAdd.Enabled = true;
                btnAdd.BackColor = Color.SlateBlue;
            }
        }

        string filename = @Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound/BGMSoundResource.xml");
        XmlDocument doc = new XmlDocument();
        const string quote = "\"";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSongName.Text.Contains("&") || txtSinger.Text.Contains("&"))
            {
                MessageBoxEx.Show(this, $"It is not allowed to have " + quote + "&" + quote + " in the name! Please try again UwU`", "Eww not again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }


            doc.Load(filename);
            XmlNode parentNode = doc.SelectSingleNode("BGM/BGM_SOUND_LIST");

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "BGM_SOUND", null);
            XmlNode nodeTitle = doc.CreateElement("Sound_Name");
            nodeTitle.InnerText = txtSongName.Text;

            XmlNode nodeSinger = doc.CreateElement("Sound_Singer");
            nodeSinger.InnerText = txtSinger.Text;

            XmlNode nodePath = doc.CreateElement("Sound_Path");
            nodePath.InnerText = @"Sound\BGM_TAKATTO_JUKEBOX\" + System.IO.Path.GetFileName(lbSongPath.Text);

            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");


            if (regex.IsMatch(System.IO.Path.GetFileName(lbSongPath.Text)))
            {
                try
                {
                    System.IO.File.Copy(lbSongPath.Text, Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound", "BGM_TAKATTO_JUKEBOX", System.IO.Path.GetFileName(lbSongPath.Text)), true);
                }
                catch
                {
                     MessageBoxEx.Show(this, $"Could not parse the song to the game data, either you have no rights or something is blocking it (maybe antivirus?). ｏ(＞＜)○", "Eww not again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }
            }
            else
            {
                try
                {
                    Random random = new Random();
                    int randomLessThan2902 = random.Next(929209);

                    string newSoundName = "music_jukebox_takatto" + randomLessThan2902 + ".mp3";
                    nodePath.InnerText = @"Sound\BGM_TAKATTO_JUKEBOX\" + newSoundName;
                    System.IO.File.Copy(lbSongPath.Text, Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound", "BGM_TAKATTO_JUKEBOX", newSoundName), true);
                }
                catch
                {
                    MessageBoxEx.Show(this, $"Could not parse the song to the game data, either you have no rights or something is blocking it (maybe antivirus?). ｏ(＞＜)○", "Eww not again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }
            }





            node.AppendChild(nodeTitle);
            node.AppendChild(nodeSinger);
            node.AppendChild(nodePath);

            //doc.DocumentElement.AppendChild(node);
            parentNode.InsertAfter(node, parentNode.LastChild);

            doc.Save(filename);





            MessageBoxEx.Show(this, $"" + quote + "" + txtSongName.Text + "" + quote + " has been added to Jukebox! ｏ(＞＜)○", "Yay it works!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Logging.Write(txtSongName.Text + " has been added to Jukebox");

            txtSongName.ReadOnly = true;
            txtSinger.ReadOnly = true;
            txtSongName.Text = "";
            txtSinger.Text = "";
            lbSongPath.Text = "[Song Path]";
            LoadMusic();
            dataGridView1.Rows[totalSong - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = totalSong - 1;
        }

        string songtodelete = null;
        string songpathtodelete = null;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(songtodelete) || string.IsNullOrEmpty(songpathtodelete))
            {
                MessageBoxEx.Show(this, $"Select a song to remove! (￣ﾊ￣*)", "eeew...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }

            if (totalSong <= 1)
            {
                MessageBoxEx.Show(this, $"Eh, you will need at least one song in the Jukebox! (￣ﾊ￣*)", "eeew...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }



            var confirmResult = MessageBoxEx.Show(this, $"Do you want to remove " + quote + "" + songtodelete + "" + quote + " from Jukebox? ", "ヘ(￣ω￣ヘ)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes) { }
            else
            {
                return;
            }

            doc.Load(filename);
            songtodelete = songtodelete.Replace("'", "\\'");
            try
            {
                XmlElement el = (XmlElement)doc.SelectSingleNode($"/BGM/BGM_SOUND_LIST/BGM_SOUND[Sound_Path = '{songpathtodelete}']");
                if (el != null) { el.ParentNode.RemoveChild(el); }
            }
            catch
            {
                MessageBoxEx.Show(this, $"" + quote + "" + songtodelete + "" + quote + " can not be removed because of invalid token, this should be fixed in the future~ (〜￣▽￣)〜	", "Eeeeehhhk!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            doc.Save(filename);
            try
            {
                Player.currentPlaylist.clear();
                System.IO.File.Delete(Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound", "BGM_TAKATTO_JUKEBOX", songtodeletefile));
            }
            catch { }

            MessageBoxEx.Show(this, $"" + quote + "" + songtodelete + "" + quote + " has been removed from Jukebox! (〜￣▽￣)〜	", "Yay it works!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Logging.Write(songtodelete + " has been removed from Jukebox");

            LoadMusic();
            //dataGridView1.ClearSelection();
        }

        private bool selectionChanged;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectionChanged = true;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                try
                {
                    songtodelete = Convert.ToString(selectedRow.Cells["Song name"].Value);
                    songpathtodelete = Convert.ToString(selectedRow.Cells["Sound_Path"].Value);
                }
                catch
                {
                    songtodelete = Convert.ToString(selectedRow.Cells["Sound_Name"].Value);
                    songpathtodelete = Convert.ToString(selectedRow.Cells["Sound_Path"].Value);
                }
            }
            else
            {
                songtodelete = null;
                songpathtodelete = null;
                //dataGridView1.ClearSelection();
            }
        }
        string songtodeletefile = "ok";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string songtoplay = "not fucking null ok";
            if (!string.IsNullOrEmpty(songpathtodelete))
            {
                songtodeletefile = songpathtodelete.Replace(@"Sound\BGM_TAKATTO_JUKEBOX\", "");
            }

            if (!string.IsNullOrEmpty(songpathtodelete) && isplaying)
            {
                try
                {
                    songtoplay = songpathtodelete.Replace(@"Sound\BGM_TAKATTO_JUKEBOX\", "");
                    Player.URL = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound", "BGM_TAKATTO_JUKEBOX", songtoplay);
                }
                catch
                {

                }
            }
            if (!selectionChanged)
            {
                //dataGridView1.ClearSelection();
                selectionChanged = true;
            }
            else
            {
                selectionChanged = false;
            }
        }

        WMPLib.WindowsMediaPlayer Player;
        bool isplaying = false;

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!isplaying)
            {
                Player = new WMPLib.WindowsMediaPlayer();
                //Player.PlayStateChange += Player_PlayStateChange;
                Player.URL = Path.Combine(PatcherSettings.GetValue(PatcherSettings.takatto00001), "Sound", "BGM_TAKATTO_JUKEBOX", songpathtodelete.Replace(@"Sound\BGM_TAKATTO_JUKEBOX\", ""));
                try
                {
                    Player.controls.play();
                    isplaying = true;
                    btnListen.Text = "Stop";
                }
                catch
                {
                    MessageBoxEx.Show(this, $"Could not load media player library on this computer! (￣▽￣)", "Eeeeehhhk!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                try
                {
                    Player.controls.stop();
                    Player.URL = null;
                    isplaying = false;
                    btnListen.Text = "♪ Listen";
                }
                catch
                {
                    MessageBoxEx.Show(this, $"Could not load media player library on this computer! (￣▽￣)", "Eeeeehhhk!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                //Actions on stop
            }
        }

        private void CustomJukeboxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isplaying)
            {
                Player.controls.stop();
                isplaying = false;
                btnListen.Text = "Listen";
            }
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            if (MainForm.frmObj.isGameRunning)
            {
                MessageBoxEx.Show(this, $"Anou... please close the game before installing this.", "QwO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirmResult = MessageBoxEx.Show(this, $"Eh, reinstall will delete all changes you made to the Jukebox, are chu sure?", "(≧w≦) ehe~", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Player.currentPlaylist.clear();
                }
                catch { }
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
    }
}
