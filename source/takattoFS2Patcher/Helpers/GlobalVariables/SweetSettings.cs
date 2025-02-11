using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using takattoFS2.Controls.Models;

namespace takattoFS2.Helpers.GlobalVariables
{
    public class SweetSettings
    {
        private SweetSettings() { }

        private static SweetSettings _uwu = null;
        public static SweetSettings SweetSettingsInstance
        {
            get
            {
                if (_uwu == null)
                    _uwu = new SweetSettings();

                return _uwu;
            }
        }

        public bool isServerSideEnabled { get; set; }
        public bool isForceRedownload { get; set; }
        public bool isHikariAlwaysMain { get; set; }
        public bool isUsingServerBaseLoveChance { get; set; }
        public string justAboutMessage { get; set; }
        public string patchTabMessage { get; set; }
        public string tweakTabMessage { get; set; }
        public string serviceTabMessage { get; set; }
        public int universalMessageProcChance { get; set; }
        public List<string> universalMessage { get; set; }
        public List<string> cutieMessage { get; set; }
        public string messageDataUri { get; set; }
        public Cutie Hikari { get; set; } //hikari/hikari_happi/hikari_angri/bg_owo_r
        public Cutie Yuzuki { get; set; }
        public Cutie Nako { get; set; }
    }
}
