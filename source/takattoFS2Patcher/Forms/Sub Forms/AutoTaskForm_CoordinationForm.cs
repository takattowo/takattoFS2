using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Forms.Sub_Forms
{
    public partial class AutoTaskForm_CoordinationForm : Form
    {
        public AutoTaskForm_CoordinationForm()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            Cursor = new Cursor(Properties.Resources.cur_1.GetHicon());
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormBorderStyle = FormBorderStyle.Sizable;
            Text = string.Empty;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ControlBox = false;
            ActiveControl = null;
        }
    }
}
