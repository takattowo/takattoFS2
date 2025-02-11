using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using takattoFS2.Controls;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class AutoTaskForm : Form
    {
        public AutoTaskForm()
        {
            InitializeComponent();
            cbMacroKey.Width = 0;
        }

        static AutoTaskForm _frmObj;
        public static AutoTaskForm frmObj
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }

        private void AutoTaskForm_Load(object sender, EventArgs e)
        {           
            LoadControl();
            txtW.ContextMenu = new ContextMenu();
            txtPoint.ContextMenu = new ContextMenu();

            var autoTaskmin = MainForm.mf.autoTaskmin;
            txtW.removePlaceHolder(null, null);
            txtW.Text = autoTaskmin.ToString();

            var tse = UserSettings.Command.Split('•');

            if (tse != null && tse.Length > 0)
            {
                txtCommand.Text = tse[0];
                if(tse.Length > 1)
                    txtPoint.Text = tse[1];
            }
           
            cbGameGraphic.SelectedIndex = MainForm.mf.autoTaske;
            radRepat.Checked = MainForm.mf.autoTaskRepeat;
            radFocusedModeOnly.Checked = MainForm.mf.isForegroundModeOnly;
            checkHistory = MainForm.mf.autoTaskRepeat;

            //cbMacroKey.SelectedIndex = Keyboarde.cbKeyboardList.SelectedIndex;
            //if (cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6)
            //{
            //    cbMacroKey.Items.AddRange(Keyboarde.cbKeyboardList.Items.Cast<Object>().ToArray());
            //    cbMacroKey.SelectedIndex = Keyboarde.cbKeyboardList.SelectedIndex;
            //}

            //if (cbGameGraphic.SelectedIndex == 7)
            //{
            //    cbMacroKey.Items.AddRange(Keyboarde.cbMouseList.Items.Cast<Object>().ToArray());
            //    cbMacroKey.SelectedIndex = Keyboarde.cbMouseList.SelectedIndex;
            //}


            txtW.SelectionStart = txtW.Text.Length;
            txtW.DeselectAll();

            frmObj = this;
        }

        private void LoadControl()
        {
            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
            
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
                if (c.GetType() == typeof(Button))
                    c.Font = MemoryFonts.SetFont(0, c.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            }

            if (MainForm.mf.isSecondTask)
                lbAFK_hint.Text = StringLoader.GetText("lb_tweak_task_interval_hint") + ":";
            else
                lbAFK_hint.Text = StringLoader.GetText("lb_tweak_task_interval_hint2") + ":";

            txtW.PlaceHolderText = StringLoader.GetText("lb_tweak_task_interval_hint");
            toolTip1.SetToolTip(txtW, StringLoader.GetText("lb_tweak_task_interval_hint"));
            toolTip1.SetToolTip(txtCommand, StringLoader.GetText("lb_tweak_task_cmd"));
            toolTip1.SetToolTip(radRepat, StringLoader.GetText("tooltip_tweak_autotask_repeat"));
            toolTip1.SetToolTip(radFocusedModeOnly, StringLoader.GetText("tooltip_tweak_autotask_macrofocus"));
            radRepat.Text = StringLoader.GetText("lb_repeat");
            radFocusedModeOnly.Text = StringLoader.GetText("lb_foreground_mode");

            cbGameGraphic.Items.AddRange(new object[] {
                StringLoader.GetText("cb_tweak_task_1"),
                StringLoader.GetText("cb_tweak_task_2"),
                StringLoader.GetText("cb_tweak_task_3"),
                StringLoader.GetText("cb_tweak_task_4"),
                StringLoader.GetText("cb_tweak_task_5")});


            if (MainForm.mf.IsHikariEd())
            {
                cbGameGraphic.Items.Add(StringLoader.GetText("cb_tweak_task_6"));
                cbGameGraphic.Items.Add(StringLoader.GetText("cb_tweak_task_7"));
                cbGameGraphic.Items.Add(StringLoader.GetText("cb_tweak_task_8"));

                radFocusedModeOnly.Visible = true;
            }

            if (MainForm.mf.IsHNakoEd())
            {
                cbGameGraphic.Items.Add(StringLoader.GetText("cb_tweak_task_9"));
            }
        }

        public void CheckFields()
        {
            if (cbGameGraphic.SelectedIndex == 4 || cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 7 || cbGameGraphic.SelectedIndex == 8)
            {
                if (string.IsNullOrEmpty(txtPoint.Text) || string.IsNullOrWhiteSpace(txtPoint.Text))
                {
                    MsgBoxs.Warning.MissingField(MainForm.mf);
                    return;
                }

                String strpattern = @"^\d*[,]\d*$"; //Pattern is Ok
                Regex regex = new Regex(strpattern);
                if (!regex.Match(txtPoint.Text.Replace(StringLoader.GetText("lb_tweak_task_5_hint"), "").Trim()).Success)
                {
                    MsgBoxs.Warning.InvalidValue(MainForm.mf);
                    return;
                }
            }

            if (cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6 || cbGameGraphic.SelectedIndex == 7)
            {
                if (cbMacroKey.SelectedIndex == 0)
                {
                    MsgBoxs.Warning.MissingField(MainForm.mf);
                    return;
                }
            }

            if (cbGameGraphic.SelectedIndex == 8)
            {
                if (KeyboardMacro.cbKeyboardList.SelectedIndex == 0 || KeyboardMacro.cbMouseList.SelectedIndex == 0)
                {
                    MsgBoxs.Warning.MissingField(MainForm.mf);
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtW.Text) || string.IsNullOrWhiteSpace(txtW.Text))
            {
                MsgBoxs.Warning.MissingField(MainForm.mf);
                return;
            }

            if (!Methods.CheckIfNumberValid(txtW.Text) || Int32.Parse(txtW.Text) <= 0 || String.IsNullOrEmpty(txtW.Text))
            {
                MsgBoxs.Warning.InvalidValue(MainForm.mf);
                return;
            }

            if (string.IsNullOrEmpty(txtCommand.Text))
            {
                txtCommand.Text = "";
            }

            UserSettings.Command = txtCommand.Text + "•" + txtPoint.Text.Replace(StringLoader.GetText("lb_tweak_task_5_hint"), "").Trim() + "•" + "null";
            MainForm.mf.AutoTaskCheck(cbGameGraphic.SelectedIndex, Int32.Parse(txtW.Text), radRepat.Checked, radFocusedModeOnly.Checked);
            Logger.Write("Auto task has been initialized");

            Close();
        }

        private void txtW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&& (e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cbGameGraphic_SelectedIndexChanged(object sender, EventArgs e)
        {
            radRepat.Checked = checkHistory;
            radFocusedModeOnly.Enabled = false;
            lbNote.Text = "";

            timerCBMacr.Start();

            if (cbGameGraphic.SelectedIndex == 2 || cbGameGraphic.SelectedIndex == 3)
            {
                txtPoint.Visible = false;
                txtCommand.Enabled = true;
                radRepat.Enabled = true;
                return;
            }

            if (cbGameGraphic.SelectedIndex == 4)
            {
                txtPoint.Enabled = true;
                txtPoint.Visible = true;
                txtCommand.Enabled = false;
                radRepat.Enabled = true;
                if (!radRepat.Checked)
                    radRepat.Checked = true;

                lbNote.Text = StringLoader.GetText("lb_tweak_task_5_note");
                txtPoint.Text = StringLoader.GetText("lb_tweak_task_5");
                return;
            }

            if (cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6)
            {
                cbMacroKey.Items.Clear();
                cbMacroKey.Items.AddRange(KeyboardMacro.cbKeyboardList.Items.Cast<Object>().ToArray());
                cbMacroKey.SelectedIndex = KeyboardMacro.cbKeyboardList.SelectedIndex;
            }

            if (cbGameGraphic.SelectedIndex == 7)
            {
                cbMacroKey.Items.Clear();
                cbMacroKey.Items.AddRange(KeyboardMacro.cbMouseList.Items.Cast<Object>().ToArray());
                cbMacroKey.SelectedIndex = KeyboardMacro.cbMouseList.SelectedIndex;

                txtPoint.Text = StringLoader.GetText("lb_initializing_mousem");
            }

            if (cbGameGraphic.SelectedIndex == 5)
            {
                txtPoint.Enabled = true;
                txtPoint.Visible = true;
                txtCommand.Enabled = false;
                radRepat.Enabled = true;
                radFocusedModeOnly.Enabled = true;
                if (!radRepat.Checked)
                    radRepat.Checked = true;

                lbNote.Text = StringLoader.GetText("lb_tweak_task_6_note");
                txtPoint.Text = StringLoader.GetText("lb_tweak_task_5");
                return;
            }

            if (cbGameGraphic.SelectedIndex == 6)
            {
                txtPoint.Enabled = false;
                txtPoint.Visible = false;
                txtCommand.Enabled = false;
                radRepat.Enabled = true;
                radFocusedModeOnly.Enabled = true;
                if (!radRepat.Checked)
                    radRepat.Checked = true;

                lbNote.Text = StringLoader.GetText("lb_tweak_task_6_note");
                txtPoint.Text = StringLoader.GetText("msgtitle_random1");
                return;
            }

            if (cbGameGraphic.SelectedIndex == 7)
            {
                txtPoint.Enabled = true;
                txtPoint.Visible = true;
                txtCommand.Enabled = false;
                radRepat.Enabled = true;
                radFocusedModeOnly.Enabled = true;
                if (!radRepat.Checked)
                    radRepat.Checked = true;

                lbNote.Text = StringLoader.GetText("lb_tweak_task_8_note");

                return;
            }

            if (cbGameGraphic.SelectedIndex == 8)
            {
                txtPoint.Enabled = true;
                txtPoint.Visible = true;
                txtCommand.Enabled = false;
                radRepat.Enabled = true;
                radFocusedModeOnly.Enabled = true;
                if (!radRepat.Checked)
                    radRepat.Checked = true;

                lbNote.Text = StringLoader.GetText("lb_tweak_task_9_note");
                txtPoint.Text = StringLoader.GetText("lb_initializing_mousem");
                return;
            }

            txtPoint.Enabled = false;
            txtCommand.Enabled = false;
            radRepat.Enabled = false;
            radFocusedModeOnly.Enabled = false;
        }


        private void cbGameGraphic_DropDownClosed(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


        int j = 0;
        private void timerCBMcrMoveUpDown_Tick(object sender, EventArgs e)
        {
            if (h <= 0 || height <= 0)
                return;

            if (cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6 || cbGameGraphic.SelectedIndex == 7)
            {
                int maxh = cbGameGraphic.Height;
                if (j >= maxh + 2)
                {
                    timerCBMcrMoveUpDown.Stop();
                    return;

                }

                j += 2;
                txtCommand.Location = new Point(txtCommand.Location.X, txtCommand.Location.Y + 2);
                txtCommand.Height -= 2;
                txtPoint.Location = txtCommand.Location;
                txtPoint.Height = txtCommand.Height;
            }
            else
            {
                if (txtCommand.Location.Y <= h)
                {
                    txtCommand.Location = new Point(txtCommand.Location.X, h);
                    txtPoint.Location = txtCommand.Location;

                    txtCommand.Height = height;
                    txtPoint.Height = txtCommand.Height;

                    timerCBMcrMoveUpDown.Stop();
                    j = 0;
                    return;
                }

                txtCommand.Location = new Point(txtCommand.Location.X, txtCommand.Location.Y - cbGameGraphic.Height / 3);
                txtCommand.Height += cbGameGraphic.Height / 3;
                txtPoint.Location = txtCommand.Location;
            }
        }

        private void timerCBMacr_Tick(object sender, EventArgs e)
        {

            if (cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6 || cbGameGraphic.SelectedIndex == 7)
            {
                if (cbMacroKey.Width >= cbGameGraphic.Width)
                {
                    cbMacroKey.Enabled = true;
                    cbMacroKey.Width = cbGameGraphic.Width;
                    timerCBMacr.Stop();
                    timerCBMcrMoveUpDown.Start();
                    return;
                }

                cbMacroKey.Width += cbGameGraphic.Width/5;
            }
            else
            {
           
                if (cbMacroKey.Width <= 0)
                {
                    cbMacroKey.Width = 0;
                    cbMacroKey.Enabled = false;
                    timerCBMacr.Stop();
                    timerCBMcrMoveUpDown.Start();
                    return;
                }

                cbMacroKey.Width -= cbGameGraphic.Width / 3;
            }
        }

        int i = 0;
        int h = 0;
        int height = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int maxh = cbGameGraphic.Height;

            i += 2;
            cbGameGraphic.Visible = true;
            txtCommand.Location = new Point(txtCommand.Location.X, txtCommand.Location.Y + 2);
            cbMacroKey.Location = new Point(cbMacroKey.Location.X, txtCommand.Location.Y + 2);
            txtPoint.Location = txtCommand.Location;
            if (i >= maxh + 2)
            {
                h = txtCommand.Location.Y;
                height = txtCommand.Height;
                timer1.Stop(); 
                cbMacroKey.Visible = true;
                timerCBMacr.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3Delay.Start();
            //if (panel1.Width >= ((MainForm.mf.tableLayoutPanel2.Width) * 48) / 100)
            //{
            //    timer2.Stop();
            //    timer3Delay.Start();
            //}

        }

        private void timer3Delay_Tick(object sender, EventArgs e)
        {
            timer3Delay.Stop();
            timer1.Start();
        }

        bool delay = false;
        bool delay2 = false;
        private void timer3PointerInGame_Tick(object sender, EventArgs e)
        {
            if (Methods.IsGameRunning_Alt() && (cbGameGraphic.SelectedIndex == 4 | cbGameGraphic.SelectedIndex == 5))
            {
                if(!delay)
                {
                    delay = true;
                    timer3PointerInGame.Interval = 3000;
                    txtPoint.Text = StringLoader.GetText("lb_initializing");
                    return;
                }

                if(delay && !delay2)
                {
                    delay2 = true;
                    timer3PointerInGame.Interval = 1000;
                    txtPoint.Text = StringLoader.GetText("lb_tweak_task_5_hint2");
                    return;
                }

                timer3PointerInGame.Interval = 120;

                var hWnd = Methods.ProcessHandler();
                NativeMethods.RECT rc = new NativeMethods.RECT();
                NativeMethods.GetWindowRect(hWnd, ref rc);
                Rectangle rect = new Rectangle(rc.left, rc.top, rc.right, rc.bottom);
                Point p = Cursor.Position;

                var x = (Cursor.Position.X - rc.left).ToString();
                var y = (Cursor.Position.Y - rc.top).ToString();

                if (!Methods.IsGameFullScreen())
                    y = (Cursor.Position.Y - rc.top - Methods.GetTitlebarHeight(hWnd)).ToString();

                if (rect.Contains(p))
                {
                    if(MainForm.mf != null && !MainForm.mf.FormActivated)
                    {
                        txtPoint.Text = StringLoader.GetText("lb_tweak_task_5_hint") + Environment.NewLine + Environment.NewLine + x + "," + y ;
                        txtPoint.SelectionLength = 0;
                        txtPoint.SelectionStart = txtPoint.Text.Length;
                    }
                    else if(MainForm.mf != null && MainForm.mf.FormActivated)
                    {
                        txtPoint.Text = txtPoint.Text.Replace(StringLoader.GetText("lb_tweak_task_5_hint"),"").Trim();
                        txtPoint.SelectionLength = 0;
                        txtPoint.SelectionStart = txtPoint.Text.Length;
                    }
                }
            }
            else if(cbGameGraphic.SelectedIndex == 7 || cbGameGraphic.SelectedIndex == 8)
            {
                delay = false;
                delay2 = false;
                timer3PointerInGame.Interval = 120;

                Point p = GetCursorPosition();

                if (MainForm.mf != null && !MainForm.mf.FormActivated)
                {
                    txtPoint.Text = StringLoader.GetText("lb_tweak_task_5_hint") + Environment.NewLine + Environment.NewLine + p.X + "," + p.Y;
                    txtPoint.SelectionLength = 0;
                    txtPoint.SelectionStart = txtPoint.Text.Length;
                }
                else if (MainForm.mf != null && MainForm.mf.FormActivated)
                {
                    txtPoint.Text = txtPoint.Text.Replace(StringLoader.GetText("lb_tweak_task_5_hint"), "").Trim();
                    txtPoint.SelectionLength = 0;
                    txtPoint.SelectionStart = txtPoint.Text.Length;
                }
            }
            else
            {
                delay = false;
                delay2 = false;
                timer3PointerInGame.Interval = 120;
            }
        }

        public static Point GetCursorPosition()
        {
            NativeMethods.POINTS lpPoint;
            NativeMethods.GetCursorPos(out lpPoint);
            // NOTE: If you need error handling
            // bool success = GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        /* private void CreateFormForCoordination(Rectangle smthing)
         {
             foreach (Form form in Application.OpenForms)
             {
                 if (form.GetType() == typeof(AutoTaskForm_CoordinationForm))
                 {
                     form.Activate();
                     return;
                 }
             }

             var frm = new AutoTaskForm_CoordinationForm
             {
                 Width = smthing.Width,
                 Height = smthing.Height,
                 Location = new Point(smthing.X, smthing.Y)
             };

             frm.Show();        
         }*/

        private void txtPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lbAFK_hint_Click(object sender, EventArgs e)
        {
            MainForm.mf.isSecondTask = !MainForm.mf.isSecondTask;
            if (MainForm.mf.isSecondTask)
                lbAFK_hint.Text = StringLoader.GetText("lb_tweak_task_interval_hint") + ":";
            else
                lbAFK_hint.Text = StringLoader.GetText("lb_tweak_task_interval_hint2") + ":";
        }

        private void cbMacroKey_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if(cbGameGraphic.SelectedIndex == 5 || cbGameGraphic.SelectedIndex == 6)
                KeyboardMacro.cbKeyboardList.SelectedIndex = cbMacroKey.SelectedIndex;

            if (cbGameGraphic.SelectedIndex == 7)
                KeyboardMacro.cbMouseList.SelectedIndex = cbMacroKey.SelectedIndex;

            ////does not work because it doesnt support dropdownlist
            //if (Keyboarde.cbKeyboardList.SelectedIndex > 0)
            //{
            //    var item = StringLoader.GetText("cb_key_selected", (Keyboarde.cbKeyboardList.SelectedItem as Keyboarde.KeyList).ToString());
            //    BeginInvoke((MethodInvoker)delegate { cbMacroKey.Text = item; });
            //}
        }

        private void radFocusedModeOnly_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (!radFocusedModeOnly.Checked)
                radFocusedModeOnly.CheckState = CheckState.Indeterminate;
            else
                radFocusedModeOnly.Checked = false;
        }

        private void radFocusedModeOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (radFocusedModeOnly.Checked)
            {
                radFocusedModeOnly.CheckState = CheckState.Indeterminate;
            }
        }

        private void radRepat_CheckedChanged(object sender, EventArgs e)
        {
            if (radRepat.Checked)
            {
                radRepat.CheckState = CheckState.Indeterminate;
            }
        }

        bool checkHistory = false;
        private void radRepat_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (!radRepat.Checked)
                radRepat.CheckState = CheckState.Indeterminate;
            else
                radRepat.Checked = false;

            checkHistory = radRepat.Checked;
        }

        /*private void lbClickToGetCoor_Click(object sender, EventArgs e)
        {
            var hWnd = Methods.ProcessHandler();
            if(hWnd != (IntPtr)null)
            {
                NativeMethods.RECT rc = new NativeMethods.RECT();
                NativeMethods.GetWindowRect(hWnd, ref rc);
                Rectangle rect = new Rectangle(rc.left, rc.top, rc.right, rc.bottom);
                CreateFormForCoordination(rect);
            }
            else
            {
                MessageBox.Show("Please run the game first");
            }
        }*/
    }
}
