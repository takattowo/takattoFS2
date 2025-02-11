
namespace takattoFS2.Forms.Sub_Forms.Camera_Forms
{
    partial class Parameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parameter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btnAScript = new System.Windows.Forms.Button();
            this.rdAbsolte = new System.Windows.Forms.CheckBox();
            this.txtLookZ = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbLZ = new System.Windows.Forms.Label();
            this.rdIgnoreBall = new System.Windows.Forms.CheckBox();
            this.txtLookY = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbLY = new System.Windows.Forms.Label();
            this.txtLookX = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbLX = new System.Windows.Forms.Label();
            this.txtPosZ = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbPZ = new System.Windows.Forms.Label();
            this.txtPosY = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbPY = new System.Windows.Forms.Label();
            this.txtPosX = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbPX = new System.Windows.Forms.Label();
            this.txtFOV = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.lbFov = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.lbCam_hint = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbTweakHeader = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer22 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.rdAbsolte);
            this.panel1.Controls.Add(this.txtLookZ);
            this.panel1.Controls.Add(this.lbLZ);
            this.panel1.Controls.Add(this.rdIgnoreBall);
            this.panel1.Controls.Add(this.txtLookY);
            this.panel1.Controls.Add(this.lbLY);
            this.panel1.Controls.Add(this.txtLookX);
            this.panel1.Controls.Add(this.lbLX);
            this.panel1.Controls.Add(this.txtPosZ);
            this.panel1.Controls.Add(this.lbPZ);
            this.panel1.Controls.Add(this.txtPosY);
            this.panel1.Controls.Add(this.lbPY);
            this.panel1.Controls.Add(this.txtPosX);
            this.panel1.Controls.Add(this.lbPX);
            this.panel1.Controls.Add(this.txtFOV);
            this.panel1.Controls.Add(this.lbFov);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 314);
            this.panel1.TabIndex = 0;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.BackColor = System.Drawing.Color.Transparent;
            this.roundCornerControl1.Controls.Add(this.btnAScript);
            this.roundCornerControl1.Location = new System.Drawing.Point(13, 198);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(237, 26);
            this.roundCornerControl1.TabIndex = 69;
            // 
            // btnAScript
            // 
            this.btnAScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAScript.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAScript.FlatAppearance.BorderSize = 0;
            this.btnAScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAScript.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAScript.Location = new System.Drawing.Point(-1, -1);
            this.btnAScript.Name = "btnAScript";
            this.btnAScript.Size = new System.Drawing.Size(238, 27);
            this.btnAScript.TabIndex = 8;
            this.btnAScript.Text = "Advanced Script";
            this.btnAScript.UseVisualStyleBackColor = false;
            this.btnAScript.Click += new System.EventHandler(this.btnc1_Click);
            // 
            // rdAbsolte
            // 
            this.rdAbsolte.AutoCheck = false;
            this.rdAbsolte.AutoSize = true;
            this.rdAbsolte.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdAbsolte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.rdAbsolte.Location = new System.Drawing.Point(13, 257);
            this.rdAbsolte.Name = "rdAbsolte";
            this.rdAbsolte.Size = new System.Drawing.Size(138, 19);
            this.rdAbsolte.TabIndex = 10;
            this.rdAbsolte.Text = "Absolutely value";
            this.rdAbsolte.CheckedChanged += new System.EventHandler(this.rdAbsolte_CheckedChanged);
            this.rdAbsolte.Click += new System.EventHandler(this.rdAbsolte_Click);
            // 
            // txtLookZ
            // 
            this.txtLookZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookZ.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLookZ.ForeColor = System.Drawing.Color.Gray;
            this.txtLookZ.Location = new System.Drawing.Point(74, 165);
            this.txtLookZ.MaxLength = 12;
            this.txtLookZ.Name = "txtLookZ";
            this.txtLookZ.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtLookZ.PlaceHolderText = "                                                           ";
            this.txtLookZ.Size = new System.Drawing.Size(175, 23);
            this.txtLookZ.TabIndex = 7;
            this.txtLookZ.Text = "  ";
            this.txtLookZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtLookZ.Leave += new System.EventHandler(this.txtLookZ_Leave);
            // 
            // lbLZ
            // 
            this.lbLZ.AutoSize = true;
            this.lbLZ.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbLZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbLZ.Location = new System.Drawing.Point(10, 168);
            this.lbLZ.Name = "lbLZ";
            this.lbLZ.Size = new System.Drawing.Size(42, 15);
            this.lbLZ.TabIndex = 67;
            this.lbLZ.Text = "LookZ";
            // 
            // rdIgnoreBall
            // 
            this.rdIgnoreBall.AutoCheck = false;
            this.rdIgnoreBall.AutoSize = true;
            this.rdIgnoreBall.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.rdIgnoreBall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.rdIgnoreBall.Location = new System.Drawing.Point(13, 230);
            this.rdIgnoreBall.Name = "rdIgnoreBall";
            this.rdIgnoreBall.Size = new System.Drawing.Size(103, 19);
            this.rdIgnoreBall.TabIndex = 9;
            this.rdIgnoreBall.Text = "Ignore ball";
            this.rdIgnoreBall.Click += new System.EventHandler(this.rdIgnoreBall_Click);
            // 
            // txtLookY
            // 
            this.txtLookY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookY.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLookY.ForeColor = System.Drawing.Color.Gray;
            this.txtLookY.Location = new System.Drawing.Point(74, 138);
            this.txtLookY.MaxLength = 12;
            this.txtLookY.Name = "txtLookY";
            this.txtLookY.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtLookY.PlaceHolderText = "                                                           ";
            this.txtLookY.Size = new System.Drawing.Size(175, 23);
            this.txtLookY.TabIndex = 6;
            this.txtLookY.Text = "  ";
            this.txtLookY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtLookY.Leave += new System.EventHandler(this.txtLookY_Leave);
            // 
            // lbLY
            // 
            this.lbLY.AutoSize = true;
            this.lbLY.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbLY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbLY.Location = new System.Drawing.Point(10, 141);
            this.lbLY.Name = "lbLY";
            this.lbLY.Size = new System.Drawing.Size(42, 15);
            this.lbLY.TabIndex = 10;
            this.lbLY.Text = "LookY";
            // 
            // txtLookX
            // 
            this.txtLookX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookX.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLookX.ForeColor = System.Drawing.Color.Gray;
            this.txtLookX.Location = new System.Drawing.Point(74, 111);
            this.txtLookX.MaxLength = 12;
            this.txtLookX.Name = "txtLookX";
            this.txtLookX.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtLookX.PlaceHolderText = "                                                           ";
            this.txtLookX.Size = new System.Drawing.Size(175, 23);
            this.txtLookX.TabIndex = 5;
            this.txtLookX.Text = "  ";
            this.txtLookX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtLookX.Leave += new System.EventHandler(this.txtLookX_Leave);
            // 
            // lbLX
            // 
            this.lbLX.AutoSize = true;
            this.lbLX.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbLX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbLX.Location = new System.Drawing.Point(10, 114);
            this.lbLX.Name = "lbLX";
            this.lbLX.Size = new System.Drawing.Size(42, 15);
            this.lbLX.TabIndex = 8;
            this.lbLX.Text = "LookX";
            // 
            // txtPosZ
            // 
            this.txtPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosZ.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtPosZ.ForeColor = System.Drawing.Color.Gray;
            this.txtPosZ.Location = new System.Drawing.Point(74, 84);
            this.txtPosZ.MaxLength = 12;
            this.txtPosZ.Name = "txtPosZ";
            this.txtPosZ.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtPosZ.PlaceHolderText = "                                                           ";
            this.txtPosZ.Size = new System.Drawing.Size(175, 23);
            this.txtPosZ.TabIndex = 4;
            this.txtPosZ.Text = "  ";
            this.txtPosZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtPosZ.Leave += new System.EventHandler(this.txtPosZ_Leave);
            // 
            // lbPZ
            // 
            this.lbPZ.AutoSize = true;
            this.lbPZ.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbPZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbPZ.Location = new System.Drawing.Point(10, 87);
            this.lbPZ.Name = "lbPZ";
            this.lbPZ.Size = new System.Drawing.Size(35, 15);
            this.lbPZ.TabIndex = 6;
            this.lbPZ.Text = "PosZ";
            // 
            // txtPosY
            // 
            this.txtPosY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosY.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtPosY.ForeColor = System.Drawing.Color.Gray;
            this.txtPosY.Location = new System.Drawing.Point(74, 57);
            this.txtPosY.MaxLength = 12;
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtPosY.PlaceHolderText = "                                                           ";
            this.txtPosY.Size = new System.Drawing.Size(175, 23);
            this.txtPosY.TabIndex = 3;
            this.txtPosY.Text = "  ";
            this.txtPosY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtPosY.Leave += new System.EventHandler(this.txtPosY_Leave);
            // 
            // lbPY
            // 
            this.lbPY.AutoSize = true;
            this.lbPY.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbPY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbPY.Location = new System.Drawing.Point(10, 60);
            this.lbPY.Name = "lbPY";
            this.lbPY.Size = new System.Drawing.Size(35, 15);
            this.lbPY.TabIndex = 4;
            this.lbPY.Text = "PosY";
            // 
            // txtPosX
            // 
            this.txtPosX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosX.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtPosX.ForeColor = System.Drawing.Color.Gray;
            this.txtPosX.Location = new System.Drawing.Point(74, 30);
            this.txtPosX.MaxLength = 12;
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtPosX.PlaceHolderText = "                                                           ";
            this.txtPosX.Size = new System.Drawing.Size(175, 23);
            this.txtPosX.TabIndex = 2;
            this.txtPosX.Text = "  ";
            this.txtPosX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtPosX.Leave += new System.EventHandler(this.txtPosX_Leave);
            // 
            // lbPX
            // 
            this.lbPX.AutoSize = true;
            this.lbPX.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbPX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbPX.Location = new System.Drawing.Point(10, 33);
            this.lbPX.Name = "lbPX";
            this.lbPX.Size = new System.Drawing.Size(35, 15);
            this.lbPX.TabIndex = 2;
            this.lbPX.Text = "PosX";
            // 
            // txtFOV
            // 
            this.txtFOV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFOV.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtFOV.ForeColor = System.Drawing.Color.Gray;
            this.txtFOV.Location = new System.Drawing.Point(74, 3);
            this.txtFOV.MaxLength = 12;
            this.txtFOV.Name = "txtFOV";
            this.txtFOV.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtFOV.PlaceHolderText = "                                                           ";
            this.txtFOV.Size = new System.Drawing.Size(175, 23);
            this.txtFOV.TabIndex = 1;
            this.txtFOV.Text = "  ";
            this.txtFOV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOV_KeyPress);
            this.txtFOV.Leave += new System.EventHandler(this.txtFOV_Leave);
            // 
            // lbFov
            // 
            this.lbFov.AutoSize = true;
            this.lbFov.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbFov.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lbFov.Location = new System.Drawing.Point(10, 6);
            this.lbFov.Name = "lbFov";
            this.lbFov.Size = new System.Drawing.Size(28, 15);
            this.lbFov.TabIndex = 0;
            this.lbFov.Text = "FOV";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.panel16);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 347);
            this.panel2.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.btnHide);
            this.panel6.Controls.Add(this.lbCam_hint);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.lbTweakHeader);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(250, 32);
            this.panel6.TabIndex = 11;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHide.BackgroundImage")));
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Location = new System.Drawing.Point(220, 3);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(29, 29);
            this.btnHide.TabIndex = 0;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lbCam_hint
            // 
            this.lbCam_hint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCam_hint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbCam_hint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbCam_hint.ForeColor = System.Drawing.Color.DarkRed;
            this.lbCam_hint.Location = new System.Drawing.Point(10, 9);
            this.lbCam_hint.Name = "lbCam_hint";
            this.lbCam_hint.Size = new System.Drawing.Size(241, 23);
            this.lbCam_hint.TabIndex = 47;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(222)))));
            this.panel10.Location = new System.Drawing.Point(0, 31);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(250, 1);
            this.panel10.TabIndex = 4;
            this.panel10.Visible = false;
            // 
            // lbTweakHeader
            // 
            this.lbTweakHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbTweakHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTweakHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbTweakHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lbTweakHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTweakHeader.Location = new System.Drawing.Point(0, 0);
            this.lbTweakHeader.Name = "lbTweakHeader";
            this.lbTweakHeader.Size = new System.Drawing.Size(250, 32);
            this.lbTweakHeader.TabIndex = 5;
            this.lbTweakHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(222)))));
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(250, 1);
            this.panel15.TabIndex = 12;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(222)))));
            this.panel16.Location = new System.Drawing.Point(250, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1, 347);
            this.panel16.TabIndex = 13;
            this.panel16.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer22
            // 
            this.timer22.Interval = 10;
            this.timer22.Tick += new System.EventHandler(this.timer22_Tick);
            // 
            // Parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(251, 347);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Name = "Parameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SimpleDialogFrom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbFov;
        private takattoFS2.Controls.UserControls.TextBoxEx txtFOV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbTweakHeader;
        private System.Windows.Forms.Panel panel15;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel16;
        private takattoFS2.Controls.UserControls.TextBoxEx txtLookY;
        private System.Windows.Forms.Label lbLY;
        private takattoFS2.Controls.UserControls.TextBoxEx txtLookX;
        private System.Windows.Forms.Label lbLX;
        private takattoFS2.Controls.UserControls.TextBoxEx txtPosZ;
        private System.Windows.Forms.Label lbPZ;
        private takattoFS2.Controls.UserControls.TextBoxEx txtPosY;
        private System.Windows.Forms.Label lbPY;
        private takattoFS2.Controls.UserControls.TextBoxEx txtPosX;
        private System.Windows.Forms.Label lbPX;
        private System.Windows.Forms.CheckBox rdIgnoreBall;
        private System.Windows.Forms.Label lbCam_hint;
        private takattoFS2.Controls.UserControls.TextBoxEx txtLookZ;
        private System.Windows.Forms.Label lbLZ;
        private System.Windows.Forms.CheckBox rdAbsolte;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Timer timer22;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.Button btnAScript;
    }
}