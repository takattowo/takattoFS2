
namespace takattoFS2.Forms.Sub_Forms
{
    partial class AutoTaskForm
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
            this.radFocusedModeOnly = new System.Windows.Forms.CheckBox();
            this.cbMacroKey = new System.Windows.Forms.ComboBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.radRepat = new System.Windows.Forms.CheckBox();
            this.lbAFK_hint = new System.Windows.Forms.Label();
            this.cbGameGraphic = new System.Windows.Forms.ComboBox();
            this.txtW = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3Delay = new System.Windows.Forms.Timer(this.components);
            this.timer3PointerInGame = new System.Windows.Forms.Timer(this.components);
            this.timerCBMacr = new System.Windows.Forms.Timer(this.components);
            this.timerCBMcrMoveUpDown = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.radFocusedModeOnly);
            this.panel1.Controls.Add(this.cbMacroKey);
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Controls.Add(this.txtPoint);
            this.panel1.Controls.Add(this.txtCommand);
            this.panel1.Controls.Add(this.radRepat);
            this.panel1.Controls.Add(this.lbAFK_hint);
            this.panel1.Controls.Add(this.cbGameGraphic);
            this.panel1.Controls.Add(this.txtW);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 362);
            this.panel1.TabIndex = 42;
            // 
            // radFocusedModeOnly
            // 
            this.radFocusedModeOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radFocusedModeOnly.AutoCheck = false;
            this.radFocusedModeOnly.BackColor = System.Drawing.Color.Transparent;
            this.radFocusedModeOnly.Enabled = false;
            this.radFocusedModeOnly.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.radFocusedModeOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.radFocusedModeOnly.Location = new System.Drawing.Point(165, 190);
            this.radFocusedModeOnly.Name = "radFocusedModeOnly";
            this.radFocusedModeOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radFocusedModeOnly.Size = new System.Drawing.Size(151, 25);
            this.radFocusedModeOnly.TabIndex = 56;
            this.radFocusedModeOnly.Text = "Focused only";
            this.radFocusedModeOnly.UseVisualStyleBackColor = false;
            this.radFocusedModeOnly.Visible = false;
            this.radFocusedModeOnly.CheckedChanged += new System.EventHandler(this.radFocusedModeOnly_CheckedChanged);
            this.radFocusedModeOnly.Click += new System.EventHandler(this.radFocusedModeOnly_Click);
            // 
            // cbMacroKey
            // 
            this.cbMacroKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMacroKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMacroKey.Enabled = false;
            this.cbMacroKey.Font = new System.Drawing.Font("Gadugi", 10F);
            this.cbMacroKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbMacroKey.FormattingEnabled = true;
            this.cbMacroKey.ItemHeight = 16;
            this.cbMacroKey.Location = new System.Drawing.Point(0, 90);
            this.cbMacroKey.Name = "cbMacroKey";
            this.cbMacroKey.Size = new System.Drawing.Size(316, 24);
            this.cbMacroKey.TabIndex = 4;
            this.cbMacroKey.Visible = false;
            this.cbMacroKey.SelectedIndexChanged += new System.EventHandler(this.cbMacroKey_SelectedIndexChanged);
            this.cbMacroKey.DropDownClosed += new System.EventHandler(this.cbGameGraphic_DropDownClosed);
            // 
            // lbNote
            // 
            this.lbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNote.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbNote.ForeColor = System.Drawing.Color.Maroon;
            this.lbNote.Location = new System.Drawing.Point(0, 218);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(316, 144);
            this.lbNote.TabIndex = 55;
            // 
            // txtPoint
            // 
            this.txtPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPoint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPoint.Location = new System.Drawing.Point(0, 61);
            this.txtPoint.Multiline = true;
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(316, 97);
            this.txtPoint.TabIndex = 3;
            this.txtPoint.Visible = false;
            this.txtPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoint_KeyPress);
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCommand.Location = new System.Drawing.Point(0, 61);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(316, 97);
            this.txtCommand.TabIndex = 3;
            // 
            // radRepat
            // 
            this.radRepat.AutoCheck = false;
            this.radRepat.BackColor = System.Drawing.Color.Transparent;
            this.radRepat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radRepat.Enabled = false;
            this.radRepat.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.radRepat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.radRepat.Location = new System.Drawing.Point(0, 190);
            this.radRepat.Name = "radRepat";
            this.radRepat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radRepat.Size = new System.Drawing.Size(146, 25);
            this.radRepat.TabIndex = 4;
            this.radRepat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radRepat.UseVisualStyleBackColor = false;
            this.radRepat.CheckedChanged += new System.EventHandler(this.radRepat_CheckedChanged);
            this.radRepat.Click += new System.EventHandler(this.radRepat_Click);
            // 
            // lbAFK_hint
            // 
            this.lbAFK_hint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAFK_hint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbAFK_hint.ForeColor = System.Drawing.Color.Teal;
            this.lbAFK_hint.Location = new System.Drawing.Point(0, 6);
            this.lbAFK_hint.Name = "lbAFK_hint";
            this.lbAFK_hint.Size = new System.Drawing.Size(316, 23);
            this.lbAFK_hint.TabIndex = 46;
            this.lbAFK_hint.Click += new System.EventHandler(this.lbAFK_hint_Click);
            // 
            // cbGameGraphic
            // 
            this.cbGameGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGameGraphic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameGraphic.Font = new System.Drawing.Font("Gadugi", 10F);
            this.cbGameGraphic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbGameGraphic.FormattingEnabled = true;
            this.cbGameGraphic.ItemHeight = 16;
            this.cbGameGraphic.Location = new System.Drawing.Point(0, 60);
            this.cbGameGraphic.Name = "cbGameGraphic";
            this.cbGameGraphic.Size = new System.Drawing.Size(316, 24);
            this.cbGameGraphic.TabIndex = 2;
            this.cbGameGraphic.Visible = false;
            this.cbGameGraphic.SelectedIndexChanged += new System.EventHandler(this.cbGameGraphic_SelectedIndexChanged);
            this.cbGameGraphic.DropDownClosed += new System.EventHandler(this.cbGameGraphic_DropDownClosed);
            // 
            // txtW
            // 
            this.txtW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtW.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtW.ForeColor = System.Drawing.Color.Gray;
            this.txtW.Location = new System.Drawing.Point(0, 32);
            this.txtW.MaxLength = 10;
            this.txtW.Name = "txtW";
            this.txtW.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtW.PlaceHolderText = "                                                                            ";
            this.txtW.ShortcutsEnabled = false;
            this.txtW.Size = new System.Drawing.Size(316, 23);
            this.txtW.TabIndex = 1;
            this.txtW.Text = " 60";
            this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3Delay
            // 
            this.timer3Delay.Tick += new System.EventHandler(this.timer3Delay_Tick);
            // 
            // timer3PointerInGame
            // 
            this.timer3PointerInGame.Enabled = true;
            this.timer3PointerInGame.Tick += new System.EventHandler(this.timer3PointerInGame_Tick);
            // 
            // timerCBMacr
            // 
            this.timerCBMacr.Interval = 20;
            this.timerCBMacr.Tick += new System.EventHandler(this.timerCBMacr_Tick);
            // 
            // timerCBMcrMoveUpDown
            // 
            this.timerCBMcrMoveUpDown.Interval = 10;
            this.timerCBMcrMoveUpDown.Tick += new System.EventHandler(this.timerCBMcrMoveUpDown_Tick);
            // 
            // AutoTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(316, 362);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AutoTaskForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.TextBoxEx txtW;
        private System.Windows.Forms.CheckBox radRepat;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbGameGraphic;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lbAFK_hint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3Delay;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Timer timer3PointerInGame;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.ComboBox cbMacroKey;
        private System.Windows.Forms.Timer timerCBMacr;
        private System.Windows.Forms.Timer timerCBMcrMoveUpDown;
        private System.Windows.Forms.CheckBox radFocusedModeOnly;
    }
}