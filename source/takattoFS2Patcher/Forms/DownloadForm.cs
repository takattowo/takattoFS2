using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class DownloadForm : Form
    {
        WebClient webClient;
        string downloadedFiled;
        string extractDirectoried;
        //private static DownloadForm _frmObj;
        //public static DownloadForm frmObj
        //{
        //    get { return _frmObj; }
        //    set { _frmObj = value; }
        //}

        public DownloadForm(string downloadURL, string downloadedFile, string extractDirectory)
        {
            InitializeComponent();
            timer1.Interval = 290;
            timer1.Enabled = false;
            downloadedFiled = downloadedFile;
            lbName.Text = StringLoader.GetText("lb_download_staring", Path.GetFileNameWithoutExtension(downloadedFile));

            extractDirectoried = extractDirectory;
            Random rand = new Random();
            int indexRant = rand.Next(Strings.Misc.CutieQuotes.Length);
            LBStatus.Text = Strings.Misc.CutieQuotes[indexRant];

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(32, 32, 32);
            webClient = new WebClient();

            if (File.Exists(downloadedFile) && new FileInfo(downloadedFile).Length > 0)
            {
                //MessageBox.Show(downloadedFile + "|");
                if (!MainForm.mf.isDLCServiceDownloading && !MainForm.mf.isImportDownloading && !MainForm.mf.isDefaMapDownloading && !MainForm.mf.isSTDPatchDownloading)
                {
                    MainForm.mf.InvokeUI(() => {
                        lbDownloadProgress.Text = StringLoader.GetText("LB_download_applying_downloaded");
                        MainForm.dForm.ProgressBar.Value = 50;
                        timer1.Enabled = true;
                    });
                    return;
                }
            }

            webClient.DownloadProgressChanged += (ov, ev) =>
            {
                MainForm.dForm.ProgressBar.Value = ev.ProgressPercentage;              

                if (ev.BytesReceived == ev.TotalBytesToReceive && ev.TotalBytesToReceive > 0)
                    lbDownloadProgress.Text = StringLoader.GetText("LB_download_extracting");
                else if (ev.BytesReceived == ev.TotalBytesToReceive && ev.TotalBytesToReceive <= 0)
                    lbDownloadProgress.Text = StringLoader.GetText("LB_download_cancelled");
                else
                    lbDownloadProgress.Text = $"{String.Format("{0:0.##}", (Convert.ToDouble(ev.BytesReceived) / (1024d * 1024d)))}/{String.Format("{0:0.##}", (Convert.ToDouble(ev.TotalBytesToReceive) / (1024d * 1024d)))}MB";
                
                if (ProgressBar.Value >= 88 && ProgressBar.Value < 100)
                    wait.BringToFront();
                else
                    wait.SendToBack();
            };

            webClient.DownloadFileCompleted += (ov, ev) =>
            {
                MainForm.mf.InvokeUI(() => {
                    MainForm.mf.DownloadComplete(downloadedFile, extractDirectory);
                    if(ev.Error == null)
                    {
                        lbDownloadProgress.Text = StringLoader.GetText("LB_download_extracting");
                        lbDownloadProgress.ForeColor = Color.LimeGreen;
                    }
                    if (ev.Error != null || ev.Cancelled || MainForm.mf.cancelDownload)
                    {
                        try { File.Delete(downloadedFile); } catch (Exception e) { Logger.Write(e.ToString()); }
                        webClient.Dispose();
                        lbDownloadProgress.Text = StringLoader.GetText("LB_download_cancelled");
                        lbDownloadProgress.ForeColor = Color.IndianRed;
                    }
                });
            };

            webClient.DownloadFileAsync(new Uri(downloadURL), downloadedFile);          
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            this.ActiveControl = LBStatus;
        }
        void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(pnDownloadBar.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(pnDownloadBar.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            //frmObj = this;
            
            lbDownloadProgress.Font = MemoryFonts.SetFont(1, lbDownloadProgress.Font.Size, PatcherSettings.fontOffset3, FontStyle.Regular);
            wait.Font = MemoryFonts.SetFont(1, wait.Font.Size, PatcherSettings.fontOffset3, FontStyle.Regular);
            LBStatus.Font = MemoryFonts.SetFont(1, LBStatus.Font.Size, PatcherSettings.fontOffset4, FontStyle.Regular);
            lbName.Font = MemoryFonts.SetFont(0, lbName.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            btnCancelDownloading.Font = MemoryFonts.SetFont(0, btnCancelDownloading.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Point loc = new Point((Width - pnDownloadBar.Width) / 2, (Height - pnDownloadBar.Height) / 2);
            pnDownloadBar.Location = loc;
            pnDownloadBar.Visible = true;

            btnCancelDownloading.Text = StringLoader.GetText("btn_cancel");
        }
        private void btnCancelDownloading_Click(object sender, EventArgs e)
        {
            LBStatus.Focus();
            MainForm.mf.cancelDownload = true;
            MainForm.mf.disable_aTimer(); 
            webClient.CancelAsync();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MainForm.dForm.ProgressBar.Value = 100; 
            MainForm.mf.InvokeUI(() => {
                lbDownloadProgress.Text = StringLoader.GetText("LB_download_extracting");
                lbDownloadProgress.ForeColor = Color.LimeGreen;
            });

            MainForm.mf.DownloadComplete(downloadedFiled, extractDirectoried);
        }
    }
}
