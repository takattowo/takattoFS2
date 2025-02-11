using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls
{
    class ColorEnum
    {
        private static Color hoverTextColor = Color.FromArgb(62, 109, 181);

        internal static Color HoverTextColor
        {
            get { return hoverTextColor; }
            set { hoverTextColor = value; }
        }

        private static Color downTextColor = Color.FromArgb(25, 71, 138);

        internal static Color DownTextColor
        {
            get { return downTextColor; }
            set { downTextColor = value; }
        }

        private static Color hoverBackColor = Color.FromArgb(213, 225, 242);

        internal static Color HoverBackColor
        {
            get { return hoverBackColor; }
            set { hoverBackColor = value; }
        }

        private static Color downBackColor = Color.FromArgb(163, 189, 227);

        internal static Color DownBackColor
        {
            get { return downBackColor; }
            set { downBackColor = value; }
        }

        private static Color normalBackColor = Color.Transparent;

        internal static Color NormalBackColor
        {
            get { return normalBackColor; }
            set { normalBackColor = value; }
        }

        internal enum MouseState
        {
            Normal,
            Hover,
            Down
        }

        internal static void SetBorderColor(Color color, List<Control> _controls)
        {
            for (int i = 0; i < _controls.Count; i++)
                _controls[i].BackColor = color;
        }

        internal static void SetTextColor(Color color, List<Control> _controls)
        {
            for (int i = 0; i < _controls.Count; i++)
                _controls[i].ForeColor = color;
        }

        internal static void SetLabelColors(Control control, MouseState state, bool ContainsFocus)
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

        //button color for tweak//
        private static Color normalBtnForce = Color.FromArgb(66,66,66);
        internal static Color NormalBtnForce
        {
            get { return normalBtnForce; }
            set { normalBtnForce = value; }
        }

        private static Color normalBtnBg = Color.Transparent; 
        internal static Color NormalBtnBg
        {
            get { return normalBtnBg; }
            set { normalBtnBg = value; }
        }

        private static Color focusedBtnForce = Color.FromArgb(17, 125, 215);
        internal static Color FocusedBtnForce
        {
            get { return focusedBtnForce; }
            set { focusedBtnForce = value; }
        }

        private static Color focuseBtnBg = Color.FromArgb(242, 244, 252);
        internal static Color FocuseBtnBg
        {
            get { return focuseBtnBg; }
            set { focuseBtnBg = value; }
        }
        //end

        private static Color activeTextColor = Color.WhiteSmoke;//Color.FromArgb(36, 41, 46);
        internal static Color ActiveTextColor
        {
            get { return activeTextColor; }
            set { activeTextColor = value; }
        }

        private static Color inactiveTextColor = Color.FromArgb(133,136,139);

        internal static Color InactiveTextColor
        {
            get { return inactiveTextColor; }
            set { inactiveTextColor = value; }
        }

        private static Color mainColor = Color.FromArgb(36, 41, 46);
        internal static Color MainColor
        {
            get { return mainColor; }
            set { mainColor = value; }
        }

        //private static Color activeBorderColor = Color.FromArgb(36, 41, 46);
        private static Color activeBorderColor = Color.FromArgb(36, 41, 46);

        internal static Color ActiveBorderColor
        {
            get { return activeBorderColor; }
            set { activeBorderColor = value; }
        }

        private static Color inactiveBorderColor = Color.FromArgb(36, 41, 46);

        internal static Color InactiveBorderColor
        {
            get { return inactiveBorderColor; }
            set { inactiveBorderColor = value; }
        }
    }
}
