
namespace takattoFS2.Forms
{
    partial class SimpleDialogFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleDialogFrom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnCopy = new System.Windows.Forms.Button();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnOke = new System.Windows.Forms.Button();
            this.lbCopied = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lbAnko = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLicense);
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.lbCopied);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.lbAnko);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 226);
            this.panel1.TabIndex = 0;
            // 
            // txtLicense
            // 
            this.txtLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicense.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLicense.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.txtLicense.Location = new System.Drawing.Point(217, 7);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLicense.ShortcutsEnabled = false;
            this.txtLicense.Size = new System.Drawing.Size(327, 176);
            this.txtLicense.TabIndex = 11;
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btnCopy);
            this.roundCornerControl2.Location = new System.Drawing.Point(358, 189);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 3;
            this.roundCornerControl2.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl2.TabIndex = 10;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.Color.DimGray;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopy.Location = new System.Drawing.Point(-1, -1);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(93, 27);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy code";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btnOke);
            this.roundCornerControl1.Location = new System.Drawing.Point(453, 189);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl1.TabIndex = 9;
            // 
            // btnOke
            // 
            this.btnOke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOke.BackColor = System.Drawing.Color.Silver;
            this.btnOke.Enabled = false;
            this.btnOke.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnOke.FlatAppearance.BorderSize = 0;
            this.btnOke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOke.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnOke.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOke.Location = new System.Drawing.Point(-1, -1);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(93, 27);
            this.btnOke.TabIndex = 3;
            this.btnOke.Text = "Got it!";
            this.btnOke.UseVisualStyleBackColor = false;
            this.btnOke.Click += new System.EventHandler(this.btn_dlc1_red_Click);
            // 
            // lbCopied
            // 
            this.lbCopied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCopied.AutoEllipsis = true;
            this.lbCopied.BackColor = System.Drawing.Color.Transparent;
            this.lbCopied.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbCopied.ForeColor = System.Drawing.Color.IndianRed;
            this.lbCopied.Location = new System.Drawing.Point(258, 122);
            this.lbCopied.Name = "lbCopied";
            this.lbCopied.Size = new System.Drawing.Size(98, 22);
            this.lbCopied.TabIndex = 8;
            this.lbCopied.Text = "Copied!";
            this.lbCopied.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbCopied.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtCode.Location = new System.Drawing.Point(167, 91);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(377, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Visible = false;
            // 
            // lbAnko
            // 
            this.lbAnko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAnko.AutoEllipsis = true;
            this.lbAnko.BackColor = System.Drawing.Color.Transparent;
            this.lbAnko.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbAnko.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbAnko.Location = new System.Drawing.Point(248, 10);
            this.lbAnko.Name = "lbAnko";
            this.lbAnko.Size = new System.Drawing.Size(296, 80);
            this.lbAnko.TabIndex = 0;
            this.lbAnko.Text = "Ehem! This tweak requires an extension to be working, but since you gave me a lot" +
    " of love, you are quailified to earn such thing! Please copy the code and send t" +
    "o me~";
            this.lbAnko.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(597, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SimpleDialogFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 226);
            this.Controls.Add(this.panel1);
            this.Name = "SimpleDialogFrom";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nako thank you!";
            this.Load += new System.EventHandler(this.SimpleDialogFrom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl2.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lbAnko;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOke;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lbCopied;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Timer timer1;
    }
}