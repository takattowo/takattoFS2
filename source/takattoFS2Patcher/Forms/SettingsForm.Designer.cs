
namespace takattoFS2.Forms
{
    partial class SettingsForm
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
            this.lb_s1 = new System.Windows.Forms.Label();
            this.cbs1 = new System.Windows.Forms.ComboBox();
            this.lb_langhintwhy = new System.Windows.Forms.Label();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.lb_lang = new System.Windows.Forms.Label();
            this.lbLang = new System.Windows.Forms.Label();
            this.lbap = new System.Windows.Forms.Label();
            this.cbMusi = new System.Windows.Forms.ComboBox();
            this.lbmusi = new System.Windows.Forms.Label();
            this.lb_musi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbLogging = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_logging = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.roundCornerControl3 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnCleanup = new System.Windows.Forms.Button();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btn_viewlog = new System.Windows.Forms.Button();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.roundCornerControl3.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_s1
            // 
            this.lb_s1.AutoSize = true;
            this.lb_s1.BackColor = System.Drawing.Color.Transparent;
            this.lb_s1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_s1.Location = new System.Drawing.Point(12, 71);
            this.lb_s1.Name = "lb_s1";
            this.lb_s1.Size = new System.Drawing.Size(98, 15);
            this.lb_s1.TabIndex = 36;
            this.lb_s1.Text = "Menu position";
            // 
            // cbs1
            // 
            this.cbs1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbs1.BackColor = System.Drawing.Color.White;
            this.cbs1.DisplayMember = "1";
            this.cbs1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbs1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbs1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbs1.FormattingEnabled = true;
            this.cbs1.Items.AddRange(new object[] {
            "Top",
            "Bottom"});
            this.cbs1.Location = new System.Drawing.Point(257, 70);
            this.cbs1.Name = "cbs1";
            this.cbs1.Size = new System.Drawing.Size(108, 23);
            this.cbs1.TabIndex = 2;
            this.cbs1.SelectedIndexChanged += new System.EventHandler(this.cbs1_SelectedIndexChanged);
            // 
            // lb_langhintwhy
            // 
            this.lb_langhintwhy.AutoSize = true;
            this.lb_langhintwhy.Font = new System.Drawing.Font("Consolas", 9F);
            this.lb_langhintwhy.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_langhintwhy.Location = new System.Drawing.Point(12, 90);
            this.lb_langhintwhy.Name = "lb_langhintwhy";
            this.lb_langhintwhy.Size = new System.Drawing.Size(154, 14);
            this.lb_langhintwhy.TabIndex = 39;
            this.lb_langhintwhy.Text = "Tab control position.";
            // 
            // cbLang
            // 
            this.cbLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLang.BackColor = System.Drawing.Color.White;
            this.cbLang.DisplayMember = "1";
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLang.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbLang.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Items.AddRange(new object[] {
            "Auto",
            "English",
            "한국어",
            "汉语"});
            this.cbLang.Location = new System.Drawing.Point(257, 18);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(108, 23);
            this.cbLang.TabIndex = 1;
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            this.cbLang.Click += new System.EventHandler(this.cbLang_Click);
            // 
            // lb_lang
            // 
            this.lb_lang.AutoSize = true;
            this.lb_lang.BackColor = System.Drawing.Color.Transparent;
            this.lb_lang.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_lang.Location = new System.Drawing.Point(12, 19);
            this.lb_lang.Name = "lb_lang";
            this.lb_lang.Size = new System.Drawing.Size(70, 15);
            this.lb_lang.TabIndex = 40;
            this.lb_lang.Text = "Language:";
            // 
            // lbLang
            // 
            this.lbLang.AutoSize = true;
            this.lbLang.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbLang.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbLang.Location = new System.Drawing.Point(12, 39);
            this.lbLang.Name = "lbLang";
            this.lbLang.Size = new System.Drawing.Size(196, 14);
            this.lbLang.TabIndex = 42;
            this.lbLang.Text = "Program language.          \r\n";
            // 
            // lbap
            // 
            this.lbap.AutoSize = true;
            this.lbap.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbap.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbap.Location = new System.Drawing.Point(15, 293);
            this.lbap.Name = "lbap";
            this.lbap.Size = new System.Drawing.Size(210, 14);
            this.lbap.TabIndex = 44;
            this.lbap.Text = "Fetch all patches, temporary.";
            this.lbap.Visible = false;
            // 
            // cbMusi
            // 
            this.cbMusi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMusi.BackColor = System.Drawing.Color.White;
            this.cbMusi.DisplayMember = "1";
            this.cbMusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMusi.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbMusi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbMusi.FormattingEnabled = true;
            this.cbMusi.Items.AddRange(new object[] {
            "Off",
            "On"});
            this.cbMusi.Location = new System.Drawing.Point(257, 126);
            this.cbMusi.Name = "cbMusi";
            this.cbMusi.Size = new System.Drawing.Size(108, 23);
            this.cbMusi.TabIndex = 3;
            // 
            // lbmusi
            // 
            this.lbmusi.AutoSize = true;
            this.lbmusi.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbmusi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbmusi.Location = new System.Drawing.Point(12, 147);
            this.lbmusi.Name = "lbmusi";
            this.lbmusi.Size = new System.Drawing.Size(196, 14);
            this.lbmusi.TabIndex = 52;
            this.lbmusi.Text = "Play cutie music at launch.";
            // 
            // lb_musi
            // 
            this.lb_musi.AutoSize = true;
            this.lb_musi.BackColor = System.Drawing.Color.Transparent;
            this.lb_musi.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_musi.Location = new System.Drawing.Point(12, 128);
            this.lb_musi.Name = "lb_musi";
            this.lb_musi.Size = new System.Drawing.Size(119, 15);
            this.lb_musi.TabIndex = 51;
            this.lb_musi.Text = "Auto play music:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roundCornerControl3);
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.cbLogging);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lb_logging);
            this.panel1.Controls.Add(this.cbMusi);
            this.panel1.Controls.Add(this.cbs1);
            this.panel1.Controls.Add(this.cbLang);
            this.panel1.Controls.Add(this.lbmusi);
            this.panel1.Controls.Add(this.lb_musi);
            this.panel1.Controls.Add(this.lbap);
            this.panel1.Controls.Add(this.lbLang);
            this.panel1.Controls.Add(this.lb_lang);
            this.panel1.Controls.Add(this.lb_langhintwhy);
            this.panel1.Controls.Add(this.lb_s1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 291);
            this.panel1.TabIndex = 53;
            // 
            // cbLogging
            // 
            this.cbLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLogging.BackColor = System.Drawing.Color.White;
            this.cbLogging.DisplayMember = "1";
            this.cbLogging.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogging.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbLogging.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbLogging.FormattingEnabled = true;
            this.cbLogging.Items.AddRange(new object[] {
            "Off",
            "On"});
            this.cbLogging.Location = new System.Drawing.Point(257, 182);
            this.cbLogging.Name = "cbLogging";
            this.cbLogging.Size = new System.Drawing.Size(108, 23);
            this.cbLogging.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 55;
            this.label1.Text = "Save program events.";
            // 
            // lb_logging
            // 
            this.lb_logging.AutoSize = true;
            this.lb_logging.BackColor = System.Drawing.Color.Transparent;
            this.lb_logging.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_logging.Location = new System.Drawing.Point(12, 183);
            this.lb_logging.Name = "lb_logging";
            this.lb_logging.Size = new System.Drawing.Size(112, 15);
            this.lb_logging.TabIndex = 54;
            this.lb_logging.Text = "Enable logging:";
            // 
            // roundCornerControl3
            // 
            this.roundCornerControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl3.Controls.Add(this.btnCleanup);
            this.roundCornerControl3.Location = new System.Drawing.Point(177, 254);
            this.roundCornerControl3.Name = "roundCornerControl3";
            this.roundCornerControl3.Radius = 3;
            this.roundCornerControl3.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl3.TabIndex = 57;
            // 
            // btnCleanup
            // 
            this.btnCleanup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanup.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnCleanup.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCleanup.FlatAppearance.BorderSize = 0;
            this.btnCleanup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanup.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnCleanup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCleanup.Location = new System.Drawing.Point(-1, -1);
            this.btnCleanup.Name = "btnCleanup";
            this.btnCleanup.Size = new System.Drawing.Size(93, 27);
            this.btnCleanup.TabIndex = 6;
            this.btnCleanup.Text = "Clean up";
            this.btnCleanup.UseVisualStyleBackColor = false;
            this.btnCleanup.Click += new System.EventHandler(this.btnCleanup_Click);
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btn_viewlog);
            this.roundCornerControl2.Location = new System.Drawing.Point(80, 254);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 3;
            this.roundCornerControl2.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl2.TabIndex = 57;
            // 
            // btn_viewlog
            // 
            this.btn_viewlog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_viewlog.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_viewlog.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_viewlog.FlatAppearance.BorderSize = 0;
            this.btn_viewlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_viewlog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_viewlog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_viewlog.Location = new System.Drawing.Point(-1, -1);
            this.btn_viewlog.Name = "btn_viewlog";
            this.btn_viewlog.Size = new System.Drawing.Size(93, 27);
            this.btn_viewlog.TabIndex = 5;
            this.btn_viewlog.Text = "View logs";
            this.btn_viewlog.UseVisualStyleBackColor = false;
            this.btn_viewlog.Click += new System.EventHandler(this.btn_viewlog_Click);
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btn_ok);
            this.roundCornerControl1.Location = new System.Drawing.Point(274, 254);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl1.TabIndex = 56;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btn_ok.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_ok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ok.Location = new System.Drawing.Point(-1, -1);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(93, 27);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "Confirm";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.SveSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(377, 291);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "SettingsForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "settingfrm";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl3.ResumeLayout(false);
            this.roundCornerControl2.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_s1;
        private System.Windows.Forms.ComboBox cbs1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lb_langhintwhy;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Label lb_lang;
        private System.Windows.Forms.Label lbLang;
        private System.Windows.Forms.Label lbap;
        private System.Windows.Forms.Button btnCleanup;
        private System.Windows.Forms.ComboBox cbMusi;
        private System.Windows.Forms.Label lbmusi;
        private System.Windows.Forms.Label lb_musi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbLogging;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_logging;
        private System.Windows.Forms.Button btn_viewlog;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
        private Controls.UserControls.RoundCornerControl roundCornerControl3;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}