using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using takattoFS2.Helpers;
using static InputManager.Mouse;

namespace takattoFS2.Controls
{
    public class KeyboardMacro
    {
        public class KeyList
        {
            private string Name { get; set; }
            public Keys Value { get; set; }
            public KeyList(string text, System.Windows.Forms.Keys value)
            {
                Name = text;
                Value = value;
            }

            public override string ToString() { return Name; }
            public Keys ToKey() { return Value; }
        }

        public class MouseList
        {
            private string Name { get; set; }
            public MouseKeys Value { get; set; }
            public MouseList(string text, MouseKeys value)
            {
                Name = text;
                Value = value;
            }

            public override string ToString() { return Name; }
            public MouseKeys ToKey() { return Value; }
        }

        internal static ComboBox cbKeyboardList;
        internal static ComboBox cbMouseList;
        internal static void PopulateKeyboardListCB()
        {
            PopulateComboBox(cbKeyboardList = new ComboBox());
            PopulateComboBoxMouse(cbMouseList = new ComboBox());
        }

        private static void PopulateComboBoxMouse(ComboBox comboBox)
        {
            comboBox.Items.Add(new MouseList(StringLoader.GetText("cb_key_select"), MouseKeys.Left));

            comboBox.Items.Add(new MouseList("L_MOUSE", MouseKeys.Left));
            comboBox.Items.Add(new MouseList("R_MOUSE", MouseKeys.Right));
            comboBox.Items.Add(new MouseList("M_MOUSE", MouseKeys.Middle));
            comboBox.Items.Add(new MouseList("DOUBLE_L_MOUSE", MouseKeys.Left));
            comboBox.Items.Add(new MouseList("DOUBLE_R_MOUSE", MouseKeys.Left));
            comboBox.Items.Add(new MouseList("DOUBLE_M_MOUSE", MouseKeys.Left));

            comboBox.SelectedIndex = 0;
        }

        private static void PopulateComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add(new KeyList(StringLoader.GetText("cb_key_select"), Keys.F13));
            comboBox.Items.Add(new KeyList("A", Keys.A));
            comboBox.Items.Add(new KeyList("B", Keys.B));
            comboBox.Items.Add(new KeyList("C", Keys.C));
            comboBox.Items.Add(new KeyList("D", Keys.D));
            comboBox.Items.Add(new KeyList("E", Keys.E));
            comboBox.Items.Add(new KeyList("F", Keys.F));
            comboBox.Items.Add(new KeyList("G", Keys.G));
            comboBox.Items.Add(new KeyList("H", Keys.H));
            comboBox.Items.Add(new KeyList("I", Keys.I));
            comboBox.Items.Add(new KeyList("K", Keys.K));
            comboBox.Items.Add(new KeyList("L", Keys.L));
            comboBox.Items.Add(new KeyList("M", Keys.M));
            comboBox.Items.Add(new KeyList("N", Keys.N));
            comboBox.Items.Add(new KeyList("O", Keys.O));
            comboBox.Items.Add(new KeyList("P", Keys.P));
            comboBox.Items.Add(new KeyList("Q", Keys.Q));
            comboBox.Items.Add(new KeyList("R", Keys.R));
            comboBox.Items.Add(new KeyList("S", Keys.S));
            comboBox.Items.Add(new KeyList("T", Keys.T));
            comboBox.Items.Add(new KeyList("U", Keys.U));
            comboBox.Items.Add(new KeyList("V", Keys.V));
            comboBox.Items.Add(new KeyList("W", Keys.W));
            comboBox.Items.Add(new KeyList("X", Keys.X));
            comboBox.Items.Add(new KeyList("Y", Keys.Y));
            comboBox.Items.Add(new KeyList("Z", Keys.Z));

            comboBox.Items.Add(new KeyList("0", Keys.D0));
            comboBox.Items.Add(new KeyList("1", Keys.D1));
            comboBox.Items.Add(new KeyList("2", Keys.D2));
            comboBox.Items.Add(new KeyList("3", Keys.D3));
            comboBox.Items.Add(new KeyList("4", Keys.D4));
            comboBox.Items.Add(new KeyList("5", Keys.D5));
            comboBox.Items.Add(new KeyList("6", Keys.D6));
            comboBox.Items.Add(new KeyList("7", Keys.D7));
            comboBox.Items.Add(new KeyList("8", Keys.D8));
            comboBox.Items.Add(new KeyList("9", Keys.D9));
            comboBox.Items.Add(new KeyList("Numpad0", Keys.NumPad0));
            comboBox.Items.Add(new KeyList("Numpad1", Keys.NumPad1));
            comboBox.Items.Add(new KeyList("Numpad2", Keys.NumPad2));
            comboBox.Items.Add(new KeyList("Numpad3", Keys.NumPad3));
            comboBox.Items.Add(new KeyList("Numpad4", Keys.NumPad4));
            comboBox.Items.Add(new KeyList("Numpad5", Keys.NumPad5));
            comboBox.Items.Add(new KeyList("Numpad6", Keys.NumPad6));
            comboBox.Items.Add(new KeyList("Numpad7", Keys.NumPad7));
            comboBox.Items.Add(new KeyList("Numpad8", Keys.NumPad8));
            comboBox.Items.Add(new KeyList("Numpad9", Keys.NumPad9));

            comboBox.Items.Add(new KeyList("F1", Keys.F1));
            comboBox.Items.Add(new KeyList("F2", Keys.F2));
            comboBox.Items.Add(new KeyList("F3", Keys.F3));
            comboBox.Items.Add(new KeyList("F4", Keys.F4));
            comboBox.Items.Add(new KeyList("F5", Keys.F5));
            comboBox.Items.Add(new KeyList("F6", Keys.F6));
            comboBox.Items.Add(new KeyList("F7", Keys.F7));
            comboBox.Items.Add(new KeyList("F8", Keys.F8));
            comboBox.Items.Add(new KeyList("F9", Keys.F9));
            comboBox.Items.Add(new KeyList("F10", Keys.F10));
            comboBox.Items.Add(new KeyList("F11", Keys.F11));
            comboBox.Items.Add(new KeyList("F12", Keys.F12));
            comboBox.Items.Add(new KeyList("F13 (ghost key)", Keys.F13));


            comboBox.Items.Add(new KeyList("Up", Keys.Up));
            comboBox.Items.Add(new KeyList("Down", Keys.Down));
            comboBox.Items.Add(new KeyList("Left", Keys.Left));
            comboBox.Items.Add(new KeyList("Right", Keys.Right));


            comboBox.Items.Add(new KeyList("LControl", Keys.LControlKey));
            comboBox.Items.Add(new KeyList("RControl", Keys.RControlKey));
            comboBox.Items.Add(new KeyList("LShift", Keys.LShiftKey));
            comboBox.Items.Add(new KeyList("RShift", Keys.RShiftKey));
            comboBox.Items.Add(new KeyList("Space", Keys.Space));
            comboBox.Items.Add(new KeyList("Enter", Keys.Enter));
            comboBox.Items.Add(new KeyList("Back", Keys.Back));
            comboBox.Items.Add(new KeyList("Tab", Keys.Tab));
            comboBox.Items.Add(new KeyList("Escape", Keys.Escape));
            comboBox.Items.Add(new KeyList("Insert", Keys.Insert));
            comboBox.Items.Add(new KeyList("Delete", Keys.Delete));
            comboBox.Items.Add(new KeyList("Home", Keys.Home));
            comboBox.Items.Add(new KeyList("End", Keys.End));
            comboBox.Items.Add(new KeyList("PgUp", Keys.PageUp));
            comboBox.Items.Add(new KeyList("PgDown", Keys.PageDown));

            comboBox.SelectedIndex = 0;
        }
    }
}
