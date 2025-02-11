
namespace takattoFS2.Forms
{
    partial class LanguageForm
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
            this.cbGameLanguage = new System.Windows.Forms.ComboBox();
            this.lb_langhint = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.lb_langhintwhy = new System.Windows.Forms.Label();
            this.nicetry = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbGameLanguage
            // 
            this.cbGameLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGameLanguage.BackColor = System.Drawing.Color.White;
            this.cbGameLanguage.DisplayMember = "1";
            this.cbGameLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGameLanguage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbGameLanguage.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbGameLanguage.FormattingEnabled = true;
            this.cbGameLanguage.Items.AddRange(new object[] {
            "ENGLISH",
            "GERMAN",
            "FRENCH",
            "THAI",
            "中國人",
            "日本語",
            "한국어"});
            this.cbGameLanguage.Location = new System.Drawing.Point(244, 12);
            this.cbGameLanguage.Name = "cbGameLanguage";
            this.cbGameLanguage.Size = new System.Drawing.Size(136, 25);
            this.cbGameLanguage.TabIndex = 0;
            this.cbGameLanguage.DropDownClosed += new System.EventHandler(this.cbGameLanguage_DropDownClosed);
            // 
            // lb_langhint
            // 
            this.lb_langhint.AutoSize = true;
            this.lb_langhint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lb_langhint.Location = new System.Drawing.Point(12, 13);
            this.lb_langhint.Name = "lb_langhint";
            this.lb_langhint.Size = new System.Drawing.Size(226, 20);
            this.lb_langhint.TabIndex = 15;
            this.lb_langhint.Text = "Choose your game language:";
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btn_confirm.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btn_confirm.FlatAppearance.BorderSize = 0;
            this.btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirm.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_confirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_confirm.Location = new System.Drawing.Point(-1, -1);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(93, 27);
            this.btn_confirm.TabIndex = 1;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_dlc1_red_Click);
            // 
            // lb_langhintwhy
            // 
            this.lb_langhintwhy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_langhintwhy.AutoEllipsis = true;
            this.lb_langhintwhy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lb_langhintwhy.Location = new System.Drawing.Point(12, 63);
            this.lb_langhintwhy.Name = "lb_langhintwhy";
            this.lb_langhintwhy.Size = new System.Drawing.Size(271, 36);
            this.lb_langhintwhy.TabIndex = 32;
            this.lb_langhintwhy.Text = "Your game language is needed for some tweaks to work correctly~";
            // 
            // nicetry
            // 
            this.nicetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nicetry.AutoSize = true;
            this.nicetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nicetry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nicetry.Location = new System.Drawing.Point(231, 42);
            this.nicetry.Name = "nicetry";
            this.nicetry.Size = new System.Drawing.Size(153, 17);
            this.nicetry.TabIndex = 33;
            this.nicetry.Text = "Caught an exception :d";
            this.nicetry.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nicetry);
            this.panel1.Controls.Add(this.cbGameLanguage);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.lb_langhintwhy);
            this.panel1.Controls.Add(this.lb_langhint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 108);
            this.panel1.TabIndex = 34;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btn_confirm);
            this.roundCornerControl1.Location = new System.Drawing.Point(289, 71);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(92, 26);
            this.roundCornerControl1.TabIndex = 34;
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(392, 108);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "LanguageForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lan";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameLanguageChangerForm_FormClosing);
            this.Load += new System.EventHandler(this.GameLanguageChangerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGameLanguage;
        private System.Windows.Forms.Label lb_langhint;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label lb_langhintwhy;
        private System.Windows.Forms.Label nicetry;
        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
    }
}