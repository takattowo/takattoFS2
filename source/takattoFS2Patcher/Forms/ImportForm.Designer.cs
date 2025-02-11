
namespace takattoFS2.Forms
{
    partial class ImportForm
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
            this.lbHint = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnImport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHint
            // 
            this.lbHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHint.BackColor = System.Drawing.Color.Transparent;
            this.lbHint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbHint.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbHint.Location = new System.Drawing.Point(-42, 16);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(370, 21);
            this.lbHint.TabIndex = 37;
            this.lbHint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbURL
            // 
            this.tbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbURL.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.tbURL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbURL.Location = new System.Drawing.Point(12, 38);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(314, 23);
            this.tbURL.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.tbURL);
            this.panel1.Controls.Add(this.lbHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 106);
            this.panel1.TabIndex = 38;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btnImport);
            this.roundCornerControl1.Location = new System.Drawing.Point(254, 71);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(73, 26);
            this.roundCornerControl1.TabIndex = 38;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnImport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImport.Location = new System.Drawing.Point(-1, -1);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(74, 27);
            this.btnImport.TabIndex = 1;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 106);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "ImportForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "i";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
    }
}