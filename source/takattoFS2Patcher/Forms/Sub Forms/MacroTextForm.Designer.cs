
using takattoFS2.Controls.UserControls;

namespace takattoFS2.Forms.Sub_Forms
{
    partial class MacroTextForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.characterCountLabel = new System.Windows.Forms.Label();
            this.panelEx2 = new takattoFS2.Controls.UserControls.PanelEx();
            this.lbEmpty = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbUIHint = new System.Windows.Forms.Label();
            this.lbNote = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checknumberofitem = new System.Windows.Forms.Timer(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.characterCountLabel);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Controls.Add(this.lbUIHint);
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 330);
            this.panel1.TabIndex = 42;
            // 
            // characterCountLabel
            // 
            this.characterCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.characterCountLabel.Font = new System.Drawing.Font("Consolas", 7.75F);
            this.characterCountLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.characterCountLabel.Location = new System.Drawing.Point(165, 9);
            this.characterCountLabel.Name = "characterCountLabel";
            this.characterCountLabel.Size = new System.Drawing.Size(88, 21);
            this.characterCountLabel.TabIndex = 57;
            this.characterCountLabel.Text = "- - -";
            this.characterCountLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.panelEx2.BorderColor = System.Drawing.Color.Transparent;
            this.panelEx2.Controls.Add(this.lbEmpty);
            this.panelEx2.Controls.Add(this.dataGridView1);
            this.panelEx2.Location = new System.Drawing.Point(0, 32);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(1);
            this.panelEx2.Size = new System.Drawing.Size(253, 200);
            this.panelEx2.TabIndex = 53;
            // 
            // lbEmpty
            // 
            this.lbEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmpty.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmpty.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbEmpty.ForeColor = System.Drawing.Color.Maroon;
            this.lbEmpty.Location = new System.Drawing.Point(12, 126);
            this.lbEmpty.Name = "lbEmpty";
            this.lbEmpty.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEmpty.Size = new System.Drawing.Size(229, 57);
            this.lbEmpty.TabIndex = 57;
            this.lbEmpty.Text = "[emty]";
            this.lbEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEmpty.Visible = false;
            // 
            // dataGridView1
            // 
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
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(251, 198);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeViewToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // changeViewToolStripMenuItem
            // 
            this.changeViewToolStripMenuItem.Name = "changeViewToolStripMenuItem";
            this.changeViewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeViewToolStripMenuItem.Click += new System.EventHandler(this.changeViewToolStripMenuItem_Click);
            // 
            // lbUIHint
            // 
            this.lbUIHint.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbUIHint.ForeColor = System.Drawing.Color.Teal;
            this.lbUIHint.Location = new System.Drawing.Point(0, 6);
            this.lbUIHint.Name = "lbUIHint";
            this.lbUIHint.Size = new System.Drawing.Size(269, 23);
            this.lbUIHint.TabIndex = 44;
            this.lbUIHint.Text = "[name]";
            // 
            // lbNote
            // 
            this.lbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNote.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lbNote.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbNote.Location = new System.Drawing.Point(0, 243);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(253, 68);
            this.lbNote.TabIndex = 56;
            this.lbNote.Text = "[note]";
            // 
            // checknumberofitem
            // 
            this.checknumberofitem.Enabled = true;
            this.checknumberofitem.Interval = 500;
            this.checknumberofitem.Tick += new System.EventHandler(this.checknumberofitem_Tick);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // MacroTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(253, 330);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MacroTextForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AutoTaskForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbUIHint;
        private PanelEx panelEx2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Label characterCountLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeViewToolStripMenuItem;
        private System.Windows.Forms.Timer checknumberofitem;
        private System.Windows.Forms.Label lbEmpty;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}