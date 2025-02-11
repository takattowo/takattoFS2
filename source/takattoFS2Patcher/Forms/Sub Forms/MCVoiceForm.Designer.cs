
namespace takattoFS2.Forms.Sub_Forms
{
    partial class MCVoiceForm
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
            this.lbVersion = new System.Windows.Forms.Label();
            this.panelEx3 = new takattoFS2.Controls.UserControls.PanelEx();
            this.panelEx1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.rdEng = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rdDefault = new System.Windows.Forms.RadioButton();
            this.rdVie = new System.Windows.Forms.RadioButton();
            this.rdKustom = new System.Windows.Forms.RadioButton();
            this.rdChine = new System.Windows.Forms.RadioButton();
            this.rdFA = new System.Windows.Forms.RadioButton();
            this.rdKor = new System.Windows.Forms.RadioButton();
            this.lbMcVoiceHint = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dlcCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.lbMcVoiceHint);
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
            this.btnUpdate.Location = new System.Drawing.Point(262, 234);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(25, 25);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbNote
            // 
            this.lbNote.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lbNote.Location = new System.Drawing.Point(2, 263);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(291, 23);
            this.lbNote.TabIndex = 57;
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbVersion.ForeColor = System.Drawing.Color.Teal;
            this.lbVersion.Location = new System.Drawing.Point(2, 240);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(254, 23);
            this.lbVersion.TabIndex = 14;
            this.lbVersion.Text = "Version";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelEx3
            // 
            this.panelEx3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx3.BackColor = System.Drawing.Color.White;
            this.panelEx3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx3.Controls.Add(this.panelEx1);
            this.panelEx3.Location = new System.Drawing.Point(0, 32);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx3.Size = new System.Drawing.Size(294, 196);
            this.panelEx3.TabIndex = 53;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.White;
            this.panelEx1.Controls.Add(this.button6);
            this.panelEx1.Controls.Add(this.rdEng);
            this.panelEx1.Controls.Add(this.button5);
            this.panelEx1.Controls.Add(this.button4);
            this.panelEx1.Controls.Add(this.button3);
            this.panelEx1.Controls.Add(this.button2);
            this.panelEx1.Controls.Add(this.button1);
            this.panelEx1.Controls.Add(this.rdDefault);
            this.panelEx1.Controls.Add(this.rdVie);
            this.panelEx1.Controls.Add(this.rdKustom);
            this.panelEx1.Controls.Add(this.rdChine);
            this.panelEx1.Controls.Add(this.rdFA);
            this.panelEx1.Controls.Add(this.rdKor);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(1, 1);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(292, 194);
            this.panelEx1.TabIndex = 51;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(259, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 25);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // rdEng
            // 
            this.rdEng.AutoSize = true;
            this.rdEng.Enabled = false;
            this.rdEng.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdEng.Location = new System.Drawing.Point(11, 60);
            this.rdEng.Name = "rdEng";
            this.rdEng.Size = new System.Drawing.Size(14, 13);
            this.rdEng.TabIndex = 4;
            this.rdEng.TabStop = true;
            this.rdEng.CheckedChanged += new System.EventHandler(this.rdEng_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(259, 165);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 13;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(259, 138);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(259, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(259, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_play_25;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(259, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // rdVie
            // 
            this.rdVie.AutoSize = true;
            this.rdVie.Enabled = false;
            this.rdVie.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdVie.Location = new System.Drawing.Point(11, 33);
            this.rdVie.Name = "rdVie";
            this.rdVie.Size = new System.Drawing.Size(14, 13);
            this.rdVie.TabIndex = 2;
            this.rdVie.TabStop = true;
            this.rdVie.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdKustom
            // 
            this.rdKustom.AutoSize = true;
            this.rdKustom.Enabled = false;
            this.rdKustom.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdKustom.Location = new System.Drawing.Point(11, 168);
            this.rdKustom.Name = "rdKustom";
            this.rdKustom.Size = new System.Drawing.Size(14, 13);
            this.rdKustom.TabIndex = 12;
            this.rdKustom.TabStop = true;
            this.rdKustom.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // rdChine
            // 
            this.rdChine.AutoSize = true;
            this.rdChine.Enabled = false;
            this.rdChine.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdChine.Location = new System.Drawing.Point(11, 87);
            this.rdChine.Name = "rdChine";
            this.rdChine.Size = new System.Drawing.Size(14, 13);
            this.rdChine.TabIndex = 6;
            this.rdChine.TabStop = true;
            this.rdChine.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdFA
            // 
            this.rdFA.AutoSize = true;
            this.rdFA.Enabled = false;
            this.rdFA.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdFA.Location = new System.Drawing.Point(11, 141);
            this.rdFA.Name = "rdFA";
            this.rdFA.Size = new System.Drawing.Size(14, 13);
            this.rdFA.TabIndex = 10;
            this.rdFA.TabStop = true;
            this.rdFA.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rdKor
            // 
            this.rdKor.AutoSize = true;
            this.rdKor.Enabled = false;
            this.rdKor.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdKor.Location = new System.Drawing.Point(11, 114);
            this.rdKor.Name = "rdKor";
            this.rdKor.Size = new System.Drawing.Size(14, 13);
            this.rdKor.TabIndex = 8;
            this.rdKor.TabStop = true;
            this.rdKor.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // lbMcVoiceHint
            // 
            this.lbMcVoiceHint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbMcVoiceHint.ForeColor = System.Drawing.Color.Teal;
            this.lbMcVoiceHint.Location = new System.Drawing.Point(0, 6);
            this.lbMcVoiceHint.Name = "lbMcVoiceHint";
            this.lbMcVoiceHint.Size = new System.Drawing.Size(269, 23);
            this.lbMcVoiceHint.TabIndex = 44;
            // 
            // dlcCheck
            // 
            this.dlcCheck.Enabled = true;
            this.dlcCheck.Interval = 2000;
            this.dlcCheck.Tick += new System.EventHandler(this.dlcCheck_Tick);
            // 
            // MCVoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(294, 328);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "MCVoiceForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbMcVoiceHint;
        private System.Windows.Forms.RadioButton rdChine;
        private System.Windows.Forms.RadioButton rdVie;
        private System.Windows.Forms.RadioButton rdDefault;
        private System.Windows.Forms.RadioButton rdKustom;
        private System.Windows.Forms.RadioButton rdFA;
        private System.Windows.Forms.RadioButton rdKor;
        private System.Windows.Forms.Panel panelEx1;
        private Controls.UserControls.PanelEx panelEx3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer dlcCheck;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton rdEng;
    }
}