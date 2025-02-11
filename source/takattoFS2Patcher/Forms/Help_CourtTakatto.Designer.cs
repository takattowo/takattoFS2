
namespace takattoFS2.Forms
{
    partial class Help_CourtTakatto
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.errorConnect = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.pnLoading = new System.Windows.Forms.Panel();
            this.lbPageConnecting = new System.Windows.Forms.Label();
            this.CbNoShowPleaseTyBye = new System.Windows.Forms.CheckBox();
            this.timerNews = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 29;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 800;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // errorConnect
            // 
            this.errorConnect.BackColor = System.Drawing.Color.White;
            this.errorConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorConnect.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.errorConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.errorConnect.Image = global::takattoFS2.Properties.Resources.smolviocat;
            this.errorConnect.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.errorConnect.Location = new System.Drawing.Point(0, 0);
            this.errorConnect.Name = "errorConnect";
            this.errorConnect.Size = new System.Drawing.Size(392, 107);
            this.errorConnect.TabIndex = 2;
            this.errorConnect.Text = "Connecting to server...\r\n";
            this.errorConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorConnect.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // WebBrowser
            // 
            this.WebBrowser.AllowWebBrowserDrop = false;
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.WebBrowser.Location = new System.Drawing.Point(0, 0);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.ScriptErrorsSuppressed = true;
            this.WebBrowser.Size = new System.Drawing.Size(392, 107);
            this.WebBrowser.TabIndex = 7;
            this.WebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.WebBrowser.Visible = false;
            // 
            // pnLoading
            // 
            this.pnLoading.BackColor = System.Drawing.Color.White;
            this.pnLoading.Controls.Add(this.lbPageConnecting);
            this.pnLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLoading.Location = new System.Drawing.Point(0, 0);
            this.pnLoading.Name = "pnLoading";
            this.pnLoading.Size = new System.Drawing.Size(392, 107);
            this.pnLoading.TabIndex = 17;
            // 
            // lbPageConnecting
            // 
            this.lbPageConnecting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPageConnecting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPageConnecting.Location = new System.Drawing.Point(0, 0);
            this.lbPageConnecting.Name = "lbPageConnecting";
            this.lbPageConnecting.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lbPageConnecting.Size = new System.Drawing.Size(392, 107);
            this.lbPageConnecting.TabIndex = 0;
            this.lbPageConnecting.Text = "Page is loading...";
            this.lbPageConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPageConnecting.Visible = false;
            // 
            // CbNoShowPleaseTyBye
            // 
            this.CbNoShowPleaseTyBye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbNoShowPleaseTyBye.AutoCheck = false;
            this.CbNoShowPleaseTyBye.Location = new System.Drawing.Point(12, 3);
            this.CbNoShowPleaseTyBye.Name = "CbNoShowPleaseTyBye";
            this.CbNoShowPleaseTyBye.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CbNoShowPleaseTyBye.Size = new System.Drawing.Size(373, 24);
            this.CbNoShowPleaseTyBye.TabIndex = 1;
            this.CbNoShowPleaseTyBye.Text = "doNotShowAgain";
            this.CbNoShowPleaseTyBye.UseVisualStyleBackColor = true;
            this.CbNoShowPleaseTyBye.Visible = false;
            this.CbNoShowPleaseTyBye.CheckedChanged += new System.EventHandler(this.CbNoShowPleaseTyBye_CheckedChanged);
            this.CbNoShowPleaseTyBye.Click += new System.EventHandler(this.CbNoShowPleaseTyBye_Click);
            // 
            // timerNews
            // 
            this.timerNews.Interval = 2000;
            this.timerNews.Tick += new System.EventHandler(this.timerNews_Tick);
            // 
            // Help_CourtTakatto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 107);
            this.Controls.Add(this.CbNoShowPleaseTyBye);
            this.Controls.Add(this.errorConnect);
            this.Controls.Add(this.pnLoading);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WebBrowser);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinimumSize = new System.Drawing.Size(146, 146);
            this.Name = "Help_CourtTakatto";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "A picture!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_CourtTakatto_FormClosing);
            this.Load += new System.EventHandler(this.CourtHelpTakatto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label errorConnect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.Panel pnLoading;
        private System.Windows.Forms.Label lbPageConnecting;
        private System.Windows.Forms.CheckBox CbNoShowPleaseTyBye;
        private System.Windows.Forms.Timer timerNews;
    }
}