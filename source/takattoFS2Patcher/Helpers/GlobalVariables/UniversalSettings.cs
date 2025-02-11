using System;
using System.Collections.Generic;
using takattoFS2.Controls.Models;

namespace takattoFS2.Helpers.GlobalVariables
{
    public class UniversalSettings
    {
        private UniversalSettings()  { }

        private static UniversalSettings _un = null;
        public static UniversalSettings UniversalSettingsInstance
        {
            get
            {
                if (_un == null)
                    _un = new UniversalSettings();

                return _un;
            }
        }
        public int LoadBGCount { get; set; } = 0;
        public string CatPrefix { get; set; } = "cat";
        public bool isNewsAutoOpen { get; set; }
        public string NewsUri { get; set; }
        public string AutoNewsUri { get; set; }
        public string DisplaySiteRootUri { get; set; }
        public string PatchRootUri { get; set; }
        public string AssetRootUri { get; set; }
        public string GameGuideUri { get; set; }
        public string CameraGuideUri { get; set; }
        public string DiscordUri { get; set; }
        public string DonateUri { get; set; }

        public List<Tuple<string, string>> TweakDisabler { get; set; } // tweakcode, reason

        public List<string> MusicList { get; set; }
        public bool isMusicListEventEnabled { get; set; }
        public string MusicListEventMessage { get; set; }
        public List<string> Mysterimo { get; set; }
        public List<string> Keymarimo { get; set; }
        public List<string> MusicListEvent { get; set; }
        public List<string> BlockedUsers { get; set; }
        public List<string> ToRemove { get; set; }
        public List<Tuple<string, string, bool>> ToChange { get; set; } // from, to, isDirectory
        public string DLC5InstallationCode { get; set; }
        public string ExtensionSignature { get; set; } = String.Empty;
        public string ServiceUri { get; set; }
        public List<Service> Services { get; set; }
    }
}
