using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class CustomJukeboxForm : Form
    {
        public CustomJukeboxForm()
        {
            InitializeComponent();
        }

        int totalSong;
        string filePath = Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.BGMKatto);
        public void LoadMusic()
        {
            Methods.MoveFile(Methods.GetFolder(Strings.FolderName.Data, Strings.FileName.BGMSoundResXML), Methods.GetFolder(Strings.FolderName.Data, Strings.KattoFileName.BGMKatto), false);

            try
            {
                DataSet dataSet = new DataSet();
                //Read xml to dataset and pass file path as parameter 
                dataSet.ReadXml(filePath);
                dataGridView1.DataSource = dataSet.Tables[2];
                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                totalSong = dataGridView1.Rows.Count;
            }
            catch (Exception ew)
            {
                HandleError(ew.ToString());      
            }
            if (isplaying)
            {
                if(musicPlayingIndex != -1)
                {
                    dataGridView1.Rows[musicPlayingIndex].Selected = true;
                }
            }
        }

        void HandleError(string error)
        {
            lbCorrupt.Visible = true;
            btn_select.Enabled = false;
            btnReset.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
            btnListen.Visible = false;
            btn_select.BackColor = Color.LightGray;
            btnReinstall.Location = btnListen.Location;
            
            try
            {
                Player.currentPlaylist.clear();
            }
            catch { }

            Logger.Write("Could not load Jukebox dataset. Kat-code: " + error);
        }

        public void CheckEnable()
        {
            glassyPanel1.Visible = !UserSettings.JukeboxTweakSetting;

            txtSongName.TabStop = UserSettings.JukeboxTweakSetting;
            txtSinger.TabStop = UserSettings.JukeboxTweakSetting;
            btn_select.TabStop = UserSettings.JukeboxTweakSetting;
            btnReinstall.TabStop = UserSettings.JukeboxTweakSetting;
            btnReset.TabStop = UserSettings.JukeboxTweakSetting;
            btnDelete.TabStop = UserSettings.JukeboxTweakSetting;
            btnAdd.TabStop = UserSettings.JukeboxTweakSetting;
            btnListen.TabStop = UserSettings.JukeboxTweakSetting;
        }
        
        private void CustomJukeboxForm_Load(object sender, EventArgs e)
        {
            CheckEnable();
            LoadControl();
            LoadMusic();

            try
            {

                dataGridView1.Columns["Sound_Name"].Width = (int)(dataGridView1.Width * 0.5); //0.5
                dataGridView1.Columns["Sound_Name"].HeaderText = StringLoader.GetText("lb_tweak_jukebox_soundname");
                dataGridView1.Columns["Sound_Singer"].Width = (int)(dataGridView1.Width * 0.5);
                dataGridView1.Columns["Sound_Singer"].HeaderText = StringLoader.GetText("lb_tweak_jukebox_artist");
                dataGridView1.Columns["Sound_Path"].Visible = false;

            }
            catch (Exception ew)
            {
                HandleError(ew.ToString());
            }

            ActiveControl = lbSongPath;
        }

        private void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                else
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }
            dataGridView1.Font = MemoryFonts.SetFont(0, btn_select.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            btn_select.Font = MemoryFonts.SetFont(0, btn_select.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            txtSongName.PlaceHolderText = StringLoader.GetText("lb_tweak_jukebox_soundname");
            txtSongName.Text = StringLoader.GetText("lb_tweak_jukebox_soundname");
            txtSinger.PlaceHolderText = StringLoader.GetText("lb_tweak_jukebox_artist");
            txtSinger.Text = StringLoader.GetText("lb_tweak_jukebox_artist");
            lbSongPath.Text = StringLoader.GetText("lb_tweak_jukebox_path");
            btn_select.Text = StringLoader.GetText("btn_select");
            lbCorrupt.Text = StringLoader.GetText("lb_tweak_jukebox_corrupted") + "\r\n~(￣ω￣)\t";
            toolTip1.SetToolTip(btn_select, StringLoader.GetText("tooltip_tweak_jukebox_select"));
            toolTip1.SetToolTip(btnListen, StringLoader.GetText("tooltip_tweak_jukebox_listen"));
            toolTip1.SetToolTip(btnReinstall, StringLoader.GetText("tooltip_tweak_jukebox_reinstall"));
            toolTip1.SetToolTip(btnReset, StringLoader.GetText("lb_reset"));
            toolTip1.SetToolTip(btnDelete, StringLoader.GetText("tooltip_tweak_jukebox_delete"));
            toolTip1.SetToolTip(btnAdd, StringLoader.GetText("tooltip_tweak_jukebox_add"));
            deleteSelectedSongToolStripMenuItem.Text = StringLoader.GetText("context_tweak_jukebox_delete");
            moveSelectedSongToTopToolStripMenuItem.Text = StringLoader.GetText("context_tweak_jukebox_move");
        }

        private void btn_gamekill_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = StringLoader.GetText("msgtitle_select_jukebox_song"),
                Filter = "MP3 uwu` (only support 128kbps)|*.mp3",
                FilterIndex = 2,
                RestoreDirectory = true
            };

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
                txtSongName.TabStop = true;
                txtSinger.ReadOnly = false;
                txtSinger.TabStop = true;

                if (!string.IsNullOrEmpty(artist))
                {
                    txtSinger.removePlaceHolder(null, null);
                    txtSinger.Text = artist;
                }
                else
                {
                    txtSinger.removePlaceHolder(null, null);
                    txtSinger.Text = "Unknown";
                }
                if (!string.IsNullOrEmpty(title))
                {
                    txtSongName.removePlaceHolder(null, null);
                    txtSongName.Text = title;
                }
                else
                {
                    txtSongName.removePlaceHolder(null, null);
                    txtSongName.Text = Path.GetFileName(fdlg.FileName).Replace(".mp3", "");
                }
                SongPath = fdlg.FileName;
                lbSongPath.Text = SongPath.Substring(0, 3) + "..." + SongPath.Substring((SongPath.Length - 11), 11);


                glassyPanel2.Visible = false;
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Reset();

            LoadMusic();
        }

        private void txtSongName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSongName.Text) || String.IsNullOrWhiteSpace(txtSongName.Text) || (txtSongName.Text).Contains(StringLoader.GetText("lb_tweak_jukebox_soundname")))
            {
                isAbletoAdd = false;
                btnAdd.BackgroundImage = Properties.Resources.icons8_add_disa_35;
            }
            else
            {
                isAbletoAdd = true;
                btnAdd.BackgroundImage = Properties.Resources.icons8_add_35;
            }
        }

        
        XmlDocument doc = new XmlDocument();
        bool isAbletoAdd = false;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (!isAbletoAdd)
                return;

            txtSongName.Text.Replace("&", ",");
            txtSinger.Text.Replace("&", ",");

            doc.Load(filePath);
            XmlNode parentNode = doc.SelectSingleNode("BGM/BGM_SOUND_LIST");

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "BGM_SOUND", null);
            XmlNode nodeTitle = doc.CreateElement("Sound_Name");
            nodeTitle.InnerText = txtSongName.Text.Trim();

            XmlNode nodeSinger = doc.CreateElement("Sound_Singer");
            nodeSinger.InnerText = txtSinger.Text.Trim();

            XmlNode nodePath = doc.CreateElement("Sound_Path");
            nodePath.InnerText = Strings.FolderName.Jukebox + "\\" + Path.GetFileName(SongPath.Trim());

            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");

            Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.Jukebox));

            if (regex.IsMatch(Path.GetFileName(SongPath.Trim())))
            {
                try
                {
                    File.Copy(SongPath.Trim(), Methods.GetFolder(Strings.FolderName.Jukebox, Path.GetFileName(SongPath.Trim())), true);
                }
                catch (Exception msg)
                {
                    MsgBoxs.Warning.Error(MainForm.mf, msg.ToString());
                    return;
                }
            }
            else
            {
                try
                {
                    Random random = new Random();
                    int randomLessThan2902 = random.Next(99929209);

                    string newSoundName = "sound" + randomLessThan2902 + ".mp3";
                    nodePath.InnerText = Strings.FolderName.Jukebox + "\\" +  newSoundName;
                    File.Copy(SongPath.Trim(), Methods.GetFolder(Strings.FolderName.Jukebox, newSoundName), true);
                }
                catch (Exception msg)
                {
                    MsgBoxs.Warning.Error(MainForm.mf, msg.ToString()); 
                    return;
                }
            }

            node.AppendChild(nodeTitle);
            node.AppendChild(nodeSinger);
            node.AppendChild(nodePath);

            parentNode.InsertAfter(node, parentNode.LastChild);

            doc.Save(filePath);

            MsgBoxs.Information.SongHasBeenAdded(MainForm.mf, txtSongName.Text.Trim());         

            Reset();

            LoadMusic();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[totalSong - 1].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = totalSong - 1;

            if (isplaying)
                dataGridView1_CellClick(null, null);
        }

        string SongPath = null;
        void Reset()
        {
            txtSongName.ReadOnly = true;
            txtSongName.TabStop = false;
            txtSinger.ReadOnly = true;
            txtSinger.TabStop = false;

            txtSongName.Text = "";
            txtSinger.Text = "";
            lbSongPath.Text = StringLoader.GetText("lb_tweak_jukebox_path");
            SongPath = null;
            txtSongName.setPlaceholder(null, null);
            txtSinger.setPlaceholder(null, null);



            glassyPanel2.Visible = true;
        }

        string songtodelete = null;
        string songpathtodelete = null;
        string songartistsomehow = null;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (string.IsNullOrEmpty(songtodelete))
            {
                MsgBoxs.Information.NoItemSelected(MainForm.mf);
                return;
            }

            if (totalSong <= 1)
            {
                MsgBoxs.Information.AtleastOneFieldRequired(MainForm.mf);
                return;
            }

            var confirmResult = MsgBoxs.Dialog.RemoveSongFromJukebox(MainForm.mf, songtodelete);
            if (confirmResult == DialogResult.Yes) { }
            else
            {
                return;
            }

            doc.Load(filePath);
            songtodelete = songtodelete.Replace("'", "\\'");
            try
            {
                if (string.IsNullOrEmpty(songpathtodelete))
                {
                    XmlElement el = (XmlElement)doc.SelectSingleNode($"/BGM/BGM_SOUND_LIST/BGM_SOUND[Sound_Name = '{songtodelete}']");
                    if (el != null) { el.ParentNode.RemoveChild(el); }
                }
                else
                {
                    XmlElement el = (XmlElement)doc.SelectSingleNode($"/BGM/BGM_SOUND_LIST/BGM_SOUND[Sound_Path = '{songpathtodelete}']");
                    if (el != null) { el.ParentNode.RemoveChild(el); }
                }
            }
            catch (Exception ew)
            {
                MsgBoxs.Warning.Error(MainForm.mf, ew.ToString());
                return;
            }

            doc.Save(filePath);

            try
            {
                Player.currentPlaylist.clear();
                File.Delete(Methods.GetFolder(Strings.FolderName.Jukebox, songtodeletefile));
            }
            catch { }

            MsgBoxs.Information.SongHasBeenRemoved(MainForm.mf, songtodelete);

            Reset();
            LoadMusic();
            if (isplaying)
                dataGridView1_CellClick(null, null);
        }

        private bool selectionChanged;
        int musicPlayingIndex = -1;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectionChanged = true;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                songtodelete = Convert.ToString(selectedRow.Cells["Sound_Name"].Value);
                songartistsomehow = Convert.ToString(selectedRow.Cells["Sound_Singer"].Value);
                songpathtodelete = Convert.ToString(selectedRow.Cells["Sound_Path"].Value);          
            }
            else
            {
                songtodelete = null;
                songpathtodelete = null; 
                //dataGridView1.ClearSelection();
            }        
        }


        string songtodeletefile = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string songtoplay;

            if (!string.IsNullOrEmpty(songpathtodelete) && isplaying)
            {
                try
                {
                    songtoplay = songpathtodelete.Replace(Strings.FolderName.Jukebox + "\\", "");
                    Player.URL = Methods.GetFolder(Strings.FolderName.Jukebox, songtoplay);
                    musicPlayingIndex = dataGridView1.SelectedCells[0].RowIndex;
                    Player.controls.play();
                }
                catch
                {
                    musicPlayingIndex = -1;
                }
            }
            if (!selectionChanged)
            {
                selectionChanged = true;
            }
            else
            {
                selectionChanged = false;
            }
        }

        WMPLib.WindowsMediaPlayer Player;
        public bool isplaying = false;

        public void DisableMusic()
        {
            if (isplaying)
            {
                try
                {
                    musicPlayingIndex = -1;
                    Player.controls.stop();
                    Player.URL = null;
                    isplaying = false;
                    btnListen.BackgroundImage = Properties.Resources.icons8_musical_notes_disa_35;
                }
                catch
                {
                    musicPlayingIndex = -1;          
                }
                Player.currentPlaylist.clear();
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (!isplaying)
            {
                Player = new WMPLib.WindowsMediaPlayer
                {
                    URL = Methods.GetFolder(Strings.FolderName.Jukebox, songpathtodelete.Replace(Strings.FolderName.Jukebox + "\\", ""))
                };
                Player.settings.setMode("loop", true);
                try
                {
                    musicPlayingIndex = dataGridView1.SelectedCells[0].RowIndex;
                    Player.controls.play();
                    isplaying = true;
                    btnListen.BackgroundImage = Properties.Resources.icons8_musical_notes_35;
                }
                catch
                {
                    musicPlayingIndex = -1; 
                    Player.URL = null;
                    isplaying = false;
                    btnListen.BackgroundImage = Properties.Resources.icons8_musical_notes_disa_35;
                    MsgBoxs.Warning.NoSoundLibExist(MainForm.mf);
                }
            }
            else
            {
                try
                {
                    musicPlayingIndex = -1;
                    Player.controls.stop();
                    Player.URL = null;
                    isplaying = false;
                    btnListen.BackgroundImage = Properties.Resources.icons8_musical_notes_disa_35;
                }
                catch
                {
                    musicPlayingIndex = -1;            
                }
                Player.currentPlaylist.clear();
            }
        }

        private void CustomJukeboxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveControl = null;
            if (isplaying)
            {
                Player.controls.stop();
                isplaying = false;
                Player.URL = null;
                Player.close();
                Marshal.FinalReleaseComObject(Player);
            }
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (Methods.AlertIfGameIsRunning(MainForm.mf))
                return;

            var confirmResult = MsgBoxs.Dialog.ReinstallJukebox(MainForm.mf);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Player.currentPlaylist.clear();
                }
                catch { }

                MainForm.mf.InstallJukebox();
                //MainForm.mf.isTweakDownloading = true;
                //MainForm.mf.TweakReset(StringLoader.GetText("LB_select_a_tweak"), "", false, false, false, false, 0);
                //Methods.DownloadFile(Urls.DLC3, Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, "DLC3"), Methods.GetGameFolder());          
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            btnDelete_Click(null, null);
            e.Cancel = true;
        }

        private void deleteSelectedSongToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hti.RowIndex].Selected = true;
                    dataGridView1_CellClick(null, null);
                }
                catch { }
            }
        }

        private void checkDLC_Tick(object sender, EventArgs e)
        {
            if (!Methods.IsJukeBoxDLCinstalled())
            {
                MainForm.mf.ClickButtonIfActiveOnTweak();
                MainForm.mf.CloseForm(MainForm.jForm);
            }
        }

        private void moveSelectedSongToTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (string.IsNullOrEmpty(songtodelete) || string.IsNullOrEmpty(songpathtodelete))
            {
                MsgBoxs.Information.NoItemSelected(MainForm.mf);
                return;
            }

            if (totalSong <= 1)
            {
                MsgBoxs.Information.AtleastOneFieldRequired(MainForm.mf); 
                return;
            }

            doc.Load(filePath);
            XmlElement el = (XmlElement)doc.SelectSingleNode($"/BGM/BGM_SOUND_LIST/BGM_SOUND[Sound_Path = '{songpathtodelete}']");
            
            XmlNode parentNode = doc.SelectSingleNode("BGM/BGM_SOUND_LIST");
            //doc.DocumentElement.AppendChild(el);

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "BGM_SOUND", null);
            XmlNode nodeTitle = doc.CreateElement("Sound_Name");
            nodeTitle.InnerText = songtodelete;

            XmlNode nodeSinger = doc.CreateElement("Sound_Singer");
            nodeSinger.InnerText = string.IsNullOrEmpty(songartistsomehow) ? "Unkown" : songartistsomehow;

            XmlNode nodePath = doc.CreateElement("Sound_Path");
            nodePath.InnerText = songpathtodelete;

            node.AppendChild(nodeTitle);
            node.AppendChild(nodeSinger);
            node.AppendChild(nodePath);

            parentNode.InsertBefore(node, parentNode.FirstChild);

            if (el != null) { el.ParentNode.RemoveChild(el); }

            //doc.DocumentElement.AppendChild(node);

            doc.Save(filePath);


            Reset();

            LoadMusic();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[0].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = 0;

            if (isplaying)
                dataGridView1_CellClick(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells[0].RowIndex == 0)
                    contextMenuStrip1.Items[0].Visible = false;
                else if (dataGridView1.SelectedCells[0].RowIndex > 0)
                    contextMenuStrip1.Items[0].Visible = true;
            }
            catch
            {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Visible = false;
            }
        }

    }
} 
