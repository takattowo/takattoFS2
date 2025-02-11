
namespace takattoFS2.Forms.Sub_Forms
{
    partial class CustomTextureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTextureForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbUIHint = new System.Windows.Forms.Label();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbPNG = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbLoading = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbWait = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbWait2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.lbUIHint);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.lbVersion);
            this.panel1.Controls.Add(this.lbPNG);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 374);
            this.panel1.TabIndex = 37;
            // 
            // lbUIHint
            // 
            this.lbUIHint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbUIHint.ForeColor = System.Drawing.Color.Teal;
            this.lbUIHint.Location = new System.Drawing.Point(0, 6);
            this.lbUIHint.Name = "lbUIHint";
            this.lbUIHint.Size = new System.Drawing.Size(326, 23);
            this.lbUIHint.TabIndex = 45;
            this.lbUIHint.Visible = false;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btnSelect);
            this.roundCornerControl1.Location = new System.Drawing.Point(240, 1);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(86, 26);
            this.roundCornerControl1.TabIndex = 45;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(-1, -1);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(87, 27);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVersion.BackColor = System.Drawing.Color.Transparent;
            this.lbVersion.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbVersion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbVersion.Location = new System.Drawing.Point(0, 242);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(325, 21);
            this.lbVersion.TabIndex = 1;
            this.lbVersion.Text = "[No extension]";
            // 
            // lbPNG
            // 
            this.lbPNG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPNG.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbPNG.Location = new System.Drawing.Point(0, 6);
            this.lbPNG.Name = "lbPNG";
            this.lbPNG.Size = new System.Drawing.Size(238, 20);
            this.lbPNG.TabIndex = 9;
            this.lbPNG.Text = ".PNG";
            this.lbPNG.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnConfirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.Location = new System.Drawing.Point(222, 333);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 29);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(327, 199);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Enter);
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabPage1.Size = new System.Drawing.Size(319, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Loading";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.lbLoading);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 170);
            this.panel2.TabIndex = 10;
            // 
            // lbLoading
            // 
            this.lbLoading.BackColor = System.Drawing.Color.Transparent;
            this.lbLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbLoading.Location = new System.Drawing.Point(0, 0);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(317, 170);
            this.lbLoading.TabIndex = 1;
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-124, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prefered resolution: aspect ratio of 1600x768~";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbWait);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabPage2.Size = new System.Drawing.Size(319, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cards";
            // 
            // lbWait
            // 
            this.lbWait.BackColor = System.Drawing.Color.White;
            this.lbWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbWait.Location = new System.Drawing.Point(0, 2);
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(317, 170);
            this.lbWait.TabIndex = 0;
            this.lbWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbWait2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabPage3.Size = new System.Drawing.Size(319, 173);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbWait2
            // 
            this.lbWait2.BackColor = System.Drawing.Color.White;
            this.lbWait2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWait2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbWait2.Location = new System.Drawing.Point(0, 2);
            this.lbWait2.Name = "lbWait2";
            this.lbWait2.Size = new System.Drawing.Size(317, 170);
            this.lbWait2.TabIndex = 1;
            this.lbWait2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(325, 374);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "CustomTextureForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Help_Jukebox_Downloader_Load);
            this.panel1.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbWait;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lbPNG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbLoading;
        public System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbUIHint;
        private System.Windows.Forms.Label lbWait2;
    }
}