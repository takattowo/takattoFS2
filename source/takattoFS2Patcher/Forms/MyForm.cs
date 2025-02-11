using System;
using System.Linq;
using System.Windows.Forms;
using takattoFS2.Properties;

namespace takattoFS2.Forms
{
    public class MyForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            /*if (Properties.Settings.Default.IsMaximised)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(Properties.Settings.Default.DesktopBounds)))
            {
                StartPosition = FormStartPosition.Manual;
                DesktopBounds = Properties.Settings.Default.DesktopBounds;
                WindowState = FormWindowState.Normal;
            }
            */
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {/*
            Properties.Settings.Default.IsMaximised = WindowState == FormWindowState.Maximized;
            if (WindowState == FormWindowState.Minimized)
            {
                Properties.Settings.Default.DesktopBounds = RestoreBounds;
            }
            else
            {
                Properties.Settings.Default.DesktopBounds = DesktopBounds;
            }

            Properties.Settings.Default.Save();*/

            base.OnFormClosing(e);
        }
    }
}
