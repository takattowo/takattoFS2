using System.Windows.Forms;
using takattoFS2.Helpers;

namespace takattoFS2.Controls.UserControls
{
    class DrawingControl
    {
        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            NativeMethods.SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            NativeMethods.SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }

}
