using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2.Controls.UserControls
{
    public class TextBoxPwEx : TextBox
    {
        bool isPassword = true;
        bool isPlaceHolder = true;
        string _placeHolderText;
        Color _placeHolderColor = Color.Gray;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }
        public bool IsPassword
        {
            get { return isPassword; }
            set
            {
                isPassword = value;
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
            if (string.IsNullOrWhiteSpace(base.Text) || Text.Contains(PlaceHolderText))
            {
                PasswordChar = Convert.ToChar(0);
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
                if(isPassword)
                    PasswordChar = '✻';

                base.Text = "";
                ForeColor = System.Drawing.SystemColors.WindowText;
                Font = new Font(Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public TextBoxPwEx()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
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
