
namespace takattoFS2.Forms.Sub_Forms
{
    partial class CustomJukeboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomJukeboxForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveSelectedSongToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSongPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.glassyPanel1 = new takattoFS2.Controls.UserControls.GlassyPanel();
            this.glassyPanel2 = new takattoFS2.Controls.UserControls.GlassyPanel();
            this.roundCornerControl1 = new takattoFS2.Controls.UserControls.RoundCornerControl();
            this.btn_select = new System.Windows.Forms.Button();
            this.btnReinstall = new System.Windows.Forms.Button();
            this.txtSinger = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.txtSongName = new takattoFS2.Controls.UserControls.TextBoxEx();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelEx1 = new takattoFS2.Controls.UserControls.PanelEx();
            this.lbCorrupt = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkDLC = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.roundCornerControl1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveSelectedSongToTopToolStripMenuItem,
            this.deleteSelectedSongToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(72, 56);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // moveSelectedSongToTopToolStripMenuItem
            // 
            this.moveSelectedSongToTopToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.moveSelectedSongToTopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("moveSelectedSongToTopToolStripMenuItem.Image")));
            this.moveSelectedSongToTopToolStripMenuItem.Name = "moveSelectedSongToTopToolStripMenuItem";
            this.moveSelectedSongToTopToolStripMenuItem.Size = new System.Drawing.Size(71, 26);
            this.moveSelectedSongToTopToolStripMenuItem.Click += new System.EventHandler(this.moveSelectedSongToTopToolStripMenuItem_Click);
            // 
            // deleteSelectedSongToolStripMenuItem
            // 
            this.deleteSelectedSongToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.deleteSelectedSongToolStripMenuItem.Image = global::takattoFS2.Properties.Resources.icons8_delete_35;
            this.deleteSelectedSongToolStripMenuItem.Name = "deleteSelectedSongToolStripMenuItem";
            this.deleteSelectedSongToolStripMenuItem.Size = new System.Drawing.Size(71, 26);
            this.deleteSelectedSongToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedSongToolStripMenuItem_Click_1);
            // 
            // lbSongPath
            // 
            this.lbSongPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSongPath.AutoEllipsis = true;
            this.lbSongPath.BackColor = System.Drawing.Color.Transparent;
            this.lbSongPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbSongPath.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbSongPath.ForeColor = System.Drawing.Color.SlateBlue;
            this.lbSongPath.Location = new System.Drawing.Point(7, 5);
            this.lbSongPath.Name = "lbSongPath";
            this.lbSongPath.Size = new System.Drawing.Size(201, 21);
            this.lbSongPath.TabIndex = 41;
            this.lbSongPath.Text = "[Song path]";
            this.lbSongPath.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbSongPath.TextChanged += new System.EventHandler(this.txtSongName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.glassyPanel1);
            this.panel1.Controls.Add(this.glassyPanel2);
            this.panel1.Controls.Add(this.roundCornerControl1);
            this.panel1.Controls.Add(this.btnReinstall);
            this.panel1.Controls.Add(this.txtSinger);
            this.panel1.Controls.Add(this.txtSongName);
            this.panel1.Controls.Add(this.btnListen);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lbSongPath);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.panelEx1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 414);
            this.panel1.TabIndex = 42;
            // 
            // glassyPanel1
            // 
            this.glassyPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glassyPanel1.Location = new System.Drawing.Point(0, 0);
            this.glassyPanel1.Name = "glassyPanel1";
            this.glassyPanel1.Size = new System.Drawing.Size(296, 244);
            this.glassyPanel1.TabIndex = 61;
            this.glassyPanel1.Visible = false;
            // 
            // glassyPanel2
            // 
            this.glassyPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glassyPanel2.Location = new System.Drawing.Point(0, 29);
            this.glassyPanel2.Name = "glassyPanel2";
            this.glassyPanel2.Opacity = 25;
            this.glassyPanel2.Size = new System.Drawing.Size(296, 55);
            this.glassyPanel2.TabIndex = 62;
            // 
            // roundCornerControl1
            // 
            this.roundCornerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundCornerControl1.Controls.Add(this.btn_select);
            this.roundCornerControl1.Location = new System.Drawing.Point(211, 1);
            this.roundCornerControl1.Name = "roundCornerControl1";
            this.roundCornerControl1.Radius = 3;
            this.roundCornerControl1.Size = new System.Drawing.Size(86, 26);
            this.roundCornerControl1.TabIndex = 44;
            // 
            // btn_select
            // 
            this.btn_select.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_select.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_select.FlatAppearance.BorderSize = 0;
            this.btn_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_select.ForeColor = System.Drawing.Color.White;
            this.btn_select.Location = new System.Drawing.Point(-1, -1);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(87, 27);
            this.btn_select.TabIndex = 0;
            this.btn_select.UseVisualStyleBackColor = false;
            this.btn_select.Click += new System.EventHandler(this.btn_gamekill_Click);
            // 
            // btnReinstall
            // 
            this.btnReinstall.BackColor = System.Drawing.Color.Transparent;
            this.btnReinstall.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_inbox_35;
            this.btnReinstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReinstall.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReinstall.FlatAppearance.BorderSize = 0;
            this.btnReinstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinstall.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReinstall.Location = new System.Drawing.Point(35, 89);
            this.btnReinstall.Name = "btnReinstall";
            this.btnReinstall.Size = new System.Drawing.Size(29, 29);
            this.btnReinstall.TabIndex = 5;
            this.btnReinstall.UseVisualStyleBackColor = false;
            this.btnReinstall.Click += new System.EventHandler(this.btnReinstall_Click);
            // 
            // txtSinger
            // 
            this.txtSinger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSinger.BackColor = System.Drawing.Color.White;
            this.txtSinger.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtSinger.ForeColor = System.Drawing.Color.Gray;
            this.txtSinger.Location = new System.Drawing.Point(0, 60);
            this.txtSinger.MaxLength = 255;
            this.txtSinger.Name = "txtSinger";
            this.txtSinger.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtSinger.PlaceHolderText = "                      ";
            this.txtSinger.ReadOnly = true;
            this.txtSinger.Size = new System.Drawing.Size(296, 23);
            this.txtSinger.TabIndex = 3;
            this.txtSinger.Text = "  ";
            // 
            // txtSongName
            // 
            this.txtSongName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSongName.BackColor = System.Drawing.Color.White;
            this.txtSongName.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtSongName.ForeColor = System.Drawing.Color.Gray;
            this.txtSongName.Location = new System.Drawing.Point(0, 32);
            this.txtSongName.MaxLength = 255;
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtSongName.PlaceHolderText = "                      ";
            this.txtSongName.ReadOnly = true;
            this.txtSongName.Size = new System.Drawing.Size(296, 23);
            this.txtSongName.TabIndex = 2;
            this.txtSongName.Text = "  ";
            // 
            // btnListen
            // 
            this.btnListen.BackColor = System.Drawing.Color.Transparent;
            this.btnListen.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_musical_notes_disa_35;
            this.btnListen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnListen.FlatAppearance.BorderSize = 0;
            this.btnListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListen.ForeColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(0, 89);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(29, 29);
            this.btnListen.TabIndex = 4;
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_reset_35;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(200, 89);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(29, 29);
            this.btnReset.TabIndex = 6;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_add_disa_35;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(267, 89);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 29);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = global::takattoFS2.Properties.Resources.icons8_delete_35;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(235, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.White;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx1.Controls.Add(this.lbCorrupt);
            this.panelEx1.Controls.Add(this.dataGridView1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 244);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx1.Size = new System.Drawing.Size(296, 170);
            this.panelEx1.TabIndex = 42;
            // 
            // lbCorrupt
            // 
            this.lbCorrupt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCorrupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbCorrupt.Location = new System.Drawing.Point(1, 1);
            this.lbCorrupt.Name = "lbCorrupt";
            this.lbCorrupt.Size = new System.Drawing.Size(294, 168);
            this.lbCorrupt.TabIndex = 9;
            this.lbCorrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCorrupt.Visible = false;
            this.lbCorrupt.Click += new System.EventHandler(this.btnReinstall_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(294, 168);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // checkDLC
            // 
            this.checkDLC.Enabled = true;
            this.checkDLC.Interval = 2000;
            this.checkDLC.Tick += new System.EventHandler(this.checkDLC_Tick);
            // 
            // CustomJukeboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(296, 414);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomJukeboxForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomJukeboxForm_FormClosing);
            this.Load += new System.EventHandler(this.CustomJukeboxForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundCornerControl1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Label lbSongPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnListen;
        private Controls.UserControls.TextBoxEx txtSongName;
        private Controls.UserControls.TextBoxEx txtSinger;
        private System.Windows.Forms.Button btnReinstall;
        private System.Windows.Forms.Panel panel1;
        private Controls.UserControls.PanelEx panelEx1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedSongToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.UserControls.RoundCornerControl roundCornerControl1;
        private System.Windows.Forms.Timer checkDLC;
        private System.Windows.Forms.ToolStripMenuItem moveSelectedSongToTopToolStripMenuItem;
        private System.Windows.Forms.Label lbCorrupt;
        private Controls.UserControls.GlassyPanel glassyPanel1;
        private Controls.UserControls.GlassyPanel glassyPanel2;
    }
}