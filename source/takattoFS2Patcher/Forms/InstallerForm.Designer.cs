
namespace takattoFS2.Forms
{
    partial class InstallerForm
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
            this.btn_repair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_captcha = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_repair
            // 
            this.btn_repair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_repair.BackColor = System.Drawing.Color.LightCoral;
            this.btn_repair.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_repair.FlatAppearance.BorderSize = 0;
            this.btn_repair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_repair.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_repair.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_repair.Location = new System.Drawing.Point(-1, -1);
            this.btn_repair.Name = "btn_repair";
            this.btn_repair.Size = new System.Drawing.Size(104, 31);
            this.btn_repair.TabIndex = 1;
            this.btn_repair.Text = "Repair";
            this.btn_repair.UseVisualStyleBackColor = false;
            this.btn_repair.Click += new System.EventHandler(this.btn_dlc1_red_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 171);
            this.label1.TabIndex = 33;
            // 
            // lb_captcha
            // 
            this.lb_captcha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_captcha.BackColor = System.Drawing.Color.Transparent;
            this.lb_captcha.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_captcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_captcha.Location = new System.Drawing.Point(12, 213);
            this.lb_captcha.Name = "lb_captcha";
            this.lb_captcha.Size = new System.Drawing.Size(522, 21);
            this.lb_captcha.TabIndex = 36;
            this.lb_captcha.Text = "Are you really sure?";
            this.lb_captcha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Location = new System.Drawing.Point(-1, -1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(104, 31);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Cancel";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.install_dlc6_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::takattoFS2.Properties.Resources._1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(263, 236);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::takattoFS2.Properties.Resources._2;
            this.pictureBox1.Location = new System.Drawing.Point(1, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.lb_captcha);
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 248);
            this.panel1.TabIndex = 40;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btn_close);
            this.roundCornerControl1.Location = new System.Drawing.Point(540, 175);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 5;
            this.roundCornerControl1.Size = new System.Drawing.Size(103, 30);
            this.roundCornerControl1.TabIndex = 40;
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btn_repair);
            this.roundCornerControl2.Location = new System.Drawing.Point(540, 207);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 5;
            this.roundCornerControl2.Size = new System.Drawing.Size(103, 30);
            this.roundCornerControl2.TabIndex = 41;
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 248);
            this.Controls.Add(this.panel1);
            this.Name = "InstallerForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "takatto Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_PatcherUninstallerForm_FormClosing);
            this.Load += new System.EventHandler(this.PatcherUninstallerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            this.roundCornerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_repair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_captcha;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
    }
}