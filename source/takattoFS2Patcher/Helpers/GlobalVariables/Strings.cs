using System.CodeDom;

namespace takattoFS2.Helpers.GlobalVariables
{
    internal sealed class Strings
    {
        internal sealed class Misc
        {
            internal const string AppExe = "furretFS2.exe";
            internal const string Installer = "katto_updater.exe";
            internal const string GameProcessName = "FreeStyle2";
            internal const string SteamProcessName = "Steam";
            internal const string LauncherKrProcessName = "FS2KOR_LAUNCHER";
            internal const string LauncherProcessName = "Launcher";
            internal const string LauncherSteamProcessName = "LauncherSteam";
            internal static readonly string[] CutieQuotes = { "Patting cats", "Feeding kitties", "Lewding neko", "Reloading Ak47", "Meow meow", "Humping shanties", "Sacrificing Bill", "Giving Sauce", "Narutooooo!", "Sasukeeee!", "Gomu gomu no!", "I, Giorno Giovanna", "Star Platinum!", "Zawarudo!", "Day dreaming~", "Ehe, te nandayo!", "Return to monke", "Rejecting humanity", "Return to phish", "Eren, Stalph killing!", "Hail Hitler", "Acting kewl~", "Joining strawhats", "Be humble, sit down", "Emeraldo Splashu!", "Hermito Purpleru", "Kono Dio Da", "Ning is cute!", "Morning, darling~", "Oi, oi , oi...", "Nico Nico Nii!" };
            internal const string LoveLetterMsgDefault = "Nice to see chu again! How are you doing?|\\Objectiooon, desuuuu!|\\The shadow from the starlight is softer than a lullabye.|\\OwO|\\I'll call you cutie so you also have to make me happy!|\\(Yuzuki, I think I’m in love!)|\\<3|\\What are you looking at you baka hentai!|\\Bad writing, I'll give you minus 100.|\\Ew...|\\Hikari loves you... so much! So much much!|\\Ummm... Yuzuki offered you to be Yuzuki's... boy friend~|\\Nako has found her love~|Nako is in love with chu~!|\\Herro!|Mamahaha and me been waiting for you!|\\";
            internal const string LoveLetterEventMsgDefault = "Stay happy, will chu? I know chu are sad, but chu will be alright~";
            internal const string LoveLetterDataDefault = "79|69|69|69|89|false|false|false|";
        }

        internal sealed class FolderName
        {
            internal const string MyComputer = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            internal const string FreeStyle2 = "FreeStyle2";
            internal const string Data = "Data";
            internal const string Script = "Script";
            internal const string Camera = Script + "\\" + "camera";
            internal const string Sound = "Sound";
            internal const string Extension = "Extension";
            internal const string CustomPatch = "Addons";
            internal const string Jukebox = Sound + "\\" + "BGM_TAKATTO_JUKEBOX";
            internal const string ActionSound = Sound + "\\" + "TAKATTO_ACTION_SOUND";
            internal const string UI = "UI";
            internal const string KattoUISWFFolder = UI + "\\" + Katto;
            internal const string PATHC_UI = "PATCH_UI";
            internal const string BM = "PATCH_COOK";
            internal const string PATCH = "PATCH";
            internal const string Texture = "Texture";
            internal const string CustomUI = CustomPatch + "\\" + PATHC_UI;
            internal const string CustomBM = CustomPatch + "\\" + BM;
            internal const string CustomP4tch = CustomPatch + "\\" + PATCH;
            internal const string CustomTexture = CustomPatch + "\\" + Texture;
            internal const string Stage = "Stage";
            internal const string Image = PATHC_UI + "\\" + "Image";
            internal const string AppData = "AppData";
            internal const string AssetAppData = AppData + "\\" + "assets";
            internal const string TempFolder = AppData + "\\" + "Temp";
            internal const string SweetData = AssetAppData + "\\" + "sweet";
            internal const string LoadingData = AssetAppData + "\\" + "loading";
            internal const string CatData = AssetAppData + "\\" + "cat";
            internal const string Katto = "Katto";
            internal const string Language = "Language";
            internal const string GameGuard = "XIGNCODE";
            internal const string GameGuardCN = "BlackCipher";
            internal const string DLC1Default = Data + "\\" + "takatto_tweak_dlc1_default";
            internal const string DLC5 = Data + "\\" + "takatto_tweak_dlc5";
            internal const string DLC6 = Data + "\\" + "takatto_tweak_dlc6";
            internal const string DLC1 = Data + "\\" + "takatto_tweak_dlc1";
            internal const string DLC1_Custom = DLC1 + "\\" + "custom";
        } 

        internal sealed class FileName
        {
            internal const string FLASH_PATH = "Flash_Path.bml";
            internal const string GameExe = "FreeStyle2.exe";
            internal const string LauncherExe = "Launcher.exe";
            internal const string LauncherSteamExe = "LauncherSteam.exe";
            internal const string LauncherExeKr = "FS2KOR_Launcher.exe";
            internal const string SecurityExe = "KattoDirectoryPermissionChecker.exe";
            internal const string GameAppDll = "GameApp.dll";
            internal const string TiancityDll = "tcUserPolicy.dll";
            internal const string CameraLub = "camera.lub";
            internal const string Script = "script.pak";
            internal const string Option = "option.ini";
            internal const string Nation = "Nation.ini";
            internal const string ActionSoundRes = "ActionSoundResource.bml";
            internal const string ActionSoundResXML = "ActionSoundResource.xml";
            internal const string EnvSoundRes = "EnvSoundResource.bml";
            internal const string EnvSoundResXML = "EnvSoundResource.xml";
            internal const string VoiceSoundRes = "VoiceSoundResource.bml";
            internal const string VoiceSoundResXML = "VoiceSoundResource.xml";
            internal const string BGMSoundRes = "BGMSoundResource.bml";
            internal const string BGMSoundResXML = "BGMSoundResource.xml";
            internal const string Sound = "sound";
            internal const string Sound00 = "sound00.pak";
            internal const string Curse = "curse.dat";
            //internal const string Sound02 = "sound02.pak";
            internal const string Sound03 = "sound03.pak";
            internal const string Sound06 = "sound06.pak";
            internal const string StageData = "stagedata.pak";
            internal const string Log1 = "UNtLog.dat";
            internal const string Log2 = "rwflog.txt";
            internal const string UI = "ui.pak";
            internal const string UIModded = "ui_modded.pak";
            internal const string UILib = "Common_Function.swf";
            internal const string FontConfig = "fontconfig_{0}.txt";
            internal const string StringData = "StringData_{0}.xml";
            internal const string StringDataItem = "StringData_{0}_Item.xml";
        }

        internal sealed class KattoFileName
        {
            internal const string UIModded = "ui_modded.txt";
            internal const string CustomServer = "server.txt";
            internal const string TakattoLock = "katto.lock";
            internal const string Takatto = "takatto.pak";
            internal const string FontConfig = "fontconfig_takatto.txt";
            internal const string FontConfigKatto = "fontconfig_kat_takatto.txt";

            internal const string DLC1Training_Blue = "stage00_blueish.pak";
            internal const string DLC1Training_Red = "stage00_redish.pak";
            internal const string DLC1Training_Dark = "stage00_dark_katto.pak";
            internal const string DLC1Training_Green = "stage00_greenish.pak";
            internal const string DLC1TrainingIMG = "courtTraining.png";

            internal const string DLC1Warehouse_New = "stage06_new.pak";
            internal const string DLC1Warehouse_Default = "stage06_default.pak";
            internal const string DLC1WarehousehIMG = "courtHidden.png";


            internal const string DLC1Katto_Night = "stage12_night.pak";
            internal const string DLC1Katto_Sunny = "stage12_sunny.pak";
            internal const string DLC1KattoIMG = "courtTakatto.png";


            internal const string DLC1Beach_New = "stage13_3x3.pak";
            internal const string DLC1Beach_Default = "stage13_default.pak";
            internal const string DLC1BeachIMG = "courtBeach.png";



            internal const string DLC1Custom = "custom\\stage10{0}.pak";


            internal const string DLC1Default = "takatto_tweak_dlc1_{0}.dat";
            internal const string DLC1DefaultIMG = "courtDefault.png";

            internal const string DLC5Manifest = "takatto_tweak_dlc5.dat";
            internal const string DLC3 = "takatto_tweak_dlc3_{0}_def.dat";
            internal const string DLC6 = "{0}.dat";
            internal const string DLCExtra = "takatto_dlc_extra.dat";

            internal const string SoundSample = "sample.mp3";
            internal const string KatLog = "katlog.txt";
            internal const string BGMKatto = "bgmkatto.dat";
            internal const string RemoveList = "rmvlist.dlc";
            internal const string StringDataKatto = "StringData_KAT.xml";


            internal const string UITextureManifest = "Custom Texture Support.txt";

            //internal const string UICore = "takatto_sv_1.nxgz.dat";
            internal const string UILibrary = "nyainit.lib"; //"takatto_sv_1.lib.dat";
            internal const string UIManifest = "nyainit_config.xml";

            internal const string UILibrary2 = "meowanit.lib"; //"takatto_sv_1.lib.dat";
            internal const string UIManifest2 = "meowanit_config.xml";

            internal const string KattoLoadingPNG = "katto_loading_screen.png";
            internal const string KattoLoadingPNGDefault = "katto_loading_screen_default.png";



            //internal const string TakattoLock = "katto.lock";
            //internal const string Takatto = "takatto.pak";
            //internal const string FontConfig = "fontconfig_kor_takatto.txt";
            //internal const string FontConfigKatto = "fontconfig_kat_takatto.txt";

            //internal const string DLC1Training_Blue = "takatto_court_tweak_blue.dat";
            //internal const string DLC1Training_Red = "takatto_court_tweak_red.dat";
            //internal const string DLC1Training_Dark = "takatto_court_tweak_dark_katto.dat";
            //internal const string DLC1Training = "takatto_tweak_dlc1.dat";
            //internal const string DLC1TrainingCN = "takatto_tweak_dlc1_CHN.dat";
            //internal const string DLC1TrainingIMG = "courtTraining.png";
            //internal const string DLC1Katto_Night = "takatto_court_tweak_takatto.dat";
            //internal const string DLC1Katto_Sunny= "takatto_court_tweak_takatto_sunny.dat";
            //internal const string DLC1Katto = "takatto_tweak_dlc1_takatto.dat";
            //internal const string DLC1KattoCN = "takatto_tweak_dlc1_takatto_CHN.dat";
            //internal const string DLC1KattoIMG = "courtTakatto.png";
            //internal const string DLC1Beach_New = "takatto_court_tweak_tourny_new.dat";
            //internal const string DLC1Beach_Default = "takatto_court_tweak_tourny.dat";
            //internal const string DLC1Beach = "takatto_tweak_dlc1_tourny.dat";
            //internal const string DLC1BeachCN = "takatto_tweak_dlc1_tourny_CHN.dat";
            //internal const string DLC1BeachIMG = "courtBeach.png";
            //internal const string DLC1Warehouse_Default = "takatto_court_tweak_hidden_warehouse.dat";
            //internal const string DLC1Warehouse_New = "takatto_court_tweak_hidden_warehouse_new.dat";
            //internal const string DLC1Warehouse = "takatto_tweak_dlc1_hidden_warehouse.dat";
            //internal const string DLC1WarehouseCN = "takatto_tweak_dlc1_hidden_warehouse_CHN.dat";
            //internal const string DLC1WarehousehIMG = "courtHidden.png";

            //internal const string DLC1Custom = "takatto_tweak_dlc1_custom.dat";
            //internal const string DLC1CustomCN = "takatto_tweak_dlc1_custom_CHN.dat";

            //internal const string DLC1Default = "takatto_tweak_dlc1_{0}.dat";
            //internal const string DLC1DefaultIMG = "courtDefault.png";

            //internal const string DLC5Manifest = "takatto_tweak_dlc5.dat";
            //internal const string DLC3 = "takatto_tweak_dlc3_{0}_def.dat";
            //internal const string DLC6 = "{0}.dat";
            //internal const string DLCExtra = "takatto_dlc_extra.dat";

            //internal const string SoundSample = "sample.mp3";
            //internal const string KatLog = "katlog.txt";
            //internal const string BGMKatto = "bgmkatto.dat";
            //internal const string RemoveList = "rmvlist.dlc";
            //internal const string StringDataKatto = "StringData_KAT.xml";
            //internal const string UICore = "takatto_sv_1.nxgz.dat";
            //internal const string UILibrary = "takatto_sv_1.lib.dat";
            //internal const string UIManifest = "takatto_sv_1.dat";
            //internal const string KattoLoadingPNG = "katto_loading_screen.png";
            //internal const string KattoLoadingPNGDefault = "katto_loading_screen_default.png";
        }
    }
}