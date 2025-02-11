using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using takattoFS2.Helpers;

namespace takattoFS2.Controls.UserControls
{
    public class ComboBoxEx : ComboBox
    {
        public ComboBoxEx() : base()
        {
            MouseClick += new System.Windows.Forms.MouseEventHandler(comboBox_MouseClick);
            MouseUp += new System.Windows.Forms.MouseEventHandler(comboBox_MouseUp);
        }

        private void comboBox_MouseUp(object sender, MouseEventArgs e)
        {
            var uwu = sender as ComboBox;
            uwu.Select(0, 0);
            IntPtr EditHandle = NativeMethods.FindWindowEx(uwu.Handle, IntPtr.Zero, "Edit", null);
            NativeMethods.HideCaret(EditHandle);
        }
        private void comboBox_MouseClick(object sender, MouseEventArgs e)
        {
            var uwu = sender as ComboBox;
            uwu.Select(0, 0);
            IntPtr EditHandle = NativeMethods.FindWindowEx(uwu.Handle, IntPtr.Zero, "Edit", null);
            NativeMethods.HideCaret(EditHandle);
            uwu.DroppedDown = true;
        }

        private Color _borderColor = Color.Black;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static readonly int WM_PAINT = 0x000F;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle);
            }
            if (m.Msg == 0x0047)
            {   // WM_WINDOWPOSCHANGED = 0x0047 
                if (SelectionLength != 0)
                {
                    SelectionLength = 0;
                }
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }

        [Category("Appearance")]
        public ButtonBorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }
    }
}
