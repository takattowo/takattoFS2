
namespace takattoFS2.Forms.Sub_Forms
{
    partial class MiscForm
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
            this.glassyPanel1 = new takattoFS2.Controls.UserControls.GlassyPanel();
            this.lbMiscHint1 = new System.Windows.Forms.CheckBox();
            this.lbMiscHint2 = new System.Windows.Forms.Label();
            this.txtW = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.txtH = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.panelEx4 = new takattoFS2.Controls.UserControls.PanelEx();
            this.panelEx2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbCopy = new System.Windows.Forms.CheckBox();
            this.txtT = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbIntervalAFK = new System.Windows.Forms.Label();
            this.btnInterval = new System.Windows.Forms.Button();
            this.cbCleanLog = new System.Windows.Forms.CheckBox();
            this.cbAFK = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customFontCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.glassyPanel1);
            this.panel1.Controls.Add(this.lbMiscHint1);
            this.panel1.Controls.Add(this.lbMiscHint2);
            this.panel1.Controls.Add(this.txtW);
            this.panel1.Controls.Add(this.txtH);
            this.panel1.Controls.Add(this.panelEx4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 384);
            this.panel1.TabIndex = 41;
            // 
            // glassyPanel1
            // 
            this.glassyPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glassyPanel1.Location = new System.Drawing.Point(0, 32);
            this.glassyPanel1.Name = "glassyPanel1";
            this.glassyPanel1.Size = new System.Drawing.Size(262, 63);
            this.glassyPanel1.TabIndex = 62;
            this.glassyPanel1.Visible = false;
            // 
            // lbMiscHint1
            // 
            this.lbMiscHint1.AutoCheck = false;
            this.lbMiscHint1.AutoSize = true;
            this.lbMiscHint1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbMiscHint1.ForeColor = System.Drawing.Color.Teal;
            this.lbMiscHint1.Location = new System.Drawing.Point(3, 5);
            this.lbMiscHint1.Name = "lbMiscHint1";
            this.lbMiscHint1.Size = new System.Drawing.Size(15, 14);
            this.lbMiscHint1.TabIndex = 0;
            this.lbMiscHint1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbMiscHint1.CheckedChanged += new System.EventHandler(this.lbMiscHint1_CheckedChanged);
            this.lbMiscHint1.Click += new System.EventHandler(this.lbMiscHint1_Click);
            // 
            // lbMiscHint2
            // 
            this.lbMiscHint2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMiscHint2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbMiscHint2.ForeColor = System.Drawing.Color.Teal;
            this.lbMiscHint2.Location = new System.Drawing.Point(-1, 98);
            this.lbMiscHint2.Name = "lbMiscHint2";
            this.lbMiscHint2.Size = new System.Drawing.Size(262, 23);
            this.lbMiscHint2.TabIndex = 58;
            // 
            // txtW
            // 
            this.txtW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtW.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtW.ForeColor = System.Drawing.Color.Gray;
            this.txtW.Location = new System.Drawing.Point(0, 32);
            this.txtW.MaxLength = 8;
            this.txtW.Name = "txtW";
            this.txtW.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtW.PlaceHolderText = "                                                                  Width";
            this.txtW.ShortcutsEnabled = false;
            this.txtW.Size = new System.Drawing.Size(262, 23);
            this.txtW.TabIndex = 1;
            this.txtW.Text = "  ";
            this.toolTip1.SetToolTip(this.txtW, "Width");
            this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // txtH
            // 
            this.txtH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtH.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtH.ForeColor = System.Drawing.Color.Gray;
            this.txtH.Location = new System.Drawing.Point(0, 60);
            this.txtH.MaxLength = 8;
            this.txtH.Name = "txtH";
            this.txtH.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtH.PlaceHolderText = "                                                                  Height";
            this.txtH.ShortcutsEnabled = false;
            this.txtH.Size = new System.Drawing.Size(262, 23);
            this.txtH.TabIndex = 2;
            this.txtH.Text = "  ";
            this.txtH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // panelEx4
            // 
            this.panelEx4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx4.BackColor = System.Drawing.Color.White;
            this.panelEx4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx4.Controls.Add(this.panelEx2);
            this.panelEx4.Location = new System.Drawing.Point(0, 124);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx4.Size = new System.Drawing.Size(262, 116);
            this.panelEx4.TabIndex = 55;
            // 
            // panelEx2
            // 
            this.panelEx2.BackColor = System.Drawing.Color.White;
            this.panelEx2.Controls.Add(this.checkBox1);
            this.panelEx2.Controls.Add(this.cbCopy);
            this.panelEx2.Controls.Add(this.txtT);
            this.panelEx2.Controls.Add(this.lbIntervalAFK);
            this.panelEx2.Controls.Add(this.btnInterval);
            this.panelEx2.Controls.Add(this.cbCleanLog);
            this.panelEx2.Controls.Add(this.cbAFK);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(1, 1);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(260, 114);
            this.panelEx2.TabIndex = 52;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoCheck = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.checkBox1.Location = new System.Drawing.Point(11, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click_1);
            // 
            // cbCopy
            // 
            this.cbCopy.AutoCheck = false;
            this.cbCopy.AutoSize = true;
            this.cbCopy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCopy.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbCopy.Location = new System.Drawing.Point(11, 60);
            this.cbCopy.Name = "cbCopy";
            this.cbCopy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCopy.Size = new System.Drawing.Size(15, 14);
            this.cbCopy.TabIndex = 5;
            this.cbCopy.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.cbCopy.Click += new System.EventHandler(this.checkBox3_Click);
            // 
            // txtT
            // 
            this.txtT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtT.Enabled = false;
            this.txtT.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtT.ForeColor = System.Drawing.Color.Gray;
            this.txtT.Location = new System.Drawing.Point(154, 115);
            this.txtT.MaxLength = 5;
            this.txtT.MinimumSize = new System.Drawing.Size(4, 4);
            this.txtT.Name = "txtT";
            this.txtT.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtT.PlaceHolderText = "                                                  40";
            this.txtT.ShortcutsEnabled = false;
            this.txtT.Size = new System.Drawing.Size(96, 23);
            this.txtT.TabIndex = 9;
            this.txtT.Text = " 40";
            this.txtT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT_KeyPress);
            // 
            // lbIntervalAFK
            // 
            this.lbIntervalAFK.BackColor = System.Drawing.Color.Transparent;
            this.lbIntervalAFK.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbIntervalAFK.ForeColor = System.Drawing.Color.Teal;
            this.lbIntervalAFK.Location = new System.Drawing.Point(8, 117);
            this.lbIntervalAFK.Name = "lbIntervalAFK";
            this.lbIntervalAFK.Size = new System.Drawing.Size(147, 23);
            this.lbIntervalAFK.TabIndex = 8;
            // 
            // btnInterval
            // 
            this.btnInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInterval.BackColor = System.Drawing.Color.Transparent;
            this.btnInterval.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_repeat_35_b;
            this.btnInterval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInterval.FlatAppearance.BorderSize = 0;
            this.btnInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInterval.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnInterval.ForeColor = System.Drawing.Color.White;
            this.btnInterval.Location = new System.Drawing.Point(227, 87);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(25, 21);
            this.btnInterval.TabIndex = 7;
            this.btnInterval.UseVisualStyleBackColor = false;
            this.btnInterval.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbCleanLog
            // 
            this.cbCleanLog.AutoCheck = false;
            this.cbCleanLog.AutoSize = true;
            this.cbCleanLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCleanLog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbCleanLog.Location = new System.Drawing.Point(11, 33);
            this.cbCleanLog.Name = "cbCleanLog";
            this.cbCleanLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCleanLog.Size = new System.Drawing.Size(15, 14);
            this.cbCleanLog.TabIndex = 4;
            this.cbCleanLog.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.cbCleanLog.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // cbAFK
            // 
            this.cbAFK.AutoCheck = false;
            this.cbAFK.AutoSize = true;
            this.cbAFK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAFK.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbAFK.Location = new System.Drawing.Point(11, 87);
            this.cbAFK.Name = "cbAFK";
            this.cbAFK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAFK.Size = new System.Drawing.Size(15, 14);
            this.cbAFK.TabIndex = 6;
            this.cbAFK.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.cbAFK.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // customFontCheck
            // 
            this.customFontCheck.Enabled = true;
            this.customFontCheck.Interval = 10;
            this.customFontCheck.Tick += new System.EventHandler(this.customFontCheck_Tick_1);
            // 
            // MiscForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(262, 384);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "MiscForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ResSettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEx4.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.UserControls.TextBoxEx txtH;
        private Controls.UserControls.TextBoxEx txtW;
        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.PanelEx panelEx4;
        private System.Windows.Forms.Panel panelEx2;
        private System.Windows.Forms.CheckBox cbCleanLog;
        private System.Windows.Forms.CheckBox cbAFK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbMiscHint2;
        private System.Windows.Forms.Button btnInterval;
        private System.Windows.Forms.Timer timer1;
        private Controls.UserControls.TextBoxEx txtT;
        private System.Windows.Forms.Label lbIntervalAFK;
        private System.Windows.Forms.CheckBox cbCopy;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer customFontCheck;
        private Controls.UserControls.GlassyPanel glassyPanel1;
        private System.Windows.Forms.CheckBox lbMiscHint1;
    }
}