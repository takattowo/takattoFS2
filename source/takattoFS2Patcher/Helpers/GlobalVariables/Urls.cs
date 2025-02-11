using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace takattoFS2.Helpers.GlobalVariables
{

    internal sealed class Urls
    {
        internal static string ReturnServer()
        {        
            var file = Path.Combine(UserSettings.PatcherPath, Strings.KattoFileName.CustomServer);
            if (File.Exists(file))
            {
                isCustomServerEnabled = true;
                return File.ReadAllText(file);
            }
            else
                return OriginalServer;
        }

        internal static bool isCustomServerEnabled = false;

#if DEBUG
        internal static string Server = Environment.ExpandEnvironmentVariables(@"%userprofile%\Documents\GitHub\takattoFS2-main\Server");
#else
        internal static string Server = ReturnServer();
#endif
        internal const string OriginalServer = "http://raw.githubusercontent.com/takattowo/takattoFS2/main/";
        internal static string ServerSettings = Server + "takatto_data/settings2.txt";
        internal static string ServerServiceSettings = Server + "takatto_data/services.txt";
        internal static string ServerFLASHPATH = Server + "takatto_data/Flash_Path.bml";
        internal static string Loading = Server + "takatto_data/assets/loading/loading{0}";
        internal const string SteamGameUri = "steam://rungameid/339610";
        internal const string UrlFormat = "ngm://launch/ -dll:platform.nexon.com/NGM/Bin/NGMDll.dll:1 -locale:{4} -mode:{3} -game:{0}:0 -token:'{1}' -passarg:'null' -a2sk:'{2}' -architectureplatform:'{5}'";
        internal const string GoogleTranslateApi = "http://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={0}&dt=t&q={1}";
        
        internal static string CatFormat = Server + "takatto_data/assets/cat/{0}";
        internal static string SweetFormat = Server + "takatto_data/assets/sweet/{0}";
        internal static string SweetNoiseFormat = Server + "takatto_data/assets/sweet/noise/{0}";
        internal const string NewsFormat = "{0}/fs2/{1}";
        internal const string MusicFormat = "{0}/{1}.wav";
        internal const string PictureFormat = "{0}/{1}";

        internal const string JoyCityUri = "https://fs2.joycity.com/web/main.do";
        internal const string DirectLoginJoyCityUri = "https://www.joycity.com/user/integrateLogin?redirect=http%3A%2F%2Ffs2.joycity.com%2Fweb%2Fmain.do&SITE_CD=FS2";
        internal const string NexonUri = "https://fs2.nexon.com/web/main.do";
        internal const string DirectLoginNexonUri = "https://nxlogin.nexon.com/common/login.aspx?redirect=http%3a%2f%2ffs2.nexon.com%2fweb%2fmain.do";
        //internal const string DirectLoginNexonUri = "https://nxlogin.nexon.com/common/login_c.aspx?redirect=https%3a%2f%2ffs2.nexon.com%2fweb%2fmain.do";
        internal const string GameKiss = "https://freestyle2.joycitygames.com/main";

        internal static string DLC3 = Server + "takatto_mods/takatto_tweak_dlc/takatto_tweak_dlc3.dat";
        internal static string DLC6 = Server +  "takatto_mods/takatto_tweak_dlc/takatto_tweak_dlc6.dat";
        internal static string DLC1Court = Server + "takatto_mods/takatto_tweak_dlc/takatto_tweak_dlc1/";

        internal static string DLC1Stage00 = DLC1Court + "stage00.dat";
        internal static string DLC1Stage06 = DLC1Court + "stage06.dat";
        internal static string DLC1Stage12 = DLC1Court + "stage12.dat";
        internal static string DLC1Stage13 = DLC1Court + "stage13.dat";
        internal static string DLC1DefaultCourt = DLC1Court + "stage_default.dat";
    }
}