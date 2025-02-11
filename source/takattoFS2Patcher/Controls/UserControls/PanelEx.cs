using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace takattoFS2.Controls.UserControls
{
    class PanelEx : Panel
    {
        private Color colorBorder = Color.Transparent;

        public PanelEx() : base()
        {
            //DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            e.Graphics.DrawRectangle(
                new Pen(
                    new SolidBrush(colorBorder), 2),
                    e.ClipRectangle);
        }
        public Color BorderColor
        {
            get
            {
                return colorBorder;
            }
            set
            {
                colorBorder = value;
            }
        }
    }

}
