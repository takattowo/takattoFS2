
namespace takattoFS2
{
    partial class SweetLoveLetterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SweetLoveLetterForm));
            this.pBG = new System.Windows.Forms.PictureBox();
            this.pChar1 = new System.Windows.Forms.PictureBox();
            this.pChar2 = new System.Windows.Forms.PictureBox();
            this.pChar3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar3)).BeginInit();
            this.SuspendLayout();
            // 
            // pBG
            // 
            this.pBG.BackColor = System.Drawing.Color.Transparent;
            this.pBG.Image = ((System.Drawing.Image)(resources.GetObject("pBG.Image")));
            this.pBG.Location = new System.Drawing.Point(11, 104);
            this.pBG.Name = "pBG";
            this.pBG.Size = new System.Drawing.Size(929, 467);
            this.pBG.TabIndex = 0;
            this.pBG.TabStop = false;
            // 
            // pChar1
            // 
            this.pChar1.BackColor = System.Drawing.Color.Transparent;
            this.pChar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pChar1.Image = ((System.Drawing.Image)(resources.GetObject("pChar1.Image")));
            this.pChar1.Location = new System.Drawing.Point(75, 192);
            this.pChar1.Name = "pChar1";
            this.pChar1.Size = new System.Drawing.Size(137, 380);
            this.pChar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pChar1.TabIndex = 1;
            this.pChar1.TabStop = false;
            // 
            // pChar2
            // 
            this.pChar2.BackColor = System.Drawing.Color.Transparent;
            this.pChar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pChar2.Image = ((System.Drawing.Image)(resources.GetObject("pChar2.Image")));
            this.pChar2.Location = new System.Drawing.Point(397, 161);
            this.pChar2.Name = "pChar2";
            this.pChar2.Size = new System.Drawing.Size(152, 410);
            this.pChar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pChar2.TabIndex = 2;
            this.pChar2.TabStop = false;
            // 
            // pChar3
            // 
            this.pChar3.BackColor = System.Drawing.Color.Transparent;
            this.pChar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pChar3.Image = ((System.Drawing.Image)(resources.GetObject("pChar3.Image")));
            this.pChar3.Location = new System.Drawing.Point(674, 165);
            this.pChar3.Name = "pChar3";
            this.pChar3.Size = new System.Drawing.Size(217, 406);
            this.pChar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pChar3.TabIndex = 3;
            this.pChar3.TabStop = false;
            // 
            // SweetLoveLetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(951, 690);
            this.Controls.Add(this.pChar3);
            this.Controls.Add(this.pChar2);
            this.Controls.Add(this.pChar1);
            this.Controls.Add(this.pBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SweetLoveLetterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SweetLoveLetterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pChar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBG;
        private System.Windows.Forms.PictureBox pChar1;
        private System.Windows.Forms.PictureBox pChar2;
        private System.Windows.Forms.PictureBox pChar3;
    }
}