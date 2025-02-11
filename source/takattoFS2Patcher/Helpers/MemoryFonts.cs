using System;
using System.Drawing.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace takattoFS2.Helpers
{
    public static class MemoryFonts
    {
        private static PrivateFontCollection pfc { get; set; }

        static MemoryFonts()
        {
            if (pfc == null) { pfc = new PrivateFontCollection(); }
        }
        
        public static void AddMemoryFont(byte[] fontResource)
        {
            IntPtr p;
            uint c = 0;

            p = Marshal.AllocCoTaskMem(fontResource.Length);
            Marshal.Copy(fontResource, 0, p, fontResource.Length);
            NativeMethods.AddFontMemResourceEx(p, (uint)fontResource.Length, IntPtr.Zero, ref c);
            pfc.AddMemoryFont(p, fontResource.Length);
            Marshal.FreeCoTaskMem(p);

            p = IntPtr.Zero;
        }

        public static Font SetFont(int fontIndex, float fontSize = 20, float offset = 0, FontStyle fontStyle = FontStyle.Regular)
        {
            return new Font(pfc.Families[fontIndex], (float)(fontSize + offset), fontStyle);
        }

        public static string UnicodeToChar(string hex)
        {
            int code = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            string unicodeString = char.ConvertFromUtf32(code);
            return unicodeString;
        }

    }
}
