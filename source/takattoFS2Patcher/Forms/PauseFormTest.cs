using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using takattoFS2.Helpers;

namespace takattoFS2.Forms
{
    public partial class PauseFormTest : Form 
    {
        //static PatchingForm _frmObj;
        //public static PatchingForm frmObj
        //{
        //    get { return _frmObj; }
        //    set { _frmObj = value; }
        //}

        public PauseFormTest()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Rectangle screenRectangle = RectangleToScreen(ClientRectangle);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height + (screenRectangle.Top - Top - 2));
        }


        private void ConnectingForm_New_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormBorderStyle = FormBorderStyle.Sizable;
            Text = string.Empty;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ControlBox = false;
            ActiveControl = null;

            WindowState = FormWindowState.Minimized;
            TopMost = true;
            Show();
            TopMost = true;
            WindowState = FormWindowState.Normal;
          
            closeToolStripMenuItem.Text = StringLoader.GetText("btn_close");
        }
        
        public int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Methods.IsGameRunning_Alt())
                return;
            
            count += 1;
            if(state)
            {
                if (Methods.suspended == false)
                {
                    state = false;
                    btnPause.BackgroundImage = Properties.Resources.icons8_play_25;
                    return;
                }

                if (count > 90)
                {
                    state = false;
                    btnPause.BackgroundImage = Properties.Resources.icons8_play_25;
                    if(Methods.suspended == true)
                        Methods.SuspendGame();
                }
            }
        }

        bool state = false;
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!Methods.IsGameRunning_Alt())
                return;
            
            if(!state)
            {
                state = true;
                btnPause.BackgroundImage = Properties.Resources.icons8_pause_25;
                if (Methods.suspended == false)
                    Methods.SuspendGame();
                count = 0;
            }
            else
            {
                state = false;
                btnPause.BackgroundImage = Properties.Resources.icons8_play_25;
                if (Methods.suspended == true)
                    Methods.SuspendGame();
            }            
        }
        
        private void btnPause_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, (int)NativeMethods.WindowMessages.WM_NCLBUTTONDOWN, (int)NativeMethods.HitTestValues.HTCAPTION, 0);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Contains("notimer"))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
            else if (toolStripTextBox1.Text.Contains("xc"))
            {

                timer2.Enabled = true;
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }

        bool xcapploed = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Methods.IsGameRunning_Alt())
            {
                if (!xcapploed)
                {
                    xcapploed = true;
                    try
                    {
                        File.Move(Methods.GetGameFolder() + "\\XIGNCODE\\x3.xem",
                                  Methods.GetGameFolder() + "\\XIGNCODE\\x3c.xem");
                    }
                    catch { }
                    File.Copy(Methods.GetGameFolder() + "\\XIGNCODE\\x31.xem", Methods.GetGameFolder() + "\\XIGNCODE\\x3.xem", true);
                }
            }
           else
            {
                if (xcapploed)
                {
                    xcapploed = false;
                    File.Copy(Methods.GetGameFolder() + "\\XIGNCODE\\x3c.xem", Methods.GetGameFolder() + "\\XIGNCODE\\x3.xem", true);
                }
            }
        }
    }
}
