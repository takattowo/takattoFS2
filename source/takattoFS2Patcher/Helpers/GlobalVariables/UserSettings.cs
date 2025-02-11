using System;
using System.IO;
using System.Linq;
using System.Reflection;
using takattoFS2.Properties;

namespace takattoFS2.Helpers.GlobalVariables
{
    internal sealed class UserSettings
    {
        internal static string AppSettingPath
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "furretFS2");//Assembly.GetExecutingAssembly().GetName().Name);
                Methods.MakeSureFolderExists(path);
                var path2 = Path.Combine(path, Strings.FolderName.AppData);
                Methods.MakeSureFolderExists(path2);
                return Path.Combine(path2 ,"katsetting.config");
            }
        }

        internal static string CourtSettings
        {
            get 
            { 
                return Settings.Default.CourtSetting; 
            }
            set 
            { 
                Settings.Default.CourtSetting = value; 
                Settings.Default.Save();
            }
        }

        internal static string WindowsLocation
        {
            get
            {
                return Settings.Default.WindowsLocation;
            }
            set
            {
                Settings.Default.WindowsLocation = value;
                Settings.Default.Save();
            }
        }

        internal static string PatcherBlackListPath
        {
            get
            {
                //return PatcherPath.Replace(Assembly.GetExecutingAssembly().GetName().Name, "KANTUSER.DAT");
                return PatcherPath.Replace("furretFS2", "KANTUSER.DAT");
            }
        }

        internal static string PatcherBlackListContent
        {
            get
            {
                //return the content of the file if exist
                if (File.Exists(PatcherBlackListPath))
                {
                    var text = File.ReadAllText(PatcherBlackListPath);
                    return KATEncryptor.DecryptSwapping(text);
                }

                return string.Empty;
            }
            set
            {
                //save content to file and create file if not exist
                if (File.Exists(PatcherBlackListPath))
                    File.Delete(PatcherBlackListPath);
                
                string encryptedStr = KATEncryptor.EncryptSwapping(value);
                File.WriteAllText(PatcherBlackListPath, PatcherSettings.Utf8Encoder.GetString(PatcherSettings.Utf8Encoder.GetBytes(encryptedStr)));
                Methods.MegaHideFile(PatcherBlackListPath);
            }
        }

        internal static string PatcherPath
        {
            get
            {
                if (!Directory.Exists(Settings.Default.PatcherWorkingDirectory))
                {
                    //var path = PatcherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
                    var path = PatcherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "furretFS2"); // static folder
                    Methods.MakeSureFolderExists(path);
                    return path;
                }
                else
                {
                    var path = Settings.Default.PatcherWorkingDirectory.Replace("\\\\", "\\");
                    Methods.MakeSureFolderExists(path);
                    return path;
                }
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    value = value.Replace("\\\\", "\\");
                    Directory.CreateDirectory(value);
                    Directory.SetCurrentDirectory(value);
                }

                Settings.Default.PatcherWorkingDirectory = value;
                Settings.Default.Save();
                Logger.Write($"Patcher path set to [{value}]");
            }
        }

        internal static string GamePath
        {
            get
            {
                return Settings.Default.GameDirectory;//.Replace("\\\\", "\\");
            }
            set
            {
                //value = value.Replace("\\\\", "\\");         
                Settings.Default.GameDirectory = value;
                Settings.Default.Save();
                if (!String.IsNullOrEmpty(value))
                {
                    Methods.EnsureDirectoryRights(value);
                    Logger.Write($"Game path set to [{value}]");
                }
            }
        }

        internal static string GameId
        {
            get
            {
                return Settings.Default.GameUserId;
            }
            set
            {
                Settings.Default.GameUserId = value;
                Settings.Default.Save();
            }
        }

        internal static string GamePw
        {
            get
            {
                return Settings.Default.GameUserPassword;
            }
            set
            {
                Settings.Default.GameUserPassword = value;
                Settings.Default.Save();
            }
        }

        internal static int GameQuality
        {
            get
            {
                return Settings.Default.RenderQuality;
            }
            set
            {
                Settings.Default.RenderQuality = value;
                Settings.Default.Save();
            }
        }
        internal static bool CloseLauncher
        {
            get
            {
                return Settings.Default.CloseLauncherAlso;
            }
            set
            {
                Settings.Default.CloseLauncherAlso = value;
                Settings.Default.Save();
            }
        }

        
        internal static int LoadBGCount
        {
            get
            {
                return Settings.Default.LoadingBgCount;
            }
            set
            {
                Settings.Default.LoadingBgCount = value;
                Settings.Default.Save();
            }
        }

        internal static bool CustomTexture
        {
            get
            {
                return Settings.Default.CustomTextureTweak;
            }
            set
            {
                Settings.Default.CustomTextureTweak = value;
                Settings.Default.Save();
            }
        }

        internal static bool CustomInteface 
        {
            get
            {
                return Settings.Default.CustomInterfaceEnabled;
            }
            set
            {
                Settings.Default.CustomInterfaceEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static int CharVoiceLanguage
        {
            get
            {
                var value = CheckCharVoiceLanguage(Settings.Default.CharVoiceTweak);
                return value;
            }
            set
            {
                Settings.Default.CharVoiceTweak = CheckCharVoiceLanguage(value);
                Settings.Default.Save();

                //if (Forms.MainForm.mf.charVoice.isSomething)
                //    Forms.SubForms.CharVoiceForm.frmObj.UpdateFields();
            }
        }

        private static int CheckCharVoiceLanguage(int n)
        {
            switch (n)
            {
                default:
                case 0:
                    return 0;
                case 1:
                    if (Methods.IsCharacterVoiceInstalled("en"))
                        return 1;
                    return 0;
                case 2:
                    if (Methods.IsCharacterVoiceInstalled("kr"))
                        return 2;
                    return 0;
                case 3:
                    if (Methods.IsCharacterVoiceInstalled("cn"))
                        return 3;
                    return 0;
                case 4:
                    if (Methods.IsCharacterVoiceInstalled("kat"))
                        return 4;
                    return 0;
            }
        }

        internal static int MCVoiceLanguage
        {
            get
            {
                var value = CheckMCVoiceLanguage(Settings.Default.MCVoiceTweak);
                return value;
            }
            set
            {
                Settings.Default.MCVoiceTweak = CheckMCVoiceLanguage(value);
                Settings.Default.Save();

                //if (Forms.MainForm.mf.mcVoice.isSomething)
                //    Forms.SubForms.MCVoiceForm.frmObj.UpdateForm();
            }
        }

        private static int CheckMCVoiceLanguage(int n)
        {
            switch(n)
            {
                default:
                case 0:
                    return 0;
                case 1:
                    if (Methods.IsMCVoiceInstalled("vi"))
                        return 1;
                    return 0;
                case 2:
                    if (Methods.IsMCVoiceInstalled("cn"))
                        return 2;
                    return 0;
                case 3:
                    if (Methods.IsMCVoiceInstalled("kr"))
                        return 3;
                    return 0;
                case 4:
                    if (Methods.IsMCVoiceInstalled("fa"))
                        return 4;
                    return 0;
                case 5:
                    if (Methods.IsMCVoiceInstalled("kat"))
                        return 5;
                    return 0;
                case 6:
                    if (Methods.IsMCVoiceInstalled("en"))
                        return 6;
                    return 0;
            }
        }


        internal static int GameHeight
        {
            get
            {
                // Split the string by comma and parse the second part as an integer
                string videoModeSize = Settings.Default.VideoMode_Size;
                string[] parts = videoModeSize.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int height))
                {
                    return height;
                }
                // Handle invalid or missing data by returning a default value
                return 0; // You can change this to an appropriate default value
            }
            set
            {
                // Get the current VideoMode_Size setting and split it into parts
                string videoModeSize = Settings.Default.VideoMode_Size;
                string[] parts = videoModeSize.Split(',');

                // Update the height part with the new value
                if (parts.Length == 2)
                {
                    parts[1] = value.ToString();
                    Settings.Default.VideoMode_Size = string.Join(",", parts);
                    Settings.Default.Save();
                }
            }
        }

        internal static int GameWidth
        {
            get
            {
                // Split the string by comma and parse the first part as an integer
                string videoModeSize = Settings.Default.VideoMode_Size;
                string[] parts = videoModeSize.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int width))
                {
                    return width;
                }
                // Handle invalid or missing data by returning a default value
                return 0; // You can change this to an appropriate default value
            }
            set
            {
                // Get the current VideoMode_Size setting and split it into parts
                string videoModeSize = Settings.Default.VideoMode_Size;
                string[] parts = videoModeSize.Split(',');

                // Update the width part with the new value
                if (parts.Length == 2)
                {
                    parts[0] = value.ToString();
                    Settings.Default.VideoMode_Size = string.Join(",", parts);
                    Settings.Default.Save();
                }
            }
        }

        internal static bool Shortcut
        {
            get
            {
                return Settings.Default.KeyboardShortcut;
            }
            set
            {
                Settings.Default.KeyboardShortcut = value;
                Settings.Default.Save();
            }
        }

        internal static string CustomPatchRepo
        {
            get
            {
                string repoUrl = Settings.Default.CustomPatchRepository;
                return IsValidWebsiteUrl(repoUrl) ? repoUrl : ""; // Default value or error handling
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                    Settings.Default.CustomPatchRepository = value;
                else if (IsValidWebsiteUrl(value))
                {
                    Settings.Default.CustomPatchRepository = value;
                    Settings.Default.Save();
                }
            }
        }  
        //check if uri site correct
        private static bool IsValidWebsiteUrl(string input)
        {
            return Uri.TryCreate(input, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        internal static string GameLanguage
        {
            get
            {
                return Settings.Default.GameLanguage;
            }
            set
            {
                Settings.Default.GameLanguage = value;
                Settings.Default.Save();
            }
        }

        internal static bool PatcherMusicSetting
        {
            get
            {
                return Settings.Default.AutoPlayMusic;
            }
            set
            {
                Settings.Default.AutoPlayMusic = value;
                Settings.Default.Save();
            }
        }

        internal static string PatchLastTab
        {
            get
            {
                return Settings.Default.PatcherLastTab;
            }
            set
            {
                Settings.Default.PatcherLastTab = value;
                Settings.Default.Save();
            }
        }

        internal static string ExtensionCredential
        {
            get
            {
                return Settings.Default.PatcherExtCredentials;
            }
            set
            {
                Settings.Default.PatcherExtCredentials = value;
                Settings.Default.Save();
            }
        }
        internal static string UILaunchOption
        {
            get
            {
                return Settings.Default.UICustomLaunchOption;
            }
            set
            {
                Settings.Default.UICustomLaunchOption = value;
                Settings.Default.Save();
            }
        }

        internal static bool GameLogCleannerEnabled
        {
            get
            {
                return Settings.Default.GameLogCleannerEnabled;
            }
            set
            {
                Settings.Default.GameLogCleannerEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static bool LoggingSetting
        {
            get
            {
                return Settings.Default.LoggingEnabled;
            }
            set
            {
                Settings.Default.LoggingEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static int WebLoginSetting
        {
            get
            {
                return Settings.Default.WebLoginSetting;
            }
            set
            {
                Settings.Default.WebLoginSetting = value;
                Settings.Default.Save();
            }
        }

        internal static bool AKFTweakSetting
        {
            get
            {
                return Settings.Default.AFKEnabled;
            }
            set
            {
                Settings.Default.AFKEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static int AFKTweakInterval
        {
            get
            {
                int afkInterval = Settings.Default.AFKInterval;
                return afkInterval > 55 ? 55 : afkInterval;
            }
            set
            {
                Settings.Default.AFKInterval = value;
                Settings.Default.Save();
            }
        }

        internal static bool JukeboxTweakSetting
        {
            get
            {
                return Settings.Default.JukeboxEnable;
            }
            set
            {
                Settings.Default.JukeboxEnable = value;
                Settings.Default.Save();
            }
        }

        internal static bool CameraTweakSetting
        {
            get
            {
                return Settings.Default.CameraEnable;
            }
            set
            {
                Settings.Default.CameraEnable = value;
                Settings.Default.Save();
            }
        }


        internal static bool TextMacroTweakSetting
        {
            get
            {
                return Settings.Default.TextMacroEnable;
            }
            set
            {
                Settings.Default.TextMacroEnable = value;
                Settings.Default.Save();
            }
        }

        internal static string TextMacroTweakData
        {
            get
            {
                return Settings.Default.TextMacroData;
            }
            set
            {
                Settings.Default.TextMacroData = value;
                Settings.Default.Save();
            }
        }

        internal static string CameraTweakSettingConfigs
        {
            get
            {
                return Settings.Default.CameraSettings;
            }
            set
            {
                Settings.Default.CameraSettings = value;
                Settings.Default.Save();
            }
        }

        private static string zacode;
        internal static bool UITweakSetting //zacardp
        {
            get
            {
                zacode = Forms.MainForm.mf.isZaCardoSV != null ? Forms.MainForm.mf.isZaCardoSV.id : new Random().Next(0, 99999999).ToString();

                if (Methods.CheckIfMatchServiceCondition(Forms.MainForm.mf.isZaCardoSV))
                    return Settings.Default.ServiceConfig.Contains(zacode);

                //Forms.MainForm.mf.isZaCardoSV.isNotMatchedCondition = true;
                Settings.Default.ServiceConfig = Settings.Default.ServiceConfig.Replace(zacode, "");
                return false;
            }
            set
            {
                zacode = Forms.MainForm.mf.isZaCardoSV != null ? Forms.MainForm.mf.isZaCardoSV.id : new Random().Next(0, 99999999).ToString();

                if (value && !Settings.Default.ServiceConfig.Contains(zacode))
                    Settings.Default.ServiceConfig += zacode;
                else
                    Settings.Default.ServiceConfig = Settings.Default.ServiceConfig.Replace(zacode, ""); 
                
                Settings.Default.Save();
            }
        }

        private static string zaltcode;
        internal static bool UITweakSetting2 //zaalt
        {
            get
            {
                zaltcode = Forms.MainForm.mf.isAltCardoSV != null ? Forms.MainForm.mf.isAltCardoSV.id : new Random().Next(0, 99999999).ToString();

                if (Methods.CheckIfMatchServiceCondition(Forms.MainForm.mf.isAltCardoSV))
                    return Settings.Default.ServiceConfig.Contains(zaltcode);

                Settings.Default.ServiceConfig = Settings.Default.ServiceConfig.Replace(zaltcode, "");
                return false;
            }
            set
            {
                zaltcode = Forms.MainForm.mf.isAltCardoSV != null ? Forms.MainForm.mf.isAltCardoSV.id : new Random().Next(0, 99999999).ToString();

                if (value && !Settings.Default.ServiceConfig.Contains(zaltcode))
                    Settings.Default.ServiceConfig += zaltcode;
                else
                    Settings.Default.ServiceConfig = Settings.Default.ServiceConfig.Replace(zaltcode, "");
                
                //Settings.Default.ServiceConfig.Replace("zaltdo", String.Empty);
                Settings.Default.Save();
            }
        }

        static string taskcode = "svatkmenalebhik";
        internal static bool TaskUnlocked //zaalt
        {
            get
            {
                if (Settings.Default.ServiceConfig.Contains(taskcode))
                    return false;

                if (Forms.MainForm.mf.IsHikariEd())
                {
                    Settings.Default.ServiceConfig += taskcode;
                    return true;
                }

                return false;
            }
        }

        internal static int CharVoiceSetting
        {
            get
            {
                return Settings.Default.CharVoiceTweak;
            }
            set
            {
                Settings.Default.CharVoiceTweak = value;
                Settings.Default.Save();
            }
        }

        internal static int MCVoiceSetting
        {
            get
            {
                return Settings.Default.CharVoiceTweak;
            }
            set
            {
                Settings.Default.CharVoiceTweak = value;
                Settings.Default.Save();
            }
        }

        internal static string NewsBlockList
        {
            get
            {
                return Settings.Default.NewSkipList;
            }
            set
            {
                Settings.Default.NewSkipList = value;
                Settings.Default.Save();
            }
        }

        internal static bool CustomSetting
        {
            get
            {
                return Settings.Default.CustomSettingEnabled;
            }
            set
            {
                Settings.Default.CustomSettingEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static bool GameFontSetting
        {
            get
            {
                return Settings.Default.CustomFontEnabled;
            }
            set
            {
                Settings.Default.CustomFontEnabled = value;
                Settings.Default.Save();
            }
        }

        internal static bool ForceSteamLauncher
        {
            get
            {
                return Settings.Default.SteamLauncherMode;
            }
            set
            {
                Settings.Default.SteamLauncherMode = value;
                Settings.Default.Save();
            }
        }

        internal static int PatcherMenuSetting
        {
            get
            {
                return Settings.Default.MenuPosition;
            }
            set
            {
                Settings.Default.MenuPosition = value;
                Settings.Default.Save();
            }
        }

        internal static string Command
        {
            get
            {
                return Settings.Default.CommandLineCode;
            }
            set
            {
                Settings.Default.CommandLineCode = value;
                Settings.Default.Save();
            }
        }

        internal static string UILanguageCode
        {
            get
            {
                return Settings.Default.UILanguage;
            }
            set
            {
                Settings.Default.UILanguage = value;
                Settings.Default.Save();
                Logger.Write($"UI Language set to [{value}]");
            }
        }
    }
}
