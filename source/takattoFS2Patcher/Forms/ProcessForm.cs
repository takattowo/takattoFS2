using System;
using System.Drawing;
using System.Windows.Forms;
using takattoFS2.Helpers;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Forms
{
    public partial class ProcessForm : Form
    {
        public ProcessForm()
        {
            InitializeComponent();

            LB1.Font = MemoryFonts.SetFont(1, LB1.Font.Size, PatcherSettings.fontOffset4, FontStyle.Regular);
            lb_langhintwhy.Font = MemoryFonts.SetFont(0, lb_langhintwhy.Font.Size, PatcherSettings.fontOffset1, FontStyle.Regular);
            btn_Return.Font = MemoryFonts.SetFont(0, btn_Return.Font.Size, PatcherSettings.fontOffset2, FontStyle.Regular);

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            lb_langhintwhy.Text = StringLoader.GetText("lb_wait_hint");
            LB1.Text = StringLoader.GetText("LB_wait_for_game");
            btn_Return.Text = StringLoader.GetText("btn_cancel");

            int style = NativeMethods.GetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE); //int style = NativeMethods.GetWindowLong(pnHi.Handle, NativeMethods.GWL_EXSTYLE);
            style |= NativeMethods.WS_EX_COMPOSITED;
            NativeMethods.SetWindowLong(panel1.Handle, NativeMethods.GWL_EXSTYLE, style);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            MainForm.mf.disable_aTimer();
            Close();
        }
    }
}
