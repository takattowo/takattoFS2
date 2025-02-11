using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BorderlessForm
{
    public partial class MainForm : FormBase
    {
      
        public MainForm()
        {
            InitializeComponent();
            InitializeTitleBar();
        }

        private void InitializeTitleBar()
        {
            Activated += MainForm_Activated;
            Deactivate += MainForm_Deactivate;

            foreach (var control in new[] { SystemLabel, MinimizeLabel, CloseLabel })
            {
                control.MouseEnter += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Hover, ContainsFocus);
                control.MouseLeave += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, ContainsFocus);
                control.MouseDown += (s, e) => ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Down, ContainsFocus);
            }

            TitleLabel.MouseDown += TitleLabel_MouseDown;
            TitleLabel.MouseUp += (s, e) => { if (e.Button == MouseButtons.Right && TitleLabel.ClientRectangle.Contains(e.Location)) ShowSystemMenu(MouseButtons); };
            TitleLabel.Text = Text;
            TextChanged += (s, e) => TitleLabel.Text = Text;

            var marlett = new Font("Marlett", 8.5f);

            MinimizeLabel.Font = marlett;
            CloseLabel.Font = marlett;
            SystemLabel.Font = marlett;

            MinimizeLabel.MouseClick += (s, e) => { if (e.Button == MouseButtons.Left) WindowState = FormWindowState.Minimized; ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, !ContainsFocus); };
            CloseLabel.MouseClick += (s, e) => { Close(e); ColorEnum.SetLabelColors((Control)s, ColorEnum.MouseState.Normal, !ContainsFocus); };
        }
        void Close(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) Close();
        }
        void MainForm_Deactivate(object sender, EventArgs e)
        {
            ColorEnum.SetBorderColor(ColorEnum.InactiveBorderColor, new List<Control> { TopBorderPanel, LeftBorderPanel, RightBorderPanel, BottomBorderPanel });
            ColorEnum.SetTextColor(ColorEnum.InactiveTextColor, new List<Control> { SystemLabel, TitleLabel, MinimizeLabel, CloseLabel });
        }
        void MainForm_Activated(object sender, EventArgs e)
        {
            ColorEnum.SetBorderColor(ColorEnum.ActiveBorderColor, new List<Control> { TopBorderPanel, LeftBorderPanel, RightBorderPanel, BottomBorderPanel });
            ColorEnum.SetTextColor(ColorEnum.ActiveTextColor, new List<Control> { SystemLabel, TitleLabel, MinimizeLabel, CloseLabel });
        }
        private Point titleClickPosition = Point.Empty;
        void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                titleClickPosition = e.Location;
                DecorationMouseDown(HitTestValues.HTCAPTION);
            }
        }
    }
}
