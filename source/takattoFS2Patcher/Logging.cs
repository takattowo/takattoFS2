using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace takattoFS2
{
    public static class Logging
    {
        private static string _Path = string.Empty;
        private static bool DEBUG = true;

        public static string EnsureEndsWithDot(this string str)
        {
            if (str.EndsWith("~"))
                return str;
            if (str.EndsWith("!"))
                return str;
            if (str.EndsWith("?"))
                return str; 
            if (!str.EndsWith(".")) 
                return str + ".";
            return str;
        }

        public static void Write(string msg)
        {
            if (File.Exists(Path.Combine(PatcherSettings.PatchDir, "katlog.txt"))) //Convert.ToBoolean(takattoFS2.Properties.Settings.Default.logging)
            {
                try
                {
                    using (StreamWriter w = File.AppendText(Path.Combine(PatcherSettings.PatchDir, "katlog.txt")))
                    {
                        Log(EnsureEndsWithDot(msg), w);
                    }

                    if (DEBUG)
                        Console.WriteLine(EnsureEndsWithDot(msg));
                }
                catch
                {
                    //Handle
                }
            }        
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        static private void Log(string msg, TextWriter w)
        {
            try
            {
                w.Write("[{0}]", ConvertToUnixTimestamp(DateTime.Now));
                w.Write(" ");
                w.WriteLine("{0}", msg);
            }
            catch (Exception e)
            {
                w.Write("[{0}]", ConvertToUnixTimestamp(DateTime.Now));
                w.Write(" ");
                w.WriteLine("Unknow logging error." + e);
            }
        }
    }
}
