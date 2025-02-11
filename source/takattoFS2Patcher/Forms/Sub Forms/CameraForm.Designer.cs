
namespace takattoFS2.Forms.Sub_Forms
{
    partial class CameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHolder = new System.Windows.Forms.TextBox();
            this.roundCornerControl2 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnc1 = new System.Windows.Forms.Button();
            this.roundCornerControl6 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnc = new System.Windows.Forms.Button();
            this.btnParameter = new System.Windows.Forms.Button();
            this.panelEx5 = new takattoFS2.Controls.UserControls.PanelEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdOverride = new System.Windows.Forms.Label();
            this.cbOverride = new System.Windows.Forms.ComboBox();
            this.panelEx4 = new takattoFS2.Controls.UserControls.PanelEx();
            this.panelEx2 = new System.Windows.Forms.Panel();
            this.txtHiliFOV = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbHiFOV = new System.Windows.Forms.Label();
            this.txtLookSpeed = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbLookVelo = new System.Windows.Forms.Label();
            this.txtVeloSpeed = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbMoveVelo = new System.Windows.Forms.Label();
            this.lbCam_hint = new System.Windows.Forms.Label();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3Delay = new System.Windows.Forms.Timer(this.components);
            this.contextReset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.r1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.r2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToVisibleOverride = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.roundCornerControl2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.roundCornerControl6.SuspendLayout();
            this.panelEx5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.contextReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.txtHolder);
            this.panel1.Controls.Add(this.roundCornerControl2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.roundCornerControl6);
            this.panel1.Controls.Add(this.btnParameter);
            this.panel1.Controls.Add(this.panelEx5);
            this.panel1.Controls.Add(this.panelEx4);
            this.panel1.Controls.Add(this.lbCam_hint);
            this.panel1.Controls.Add(this.cbCamera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 518);
            this.panel1.TabIndex = 42;
            // 
            // txtHolder
            // 
            this.txtHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHolder.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtHolder.Location = new System.Drawing.Point(0, 40);
            this.txtHolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHolder.Name = "txtHolder";
            this.txtHolder.Size = new System.Drawing.Size(306, 30);
            this.txtHolder.TabIndex = 71;
            this.txtHolder.Text = " - - -";
            // 
            // roundCornerControl2
            // 
            this.roundCornerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl2.Controls.Add(this.btnSave);
            this.roundCornerControl2.Location = new System.Drawing.Point(201, 1);
            this.roundCornerControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roundCornerControl2.Name = "roundCornerControl2";
            this.roundCornerControl2.Radius = 3;
            this.roundCornerControl2.Size = new System.Drawing.Size(108, 32);
            this.roundCornerControl2.TabIndex = 70;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(-1, -1);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExpand);
            this.flowLayoutPanel1.Controls.Add(this.btnReset);
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Controls.Add(this.btnImport);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 76);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(188, 36);
            this.flowLayoutPanel1.TabIndex = 69;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.Transparent;
            this.btnExpand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpand.BackgroundImage")));
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.ForeColor = System.Drawing.Color.White;
            this.btnExpand.Location = new System.Drawing.Point(0, 0);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(36, 36);
            this.btnExpand.TabIndex = 6;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(36, 0);
            this.btnReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(36, 36);
            this.btnReset.TabIndex = 7;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExport.BackgroundImage")));
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(72, 0);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(36, 36);
            this.btnExport.TabIndex = 8;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(108, 0);
            this.btnImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(36, 36);
            this.btnImport.TabIndex = 9;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.BackgroundImage")));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(231, 76);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(36, 36);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.BackColor = System.Drawing.Color.Transparent;
            this.roundCornerControl1.Controls.Add(this.btnc1);
            this.roundCornerControl1.Location = new System.Drawing.Point(14, 376);
            this.roundCornerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(279, 32);
            this.roundCornerControl1.TabIndex = 68;
            this.roundCornerControl1.Visible = false;
            // 
            // btnc1
            // 
            this.btnc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnc1.BackColor = System.Drawing.Color.Crimson;
            this.btnc1.FlatAppearance.BorderSize = 0;
            this.btnc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnc1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnc1.Location = new System.Drawing.Point(-1, -1);
            this.btnc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnc1.Name = "btnc1";
            this.btnc1.Size = new System.Drawing.Size(280, 34);
            this.btnc1.TabIndex = 0;
            this.btnc1.UseVisualStyleBackColor = false;
            // 
            // roundCornerControl6
            // 
            this.roundCornerControl6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl6.BackColor = System.Drawing.Color.Transparent;
            this.roundCornerControl6.Controls.Add(this.btnc);
            this.roundCornerControl6.Location = new System.Drawing.Point(14, 336);
            this.roundCornerControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roundCornerControl6.Name = "roundCornerControl6";
            this.roundCornerControl6.Radius = 3;
            this.roundCornerControl6.Size = new System.Drawing.Size(279, 32);
            this.roundCornerControl6.TabIndex = 67;
            this.roundCornerControl6.Visible = false;
            // 
            // btnc
            // 
            this.btnc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnc.BackColor = System.Drawing.Color.SteelBlue;
            this.btnc.FlatAppearance.BorderSize = 0;
            this.btnc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnc.Location = new System.Drawing.Point(-1, -1);
            this.btnc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnc.Name = "btnc";
            this.btnc.Size = new System.Drawing.Size(280, 34);
            this.btnc.TabIndex = 0;
            this.btnc.UseVisualStyleBackColor = false;
            this.btnc.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnParameter
            // 
            this.btnParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParameter.BackColor = System.Drawing.Color.Transparent;
            this.btnParameter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnParameter.BackgroundImage")));
            this.btnParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParameter.FlatAppearance.BorderSize = 0;
            this.btnParameter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParameter.ForeColor = System.Drawing.Color.White;
            this.btnParameter.Location = new System.Drawing.Point(271, 76);
            this.btnParameter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnParameter.Name = "btnParameter";
            this.btnParameter.Size = new System.Drawing.Size(36, 36);
            this.btnParameter.TabIndex = 11;
            this.btnParameter.UseVisualStyleBackColor = false;
            this.btnParameter.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // panelEx5
            // 
            this.panelEx5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx5.BackColor = System.Drawing.Color.White;
            this.panelEx5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx5.Controls.Add(this.panel2);
            this.panelEx5.Location = new System.Drawing.Point(0, 242);
            this.panelEx5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx5.Size = new System.Drawing.Size(308, 85);
            this.panelEx5.TabIndex = 56;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.rdOverride);
            this.panel2.Controls.Add(this.cbOverride);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 83);
            this.panel2.TabIndex = 52;
            // 
            // rdOverride
            // 
            this.rdOverride.AutoSize = true;
            this.rdOverride.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdOverride.Location = new System.Drawing.Point(11, 9);
            this.rdOverride.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rdOverride.Name = "rdOverride";
            this.rdOverride.Size = new System.Drawing.Size(0, 20);
            this.rdOverride.TabIndex = 81;
            // 
            // cbOverride
            // 
            this.cbOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOverride.AutoCompleteCustomSource.AddRange(new string[] {
            "NONE"});
            this.cbOverride.BackColor = System.Drawing.Color.White;
            this.cbOverride.DisplayMember = "1";
            this.cbOverride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOverride.Enabled = false;
            this.cbOverride.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cbOverride.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbOverride.FormattingEnabled = true;
            this.cbOverride.Items.AddRange(new object[] {
            "NONE"});
            this.cbOverride.Location = new System.Drawing.Point(14, 41);
            this.cbOverride.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbOverride.Name = "cbOverride";
            this.cbOverride.Size = new System.Drawing.Size(277, 27);
            this.cbOverride.TabIndex = 5;
            this.cbOverride.Visible = false;
            this.cbOverride.SelectedIndexChanged += new System.EventHandler(this.cbOverride_SelectedIndexChanged_1);
            this.cbOverride.DropDownClosed += new System.EventHandler(this.cbOverride_DropDownClosed);
            // 
            // panelEx4
            // 
            this.panelEx4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx4.BackColor = System.Drawing.Color.White;
            this.panelEx4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx4.Controls.Add(this.panelEx2);
            this.panelEx4.Location = new System.Drawing.Point(0, 120);
            this.panelEx4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx4.Size = new System.Drawing.Size(308, 119);
            this.panelEx4.TabIndex = 55;
            // 
            // panelEx2
            // 
            this.panelEx2.BackColor = System.Drawing.Color.White;
            this.panelEx2.Controls.Add(this.txtHiliFOV);
            this.panelEx2.Controls.Add(this.lbHiFOV);
            this.panelEx2.Controls.Add(this.txtLookSpeed);
            this.panelEx2.Controls.Add(this.lbLookVelo);
            this.panelEx2.Controls.Add(this.txtVeloSpeed);
            this.panelEx2.Controls.Add(this.lbMoveVelo);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(1, 1);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(306, 117);
            this.panelEx2.TabIndex = 52;
            // 
            // txtHiliFOV
            // 
            this.txtHiliFOV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHiliFOV.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtHiliFOV.ForeColor = System.Drawing.Color.Gray;
            this.txtHiliFOV.Location = new System.Drawing.Point(162, 76);
            this.txtHiliFOV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHiliFOV.MaxLength = 12;
            this.txtHiliFOV.Name = "txtHiliFOV";
            this.txtHiliFOV.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtHiliFOV.PlaceHolderText = "                                                                              ";
            this.txtHiliFOV.Size = new System.Drawing.Size(129, 27);
            this.txtHiliFOV.TabIndex = 4;
            this.txtHiliFOV.Text = "  ";
            this.txtHiliFOV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVeloSpeed_KeyPress);
            this.txtHiliFOV.Leave += new System.EventHandler(this.txtHiliFOV_Leave);
            // 
            // lbHiFOV
            // 
            this.lbHiFOV.AutoSize = true;
            this.lbHiFOV.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbHiFOV.Location = new System.Drawing.Point(10, 80);
            this.lbHiFOV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHiFOV.Name = "lbHiFOV";
            this.lbHiFOV.Size = new System.Drawing.Size(0, 20);
            this.lbHiFOV.TabIndex = 80;
            // 
            // txtLookSpeed
            // 
            this.txtLookSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookSpeed.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLookSpeed.ForeColor = System.Drawing.Color.Gray;
            this.txtLookSpeed.Location = new System.Drawing.Point(162, 42);
            this.txtLookSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLookSpeed.MaxLength = 12;
            this.txtLookSpeed.Name = "txtLookSpeed";
            this.txtLookSpeed.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtLookSpeed.PlaceHolderText = "                                                                              ";
            this.txtLookSpeed.Size = new System.Drawing.Size(129, 27);
            this.txtLookSpeed.TabIndex = 3;
            this.txtLookSpeed.Text = "  ";
            this.txtLookSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVeloSpeed_KeyPress);
            this.txtLookSpeed.Leave += new System.EventHandler(this.txtLookSpeed_Leave);
            // 
            // lbLookVelo
            // 
            this.lbLookVelo.AutoSize = true;
            this.lbLookVelo.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbLookVelo.Location = new System.Drawing.Point(10, 46);
            this.lbLookVelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLookVelo.Name = "lbLookVelo";
            this.lbLookVelo.Size = new System.Drawing.Size(0, 20);
            this.lbLookVelo.TabIndex = 78;
            // 
            // txtVeloSpeed
            // 
            this.txtVeloSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVeloSpeed.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtVeloSpeed.ForeColor = System.Drawing.Color.Gray;
            this.txtVeloSpeed.Location = new System.Drawing.Point(162, 9);
            this.txtVeloSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVeloSpeed.MaxLength = 12;
            this.txtVeloSpeed.Name = "txtVeloSpeed";
            this.txtVeloSpeed.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtVeloSpeed.PlaceHolderText = "                                                                              ";
            this.txtVeloSpeed.Size = new System.Drawing.Size(129, 27);
            this.txtVeloSpeed.TabIndex = 2;
            this.txtVeloSpeed.Text = "  ";
            this.txtVeloSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVeloSpeed_KeyPress);
            this.txtVeloSpeed.Leave += new System.EventHandler(this.txtVeloSpeed_Leave);
            // 
            // lbMoveVelo
            // 
            this.lbMoveVelo.AutoSize = true;
            this.lbMoveVelo.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbMoveVelo.Location = new System.Drawing.Point(10, 12);
            this.lbMoveVelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMoveVelo.Name = "lbMoveVelo";
            this.lbMoveVelo.Size = new System.Drawing.Size(0, 20);
            this.lbMoveVelo.TabIndex = 77;
            // 
            // lbCam_hint
            // 
            this.lbCam_hint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCam_hint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbCam_hint.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbCam_hint.Location = new System.Drawing.Point(9, 6);
            this.lbCam_hint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCam_hint.Name = "lbCam_hint";
            this.lbCam_hint.Size = new System.Drawing.Size(189, 26);
            this.lbCam_hint.TabIndex = 46;
            this.lbCam_hint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbCamera
            // 
            this.cbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Font = new System.Drawing.Font("Gadugi", 10F);
            this.cbCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.ItemHeight = 20;
            this.cbCamera.Location = new System.Drawing.Point(0, 40);
            this.cbCamera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(306, 28);
            this.cbCamera.TabIndex = 1;
            this.cbCamera.Visible = false;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbGameGraphic_SelectedIndexChanged);
            this.cbCamera.DropDownClosed += new System.EventHandler(this.cbGameGraphic_DropDownClosed);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3Delay
            // 
            this.timer3Delay.Tick += new System.EventHandler(this.timer3Delay_Tick);
            // 
            // contextReset
            // 
            this.contextReset.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contextReset.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextReset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.r1ToolStripMenuItem,
            this.r2ToolStripMenuItem});
            this.contextReset.Name = "contextLauncher";
            this.contextReset.Size = new System.Drawing.Size(70, 48);
            this.contextReset.Opening += new System.ComponentModel.CancelEventHandler(this.contextReset_Opening);
            // 
            // r1ToolStripMenuItem
            // 
            this.r1ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.r1ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.r1ToolStripMenuItem.Name = "r1ToolStripMenuItem";
            this.r1ToolStripMenuItem.Size = new System.Drawing.Size(69, 22);
            this.r1ToolStripMenuItem.Click += new System.EventHandler(this.r1ToolStripMenuItem_Click);
            // 
            // r2ToolStripMenuItem
            // 
            this.r2ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.r2ToolStripMenuItem.Name = "r2ToolStripMenuItem";
            this.r2ToolStripMenuItem.Size = new System.Drawing.Size(69, 22);
            this.r2ToolStripMenuItem.Click += new System.EventHandler(this.r2ToolStripMenuItem_Click);
            // 
            // timerToVisibleOverride
            // 
            this.timerToVisibleOverride.Interval = 10;
            this.timerToVisibleOverride.Tick += new System.EventHandler(this.timerToVisibleOverride_Tick);
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(308, 518);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CameraForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.roundCornerControl1.ResumeLayout(false);
            this.roundCornerControl6.ResumeLayout(false);
            this.panelEx5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelEx4.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.contextReset.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCam_hint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3Delay;
        private System.Windows.Forms.ComboBox cbCamera;
        private Controls.UserControls.PanelEx panelEx4;
        private System.Windows.Forms.Panel panelEx2;
        private System.Windows.Forms.ComboBox cbOverride;
        private System.Windows.Forms.Button btnParameter;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ContextMenuStrip contextReset;
        private System.Windows.Forms.ToolStripMenuItem r1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem r2ToolStripMenuItem;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.Button btnc1;
        private System.Windows.Forms.Button btnHelp;
        private Controls.UserControls.TextBoxEx txtLookSpeed;
        private System.Windows.Forms.Label lbLookVelo;
        private Controls.UserControls.TextBoxEx txtVeloSpeed;
        private System.Windows.Forms.Label lbMoveVelo;
        private Controls.UserControls.TextBoxEx txtHiliFOV;
        private System.Windows.Forms.Label lbHiFOV;
        private Controls.UserControls.RoundCornerControl roundCornerControl6;
        private System.Windows.Forms.Button btnc;
        private Controls.UserControls.PanelEx panelEx5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Timer timerToVisibleOverride;
        private System.Windows.Forms.Label rdOverride;
        private Controls.UserControls.RoundCornerControl roundCornerControl2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHolder;
    }
}