using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    public class ProgressBarEx : System.Windows.Forms.ProgressBar
    {
        public ProgressBarEx()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(-2, 1, Width+6, Height+1);
            double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)((rec.Width * scaleFactor) -2 ); //4
            rec.Height -=2;
            brush = new LinearGradientBrush(rec, ForeColor, BackColor, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(brush, 0, 1, rec.Width, rec.Height);
        }
    }
}
