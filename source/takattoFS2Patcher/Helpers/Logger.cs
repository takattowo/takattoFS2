using System;
using System.IO;
using takattoFS2.Controls;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Helpers
{
    internal static class Logger
    {
        private static readonly bool DEBUG = false;

        private static string EnsureEndsWithDot(this string str)
        {
            if (str.EndsWith("~"))
                return str;
            else if (str.EndsWith("!") || str.EndsWith("！"))
                return str;
            else if (str.EndsWith("?") || str.EndsWith("？"))
                return str;
            else if (!str.EndsWith(".") && !str.EndsWith("。"))
                return str + ".";

            return str;
        }

        static bool forced = false;
        internal static void Write(string msg)
        {
            if(DEBUG)
            {
                using (StreamWriter w = File.AppendText(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)))
                {
                    Log(EnsureEndsWithDot(msg), w);
                }

                return;
            }
            if (UserSettings.LoggingSetting || forced)
            {
                try
                {
                    using (StreamWriter w = File.AppendText(Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, Strings.KattoFileName.KatLog)))
                    {
                        Log(EnsureEndsWithDot(msg), w);
                    }

                    if (DEBUG)
                        Console.WriteLine(EnsureEndsWithDot(msg));
                }
                catch  { } //catch it because something weird might happen, and unfixable
            }        
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private static void Log(string msg, TextWriter w)
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
                w.WriteLine("Logging error: " + e);
            }
        }
    }
}
