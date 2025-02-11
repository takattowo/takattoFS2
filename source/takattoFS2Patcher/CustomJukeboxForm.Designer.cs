
namespace takattoFS2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.lb_customJukeboxhint = new System.Windows.Forms.Label();
            this.btn_gamekill = new System.Windows.Forms.Button();
            this.lbSongName = new System.Windows.Forms.Label();
            this.lbSinger = new System.Windows.Forms.Label();
            this.lbSongPath = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.txtSinger = new System.Windows.Forms.TextBox();
            this.btnReinstall = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 186);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(403, 225);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnConfirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.Location = new System.Drawing.Point(324, 420);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 29);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(89)))), ((int)(((byte)(106)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(227, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 29);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Remove -";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnReload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReload.Location = new System.Drawing.Point(12, 420);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(88, 29);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Import";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lb_customJukeboxhint
            // 
            this.lb_customJukeboxhint.AutoSize = true;
            this.lb_customJukeboxhint.BackColor = System.Drawing.Color.Transparent;
            this.lb_customJukeboxhint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_customJukeboxhint.Location = new System.Drawing.Point(12, 18);
            this.lb_customJukeboxhint.Name = "lb_customJukeboxhint";
            this.lb_customJukeboxhint.Size = new System.Drawing.Size(301, 20);
            this.lb_customJukeboxhint.TabIndex = 35;
            this.lb_customJukeboxhint.Text = "Select a song to add to Jukebox (mp3):";
            // 
            // btn_gamekill
            // 
            this.btn_gamekill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gamekill.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_gamekill.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_gamekill.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_gamekill.FlatAppearance.BorderSize = 0;
            this.btn_gamekill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gamekill.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btn_gamekill.ForeColor = System.Drawing.Color.White;
            this.btn_gamekill.Location = new System.Drawing.Point(324, 16);
            this.btn_gamekill.Name = "btn_gamekill";
            this.btn_gamekill.Size = new System.Drawing.Size(91, 25);
            this.btn_gamekill.TabIndex = 0;
            this.btn_gamekill.Text = "Select music";
            this.btn_gamekill.UseVisualStyleBackColor = false;
            this.btn_gamekill.Click += new System.EventHandler(this.btn_gamekill_Click);
            // 
            // lbSongName
            // 
            this.lbSongName.BackColor = System.Drawing.Color.Transparent;
            this.lbSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lbSongName.Location = new System.Drawing.Point(12, 47);
            this.lbSongName.Name = "lbSongName";
            this.lbSongName.Size = new System.Drawing.Size(112, 25);
            this.lbSongName.TabIndex = 39;
            this.lbSongName.Text = "Sound name:";
            this.lbSongName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbSinger
            // 
            this.lbSinger.BackColor = System.Drawing.Color.Transparent;
            this.lbSinger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.lbSinger.Location = new System.Drawing.Point(12, 78);
            this.lbSinger.Name = "lbSinger";
            this.lbSinger.Size = new System.Drawing.Size(112, 25);
            this.lbSinger.TabIndex = 40;
            this.lbSinger.Text = "Artist(s):";
            this.lbSinger.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbSongPath
            // 
            this.lbSongPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSongPath.AutoEllipsis = true;
            this.lbSongPath.BackColor = System.Drawing.Color.Transparent;
            this.lbSongPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbSongPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbSongPath.ForeColor = System.Drawing.Color.SlateBlue;
            this.lbSongPath.Location = new System.Drawing.Point(130, 108);
            this.lbSongPath.Name = "lbSongPath";
            this.lbSongPath.Size = new System.Drawing.Size(285, 21);
            this.lbSongPath.TabIndex = 41;
            this.lbSongPath.Text = "[Song Path]";
            this.lbSongPath.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbSongPath.TextChanged += new System.EventHandler(this.txtSongName_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(340, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add +";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReset.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(259, 155);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnListen
            // 
            this.btnListen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnListen.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnListen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnListen.FlatAppearance.BorderSize = 0;
            this.btnListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListen.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnListen.ForeColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(12, 155);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 25);
            this.btnListen.TabIndex = 6;
            this.btnListen.Text = "♪ Listen";
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtSongName
            // 
            this.txtSongName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSongName.BackColor = System.Drawing.Color.White;
            this.txtSongName.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtSongName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSongName.Location = new System.Drawing.Point(130, 46);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.ReadOnly = true;
            this.txtSongName.Size = new System.Drawing.Size(285, 25);
            this.txtSongName.TabIndex = 1;
            // 
            // txtSinger
            // 
            this.txtSinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSinger.BackColor = System.Drawing.Color.White;
            this.txtSinger.Font = new System.Drawing.Font("Gadugi", 10F);
            this.txtSinger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSinger.Location = new System.Drawing.Point(130, 77);
            this.txtSinger.Name = "txtSinger";
            this.txtSinger.ReadOnly = true;
            this.txtSinger.Size = new System.Drawing.Size(285, 25);
            this.txtSinger.TabIndex = 2;
            // 
            // btnReinstall
            // 
            this.btnReinstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReinstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReinstall.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReinstall.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnReinstall.FlatAppearance.BorderSize = 0;
            this.btnReinstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinstall.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.btnReinstall.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReinstall.Location = new System.Drawing.Point(106, 420);
            this.btnReinstall.Name = "btnReinstall";
            this.btnReinstall.Size = new System.Drawing.Size(88, 29);
            this.btnReinstall.TabIndex = 8;
            this.btnReinstall.Text = "Reinstall";
            this.btnReinstall.UseVisualStyleBackColor = false;
            this.btnReinstall.Click += new System.EventHandler(this.btnReinstall_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::takattoFS2.Properties.Resources.back_patch3;
            this.panel1.Controls.Add(this.btnReinstall);
            this.panel1.Controls.Add(this.txtSinger);
            this.panel1.Controls.Add(this.txtSongName);
            this.panel1.Controls.Add(this.btnListen);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lbSongPath);
            this.panel1.Controls.Add(this.lbSinger);
            this.panel1.Controls.Add(this.lbSongName);
            this.panel1.Controls.Add(this.btn_gamekill);
            this.panel1.Controls.Add(this.lb_customJukeboxhint);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 461);
            this.panel1.TabIndex = 42;
            // 
            // CustomJukeboxForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::takattoFS2.Properties.Resources.back_patch3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(427, 461);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "CustomJukeboxForm";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Jukebox Management♪♪♪ ヽ(ˇ∀ˇ )ゞ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomJukeboxForm_FormClosing);
            this.Load += new System.EventHandler(this.CustomJukeboxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lb_customJukeboxhint;
        private System.Windows.Forms.Button btn_gamekill;
        private System.Windows.Forms.Label lbSongName;
        private System.Windows.Forms.Label lbSinger;
        private System.Windows.Forms.Label lbSongPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.TextBox txtSinger;
        private System.Windows.Forms.Button btnReinstall;
        private System.Windows.Forms.Panel panel1;
    }
}