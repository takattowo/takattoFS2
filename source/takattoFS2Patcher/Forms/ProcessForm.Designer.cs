
namespace takattoFS2.Forms
{
    partial class ProcessForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btn_Return = new System.Windows.Forms.Button();
            this.LB1 = new System.Windows.Forms.Label();
            this.lb_langhintwhy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.LB1);
            this.panel1.Controls.Add(this.lb_langhintwhy);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 432);
            this.panel1.TabIndex = 0;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btn_Return);
            this.roundCornerControl1.Location = new System.Drawing.Point(338, 9);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(76, 26);
            this.roundCornerControl1.TabIndex = 35;
            // 
            // btn_Return
            // 
            this.btn_Return.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(46)))), ((int)(((byte)(76)))));
            this.btn_Return.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Return.FlatAppearance.BorderSize = 0;
            this.btn_Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Return.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_Return.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Return.Location = new System.Drawing.Point(-1, -1);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(77, 27);
            this.btn_Return.TabIndex = 0;
            this.btn_Return.Text = "Return";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // LB1
            // 
            this.LB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB1.BackColor = System.Drawing.Color.Transparent;
            this.LB1.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold);
            this.LB1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.LB1.Location = new System.Drawing.Point(0, 50);
            this.LB1.Name = "LB1";
            this.LB1.Size = new System.Drawing.Size(419, 78);
            this.LB1.TabIndex = 0;
            this.LB1.Text = "Waiting for game";
            this.LB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_langhintwhy
            // 
            this.lb_langhintwhy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_langhintwhy.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_langhintwhy.ForeColor = System.Drawing.Color.DimGray;
            this.lb_langhintwhy.Location = new System.Drawing.Point(39, 13);
            this.lb_langhintwhy.Name = "lb_langhintwhy";
            this.lb_langhintwhy.Size = new System.Drawing.Size(293, 21);
            this.lb_langhintwhy.TabIndex = 33;
            this.lb_langhintwhy.Text = "Have you applied the tweaks?";
            this.lb_langhintwhy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::takattoFS2.Properties.Resources.waitin;
            this.pictureBox1.Location = new System.Drawing.Point(56, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 432);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcessForm";
            this.panel1.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB1;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.Label lb_langhintwhy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
    }
}