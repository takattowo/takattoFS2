using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BorderlessForm
{
    class ColorEnum
    {
        private static Color hoverTextColor = Color.FromArgb(62, 109, 181);

        public static Color HoverTextColor
        {
            get { return hoverTextColor; }
            set { hoverTextColor = value; }
        }

        private static Color downTextColor = Color.FromArgb(25, 71, 138);

        public static Color DownTextColor
        {
            get { return downTextColor; }
            set { downTextColor = value; }
        }

        private static Color hoverBackColor = Color.FromArgb(213, 225, 242);

        public static Color HoverBackColor
        {
            get { return hoverBackColor; }
            set { hoverBackColor = value; }
        }

        private static Color downBackColor = Color.FromArgb(163, 189, 227);

        public static Color DownBackColor
        {
            get { return downBackColor; }
            set { downBackColor = value; }
        }

        private static Color normalBackColor = Color.White;

        public static Color NormalBackColor
        {
            get { return normalBackColor; }
            set { normalBackColor = value; }
        }

        public enum MouseState
        {
            Normal,
            Hover,
            Down
        }

        public static void SetBorderColor(Color color, List<Control> _controls)
        {
            for (int i = 0; i<_controls.Count;i++)
                _controls[i].BackColor = color;
        }

        public static void SetTextColor(Color color, List<Control> _controls)
        {
            for (int i = 0; i < _controls.Count; i++)
                _controls[i].ForeColor = color;
        }

        public static void SetLabelColors(Control control, MouseState state, bool ContainsFocus)
        {
            if (!ContainsFocus) return;

            var textColor = ActiveTextColor;
            var backColor = NormalBackColor;

            switch (state)
            {
                case MouseState.Hover:
                    textColor = HoverTextColor;
                    backColor = HoverBackColor;
                    break;
                case MouseState.Down:
                    textColor = DownTextColor;
                    backColor = DownBackColor;
                    break;
            }

            control.ForeColor = textColor;
            control.BackColor = backColor;
        }

        private static Color activeTextColor = Color.FromArgb(68, 68, 68);

        public static Color ActiveTextColor
        {
            get { return activeTextColor; }
            set { activeTextColor = value; }
        }

        private static Color inactiveTextColor = Color.FromArgb(177, 177, 177);

        public static Color InactiveTextColor
        {
            get { return inactiveTextColor; }
            set { inactiveTextColor = value; }
        }


        private static Color activeBorderColor = Color.FromArgb(43, 87, 154);

        public static Color ActiveBorderColor
        {
            get { return activeBorderColor; }
            set { activeBorderColor = value; }
        }

        private static Color inactiveBorderColor = Color.FromArgb(131, 131, 131);

        public static Color InactiveBorderColor
        {
            get { return inactiveBorderColor; }
            set { inactiveBorderColor = value; }
        }
    }
}
