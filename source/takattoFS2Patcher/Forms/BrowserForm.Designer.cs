namespace takattoFS2.Forms
{
    partial class BrowserForm
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
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.nexonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.btnSendPassword = new System.Windows.Forms.Button();
            this.tbRememberPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerPw = new System.Windows.Forms.Timer(this.components);
            this.btnLaunch = new System.Windows.Forms.Button();
            this.timerJoy = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.pnLoading = new System.Windows.Forms.Panel();
            this.lbConnecting = new System.Windows.Forms.Label();
            this.timer3loading = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.pnLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebBrowser
            // 
            this.WebBrowser.AllowWebBrowserDrop = false;
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.WebBrowser.Location = new System.Drawing.Point(0, 37);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.ScriptErrorsSuppressed = true;
            this.WebBrowser.Size = new System.Drawing.Size(1101, 512);
            this.WebBrowser.TabIndex = 6;
            this.WebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nexonToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1101, 37);
            this.MenuStrip.TabIndex = 7;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // nexonToolStripMenuItem
            // 
            this.nexonToolStripMenuItem.AutoSize = false;
            this.nexonToolStripMenuItem.Name = "nexonToolStripMenuItem";
            this.nexonToolStripMenuItem.Size = new System.Drawing.Size(58, 33);
            this.nexonToolStripMenuItem.Text = "Refresh";
            this.nexonToolStripMenuItem.Visible = false;
            this.nexonToolStripMenuItem.Click += new System.EventHandler(this.LoginPageToolStripMenuItem_Click);
            // 
            // LoginPageToolStripMenuItem
            // 
            this.LoginPageToolStripMenuItem.Name = "LoginPageToolStripMenuItem";
            this.LoginPageToolStripMenuItem.Size = new System.Drawing.Size(58, 33);
            this.LoginPageToolStripMenuItem.Text = "Refresh";
            this.LoginPageToolStripMenuItem.Click += new System.EventHandler(this.LoginPageToolStripMenuItem_Click);
            // 
            // ModeToolStripComboBox
            // 
            this.ModeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeToolStripComboBox.Items.AddRange(new object[] {
            "Nexon",
            "Joycity"});
            this.ModeToolStripComboBox.Name = "ModeToolStripComboBox";
            this.ModeToolStripComboBox.Size = new System.Drawing.Size(121, 23);
            this.ModeToolStripComboBox.DropDownClosed += new System.EventHandler(this.ModeToolStripComboBox_DropDownClosed);
            this.ModeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeToolStripComboBox_SelectedIndexChanged);
            // 
            // btnSendPassword
            // 
            this.btnSendPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendPassword.BackColor = System.Drawing.Color.Gray;
            this.btnSendPassword.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.btnSendPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendPassword.FlatAppearance.BorderSize = 0;
            this.btnSendPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendPassword.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnSendPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSendPassword.Location = new System.Drawing.Point(1059, 6);
            this.btnSendPassword.Name = "btnSendPassword";
            this.btnSendPassword.Size = new System.Drawing.Size(34, 23);
            this.btnSendPassword.TabIndex = 10;
            this.btnSendPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSendPassword.UseVisualStyleBackColor = false;
            this.btnSendPassword.Click += new System.EventHandler(this.btnSendPassword_Click);
            // 
            // tbRememberPassword
            // 
            this.tbRememberPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRememberPassword.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.tbRememberPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRememberPassword.Location = new System.Drawing.Point(918, 6);
            this.tbRememberPassword.Name = "tbRememberPassword";
            this.tbRememberPassword.PasswordChar = '✻';
            this.tbRememberPassword.Size = new System.Drawing.Size(137, 23);
            this.tbRememberPassword.TabIndex = 9;
            this.tbRememberPassword.TextChanged += new System.EventHandler(this.lbRememberPassword_TextChanged);
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbPassword.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbPassword.Location = new System.Drawing.Point(744, 5);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(168, 27);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Remember Password:";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Loading Nexon Login Page...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerPw
            // 
            this.timerPw.Enabled = true;
            this.timerPw.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.btnLaunch.FlatAppearance.BorderSize = 0;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnLaunch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLaunch.Location = new System.Drawing.Point(137, 6);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(94, 23);
            this.btnLaunch.TabIndex = 12;
            this.btnLaunch.Text = "Launch game";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerJoy
            // 
            this.timerJoy.Tick += new System.EventHandler(this.timerJoy_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // modeComboBox
            // 
            this.modeComboBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "Nexon",
            "Joycity"});
            this.modeComboBox.Location = new System.Drawing.Point(10, 6);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(121, 23);
            this.modeComboBox.TabIndex = 15;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeToolStripComboBox_SelectedIndexChanged);
            this.modeComboBox.DropDownClosed += new System.EventHandler(this.ModeToolStripComboBox_DropDownClosed);
            // 
            // pnLoading
            // 
            this.pnLoading.BackColor = System.Drawing.Color.White;
            this.pnLoading.Controls.Add(this.lbConnecting);
            this.pnLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLoading.Location = new System.Drawing.Point(0, 37);
            this.pnLoading.Name = "pnLoading";
            this.pnLoading.Size = new System.Drawing.Size(1101, 512);
            this.pnLoading.TabIndex = 16;
            // 
            // lbConnecting
            // 
            this.lbConnecting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConnecting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnecting.Location = new System.Drawing.Point(0, 0);
            this.lbConnecting.Name = "lbConnecting";
            this.lbConnecting.Padding = new System.Windows.Forms.Padding(0, 0, 0, 29);
            this.lbConnecting.Size = new System.Drawing.Size(1101, 512);
            this.lbConnecting.TabIndex = 0;
            this.lbConnecting.Text = "Page is loading...";
            this.lbConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer3loading
            // 
            this.timer3loading.Enabled = true;
            this.timer3loading.Interval = 629;
            this.timer3loading.Tick += new System.EventHandler(this.timer3loading_Tick);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1101, 549);
            this.Controls.Add(this.pnLoading);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.WebBrowser);
            this.Controls.Add(this.btnSendPassword);
            this.Controls.Add(this.tbRememberPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MenuStrip);
            this.MinimumSize = new System.Drawing.Size(800, 378);
            this.Name = "BrowserForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.pnLoading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoginPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ModeToolStripComboBox;
        private System.Windows.Forms.Button btnSendPassword;
        private System.Windows.Forms.TextBox tbRememberPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Timer timerJoy;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem nexonToolStripMenuItem;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Panel pnLoading;
        private System.Windows.Forms.Label lbConnecting;
        private System.Windows.Forms.Timer timer3loading;
        private System.Windows.Forms.Timer timerPw;
    }
}

