namespace takattoFS2.Forms
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LBStatus = new System.Windows.Forms.Label();
            this.pnDownloadBar = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnCancelDownloading = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDownloadProgress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wait = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnDownloadBar.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LBStatus
            // 
            this.LBStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBStatus.AutoEllipsis = true;
            this.LBStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold);
            this.LBStatus.ForeColor = System.Drawing.Color.White;
            this.LBStatus.Location = new System.Drawing.Point(0, 45);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(419, 78);
            this.LBStatus.TabIndex = 1;
            this.LBStatus.Text = "Patting cats~";
            this.LBStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnDownloadBar
            // 
            this.pnDownloadBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnDownloadBar.Controls.Add(this.roundCornerControl1);
            this.pnDownloadBar.Controls.Add(this.ProgressBar);
            this.pnDownloadBar.Controls.Add(this.lbName);
            this.pnDownloadBar.Controls.Add(this.lbDownloadProgress);
            this.pnDownloadBar.Controls.Add(this.LBStatus);
            this.pnDownloadBar.Controls.Add(this.pictureBox1);
            this.pnDownloadBar.Controls.Add(this.wait);
            this.pnDownloadBar.Controls.Add(this.cancel);
            this.pnDownloadBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDownloadBar.Location = new System.Drawing.Point(0, 0);
            this.pnDownloadBar.Name = "pnDownloadBar";
            this.pnDownloadBar.Size = new System.Drawing.Size(419, 432);
            this.pnDownloadBar.TabIndex = 3;
            this.pnDownloadBar.Visible = false;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btnCancelDownloading);
            this.roundCornerControl1.Location = new System.Drawing.Point(338, 9);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(76, 26);
            this.roundCornerControl1.TabIndex = 37;
            // 
            // btnCancelDownloading
            // 
            this.btnCancelDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelDownloading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelDownloading.FlatAppearance.BorderSize = 0;
            this.btnCancelDownloading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelDownloading.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnCancelDownloading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelDownloading.Location = new System.Drawing.Point(-1, -1);
            this.btnCancelDownloading.Name = "btnCancelDownloading";
            this.btnCancelDownloading.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancelDownloading.Size = new System.Drawing.Size(77, 27);
            this.btnCancelDownloading.TabIndex = 0;
            this.btnCancelDownloading.Text = "Cancel";
            this.btnCancelDownloading.UseVisualStyleBackColor = false;
            this.btnCancelDownloading.Click += new System.EventHandler(this.btnCancelDownloading_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(19, 399);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(383, 13);
            this.ProgressBar.TabIndex = 33;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoEllipsis = true;
            this.lbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbName.Location = new System.Drawing.Point(21, 267);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(377, 24);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Staring: [PATCH_NAME]";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDownloadProgress
            // 
            this.lbDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDownloadProgress.Font = new System.Drawing.Font("Consolas", 16F);
            this.lbDownloadProgress.ForeColor = System.Drawing.Color.White;
            this.lbDownloadProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDownloadProgress.Location = new System.Drawing.Point(12, 370);
            this.lbDownloadProgress.Name = "lbDownloadProgress";
            this.lbDownloadProgress.Size = new System.Drawing.Size(397, 31);
            this.lbDownloadProgress.TabIndex = 2;
            this.lbDownloadProgress.Text = "Fetching...";
            this.lbDownloadProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::takattoFS2.Properties.Resources.loadin;
            this.pictureBox1.Location = new System.Drawing.Point(0, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(419, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // wait
            // 
            this.wait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wait.Font = new System.Drawing.Font("Consolas", 16F);
            this.wait.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.wait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wait.Location = new System.Drawing.Point(12, 370);
            this.wait.Name = "wait";
            this.wait.Size = new System.Drawing.Size(397, 26);
            this.wait.TabIndex = 35;
            this.wait.Text = "Almost there~";
            this.wait.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Font = new System.Drawing.Font("Consolas", 16F);
            this.cancel.ForeColor = System.Drawing.Color.LightCoral;
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(12, 370);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(397, 26);
            this.cancel.TabIndex = 36;
            this.cancel.Text = "Cancelling... OAO";
            this.cancel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(419, 432);
            this.Controls.Add(this.pnDownloadBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DownloadForm";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.pnDownloadBar.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label LBStatus;
        private System.Windows.Forms.Panel pnDownloadBar;
        public System.Windows.Forms.Label lbDownloadProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        public System.Windows.Forms.Label wait;
        public System.Windows.Forms.Label cancel;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        internal System.Windows.Forms.Button btnCancelDownloading;
    }
}