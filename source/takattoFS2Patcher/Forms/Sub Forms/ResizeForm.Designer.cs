
namespace takattoFS2.Forms.Sub_Forms
{
    partial class ResizeForm
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
            this.lbW = new System.Windows.Forms.Label();
            this.lbH = new System.Windows.Forms.Label();
            this.lbTip = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnResize = new System.Windows.Forms.Button();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.lbCrash = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbW
            // 
            this.lbW.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbW.Location = new System.Drawing.Point(5, 20);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(65, 15);
            this.lbW.TabIndex = 0;
            this.lbW.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbH
            // 
            this.lbH.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbH.Location = new System.Drawing.Point(5, 48);
            this.lbH.Name = "lbH";
            this.lbH.Size = new System.Drawing.Size(65, 15);
            this.lbH.TabIndex = 2;
            this.lbH.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbTip
            // 
            this.lbTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTip.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTip.Location = new System.Drawing.Point(12, 80);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(348, 55);
            this.lbTip.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.txtH);
            this.panel1.Controls.Add(this.txtW);
            this.panel1.Controls.Add(this.lbCrash);
            this.panel1.Controls.Add(this.lbTip);
            this.panel1.Controls.Add(this.lbH);
            this.panel1.Controls.Add(this.lbW);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 143);
            this.panel1.TabIndex = 36;
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btnClose);
            this.roundCornerControl2.Location = new System.Drawing.Point(285, 45);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 3;
            this.roundCornerControl2.Size = new System.Drawing.Size(76, 26);
            this.roundCornerControl2.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(89)))), ((int)(((byte)(106)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(-1, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btnResize);
            this.roundCornerControl1.Location = new System.Drawing.Point(207, 45);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(76, 26);
            this.roundCornerControl1.TabIndex = 38;
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnResize.FlatAppearance.BorderSize = 0;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnResize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnResize.Location = new System.Drawing.Point(-1, -1);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(77, 27);
            this.btnResize.TabIndex = 5;
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtH
            // 
            this.txtH.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtH.Location = new System.Drawing.Point(74, 46);
            this.txtH.MaxLength = 8;
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(105, 23);
            this.txtH.TabIndex = 3;
            this.txtH.Text = "720";
            this.txtH.TextChanged += new System.EventHandler(this.txtW_TextChanged);
            this.txtH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // txtW
            // 
            this.txtW.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtW.Location = new System.Drawing.Point(74, 18);
            this.txtW.MaxLength = 8;
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(105, 23);
            this.txtW.TabIndex = 1;
            this.txtW.Text = "1280";
            this.txtW.TextChanged += new System.EventHandler(this.txtW_TextChanged);
            this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // lbCrash
            // 
            this.lbCrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCrash.AutoSize = true;
            this.lbCrash.BackColor = System.Drawing.Color.Transparent;
            this.lbCrash.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbCrash.ForeColor = System.Drawing.Color.Firebrick;
            this.lbCrash.Location = new System.Drawing.Point(241, 20);
            this.lbCrash.Name = "lbCrash";
            this.lbCrash.Size = new System.Drawing.Size(0, 15);
            this.lbCrash.TabIndex = 37;
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(372, 143);
            this.Controls.Add(this.panel1);
            this.Name = "ResizeForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "1";
            this.Load += new System.EventHandler(this.ResizeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl2.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbW;
        private System.Windows.Forms.Label lbH;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCrash;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
    }
}