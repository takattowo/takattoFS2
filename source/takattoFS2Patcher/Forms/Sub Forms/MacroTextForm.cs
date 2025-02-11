using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class MacroTextForm : Form
    {


        public MacroTextForm()
        {
            InitializeComponent(); 
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;

            //dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            //dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            
        }

        private bool isEditingNewRow = false;
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check if a new row is being edited
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                isEditingNewRow = true; // Set the flag to indicate editing of a new row
                HighlightEmptyCellsInNewRow(e.RowIndex);
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if editing of a new row has ended
            if (isEditingNewRow && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Reset the flag and remove the highlights when editing of a new row ends
                isEditingNewRow = false;
                UnhighlightEmptyCellsInNewRow(e.RowIndex);
            }
        }

        private void HighlightEmptyCellsInNewRow(int rowIndex)
        {
            // Iterate through all cells in the new row
            foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
            {
                if (string.IsNullOrEmpty(Convert.ToString(cell.Value)))
                {
                    // Highlight the empty cell
                    cell.Style.BackColor = Color.FromArgb(3, 102, 214); // Highlight the cell in yellow
                }
            }
        }


        private void UnhighlightEmptyCellsInNewRow(int rowIndex)
        {
            // Iterate through all cells in the new row
            foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
            {
                // Reset the cell background color
                cell.Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
            }
        }


        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Automatically save changes to UserSettings.TextMacroTweakData
            SaveDataToUserSettings();
        }

        // Function to save the converted data back to UserSettings.TextMacroTweakData
        private void SaveDataToUserSettings()
        {
            StringBuilder result = new StringBuilder();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Check if the row is not a new row and both columns have values
                if (!row.IsNewRow &&
                    !string.IsNullOrEmpty(Convert.ToString(row.Cells["Replace"].Value)) &&
                    !string.IsNullOrEmpty(Convert.ToString(row.Cells["By"].Value)))
                {
                    string replace = row.Cells["Replace"].Value.ToString().Trim(); // Remove leading/trailing whitespace
                    string by = row.Cells["By"].Value.ToString().Trim(); // Remove leading/trailing whitespace

                    // Append the data in the original format with tab characters and newlines
                    result.AppendLine($"{replace}\t{by}");
                }
            }

            // Set UserSettings.TextMacroTweakData to the result
            UserSettings.TextMacroTweakData = result.ToString().TrimEnd(); // Remove the trailing newline
        }

        private void AutoTaskForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            LoadMusic();

            ActiveControl = lbUIHint;
        }

        private void LoadMusic()
        {
            // Create columns for the DataGridView
            dataGridView1.Columns.Add("Replace", "Replace");
            dataGridView1.Columns.Add("By", "By");
            dataGridView1.Columns["Replace"].Width = (int)(dataGridView1.Width * 0.37); //0.5         
            dataGridView1.Columns["By"].Width = (int)(dataGridView1.Width * 0.63);

            PopulateDataGridViewFromUserSettings();


            // Set the WrapMode property for the specific columns
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.Columns["By"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.CurrentCell = null;

            dataGridView1.Columns["Replace"].HeaderText = StringLoader.GetText("lb_tweak_textmacro_replace");
            dataGridView1.Columns["By"].HeaderText = StringLoader.GetText("lb_tweak_textmacro_by");
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0) // First column
            {
                string value = e.FormattedValue.ToString();
                if (value.Length > 15)// || !Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
                {
                    e.Cancel = true;

                    MsgBoxs.Warning.MaximumCharacterAllowed(15, MainForm.mf);
                }
            }
            else if (e.ColumnIndex == 1) // Second column
            {
                string value = e.FormattedValue.ToString();
                if (value.Length > 128)
                {
                    e.Cancel = true;

                    MsgBoxs.Warning.MaximumCharacterAllowed(128, MainForm.mf);
                }
            }
        }



        private void PopulateDataGridViewFromUserSettings()
        {
            // Assuming UserSettings.TextMacroTweakData is a string containing data in the specified format
            string textMacroData = UserSettings.TextMacroTweakData;

            string[] lines = textMacroData.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Split the string into lines
            foreach (var line in lines)
            {
                // Split each line into "Replace" and "By" values using the tab character as a separator
                string[] parts = line.Split('\t');

                if (parts.Length == 2)
                {
                    // Trim leading and trailing whitespace from the values
                    string replace = parts[0].Trim();
                    string by = parts[1].Trim();

                    // Add the trimmed values to the DataGridView
                    dataGridView1.Rows.Add(replace, by);
                }
                else
                {
                    // If there are lines with unexpected formats, you can log them or handle them differently.
                    // For now, we'll simply ignore them.
                }
            }
        }


        void LoadControl()
        {
            changeViewToolStripMenuItem.Text = StringLoader.GetText("btn_resize");
            copyToolStripMenuItem.Text = StringLoader.GetText("tooltip_export_settings");
            lbEmpty.Text = StringLoader.GetText("lb_tweak_textmacro_empty");
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);

            foreach (System.Windows.Forms.Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                else
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            foreach (System.Windows.Forms.Control c in panelEx2.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
                else
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            dataGridView1.Font = MemoryFonts.SetFont(0, lbUIHint.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());

            lbUIHint.Text = StringLoader.GetText("lb_tweak_textmacro_hint") + ":";
            lbNote.Text = StringLoader.GetText("lb_tweak_textmacro_note");
        }

        // Helper function to check if the row is the "Add New Row"
        private bool IsAddNewRow(int rowIndex)
        {
            return dataGridView1.Rows[rowIndex].IsNewRow;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the cell is not in the "Add New Row"
                if (!IsAddNewRow(e.RowIndex))
                {
                    // Draw the bottom border for each cell
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Calculate the bottom rectangle
                    var bottomRect = new Rectangle(e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Width, 1);

                    // Draw the bottom border with the custom color
                    using (var borderBrush = new SolidBrush(Color.FromArgb(225, 228, 232)))
                    {
                        e.Graphics.FillRectangle(borderBrush, bottomRect);
                    }

                    // Prevent the default painting of the cell's content
                    e.Handled = true;

                    // Check if the cell is in edit mode
                    if (dataGridView1.CurrentCell != null && e.ColumnIndex == dataGridView1.CurrentCell.ColumnIndex && e.RowIndex == dataGridView1.CurrentCell.RowIndex)
                    {
                        // Draw the bottom line again to ensure it's visible during editing
                        var cellBounds = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                        var cellBottomRect = new Rectangle(cellBounds.X, cellBounds.Bottom - 1, cellBounds.Width, 1);

                        using (var editBorderBrush = new SolidBrush(Color.FromArgb(225, 228, 232)))
                        {
                            e.Graphics.FillRectangle(editBorderBrush, cellBottomRect);
                        }
                    }
                }
            }
        }

        bool minimize = true;
        private void changeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (minimize)
            {
                minimize = false;
                // Set the WrapMode property for the specific columns
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Columns["By"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                changeViewToolStripMenuItem.Text = "√ " + StringLoader.GetText("btn_resize");
                changeViewToolStripMenuItem.Enabled = false;
            }
            else
            {
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.Columns["By"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
            }

        }

        private void checknumberofitem_Tick(object sender, EventArgs e)
        {
            int rowCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isRowComplete = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isRowComplete = false;
                        break;
                    }
                }

                if (isRowComplete)
                {
                    rowCount++;
                }
            }

            characterCountLabel.Text = rowCount.ToString();

            if(rowCount <= 0)
            {
                lbEmpty.Visible = true;
                return;
            }

            lbEmpty.Visible = false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            try
            {
                Clipboard.SetText(UserSettings.TextMacroTweakData);
                MsgBoxs.Information.HasBeenCopiedToClipBoard(MainForm.mf, StringLoader.GetText("lb_tweak_textmacro_hint"));
            }
            catch (Exception msg)
            {
                MsgBoxs.Warning.Error(MainForm.mf, msg.ToString());
                return;
            }
        }
    }
}
