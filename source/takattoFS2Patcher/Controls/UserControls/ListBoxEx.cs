using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    public class ListBoxEx : ListBox
    {
        public ListBoxEx() : base()
        {
            DrawItem += ListBoxEx_DrawItem;
            DrawItem += ListBoxEx_DrawHighLightItem;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void ListBoxEx_DrawHighLightItem(object sender, DrawItemEventArgs e)
        {
            var listBox = sender as ListBox;
            if (e.Index > -1)
            {
                Color textColor;         /*Default ForeColor*/
                string prefix;
                switch (listBox.GetItemText(listBox.Items[e.Index]).ToString())
                {
                    case string a when a.Contains("[NL]"):
                        prefix = "[NL]";
                        textColor = Color.DimGray;
                        break;
                    case string a when a.Contains("[AD]"):
                        prefix = "[AD]";
                        textColor = Color.DimGray;
                        break;
                    case string a when a.Contains("[STD]"):
                        prefix = "[STD]";
                        textColor = Color.Teal;
                        break;
                    case string a when a.Contains("[OB]"):
                        prefix = "[OB]";
                        textColor = Color.FromArgb(192,0,0);
                        break;
                    case string a when a.Contains("[EXT]"):
                        prefix = "[EXT]";
                        textColor = Color.PaleVioletRed;
                        break;
                    case string a when a.Contains("[BM]"):
                        prefix = "[BM]";
                        textColor = Color.MediumVioletRed;
                        break;
                    case string a when a.Contains("[TEST]"):
                        prefix = "[TEST]";
                        textColor = Color.Sienna;
                        break;
                    case string a when a.Contains("[WIP]"):
                        prefix = "[WIP]";
                        textColor = Color.IndianRed;
                        break;
                    case string a when a.Contains("[UI]"):
                        prefix = "[UI]";
                        textColor = Color.Olive;
                        break;
                    case string a when a.Contains("[FONT]"):
                        prefix = "[FONT]";
                        textColor = Color.CornflowerBlue;
                        break;
                    default:
                        prefix = "";
                        textColor = ForeColor;
                        break;
                }
                  
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    textColor = Color.FromArgb(217,242,255);

                TextRenderer.DrawText(e.Graphics, " " + prefix, listBox.Font, e.Bounds, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }

        public void ListBoxEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            var listBox = sender as ListBox;
            if (e.Index > -1)
            {
                var backColor = Color.White;         /*Default BackColor*/
                var textColor = ForeColor;         /*Default ForeColor*/
                var txt = listBox.GetItemText(listBox.Items[e.Index]);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    backColor = Color.FromArgb(3, 102, 214);        /*Seletion BackColor*/
                    textColor = Color.White;           /*Seletion ForeColor*/
                }

                using (var brush = new SolidBrush(backColor))
                    e.Graphics.FillRectangle(brush, e.Bounds);

                TextRenderer.DrawText(e.Graphics, txt, listBox.Font, e.Bounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }
    }
}
