
namespace takattoFS2.Forms.Sub_Forms
{
    partial class CharVoiceForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbNote = new System.Windows.Forms.Label();
            this.panelEx2 = new takattoFS2.Controls.UserControls.PanelEx();
            this.panelEx1 = new System.Windows.Forms.Panel();
            this.btnCustomS = new System.Windows.Forms.Button();
            this.btnKorS = new System.Windows.Forms.Button();
            this.btnCnS = new System.Windows.Forms.Button();
            this.btnES = new System.Windows.Forms.Button();
            this.rdDefault = new System.Windows.Forms.RadioButton();
            this.rdEnglish = new System.Windows.Forms.RadioButton();
            this.rdChinese = new System.Windows.Forms.RadioButton();
            this.rdKustom = new System.Windows.Forms.RadioButton();
            this.rdKorean = new System.Windows.Forms.RadioButton();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbCharvoice_hint = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkDLC = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.lbCharvoice_hint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 328);
            this.panel1.TabIndex = 42;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_inbox_35;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(260, 180);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(25, 25);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbNote
            // 
            this.lbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNote.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lbNote.Location = new System.Drawing.Point(0, 209);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(291, 110);
            this.lbNote.TabIndex = 54;
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.BackColor = System.Drawing.Color.White;
            this.panelEx2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx2.Controls.Add(this.panelEx1);
            this.panelEx2.Location = new System.Drawing.Point(0, 32);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(294, 142);
            this.panelEx2.TabIndex = 53;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.White;
            this.panelEx1.Controls.Add(this.btnCustomS);
            this.panelEx1.Controls.Add(this.btnKorS);
            this.panelEx1.Controls.Add(this.btnCnS);
            this.panelEx1.Controls.Add(this.btnES);
            this.panelEx1.Controls.Add(this.rdDefault);
            this.panelEx1.Controls.Add(this.rdEnglish);
            this.panelEx1.Controls.Add(this.rdChinese);
            this.panelEx1.Controls.Add(this.rdKustom);
            this.panelEx1.Controls.Add(this.rdKorean);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(292, 140);
            this.panelEx1.TabIndex = 51;
            // 
            // btnCustomS
            // 
            this.btnCustomS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomS.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomS.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.btnCustomS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCustomS.FlatAppearance.BorderSize = 0;
            this.btnCustomS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomS.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnCustomS.ForeColor = System.Drawing.Color.White;
            this.btnCustomS.Location = new System.Drawing.Point(259, 111);
            this.btnCustomS.Name = "btnCustomS";
            this.btnCustomS.Size = new System.Drawing.Size(25, 25);
            this.btnCustomS.TabIndex = 9;
            this.btnCustomS.UseVisualStyleBackColor = false;
            this.btnCustomS.Visible = false;
            this.btnCustomS.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnKorS
            // 
            this.btnKorS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKorS.BackColor = System.Drawing.Color.Transparent;
            this.btnKorS.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.btnKorS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKorS.FlatAppearance.BorderSize = 0;
            this.btnKorS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKorS.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnKorS.ForeColor = System.Drawing.Color.White;
            this.btnKorS.Location = new System.Drawing.Point(259, 84);
            this.btnKorS.Name = "btnKorS";
            this.btnKorS.Size = new System.Drawing.Size(25, 25);
            this.btnKorS.TabIndex = 7;
            this.btnKorS.UseVisualStyleBackColor = false;
            this.btnKorS.Visible = false;
            this.btnKorS.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCnS
            // 
            this.btnCnS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCnS.BackColor = System.Drawing.Color.Transparent;
            this.btnCnS.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.btnCnS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCnS.FlatAppearance.BorderSize = 0;
            this.btnCnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCnS.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnCnS.ForeColor = System.Drawing.Color.White;
            this.btnCnS.Location = new System.Drawing.Point(259, 57);
            this.btnCnS.Name = "btnCnS";
            this.btnCnS.Size = new System.Drawing.Size(25, 25);
            this.btnCnS.TabIndex = 5;
            this.btnCnS.UseVisualStyleBackColor = false;
            this.btnCnS.Visible = false;
            this.btnCnS.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnES
            // 
            this.btnES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnES.BackColor = System.Drawing.Color.Transparent;
            this.btnES.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.btnES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnES.FlatAppearance.BorderSize = 0;
            this.btnES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnES.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnES.ForeColor = System.Drawing.Color.White;
            this.btnES.Location = new System.Drawing.Point(259, 30);
            this.btnES.Name = "btnES";
            this.btnES.Size = new System.Drawing.Size(25, 25);
            this.btnES.TabIndex = 3;
            this.btnES.UseVisualStyleBackColor = false;
            this.btnES.Visible = false;
            this.btnES.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdDefault
            // 
            this.rdDefault.AutoSize = true;
            this.rdDefault.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdDefault.Location = new System.Drawing.Point(11, 6);
            this.rdDefault.Name = "rdDefault";
            this.rdDefault.Size = new System.Drawing.Size(14, 13);
            this.rdDefault.TabIndex = 1;
            this.rdDefault.TabStop = true;
            this.rdDefault.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdEnglish
            // 
            this.rdEnglish.AutoSize = true;
            this.rdEnglish.Enabled = false;
            this.rdEnglish.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdEnglish.Location = new System.Drawing.Point(11, 33);
            this.rdEnglish.Name = "rdEnglish";
            this.rdEnglish.Size = new System.Drawing.Size(14, 13);
            this.rdEnglish.TabIndex = 2;
            this.rdEnglish.TabStop = true;
            this.rdEnglish.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdChinese
            // 
            this.rdChinese.AutoSize = true;
            this.rdChinese.Enabled = false;
            this.rdChinese.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdChinese.Location = new System.Drawing.Point(11, 60);
            this.rdChinese.Name = "rdChinese";
            this.rdChinese.Size = new System.Drawing.Size(14, 13);
            this.rdChinese.TabIndex = 4;
            this.rdChinese.TabStop = true;
            this.rdChinese.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdKustom
            // 
            this.rdKustom.AutoSize = true;
            this.rdKustom.Enabled = false;
            this.rdKustom.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdKustom.Location = new System.Drawing.Point(11, 114);
            this.rdKustom.Name = "rdKustom";
            this.rdKustom.Size = new System.Drawing.Size(14, 13);
            this.rdKustom.TabIndex = 8;
            this.rdKustom.TabStop = true;
            this.rdKustom.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rdKorean
            // 
            this.rdKorean.AutoSize = true;
            this.rdKorean.Enabled = false;
            this.rdKorean.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdKorean.Location = new System.Drawing.Point(11, 87);
            this.rdKorean.Name = "rdKorean";
            this.rdKorean.Size = new System.Drawing.Size(14, 13);
            this.rdKorean.TabIndex = 6;
            this.rdKorean.TabStop = true;
            this.rdKorean.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // lbVersion
            // 
            this.lbVersion.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbVersion.ForeColor = System.Drawing.Color.Teal;
            this.lbVersion.Location = new System.Drawing.Point(0, 186);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(291, 23);
            this.lbVersion.TabIndex = 10;
            this.lbVersion.Text = "Version";
            this.lbVersion.DoubleClick += new System.EventHandler(this.label2_Click);
            // 
            // lbCharvoice_hint
            // 
            this.lbCharvoice_hint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbCharvoice_hint.ForeColor = System.Drawing.Color.Teal;
            this.lbCharvoice_hint.Location = new System.Drawing.Point(0, 6);
            this.lbCharvoice_hint.Name = "lbCharvoice_hint";
            this.lbCharvoice_hint.Size = new System.Drawing.Size(269, 23);
            this.lbCharvoice_hint.TabIndex = 0;
            // 
            // checkDLC
            // 
            this.checkDLC.Enabled = true;
            this.checkDLC.Interval = 2000;
            this.checkDLC.Tick += new System.EventHandler(this.checkDLC_Tick);
            // 
            // CharVoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(294, 328);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CharVoiceForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCharvoice_hint;
        private System.Windows.Forms.RadioButton rdChinese;
        private System.Windows.Forms.RadioButton rdEnglish;
        private System.Windows.Forms.RadioButton rdDefault;
        private System.Windows.Forms.RadioButton rdKorean;
        private System.Windows.Forms.Panel panelEx1;
        private System.Windows.Forms.RadioButton rdKustom;
        private System.Windows.Forms.Label lbVersion;
        private Controls.UserControls.PanelEx panelEx2;
        private System.Windows.Forms.Button btnCustomS;
        private System.Windows.Forms.Button btnKorS;
        private System.Windows.Forms.Button btnCnS;
        private System.Windows.Forms.Button btnES;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Timer checkDLC;
        private System.Windows.Forms.Button btnUpdate;
    }
}