﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    class ButtonX : System.Windows.Forms.Button
    {
        Color clr1;
        private Color color = Color.Teal;
        private Color m_hovercolor = Color.FromArgb(0, 0, 140);
        private Color clickcolor = Color.FromArgb(160, 180, 200);
        private int textX = 6;
        private int textY = -20;
        private String text = "_";
        private bool isChanged = true;

        public String DisplayText
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }
        public Color BXBackColor
        {
            get { return color; }
            set { color = value; Invalidate(); }
        }

        public Color MouseHoverColor
        {
            get { return m_hovercolor; }
            set { m_hovercolor = value; Invalidate(); }
        }

        public Color MouseClickColor1
        {
            get { return clickcolor; }
            set { clickcolor = value; Invalidate(); }
        }

        public bool ChangeColorMouseHC
        {
            get { return isChanged; }
            set { isChanged = value; Invalidate(); }
        }


        public int TextLocation_X
        {
            get { return textX; }
            set { textX = value; Invalidate(); }
        }
        public int TextLocation_Y
        {
            get { return textY; }
            set { textY = value; Invalidate(); }
        }
        public ButtonX()
        {
            this.Size = new System.Drawing.Size(31, 24);
            this.ForeColor = Color.White;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Text = "_";
            text = this.Text;
        }

        //method mouse enter
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            clr1 = color;
            color = m_hovercolor;
        }

        //method mouse leave
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (isChanged)
            {
                color = clr1;
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (isChanged)
            {
                color = clickcolor;
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (isChanged)
            {
                color = clr1;
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            text = this.Text;
            if (textX == 100 && textY == 25)
            {
                textX = ((this.Width) / 3) + 10;
                textY = (this.Height / 2) - 1;
            }

            Point p = new Point(textX, textY);
            pe.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
            pe.Graphics.DrawString(text, this.Font, new SolidBrush(this.ForeColor), p);
        }

    }
}
