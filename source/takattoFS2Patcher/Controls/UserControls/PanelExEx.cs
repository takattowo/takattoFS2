﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    class PanelExEx : Panel
    {
        Pen pen;
        readonly float penWidth = 2.0f;
        int _edge = 20;
        Color _borderColor = Color.White;
        public int Edge
        {
            get
            {
                return _edge;
            }
            set
            {
                _edge = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                pen = new Pen(_borderColor, penWidth);
                Invalidate();
            }
        }

        public PanelExEx()
        {
            pen = new Pen(_borderColor, penWidth);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ExtendedDraw(e);
            //DrawBorder(e.Graphics);
        }

        private void ExtendedDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Edge), 180, 90);
            path.AddLine(Edge, 0, Width - Edge, 0);
            path.AddArc(GetRightUpper(Edge), 270, 90);
            path.AddLine(Width, Edge, Width, Height - Edge);
            path.AddArc(GetRightLower(Edge), 0, 90);
            path.AddLine(Width - Edge, Height, Edge, Height);
            path.AddArc(GetLeftLower(Edge), 90, 90);
            path.AddLine(0, Height - Edge, 0, Edge);
            path.CloseFigure();

            Region = new Region(path);
        }

        Rectangle GetLeftUpper(int e)
        {
            return new Rectangle(0, 0, e, e);
        }
        Rectangle GetRightUpper(int e)
        {
            return new Rectangle(Width - e, 0, e, e);
        }
        Rectangle GetRightLower(int e)
        {
            return new Rectangle(Width - e, Height - e, e, e);
        }
        Rectangle GetLeftLower(int e)
        {
            return new Rectangle(0, Height - e, e, e);
        }

        void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(pen, new Rectangle(0, 0, Edge, Edge), 180, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, -1, Edge, Edge), 270, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, Height - Edge - 1, Edge, Edge), 0, 90);
            graphics.DrawArc(pen, new Rectangle(0, Height - Edge - 1, Edge, Edge), 90, 90);

            graphics.DrawRectangle(pen, 0.0F, 0.0F, Width - 1, Height - 1);
        }

        void DrawBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
    }
}