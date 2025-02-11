using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    class RoundedPicturebox : PictureBox
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            using (var gp = new GraphicsPath())
            {
                Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
                gp.AddEllipse(r);
                Region = new Region(gp);

            }

        }
        
    }

}
