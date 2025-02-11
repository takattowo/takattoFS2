using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    public partial class SweetLoveLetterForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public SweetLoveLetterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void SweetLoveLetterForm_Load(object sender, EventArgs e)
        {
            pChar1.Parent = pBG;
            pChar1.Parent.BackColor = Color.Transparent;
            pChar1.Location = new Point(75,91);

            pChar2.Parent = pBG;
            pChar2.Parent.BackColor = Color.Transparent;
            pChar2.Location = new Point(397, 61);

            pChar3.Parent = pBG;
            pChar3.Parent.BackColor = Color.Transparent;
            pChar3.Location = new Point(674, 65);
        }
    }
}
