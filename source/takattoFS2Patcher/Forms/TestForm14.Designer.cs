
namespace takattoFS2.Forms
{
    partial class TestForm14
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.outp = new System.Windows.Forms.TextBox();
            this.inp = new System.Windows.Forms.TextBox();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnb = new System.Windows.Forms.Button();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btna = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbW
            // 
            this.lbW.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbW.Location = new System.Drawing.Point(12, 20);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(58, 15);
            this.lbW.TabIndex = 0;
            this.lbW.Text = "From";
            this.lbW.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbH
            // 
            this.lbH.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbH.Location = new System.Drawing.Point(12, 48);
            this.lbH.Name = "lbH";
            this.lbH.Size = new System.Drawing.Size(58, 15);
            this.lbH.TabIndex = 2;
            this.lbH.Text = "To";
            this.lbH.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.outp);
            this.panel1.Controls.Add(this.inp);
            this.panel1.Controls.Add(this.lbH);
            this.panel1.Controls.Add(this.lbW);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 120);
            this.panel1.TabIndex = 36;
            // 
            // outp
            // 
            this.outp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outp.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.outp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.outp.Location = new System.Drawing.Point(74, 46);
            this.outp.Name = "outp";
            this.outp.Size = new System.Drawing.Size(286, 23);
            this.outp.TabIndex = 3;
            // 
            // inp
            // 
            this.inp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inp.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.inp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inp.Location = new System.Drawing.Point(74, 18);
            this.inp.Name = "inp";
            this.inp.Size = new System.Drawing.Size(286, 23);
            this.inp.TabIndex = 1;
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btnb);
            this.roundCornerControl2.Location = new System.Drawing.Point(239, 85);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 3;
            this.roundCornerControl2.Size = new System.Drawing.Size(122, 26);
            this.roundCornerControl2.TabIndex = 39;
            // 
            // btnb
            // 
            this.btnb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnb.BackColor = System.Drawing.Color.SteelBlue;
            this.btnb.FlatAppearance.BorderSize = 0;
            this.btnb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnb.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnb.Location = new System.Drawing.Point(-1, -1);
            this.btnb.Name = "btnb";
            this.btnb.Size = new System.Drawing.Size(123, 27);
            this.btnb.TabIndex = 6;
            this.btnb.Text = "Reverse bean it";
            this.btnb.UseVisualStyleBackColor = false;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btna);
            this.roundCornerControl1.Location = new System.Drawing.Point(113, 85);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(122, 26);
            this.roundCornerControl1.TabIndex = 38;
            // 
            // btna
            // 
            this.btna.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btna.FlatAppearance.BorderSize = 0;
            this.btna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btna.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btna.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btna.Location = new System.Drawing.Point(-1, -1);
            this.btna.Name = "btna";
            this.btna.Size = new System.Drawing.Size(123, 27);
            this.btna.TabIndex = 5;
            this.btna.Text = "Bean it";
            this.btna.UseVisualStyleBackColor = false;
            // 
            // TestForm14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(372, 120);
            this.Controls.Add(this.panel1);
            this.Name = "TestForm14";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bean maker [Test 14]";
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
        private System.Windows.Forms.Button btna;
        private System.Windows.Forms.Button btnb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox outp;
        private System.Windows.Forms.TextBox inp;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
    }
}