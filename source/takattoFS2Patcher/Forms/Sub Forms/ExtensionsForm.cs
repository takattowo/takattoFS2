using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class ExtensionsForm : Form
    {
        public ExtensionsForm()
        {
            InitializeComponent();
            
            Methods.MakeSureFolderExists(Methods.GetFolder(Strings.FolderName.Extension));
        }

        string[] exList;
        public void UpdateListBox()
        {
            try
            {
                string previousItem = "null";
                if(lbExtensions.SelectedIndex!=-1)
                    previousItem = lbExtensions.SelectedItem.ToString();
               
                lbExtensions.Items.Clear();
                exList = Methods.PopulateExtensionList();
                if (exList == null || exList.Length == 0)
                {
                    lbExtensions.Items.Clear();
                    lbExtensions.Items.Add(" " + StringLoader.GetText("lb_tweak_patch_none"));
                    lbExtensions.SelectedIndex = 0;
                    VisibleConfuse();
                    return;
                }
                for (int i = 0; i < exList.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(exList[i]))
                    {
                        lbExtensions.Items.Add(" " + exList[i]);
                    }                
                }
                lbExtensions.SelectedIndex = lbExtensions.FindStringExact(previousItem);
            }
            catch
            {
                lbExtensions.Items.Clear();
                lbExtensions.Items.Add(" " + StringLoader.GetText("lb_tweak_patch_none"));
                lbExtensions.SelectedIndex = 0;
            }
            if(firstime)
            {
                firstime = false;
                ActiveControl = null;
                if (lbExtensions.Items.Count > 0)
                    lbExtensions.SelectedIndex = 0;
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

            lbExtensions.Font = MemoryFonts.SetFont(0, lbExtensions.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            txtCredential.Font = MemoryFonts.SetFont(0, txtCredential.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            lbNoItemExist.Text = StringLoader.GetText("lb_tweak_gotodownload_hint", StringLoader.GetText("tab2"));

            lbExtensions.ItemHeight = MainForm.mf.lbPatchStatus.Height + (MainForm.mf.lbPatchStatus.Height / 5);
            lbExtensions.Height -= lbExtensions.ItemHeight;
          
            lbExtensionHint.Text = StringLoader.GetText("lb_tweak_extension_hint") + ":";
            txtCredential.PlaceHolderText = StringLoader.GetText("text_tweak_extension_hint") + ":";
            txtCredential.Text = StringLoader.GetText("text_tweak_extension_hint") + ":";

            string credential = UserSettings.ExtensionCredential;
            if (!string.IsNullOrEmpty(credential))
            {
                txtCredential.removePlaceHolder(null, null);
                txtCredential.Text = credential;
            }

            toolTip1.SetToolTip(btnDelete, StringLoader.GetText("tooltip_tweak_delete"));
            toolTip1.SetToolTip(txtCredential, StringLoader.GetText("tooltip_tweak_extension_hint"));

            txtCredential.TextChanged += new EventHandler(txtCredential_TextChanged);
        }

        private void lbExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbExtensions.SelectedIndex == -1 || lbExtensions.SelectedItem.ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
            {
                lbExtensions.ClearSelected();
                btnDelete.Visible = false;
                return;
            }

            btnDelete.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            if (lbExtensions.SelectedIndex == -1 || lbExtensions.SelectedItem.ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
            {
                MsgBoxs.Warning.IncorrectParametter(MainForm.mf);
                return;
            }
            var item = lbExtensions.SelectedItem.ToString().Trim();
            var confirmResult = MsgBoxs.Dialog.RemoveExtension(MainForm.mf, item);
            if (confirmResult == DialogResult.Yes) {
                try
                {
                    File.Delete(Methods.GetFolder(Strings.FolderName.Extension, item + ".exe"));
                }
                catch (Exception ew) {
                    MsgBoxs.Warning.Error(MainForm.mf, ew.ToString());
                }

                MsgBoxs.Information.Uninstalled(MainForm.mf, item);
                UpdateListBox();
                btnDelete.Visible = false;
            }
        }

        void VisibleConfuse()
        {
            lbNoItemExist.Location = lbExtensions.Location;
            lbNoItemExist.Width = lbExtensions.Width;
            lbNoItemExist.Height = lbExtensions.Height;
            lbNoItemExist.Visible = true;
        }

        private void refreshListBox_Tick(object sender, EventArgs e)
        {
            UpdateListBox();
            if (lbExtensions.Items[0].ToString().Contains(StringLoader.GetText("lb_tweak_patch_none")))
                VisibleConfuse();


            Methods.ExtractKatAddon(Methods.GetFolder(Strings.FolderName.Extension));
        }

        private void txtCredential_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCredential.Text) || txtCredential.Text.Contains(txtCredential.PlaceHolderText.Trim()))
            {
                UserSettings.ExtensionCredential = null;
                return;
            }

            UserSettings.ExtensionCredential = txtCredential.Text;          
        }
    }
}
