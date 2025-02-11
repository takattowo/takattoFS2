using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    class TextBoxEx : TextBox
    {
        bool isPlaceHolder = true;
        string _placeHolderText;
        Color _placeHolderColor = Color.Gray;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = " " + value;
                setPlaceholder();
            }
        }
        public Color PlaceHolderColor
        {
            get { return _placeHolderColor; }
            set
            {
                _placeHolderColor = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? "" : base.Text;
            set => base.Text = value;
        }

        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(base.Text))
            {
                base.Text = PlaceHolderText;
                ForeColor = PlaceHolderColor;
                isPlaceHolder = true;
            }
        }


        //when the control is focused, the placeholder is removed
        private void removePlaceHolder()
        {
            if (isPlaceHolder)
            {
                base.Text = "";
                ForeColor = System.Drawing.SystemColors.WindowText;
                Font = new Font(Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public TextBoxEx()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
            TextChanged += textChanged;
            Click += onClicked;
            MouseLeave += onClicked;
        }

        private void onClicked(object sender, EventArgs e)
        {
            if (SelectionStart == 0)
            {
                SelectionStart = 1;
                //if (SelectionLength >= 2)
                //{
                //    if(SelectionLength >= Text.Trim().Length)
                //        SelectionLength = Text.Trim().Length;
                //    else
                //        SelectionLength = SelectionLength - 1;
                //}
                //else
                    SelectionLength = SelectionLength;

                if(string.IsNullOrWhiteSpace(SelectedText))
                    SelectionLength = 0;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            var spaceEnding = false;
            var textBox = sender as TextBox;
            if (textBox.Text.EndsWith(" "))
                spaceEnding = true;
            int pad = 1;
            int cursorPos = textBox.SelectionStart;
            textBox.Text = textBox.Text.Trim().PadLeft(textBox.Text.Trim().Length + pad) + ((spaceEnding) ? " " : string.Empty);
            
            if(textBox.Text.Length > 2)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text[2].ToString()))
                {
                    textBox.Text = textBox.Text.Remove(2, 1);
                }
            }
            
            textBox.SelectionStart = (cursorPos > pad ? cursorPos : pad);   
        }

        public void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        public void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }
}
