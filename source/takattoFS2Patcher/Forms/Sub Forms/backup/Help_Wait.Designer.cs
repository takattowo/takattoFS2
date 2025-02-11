
namespace takattoFS2.Forms
{
    partial class Help_Wait
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 629;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lb
            // 
            this.lb.BackColor = System.Drawing.Color.Transparent;
            this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb.Image = global::takattoFS2.Properties.Resources.smolviocat;
            this.lb.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lb.Location = new System.Drawing.Point(0, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(411, 109);
            this.lb.TabIndex = 0;
            this.lb.Text = "Revivifying the game data.\r\nPlease wait for a while before launching the game aga" +
    "in!\r\n";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Help_Wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 109);
            this.Controls.Add(this.lb);
            this.Name = "Help_Wait";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UwU";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Help_Voice_Downloader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Timer timer2;
    }
}