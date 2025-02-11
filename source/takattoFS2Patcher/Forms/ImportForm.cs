using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class ImportForm : Form
    {
        public ImportForm(bool isImportingCamera)
        {
            InitializeComponent();

            if(!isImportingCamera)
            {
                isImportingCamerad = false;
                btnImport.Click += new EventHandler(this.BtnURL_Click);
            }
                
            else
            {
                isImportingCamerad = true;
                btnImport.Click += new EventHandler(this.BtnCAMERTA_Click);
            }
                
        }
        bool isImportingCamerad = false;
        void LoadControl()
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = MainForm.mf.Icon;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ActiveControl = null;


            this.Text = StringLoader.GetText("btn_import");
            if(!isImportingCamerad)
                lbHint.Text = StringLoader.GetText("lb_import_enter_url") + ":";
            else
                lbHint.Text = StringLoader.GetText("lb_camera_import_enter_json") + ":";

            btnImport.Text = StringLoader.GetText("btn_import");

            lbHint.Font = MemoryFonts.SetFont(0, lbHint.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            tbURL.Font = MemoryFonts.SetFont(0, tbURL.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            btnImport.Font = MemoryFonts.SetFont(0, btnImport.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
        }
        private void ImportForm_Load(object sender, EventArgs e)
        {
            LoadControl();        
        }

        private void BtnCAMERTA_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbURL.Text))
            {
                lbHint.Text = StringLoader.GetText("lb_import_empty_url");
                tbURL.Focus();
                return;
            }

            try
            {
                CameraHelper.cam = Newtonsoft.Json.JsonConvert.DeserializeObject<Camera>(tbURL.Text);
                MsgBoxs.Information.SettingsHasBeenImported(MainForm.mf);
                Sub_Forms.CameraForm.frmObj.Reset();
                Close();
            }
            catch (Exception ex)
            {
                MsgBoxs.Warning.Error(MainForm.mf, ex.ToString());
                lbHint.Text = StringLoader.GetText("msgtitle_ewk");
            }
        }


        private void BtnURL_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbURL.Text))
            {
                lbHint.Text = StringLoader.GetText("lb_import_empty_url");
                tbURL.Focus();
                return;
            }
            if (!Uri.IsWellFormedUriString(tbURL.Text, UriKind.Absolute))
            {
                lbHint.Text = StringLoader.GetText("lb_import_empty_url_error");
                tbURL.Focus();
                return;
            }

            Close();
            MainForm.mf.isTweakDownloading = true;
            MainForm.mf.isImportDownloading = true;

            var yes = new Uri(tbURL.Text).Segments.Last().Replace("/",string.Empty);
            
            if (string.IsNullOrEmpty(yes) || string.IsNullOrWhiteSpace(yes))
                yes = "IMPORT_UNKNOW";

            yes += ".DAT";

            string tempName = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.TempFolder, yes);

            Methods.DownloadFile(tbURL.Text, tempName, Methods.GetGameFolder());         
            return;
        }
    }
}
