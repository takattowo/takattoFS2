
using takattoFS2.Controls.UserControls;

namespace takattoFS2.Forms.Sub_Forms
{
    partial class InstalledPatchesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomInterfaceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnWarning = new System.Windows.Forms.Button();
            this.panelEx2 = new takattoFS2.Controls.UserControls.PanelEx();
            this.lbNoItemExist = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCre = new System.Windows.Forms.Button();
            this.txtCommand = new takattoFS2.Controls.UserControls.TextBoxPwEx();
            this.lbUIs = new takattoFS2.Controls.UserControls.ListBoxEx();
            this.lbUIHint = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.refreshListBox = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Controls.Add(this.lbUIHint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 330);
            this.panel1.TabIndex = 42;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnWarning);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(179, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(67, 23);
            this.flowLayoutPanel1.TabIndex = 55;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(44, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnWarning
            // 
            this.btnWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarning.BackColor = System.Drawing.Color.Transparent;
            this.btnWarning.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWarning.BackgroundImage")));
            this.btnWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWarning.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnWarning.FlatAppearance.BorderSize = 0;
            this.btnWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarning.ForeColor = System.Drawing.Color.White;
            this.btnWarning.Location = new System.Drawing.Point(14, 0);
            this.btnWarning.Margin = new System.Windows.Forms.Padding(0);
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.Size = new System.Drawing.Size(23, 23);
            this.btnWarning.TabIndex = 2;
            this.btnWarning.UseVisualStyleBackColor = false;
            this.btnWarning.Visible = false;
            this.btnWarning.Click += new System.EventHandler(this.btnWarning_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx2.BorderColor = System.Drawing.Color.Transparent;
            this.panelEx2.Controls.Add(this.lbNoItemExist);
            this.panelEx2.Controls.Add(this.panel2);
            this.panelEx2.Controls.Add(this.lbUIs);
            this.panelEx2.Location = new System.Drawing.Point(0, 32);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(253, 298);
            this.panelEx2.TabIndex = 53;
            // 
            // lbNoItemExist
            // 
            this.lbNoItemExist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNoItemExist.BackColor = System.Drawing.Color.White;
            this.lbNoItemExist.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lbNoItemExist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lbNoItemExist.Location = new System.Drawing.Point(22, 83);
            this.lbNoItemExist.Name = "lbNoItemExist";
            this.lbNoItemExist.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lbNoItemExist.Size = new System.Drawing.Size(191, 141);
            this.lbNoItemExist.TabIndex = 57;
            this.lbNoItemExist.Text = "lb";
            this.lbNoItemExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNoItemExist.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCre);
            this.panel2.Controls.Add(this.txtCommand);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 31);
            this.panel2.TabIndex = 56;
            // 
            // btnCre
            // 
            this.btnCre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.btnCre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCre.BackgroundImage")));
            this.btnCre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCre.Enabled = false;
            this.btnCre.FlatAppearance.BorderSize = 0;
            this.btnCre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCre.Location = new System.Drawing.Point(224, 3);
            this.btnCre.Name = "btnCre";
            this.btnCre.Size = new System.Drawing.Size(23, 23);
            this.btnCre.TabIndex = 5;
            this.btnCre.UseVisualStyleBackColor = false;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txtCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtCommand.ForeColor = System.Drawing.Color.Gray;
            this.txtCommand.IsPassword = false;
            this.txtCommand.Location = new System.Drawing.Point(7, 7);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtCommand.PlaceHolderText = "";
            this.txtCommand.Size = new System.Drawing.Size(212, 16);
            this.txtCommand.TabIndex = 4;
            // 
            // lbUIs
            // 
            this.lbUIs.BackColor = System.Drawing.Color.White;
            this.lbUIs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUIs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbUIs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbUIs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lbUIs.Items.AddRange(new object[] {
            "Fetching..."});
            this.lbUIs.Location = new System.Drawing.Point(1, 1);
            this.lbUIs.Name = "lbUIs";
            this.lbUIs.ScrollAlwaysVisible = true;
            this.lbUIs.Size = new System.Drawing.Size(251, 260);
            this.lbUIs.TabIndex = 0;
            this.lbUIs.SelectedIndexChanged += new System.EventHandler(this.lbExtensions_SelectedIndexChanged);
            // 
            // lbUIHint
            // 
            this.lbUIHint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbUIHint.ForeColor = System.Drawing.Color.Teal;
            this.lbUIHint.Location = new System.Drawing.Point(0, 6);
            this.lbUIHint.Name = "lbUIHint";
            this.lbUIHint.Size = new System.Drawing.Size(269, 23);
            this.lbUIHint.TabIndex = 44;
            // 
            // refreshListBox
            // 
            this.refreshListBox.Enabled = true;
            this.refreshListBox.Interval = 1100;
            this.refreshListBox.Tick += new System.EventHandler(this.refreshListBox_Tick);
            // 
            // CustomInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(253, 330);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomInterfaceForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbUIHint;
        public Controls.UserControls.ListBoxEx lbUIs;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Timer refreshListBox;
        private PanelEx panelEx2;
        private System.Windows.Forms.Button btnWarning;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCre;
        private TextBoxPwEx txtCommand;
        private System.Windows.Forms.Label lbNoItemExist;
    }
}