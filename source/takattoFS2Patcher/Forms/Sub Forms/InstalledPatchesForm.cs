using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class InstalledPatchesForm : Form
    {
        public InstalledPatchesForm()
        {
            InitializeComponent();
            
            Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.CustomUI));
        }

        string[] exList;
        public void UpdateListBox()
        {
            try
            {
                string previousItem = "";
                if(lbUIs.SelectedIndex!=-1)
                    previousItem = lbUIs.SelectedItem.ToString();
               
                lbUIs.Items.Clear();
                exList = Methods.PopulateCustomUIList(null);
                if (exList == null || exList.Length == 0)
                {
                    lbUIs.Items.Clear();
                    lbUIs.Items.Add(" " + StringLoader.GetText("lb_tweak_patch_none"));
                    lbUIs.SelectedIndex = 0;
                    VisibleConfuse(false);
                    return;
                }
                for (int i = 0; i < exList.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(exList[i]))
                    {
                        lbUIs.Items.Add(" " + exList[i]);
                    }                
                }
                lbUIs.SelectedIndex = lbUIs.FindStringExact(previousItem);
                lbNoItemExist.Visible = false;
            }
            catch
            {
                lbUIs.Items.Clear();
                lbUIs.Items.Add(" " + StringLoader.GetText("lb_tweak_patch_none"));
                lbUIs.SelectedIndex = 0;
            }
            if(firstime)
            {
                firstime = false;
                ActiveControl = null;
                if (lbUIs.Items.Count > 0)
                    lbUIs.SelectedIndex = 0;
            }
        }

        void VisibleConfuse(bool isConflicted)
        {
            lbNoItemExist.Location = lbUIs.Location;
            lbNoItemExist.Width = lbUIs.Width;
            lbNoItemExist.Height = lbUIs.Height;
            lbNoItemExist.Visible = true;

            if(!isConflicted)
                lbNoItemExist.Text = StringLoader.GetText("lb_tweak_gotodownload_hint", StringLoader.GetText("tab2"));
            else
                lbNoItemExist.Text = StringLoader.GetText("msgtitle_check_again", StringLoader.GetText("tab2"));
        }

        public void CheckForConflict()
        {
            if (lbUIs.Items[0].ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
            {
                btnWarning.Visible = false;
                return;
            }

            var conflicts = new System.Collections.Generic.List<string>();
            foreach (var itemw in lbUIs.Items)
            {
                var item = itemw.ToString().Trim();
                string patch_json = KATEncryptor.Decrypt(File.ReadAllText(Methods.GetFolder(Strings.FolderName.CustomUI, $"{item}.txt")), 1);
                var result = @patch_json.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();
                for (int i = 1; i < result.Length; i++) //skip version
                {
                    if (!string.IsNullOrWhiteSpace(result[i]))
                        conflicts.Add(result[i]);
                }
            }

            if (conflicts.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                btnWarning.Visible = true;
            }
            else
            {
                btnWarning.Visible = false;
            }
        }

        bool firstime = true;
        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl(); 
            UpdateListBox();         
        }

        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;
            
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            lbUIs.Font = MemoryFonts.SetFont(0, lbUIs.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            txtCommand.Font = MemoryFonts.SetFont(0, txtCommand.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);

            lbUIs.ItemHeight = MainForm.mf.lbPatchStatus.Height + (MainForm.mf.lbPatchStatus.Height / 5);
            lbUIs.Height -= lbUIs.ItemHeight;
          
            lbNoItemExist.Text = StringLoader.GetText("lb_tweak_gotodownload_hint", StringLoader.GetText("tab2"));
            lbUIHint.Text = StringLoader.GetText("lb_tweak_interface_hint") + ":";
            txtCommand.PlaceHolderText = StringLoader.GetText("tooltip_tweak_interface_hint") + ":";
            txtCommand.Text = StringLoader.GetText("tooltip_tweak_interface_hint") + ":";
            string credential = UserSettings.UILaunchOption;
            if (!string.IsNullOrEmpty(credential))
            {
                txtCommand.removePlaceHolder(null, null);
                txtCommand.Text = credential;
            }

            toolTip1.SetToolTip(btnWarning, StringLoader.GetText("lb_warning"));
            toolTip1.SetToolTip(btnDelete, StringLoader.GetText("tooltip_tweak_delete"));
            toolTip1.SetToolTip(txtCommand, StringLoader.GetText("tooltip_tweak_interface_hint"));
            txtCommand.TextChanged += new EventHandler(txtCredential_TextChanged);
        }
        private void txtCredential_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommand.Text) || txtCommand.Text.Contains(txtCommand.PlaceHolderText.Trim()))
            {
                UserSettings.UILaunchOption = null;
                return;
            }

            UserSettings.UILaunchOption = txtCommand.Text;
        }

        private void lbExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUIs.SelectedIndex == -1 || lbUIs.SelectedItem.ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
            {
                lbUIs.ClearSelected();
                btnDelete.Visible = false;
                return;
            }

            btnDelete.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (lbUIs.SelectedIndex == -1 || lbUIs.SelectedItem.ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
            {
                MsgBoxs.Warning.IncorrectParametter(MainForm.mf);
                return;
            }
            var item = lbUIs.SelectedItem.ToString().Trim();
            var confirmResult = MsgBoxs.Dialog.Uninstall(MainForm.mf, item);
            if (confirmResult == DialogResult.Yes)
            {
                string patch_json = KATEncryptor.Decrypt(File.ReadAllText(Methods.GetFolder(Strings.FolderName.CustomUI, $"{item}.txt")),1);
                if (!string.IsNullOrEmpty(patch_json))
                {
                    var result = @patch_json.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();

                    if (result != null && result.Length > 1)
                    {
                        for (int i = 1; i < result.Length; i++) //skip version
                        {
                            if (!string.IsNullOrWhiteSpace(result[i]))
                            {
                                if (File.Exists(Methods.GetFolder(Strings.FolderName.CustomUI, result[i])))
                                {
                                    try
                                    {
                                        File.Delete(Methods.GetFolder(Strings.FolderName.CustomUI, result[i]));
                                    }
                                    catch (Exception ew)
                                    {
                                        Logger.Write(result[i] + " could not be deleted. Kat-code: " + ew.ToString());
                                    }
                                }
                            }
                        }

                        try { File.Delete(Methods.GetFolder(Strings.FolderName.CustomUI, $"{item}.txt")); } catch { }

                    }
                }

                MsgBoxs.Information.Uninstalled(MainForm.mf, item);

                UpdateListBox();
                btnDelete.Visible = false;
            }
        }

        bool once = false;
        private void refreshListBox_Tick(object sender, EventArgs e)
        {
            if(!once)
            {
                once = true;
                refreshListBox.Interval = 2700;
            }

            UpdateListBox();

            if (lbUIs.Items[0].ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
                VisibleConfuse(false);

            if(File.Exists(Methods.GetFolder(Strings.FolderName.CustomPatch, Strings.FileName.UI)))
                VisibleConfuse(true);

            CheckForConflict();

            Methods.ExtractKatAddon(Methods.GetFolder(Strings.FolderName.CustomUI));
        }

        private void btnWarning_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            MsgBoxs.Warning.UIConflict(MainForm.mf);
        }
    }
}
