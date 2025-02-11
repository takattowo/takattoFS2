using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takattoFS2
{
    static class PatcherSettings
    {
        public static string AppDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "takattoFS2");
        public static string PatchDir = Path.Combine(AppDir, "AppData");
        public static string TempDir = Path.Combine(PatchDir, "Temp");
        public static string SweetLetterDir = Path.Combine(PatchDir, "SweetLetter");
        //public static string DlcDir = Path.Combine(AppDir, "DLC");

        //setting names
        public const string PATCH_SERVER_ROOT = nameof(PATCH_SERVER_ROOT);
        public const string PATCH_SERVER_HACKER_MODE_ROOT = nameof(PATCH_SERVER_HACKER_MODE_ROOT);
        public const string PATCH_SERVER_MUSIC = nameof(PATCH_SERVER_MUSIC);
        public const string PATCH_SERVER_PATCHES = nameof(PATCH_SERVER_PATCHES);
        public const string PATCH_SERVER_SERVICES = nameof(PATCH_SERVER_SERVICES);
        public const string PATCH_SERVER_PATCHES_ASSETS = nameof(PATCH_SERVER_PATCHES_ASSETS);
        public const string DISPLAY_WEBSITE = nameof(DISPLAY_WEBSITE);
        public const string GAME_GUIDE = nameof(GAME_GUIDE);
        public const string PROGRAM_VERSION = nameof(PROGRAM_VERSION);
        public const string TAKA_PAYPAL = nameof(TAKA_PAYPAL);
        public const string INSTALLER_URL = nameof(INSTALLER_URL);
        public const string takatto00004 = nameof(takatto00004); //LAUNCHER_TAB
        public const string takatto00001 = nameof(takatto00001); //GAME_FOLDER
        public const string takatto00003 = nameof(takatto00003); //GAME_LANGUAGE
        public const string DISCORD_SERVER = nameof(DISCORD_SERVER);
        public const string takatto00456 = nameof(takatto00456); //DLCs_VERSION DLC5|ZACARDO
        public const string takatto29022 = nameof(takatto29022); //LOVELETTER|HIKARIHEART|YUZUKIHEART|NAKOHEART|COUNT|ISHI|ISYU|ISNA|
        public const string takatto10456 = nameof(takatto10456); //SERVICE CODES
        public const string takatto10001 = nameof(takatto10001); //HELLO WORLD
        public const string takatto00012 = nameof(takatto00012); //SOUND_LIST
        public const string takatto00000 = nameof(takatto00000); //FIRST_RUN
        public const string takatto00002 = nameof(takatto00002); //LAUNCHER_SETTINGS
        public const string takatto00028 = nameof(takatto00028); //REMEMBER_PASSWORD
        public const string takatto00029 = nameof(takatto00029); //BROWSER_NEXON_OR_JOYCITY
        public static bool takatto00119 = false; //IS_NEWS_AUTO_OPEN
        public static string takatto00119s = null; //IS_NEWS_AUTO_OPEN
        public static string takatto00120b = null; //BLOCKED USERS
        public static bool takatto00121 = false; //LOVE_SERVER_LETTER ENABLED?
        public static string takatto00121b = null; //LOVE_SERVER_LETTER
        public static string takatto00012s = null; //EVENTED_SOUND_LIST

        public static string HikariAltName = null;
        public static string YuzukiAltName = null;
        public static string NakoAltName = null;


        public const string takatto11000 = nameof(takatto11000); //msgStrHikariWelcome\msgStrHikari\msgStrYuzuki\msgStrNako\msgStrHikariLove\msgStrYuzukiLove\msgStrNakoLove\msgStrHikariAngry\msgStrYuzukiAngry\msgStrNakoAngry\hikariloved\yuzukiloved\nakoloved

        public static string GetDefault(string name)
        {
            switch(name)
            {
                case PATCH_SERVER_ROOT:
                    return "https://raw.githubusercontent.com/takattowo/takattofs2-site/main/fs2/index_fs2_patch_list.html"; //https://takattowo.github.io/fs2/index_fs2_patch_list
                case PATCH_SERVER_HACKER_MODE_ROOT:
                    return "https://raw.githubusercontent.com/takattowo/takattofs2-site/main/fs2/index_fs2_patch_list_alt.html";
                case PATCH_SERVER_MUSIC:
                    return "https://raw.githubusercontent.com/takattowo/takattofs2-site/main/fs2/index_music_list.html";
                case PATCH_SERVER_PATCHES:
                    return "http://raw.githubusercontent.com/takattowo/takattoFS2/main"; //https://github.com/takattowo/takattoFS2/raw/main/
                case PATCH_SERVER_SERVICES:
                    return "https://raw.githubusercontent.com/takattowo/takattofs2-site/main/fs2/index_fs2_patch_list_ser.html";
                case PATCH_SERVER_PATCHES_ASSETS:
                    return "https://raw.githubusercontent.com/takattowo/takattofs2-site/main"; //https://github.com/takattowo/takattowo.github.io/raw/main/
                case DISPLAY_WEBSITE:
                    return "https://takattowo.github.io/takattofs2-site";
                case GAME_GUIDE:
                    return "https://takattowo.github.io/takattofs2-site#howtouse";
                case PROGRAM_VERSION:
                    return "2.8.6.7";
                case INSTALLER_URL:
                    return "https://takattowo.github.io/takattofs2-site#install";
                case TAKA_PAYPAL:
                    return "https://www.paypal.com/paypalme/taka2902";
                case DISCORD_SERVER:
                    return "https://discord.gg/yJmKf7PDzS";
                default:
                    return null;
            }
        }

        public static string GetWebValue(string name)
        {
            string url = $"{GetValue(PATCH_SERVER_ROOT)}/{name}.dat";
            string defaultValue = GetDefault(name);
            try
            {
                WebClient wc = new WebClient();
                string value = wc.DownloadString(url);
                return value;
            }
            catch (Exception e)
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                    return defaultValue;

                MessageBoxEx.Show($"Could not fetch takattoFS2 Web value~", "Oh noo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logging.Write($"Web value could not be fetched. Kat-code: " + e.Message);
                return null; 
            }
        }


        public static string GetValue(string name)
        {
            string tentativeFile = Path.Combine(PatchDir, $"{name}.dat");
            string defaultValue = GetDefault(name);

            string resultSecretKey = null;
            if (File.Exists(tentativeFile))
            {
                var secretKey = File.ReadAllText(tentativeFile).ToString().Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<br>", "\n");

                //secretKey.Reverse().ToArray();
                foreach (char ch in secretKey.ToCharArray()) // loop through each character in str
                {
                    resultSecretKey += (char)(ch - 29022000); // need to cast subtraction to char
                }
                return resultSecretKey;
            }
            else
                return defaultValue;
        }

        public static void SetValue(string name, string value)
        {
            string tentativeFile = Path.Combine(PatchDir, $"{name}.dat");
            try
            {
                //MessageBoxEx.Show(value);
                String str = value;
                String encryptedStr = "";
                foreach (char ch in str.ToCharArray())
                    encryptedStr += (char)(ch + 29022000);
                //encryptedStr.Reverse().ToArray();
                //MessageBoxEx.Show(encryptedStr);
                File.WriteAllText(tentativeFile, Utf8Encoder.GetString(Utf8Encoder.GetBytes(encryptedStr)));
            }
            catch (Exception e)
            {
                MessageBoxEx.Show($"Could not save settings for kat_{name}. Kat-code: " + e.Message + " If the program still working fine then nothing to worries about~","This is a bad sign! QwQ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logging.Write($"Settings for kat_{name} could not be saved. Kat-code: " + e.Message);
            }
        }

        public static void SetValueWithoutCrypting(string name, string value)
        {
            string tentativeFile = Path.Combine(PatchDir, $"{name}.dat");
            try
            {
                File.WriteAllText(tentativeFile, value);
            }
            catch (Exception e)
            {
                MessageBoxEx.Show($"Could not save settings for kat_{name}. Kat-code: " + e.Message + " If the program still working fine then nothing to worries about~", "This is a bad sign! QwQ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logging.Write($"Settings for kat_{name} could not be saved. Kat-code: " + e.Message);
            }
        }

        public static string GetValueWithoutCrypting(string name)
        {
            string tentativeFile = Path.Combine(PatchDir, $"{name}.dat");
            string defaultValue = GetDefault(name);

            if (File.Exists(tentativeFile))
                return File.ReadAllText(tentativeFile).ToString().Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<br>", "\n");
            else
                return defaultValue;
        }

        private static readonly Encoding Utf8Encoder = Encoding.GetEncoding(
            "UTF-8",
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
        );

        public static void DeleteValue(string name)
        {
            string tentativeFile = Path.Combine(PatchDir, $"{name}.dat");

            try
            {
                if (File.Exists(tentativeFile))
                    File.Delete(tentativeFile);
            }
            catch (Exception e)
            {
                MessageBoxEx.Show($"Could not delete settings for kat_{name}. Kat-code: " + e.Message + " If the program still working fine then nothing to worries about~", "This is a bad sign! QwQ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logging.Write($"Settings for kat_{name} could not be deleted. Kat-code: " + e.Message);
            }
        }

    }
}
