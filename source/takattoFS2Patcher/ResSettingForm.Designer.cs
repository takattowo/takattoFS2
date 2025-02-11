
namespace takattoFS2
{
    partial class ResSettingForm
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
            this.btn_dlc1_red = new System.Windows.Forms.Button();
            this.lb_langhintwhy = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtW = new System.Windows.Forms.TextBox();
            this.cbGameGraphic = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UseThisOrRadbtn = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_dlc1_red
            // 
            this.btn_dlc1_red.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dlc1_red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btn_dlc1_red.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_dlc1_red.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_dlc1_red.FlatAppearance.BorderSize = 0;
            this.btn_dlc1_red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dlc1_red.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_dlc1_red.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_dlc1_red.Location = new System.Drawing.Point(305, 109);
            this.btn_dlc1_red.Name = "btn_dlc1_red";
            this.btn_dlc1_red.Size = new System.Drawing.Size(75, 25);
            this.btn_dlc1_red.TabIndex = 6;
            this.btn_dlc1_red.Text = "Confirm";
            this.btn_dlc1_red.UseVisualStyleBackColor = false;
            this.btn_dlc1_red.Click += new System.EventHandler(this.btn_dlc1_red_Click);
            // 
            // lb_langhintwhy
            // 
            this.lb_langhintwhy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_langhintwhy.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lb_langhintwhy.Location = new System.Drawing.Point(12, 80);
            this.lb_langhintwhy.Name = "lb_langhintwhy";
            this.lb_langhintwhy.Size = new System.Drawing.Size(287, 58);
            this.lb_langhintwhy.TabIndex = 34;
            this.lb_langhintwhy.Text = "Game settings will be overwritten at launch and will reset if you make changes in" +
    " game setting.";
            // 
            // txtH
            // 
            this.txtH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtH.Location = new System.Drawing.Point(74, 46);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(105, 20);
            this.txtH.TabIndex = 2;
            this.txtH.Text = "720";
            this.txtH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // txtW
            // 
            this.txtW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtW.Location = new System.Drawing.Point(74, 18);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(105, 20);
            this.txtW.TabIndex = 1;
            this.txtW.Text = "1280";
            this.txtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtW_KeyPress);
            // 
            // cbGameGraphic
            // 
            this.cbGameGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGameGraphic.BackColor = System.Drawing.Color.White;
            this.cbGameGraphic.DisplayMember = "1";
            this.cbGameGraphic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameGraphic.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbGameGraphic.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbGameGraphic.FormattingEnabled = true;
            this.cbGameGraphic.Items.AddRange(new object[] {
            "HIGH",
            "MEDIUM",
            "LOW"});
            this.cbGameGraphic.Location = new System.Drawing.Point(275, 17);
            this.cbGameGraphic.Name = "cbGameGraphic";
            this.cbGameGraphic.Size = new System.Drawing.Size(105, 23);
            this.cbGameGraphic.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label3.Location = new System.Drawing.Point(206, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "Graphic:";
            // 
            // UseThisOrRadbtn
            // 
            this.UseThisOrRadbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseThisOrRadbtn.AutoCheck = false;
            this.UseThisOrRadbtn.AutoSize = true;
            this.UseThisOrRadbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.UseThisOrRadbtn.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.UseThisOrRadbtn.ForeColor = System.Drawing.Color.Firebrick;
            this.UseThisOrRadbtn.Location = new System.Drawing.Point(235, 47);
            this.UseThisOrRadbtn.Name = "UseThisOrRadbtn";
            this.UseThisOrRadbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UseThisOrRadbtn.Size = new System.Drawing.Size(145, 19);
            this.UseThisOrRadbtn.TabIndex = 4;
            this.UseThisOrRadbtn.Text = "?Use this setting";
            this.UseThisOrRadbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UseThisOrRadbtn.UseVisualStyleBackColor = true;
            this.UseThisOrRadbtn.Click += new System.EventHandler(this.btnUseThis_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(89)))), ((int)(((byte)(106)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(305, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UseThisOrRadbtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbGameGraphic);
            this.panel1.Controls.Add(this.txtH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtW);
            this.panel1.Controls.Add(this.btn_dlc1_red);
            this.panel1.Controls.Add(this.lb_langhintwhy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 143);
            this.panel1.TabIndex = 41;
            // 
            // ResSettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(392, 143);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "ResSettingForm";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.ResSettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_dlc1_red;
        private System.Windows.Forms.Label lb_langhintwhy;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.ComboBox cbGameGraphic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox UseThisOrRadbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}