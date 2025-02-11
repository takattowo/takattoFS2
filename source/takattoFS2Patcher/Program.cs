using Microsoft.Win32;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using takattoFS2.Forms;
using takattoFS2.Helpers;

namespace takattoFS2
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main()
        {
            bool yes = true;
#if debug
                        yes = true;
#endif
            if (!yes)
                Methods.AdminRightsEnforcing(false);

            AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures.2", true);
            AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures", false);

            Arguments.GameId = "335";

            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanging += SystemEvents_DisplaySettingsChanging;
            Microsoft.Win32.SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;

            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            using (Mutex mutex = new Mutex(false, "Global\\" + Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper()))
            {
                if (!mutex.WaitOne(0, false))
                {
                    //MessageBox.Show("Instance already running");
                    return;
                }

                Application.Run(new MainForm());
            }
            //Application.Run(new MainForm());             
        }

        private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
        }

        private static void SystemEvents_DisplaySettingsChanging(object sender, EventArgs e)
        {
        }

        private static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
        }
    }
}
