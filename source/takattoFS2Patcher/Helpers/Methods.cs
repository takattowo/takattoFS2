using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using takattoFS2.Controls.Models;
using System.Windows.Shapes;
using takattoFS2.Helpers.GlobalVariables;
using FileName = takattoFS2.Helpers.GlobalVariables.Strings.FileName;
using FolderName = takattoFS2.Helpers.GlobalVariables.Strings.FolderName;
using KattoFileName = takattoFS2.Helpers.GlobalVariables.Strings.KattoFileName;
using Path = System.IO.Path;
using System.Xml;
using static System.Windows.Forms.LinkLabel;
using System.Security.Policy;
using System.DirectoryServices.ActiveDirectory;

namespace takattoFS2.Helpers
{
    internal class Methods
    {    
        internal static void DownloadFile(string url, string file, string dest)
        {
            if(Forms.MainForm.mf != null)
                Forms.MainForm.mf.DownloadFile(url, file, dest);
        }

        internal static void DownloadSweetAsset(string uri, string st, string path, bool ignoreException)
        {
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    var url = String.Format(uri, st);
                    client.DownloadFile(new Uri(url), Path.Combine(UserSettings.PatcherPath, path, st));
                }
                catch (Exception e)
                {
                    client.CancelAsync();
                    if (!ignoreException)
                        Logger.Write("The asset " + st + " has failed to download. Kat-code: " + e.ToString());
                }
            }
        }

        internal static void MakeSureFolderExists(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                MsgBoxs.Warning.FailedToCreatePath(e.ToString());
            }
        }

        internal static string BasedLanguageUri(string text)
        {
            switch (UserSettings.UILanguageCode)
            {
                case "en":
                    return text.Replace("_{0}", "").Replace("{0}", "");
                case "ko":
                    return text.Replace("{0}", "kr");
                case "zh":
                    return text.Replace("{0}", "zh");
                default:
                    return text.Replace("_{0}", "").Replace("{0}", "");
            }   
        }

        internal static bool DirectoryHasRights(string folderPath, FileSystemRights rights)
        {
            var currentUserIdentity = WindowsIdentity.GetCurrent();
            SecurityIdentifier currentUserSID = currentUserIdentity.User;
            bool allow = false;
            bool deny = false;
            DirectorySecurity acl = Directory.GetAccessControl(folderPath);
            if (acl == null)
            {
                return false;
            }

            AuthorizationRuleCollection accessRules = acl.GetAccessRules(true, true, typeof(SecurityIdentifier));
            if (accessRules == null)
            {
                return false;
            }

            foreach (FileSystemAccessRule accessRule in accessRules)
            {
                if (currentUserSID.Equals(accessRule.IdentityReference))
                {
                    if ((rights & accessRule.FileSystemRights) != rights)
                    {
                        continue;
                    }

                    if (accessRule.AccessControlType == AccessControlType.Allow)
                    {
                        allow = true;
                    }
                    else if (accessRule.AccessControlType == AccessControlType.Deny)
                    {
                        deny = true;
                    }
                }
            }

            return allow && !deny;
        }

        internal static string SecurityExePath()
        {
            string securityExePath = Path.Combine(Path.GetTempPath(), Strings.FileName.SecurityExe);
            
            if(!File.Exists(securityExePath))
            {
                try
                {
                    File.WriteAllBytes(securityExePath, Properties.Resources.DirectoryRights);
                }
                catch { return null; }
            }
               
            return securityExePath;
        }

        internal static bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                System.Drawing.Point formTopLeft = new System.Drawing.Point(form.Left, form.Top);

                if (screen.WorkingArea.Contains(formTopLeft))
                    return true;
            }

            return false;
        }

        internal static void EnsureDirectoryRights(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
                return;

            FileSystemRights rights = FileSystemRights.Modify;

            if (!DirectoryHasRights(folderPath, rights))
            {
                Logger.Write("Granting directory permissions");
                string securityExePath = SecurityExePath();

                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    Verb = "runas",
                    Arguments = $"\"{folderPath}\" \"{rights}\"",
                    FileName = securityExePath
                };

                try
                {
                    var process = Process.Start(startInfo);

                    if (!process.WaitForExit(10000))
                    {
                        process.Kill();
                    }

                    int exitCode = process.ExitCode;

                    if (exitCode != 0)
                    {
                        if (exitCode == -2)
                            MsgBoxs.Warning.Error(StringLoader.GetText("msgtitle_game_folder_not_found"));
                        else
                            MsgBoxs.Warning.Error("Exit: " + exitCode.ToString() + ".");
                    }

                }
                catch (Exception ex) { MsgBoxs.Warning.Error("Could not access folder permissions, I assume you have full access by default. Error code: " + ex.Message + "."); } 
            }
        }

        internal static bool IsGameFullScreen()
        {
            string nationCheckeru = null;

            try
            {
                nationCheckeru = File.ReadAllText(GetFolder(FileName.Option));
            }
            catch { }

            if (!string.IsNullOrEmpty(nationCheckeru))
            {
                var ok = (GetInt(Regex.Match(nationCheckeru, @"FullMode=\d+").ToString()) == 1) ? true : false;
                return ok;
            }

            return false;
        }

        internal static bool IsWindowsActivated(IntPtr hw)
        {
            return NativeMethods.GetForegroundWindow() == hw;
        }

        internal static int GetTitlebarHeight(IntPtr window_handle)
        {
            NativeMethods.RECT window_rectangle = new NativeMethods.RECT();
            NativeMethods.RECT client_rectangle = new NativeMethods.RECT();
            int height, width;
            NativeMethods.GetWindowRect(window_handle, ref window_rectangle);
            NativeMethods.GetClientRect(window_handle, ref client_rectangle);
            height = (window_rectangle.bottom - window_rectangle.top) - (client_rectangle.bottom - client_rectangle.top);
            width = (window_rectangle.right - window_rectangle.left) - (client_rectangle.right - client_rectangle.left);
            return height - (width / 2);
        }

        internal static bool IsValidFS2Path(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            bool f1 = Directory.Exists(path);

            string dataPath = Path.Combine(path, FolderName.Data);
            bool f2 = Directory.Exists(dataPath);

            string exePath = Path.Combine(path, FileName.GameExe);
            bool f3 = File.Exists(exePath);

            string dllPath = Path.Combine(path, FileName.GameAppDll);
            bool f4 = File.Exists(dllPath);

            return f1 && f2 && f3 && f4;
        }

        internal static void KillLauncher(bool forceKillWithoutCheckingIfGameIsRunning)
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return;

            Process[] KR = Process.GetProcessesByName(Strings.Misc.LauncherKrProcessName);
            Process[] Global = Process.GetProcessesByName(Strings.Misc.LauncherProcessName);
            Process[] GlobalSteam = Process.GetProcessesByName(Strings.Misc.LauncherSteamProcessName);
            
            if (Global.Length >= 1)
            {
                try
                {
                    if (Global[0].MainModule.FileName == @GetFolder(FileName.LauncherExe) )
                    {
                        if(IsGameRunning_Alt() || forceKillWithoutCheckingIfGameIsRunning)
                            Global[0].Kill();
                    }
                        
                }
                catch { }
            }

            if (GlobalSteam.Length >= 1)
            {
                try
                {
                    if (GlobalSteam[0].MainModule.FileName == @GetFolder(FileName.LauncherSteamExe))
                    {
                        if (IsGameRunning_Alt() || forceKillWithoutCheckingIfGameIsRunning)
                            GlobalSteam[0].Kill();
                    }
                }
                catch { }
               
            }

            if (KR.Length >= 1)
            {
                try
                {
                    if (KR[0].MainModule.FileName == @GetFolder(FileName.LauncherExeKr))
                    {
                        if (IsGameRunning_Alt() || forceKillWithoutCheckingIfGameIsRunning)
                            KR[0].Kill();
                    }
                }
                catch { }        
            }

            //foreach (var kr1 in KR) { kr1.Kill(); }
        }

        internal static bool suspended = false;
        internal static void SuspendGame()
        {
            if (RunningFS2Process != null)
            {
                if (!suspended)
                {
                    suspended = true;
                    RunningFS2Process.Suspend();
                }
                else
                {
                    suspended = false;
                    RunningFS2Process.Resume();
                }
            }
        }

        //static bool suspended = false;
        internal static void KillGame()
        {
            if (RunningFS2Process != null)
            {
                try
                {
                    RunningFS2Process.Kill();
                }
                catch { }
            }         
        }

        internal static IntPtr ProcessHandler()
        {
            if (RunningFS2Process != null)
            {
                Process[] collectionOfProcess = Process.GetProcessesByName(Strings.Misc.GameProcessName);
                if (collectionOfProcess.Length > 0)
                {
                    for (int i = 0; i < collectionOfProcess.Length; i++)
                    {
                        try
                        {
                            if (collectionOfProcess[i].Id == RunningFS2Process.Id)
                            {
                                return collectionOfProcess[i].MainWindowHandle;
                            }
                        }
                        catch { return (IntPtr)null; }
                    }
                }         
            }
                         
            return (IntPtr)null;
        }

        internal static bool IsGameRunning_Alt()
        {
            return Forms.MainForm.mf.isGameRunning;
        }


        // temporary fixes due to the game process has been intinialized the Loader to hide its process, for now
        internal static bool IsGameRunning()
        {
            Process[] processes = Process.GetProcessesByName(Strings.Misc.GameProcessName);

            if(processes.Length > 0)
            {
                try
                {
                    RunningFS2Process = processes[0];
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }

                return true;
            }

            RunningFS2Process = null;
            return false;
        }

        internal static Process RunningFS2Process;
        internal static bool IsGameRunning_()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;
            
            string targetProcessPath = @GetFolder(FileName.GameExe);

            Process[] collectionOfProcess = Process.GetProcessesByName(Strings.Misc.GameProcessName);

            if (collectionOfProcess.Length > 0)
            {
                for (int i = 0; i < collectionOfProcess.Length; i++)
                {
                    if (RunningFS2Process != null)
                    {
                        var IsIt = collectionOfProcess[i].Id == RunningFS2Process.Id;
                        if (IsIt)
                            return true;
                    }

                    if (RunningFS2Process == null)
                    {


                        try
                        {
                            if (collectionOfProcess[i].MainModule.FileName == targetProcessPath) //permission error could throw by xigncode
                            {
                                RunningFS2Process = collectionOfProcess[i];
                                return true;
                            }
                        }
                        catch
                        { //no log because it would fill up the log
                            //suspended = false;
                            //return false; 
                        }
                    }
                }
            }
            
            RunningFS2Process = null;
            suspended = false;
            return false;
        }

        internal static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        internal static void MegaHideFile(string filePath)
        {
            try
            {
                File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden | FileAttributes.System);
            }
            catch { }
        }

        internal static bool AlertIfFS2FolderIsMissing(Form form)
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
            {
                if(Forms.MainForm.mf == null)
                {
                    MsgBoxs.Warning.IncorrectParametter(form);
                    return true;
                }

                var diag = MsgBoxs.Dialog.GameFolderNotFound(form);
                if (diag == DialogResult.Yes)
                    Forms.MainForm.mf.BrowseGameDirectory_Click(null, null);

                return true;
            }

            return false;
        }

        internal static string NationNumberToCountry(int number)
        {
            switch (number)
            {
                case 0:
                    return "KOR";
                case 1:
                    return "CHN";
                case 2:
                    return "TWN";
                case 3:
                    return "ENG";
                case 5:
                    return "GER";
                case 6:
                    return "FRA";
                case 7:
                    return "THI";
                case 8:
                    return "JPN";
                default:
                    return "ENG";
            }
        }

        internal static bool AlertIfGameIsRunning(Form form)
        {
            if (AlertIfFS2FolderIsMissing(form))
            {
                return true;
            }

            if (IsGameRunning_Alt())
            {
                MsgBoxs.Warning.CloseGameFirst(form);
                return true;
            }        

            return false;
        }

        internal static bool IsFreeStyle2Running()
        {
            return Process.GetProcessesByName(Strings.Misc.GameProcessName).Length > 0;
        }

        internal static bool IsSteamRunning()
        {
            return Process.GetProcessesByName(Strings.Misc.SteamProcessName).Length > 0;
        }

        internal static string GetGameFolder()
        {
            return UserSettings.GamePath;
        }

        internal static string GetFolder(params string[] folder)
        {
            var gameFolder = GetGameFolder();
            if (string.IsNullOrEmpty(gameFolder))
                return null;

            for (int i = 0; i < folder.Length; i++)
            {
                if(!string.IsNullOrEmpty(folder[i]))
                    gameFolder = Path.Combine(gameFolder, folder[i]);
            }

            return gameFolder;
        }

        internal static void Run(string FilePath, params string[] arguments)
        {
            var proc = new Process();
            proc.StartInfo.WorkingDirectory = GetGameFolder();
            proc.StartInfo.FileName = FilePath;
            if (arguments.Length > 0) proc.StartInfo.Arguments = arguments[0];
            
            proc.Start();
            Logger.Write(FilePath + " launched.");
        }

        internal static void AdminRightsEnforcing(bool force)
        {
            if (!RunningAsAdmin(force))
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = AssemblyAccessor.FileName;
                proc.Verb = "runas";
                try
                {
                    Process.Start(proc);
                    Environment.Exit(0);
                }
                catch
                {
                    Environment.Exit(0);
                    //return;
                    //var dia = MessageBox.Show("Could not elevate administrator rights, some of functions of the program may not apply to the game~ \n\nDo you want to process?", "I am fine UwU/", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    //if (dia != DialogResult.Yes)
                    //{
                    //    Environment.Exit(0);
                    //}
                }
            }
        }
        
        private static bool RunningAsAdmin(bool force)
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            if (force)
                return false;

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static bool ExecuteCMD(string cmd, bool waitforexit)
        {
            Logger.Write("Command executed: " + KATEncryptor.Encrypt(cmd, 1));
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = GetGameFolder(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = cmd
                }
            };

            proc.Start();
             
            if (waitforexit) 
            {
                if (!proc.WaitForExit(60000))
                {
                    proc.Kill();
                    return false;
                }
            }

            return true;
        }

        internal static void RunAsUser(string FilePath)
        {
            try
            {
                File.WriteAllText(GetFolder("katto_run_helper.bat"), "echo off \necho Elevating process without administrator privileges... \n" +  $"cd /d { GetGameFolder()} \n" + "echo Launching the launcher... \necho This window may not close correctly if using Terminal~\n" + "Start " + FilePath.Split('\\').Last() + $"\ndel \"{GetFolder("katto_run_helper.bat")}\"");
            }       
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw e;
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    WorkingDirectory = GetGameFolder(),
                    Arguments = GetFolder("katto_run_helper.bat"),
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Minimized
                }
            };

            proc.Start();
        }

        internal static bool IsTiancityFS2()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            string edllCnPath = GetFolder(FileName.TiancityDll);
            bool f1 = File.Exists(edllCnPath);

            return IsChinaClient() && f1;
        }

        internal static bool IsChinaClient()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            string xigncodeCnPath = GetFolder(FolderName.GameGuardCN);
            bool f1 = Directory.Exists(xigncodeCnPath);

            return f1;
        }

        internal static bool IsKoreaClient()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            string korLauncher = GetFolder(FileName.LauncherExeKr);
            bool f1 = File.Exists(korLauncher);

            return f1;
        }

        internal static bool IsJukeBoxDLCinstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            return Directory.Exists(GetFolder(FolderName.Jukebox)) && File.Exists(GetFolder(FolderName.Data, KattoFileName.BGMKatto));
        }

        internal static bool IsCharacterVoiceInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            return Directory.Exists(GetFolder(FolderName.DLC5)) 
                && File.Exists(GetFolder(FolderName.DLC5,KattoFileName.DLC5Manifest));
        }

        internal static bool IsCharacterVoiceInstalled(string lang)
        {
            if (!IsCharacterVoiceInstalled() || !Directory.Exists(GetFolder(FolderName.DLC5, lang)))
                return false;
            
            return File.Exists(GetFolder(FolderName.DLC5, lang, FileName.VoiceSoundRes)) | File.Exists(GetFolder(FolderName.DLC5, lang, FileName.VoiceSoundResXML));
        }

        internal static string IsCharacterVoiceSampleInstalled(string lang)
        {
            if (File.Exists(GetFolder(FolderName.DLC5, lang, KattoFileName.SoundSample)))
                return GetFolder(FolderName.DLC5, lang, KattoFileName.SoundSample);

            return null;
        }

        internal static bool IsMCVoiceInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            return Directory.Exists(GetFolder(FolderName.DLC6));
        }

        internal static bool IsMCVoiceInstalled(string lang)
        {
            if (!IsMCVoiceInstalled() || !Directory.Exists(GetFolder(FolderName.DLC6, lang)))
                return false;

            var files = Directory.GetFiles(GetFolder(FolderName.DLC6, lang), "*.bml");
            var files2 = Directory.GetFiles(GetFolder(FolderName.DLC6, lang), "*.xml");

            return files.Any() | files2.Any();
        }

        internal static string IsMCVoiceSampleInstalled(string lang)
        {
            if (File.Exists(GetFolder(FolderName.DLC6, lang, KattoFileName.SoundSample)))
                return GetFolder(FolderName.DLC6, lang, KattoFileName.SoundSample);

            return null;
        }

        internal static bool IsCustomTextureInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            var smthing = PopulateCustomUIList(KattoFileName.UITextureManifest);

            return (smthing != null && smthing.Length > 0);
        }

        internal static bool IsUIInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            if(File.Exists(GetFolder(FolderName.Data, KattoFileName.UILibrary)))
                MegaHideFile(GetFolder(FolderName.Data, KattoFileName.UILibrary));

            return File.Exists(GetFolder(FolderName.Data, KattoFileName.UIManifest)) 
                //&& File.Exists(GetFolder(FolderName.Data, KattoFileName.UICore))
                && File.Exists(GetFolder(FolderName.Data, KattoFileName.UILibrary));
        }

        internal static bool IsUIInstalled2()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            if (File.Exists(GetFolder(FolderName.Data, KattoFileName.UILibrary2)))
                MegaHideFile(GetFolder(FolderName.Data, KattoFileName.UILibrary2));

            return File.Exists(GetFolder(FolderName.Data, KattoFileName.UIManifest2))
                && File.Exists(GetFolder(FolderName.Data, KattoFileName.UILibrary2));
        }

        internal static bool IsFontInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;        
            
            return File.Exists(GetFolder(FolderName.Language, KattoFileName.FontConfig));
        }

        internal static bool IsCustomLanguageInstalled()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            return File.Exists(GetFolder(FolderName.Language, KattoFileName.FontConfigKatto)) 
                && File.Exists(GetFolder(FolderName.Language, KattoFileName.StringDataKatto));
        }

        internal static bool IsCustomPatchAvailable()
        {
            if (string.IsNullOrEmpty(GetGameFolder()))
                return false;

            //MakeSureFolderExists(GetFolder(FolderName.CustomPatch));

            if (Directory.Exists(GetFolder(FolderName.CustomPatch)))
            {
                var customePatchLoadedList = Directory.GetFiles(GetFolder(FolderName.CustomPatch)).Select(file => Path.GetFileName(file)).ToArray();
                for (int i = 0; i < customePatchLoadedList.Length; i++)
                {
                    try
                    {
                        if (File.Exists(GetFolder(customePatchLoadedList[i])) || Path.GetExtension(GetFolder(customePatchLoadedList[i])).ToLower() == ".rmv")
                            return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                            
            }
            
            return false;
        }

        internal static string CheckIfTextExistIfNotThenAddFirst(string texttocheck, string strinzg)
        {
            if (!strinzg.Contains("[") && !strinzg.Contains(texttocheck))
                strinzg = texttocheck + " " + strinzg;

            return strinzg;
        }

        internal static string[] PopulateExtensionList()
        {
            if (!Directory.Exists(GetFolder(FolderName.Extension)))
                return null;

            return Directory.GetFiles(GetFolder(FolderName.Extension), "*.exe")
                .Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
        }

        internal static void ExtractKatAddon(string path)
        {
            if (!Directory.Exists(path))
                return;

            var files = Directory.GetFiles(path, "*.kat");
            if(files.Length != 0)
            {
                foreach(var otem in files)
                {
                    try
                    {
                        UnZipping(otem, path, true, true);
                    }
                    catch (Exception e) 
                    { 
                        Logger.Write(e.ToString());  
                        File.Delete(otem); 
                    }
                }
            }
        }

        private static List<string> swfFiles;
        static void CopyDatlFiles(string sourceFolder, string destinationFolder, bool records)
        {
            Directory.CreateDirectory(destinationFolder);
            foreach (var datlFilePath in Directory.GetFiles(sourceFolder, "*.swf"))
            {
                string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(datlFilePath));
                File.Copy(datlFilePath, destinationPath, true);

                if (records)
                {
                    swfFiles.Add(Path.GetFileName(datlFilePath));
                }
            }
        }
        public static string GetHardwareId()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "csproduct get uuid",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();
            var lines = output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            return lines.Length > 1 ? lines[1].Trim() : string.Empty;
        }


        internal static IEnumerable<string> FindFoldersWithOnlySWFFiles(string directoryPath)
        {
            var result = new List<string>();

            foreach (var subdirectory in Directory.GetDirectories(directoryPath))
            {
                // Check if the folder contains only SWF files
                bool containsOtherFiles = Directory.EnumerateFiles(subdirectory)
                    .Any(file => !file.EndsWith(".swf", StringComparison.OrdinalIgnoreCase));

                if (!containsOtherFiles)
                {
          
                        

                        CopyDatlFiles(subdirectory, GetFolder(Strings.FolderName.UI), true);
                        result.Add(subdirectory);                   
                }
            }

            foreach (var subdirectory in Directory.GetDirectories(directoryPath))
            {
                result.AddRange(FindFoldersWithOnlySWFFiles(subdirectory));
            }

            return result;
        }

        internal static IEnumerable<string> FindPatchFiles(string directoryPath, string[] validExtensions)
        {
            var result = new List<string>();

            foreach (var filePath in Directory.GetFiles(directoryPath, "patch.*"))
            {
                if (IsValidExtension(filePath, validExtensions))
                {
                    result.Add(filePath);

                    // Copy .swf files from the folder containing the "patch" file to the destination folder
                    CopyDatlFiles(Path.GetDirectoryName(filePath), GetFolder(Strings.FolderName.UI), false);
                }
            }

            foreach (var subdirectory in Directory.GetDirectories(directoryPath))
            {
                result.AddRange(FindPatchFiles(subdirectory, validExtensions));
            }

            return result;
        }


        internal static string[] FindFoldersWithPatchFile(string directoryPath, string[] validExtensions)
        {
            var result = Directory.GetDirectories(directoryPath)
                .Where(dir => Directory.GetFiles(dir, "patch.*").Any(file => IsValidExtension(file, validExtensions)))
                .ToArray();

            foreach (var subdirectory in Directory.GetDirectories(directoryPath))
            {
                result = result.Concat(FindFoldersWithPatchFile(subdirectory, validExtensions)).ToArray();
            }

            return result;
        }

        internal static List<string> FindFilesInFolder(string folderPath, string excludeFileName)
        {
            List<string> filePaths = new List<string>();

            try
            {
                // Get all files in the current folder
                string[] files = Directory.GetFiles(folderPath);

                // Filter out files with the excludeFileName
                files = files.Where(file => Path.GetFileName(file).IndexOf(excludeFileName, StringComparison.OrdinalIgnoreCase) == -1).ToArray();

                // Add the remaining files to the list
                filePaths.AddRange(files);

                // Recursively search subfolders
                string[] subdirectories = Directory.GetDirectories(folderPath);
                foreach (string subdirectory in subdirectories)
                {
                    List<string> subfolderFiles = FindFilesInFolder(subdirectory, excludeFileName);
                    filePaths.AddRange(subfolderFiles);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return filePaths;
        }
   

        internal static bool IsValidExtension(string filePath, string[] validExtensions)
        {
            string extension = Path.GetExtension(filePath);
            return validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        internal static string FindFileWithExtensions(string filePath, string fileName, string[] validExtensions)
        {
            foreach (string extension in validExtensions)
            {
                string fullFilePath = Path.Combine(filePath, $"{fileName}{extension}");
                if (File.Exists(fullFilePath))
                {
                    return fullFilePath;
                }
            }

            return null;
        }


        internal static bool CheckIfPatchConfigExist(string path, string patchid)
        {
            string fileName = "patch"; // Change this variable to the desired file name (without extension)
            string[] validExtensions = new string[] { ".txt", ".xml", ".config", ".kat", "" };
            string filePath = Methods.FindFileWithExtensions(Methods.GetFolder(path, patchid), fileName, validExtensions);

            //now use patchid instead of patch incase the patch.valid extension does not exist
            if (string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(patchid))
            {
                filePath = Methods.FindFileWithExtensions(Methods.GetFolder(path, patchid), patchid, validExtensions);
                if (File.Exists(filePath))
                {
                    string newFileName = "patch.txt";
                    string folderPath = Path.GetDirectoryName(filePath); // Get the directory path
                    string newFilePath = Path.Combine(folderPath, newFileName); // Create the new file path
                    File.Move(filePath, newFilePath);

                    filePath = newFilePath;
                }
            }

            return !string.IsNullOrEmpty(filePath);
        }

        internal static string ReturnPatchConfig(string path, string patchid)
        {
            string fileName = "patch"; // Change this variable to the desired file name (without extension)
            string[] validExtensions = new string[] { ".txt", ".xml", ".config", ".kat", "" };
            string filePath = Methods.FindFileWithExtensions(Methods.GetFolder(path, patchid), fileName, validExtensions);
            //now use patchid instead of patch incase the patch.valid extension does not exist
            //if (string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(patchid))
            //    filePath = Methods.FindFileWithExtensions(Methods.GetFolder(path, patchid), patchid, validExtensions); 

            return filePath != null ? KATEncryptor.Decrypt(File.ReadAllText(filePath), 2) : null;
        }


        internal static string ExtractVersion(string fileContent)
        {
            string pattern = @"<version>(.*?)<\/version>";
            Match match = Regex.Match(fileContent, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }
            return null;
        }

        internal static List<string> ExtractTagItems(string fileContent, string tagName)
        {
            List<string> itemsList = new List<string>();

            // Dynamically build the pattern using the provided tagName
            string pattern = $@"<{tagName}>(.*?)<\/{tagName}>";
            MatchCollection matches = Regex.Matches(fileContent, pattern, RegexOptions.Singleline);

            if (matches.Count > 0)
            {
                string tagContent = matches[0].Groups[1].Value;

                // Split tagContent by newline to get individual items
                string[] items = tagContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in items)
                {
                    itemsList.Add(item.Trim()); // Trim to remove any leading/trailing whitespace
                }
            }

            return itemsList;
        }

        internal static string[] PopulateCustomUIList(string singleFile)
        {
            if (!Directory.Exists(GetFolder(FolderName.CustomUI)))
                return null;

            var array = string.IsNullOrEmpty(singleFile) ? Directory.GetFiles(GetFolder(FolderName.CustomUI), "*.txt")
                .Select(file => Path.GetFileNameWithoutExtension(file)).ToList() 
                : Directory.GetFiles(GetFolder(FolderName.CustomUI), singleFile)
                .Select(file => Path.GetFileNameWithoutExtension(file)).ToList()
                ;

            var array2 = new System.Collections.Generic.List<string>();

            for (int i = 0; i < array.Count; i++)
            {
                bool isValidFile = false;
                string patch_json = KATEncryptor.Decrypt(File.ReadAllText(GetFolder(FolderName.CustomUI, $"{array[i]}.txt")), 2);
                if (!string.IsNullOrEmpty(patch_json))
                {
                    var result = @patch_json.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();
                    if (result != null && result.Length > 1)
                    {
                        for (int ii = 0; ii < result.Length; ii++)
                        {
                            if (!string.IsNullOrWhiteSpace(result[ii]))
                            {
                                if (File.Exists(GetFolder(FolderName.CustomUI, result[ii])))
                                {
                                    isValidFile = true;
                                    array2.Add(array[i]);
                                    break;
                                }
                            }
                        }

                    }
                }

                if (!isValidFile)
                {
                    try { File.Delete(GetFolder(FolderName.CustomUI, $"{array[i]}.txt")); }
                    catch { }
                }
            }

            return array2.ToArray();
        }

        internal static string[] InterfaceLAddonList(string[] something, bool customTexture)
        {
            if (something == null || something.Length <= 0)
                return null;

            var nonconflicts = new System.Collections.Generic.List<string>();
            foreach (var itemw in something)
            {
                var item = itemw.Trim();

                if (!customTexture && KattoFileName.UITextureManifest.Contains(item))
                    continue;

                string patch_json = KATEncryptor.Decrypt(File.ReadAllText(GetFolder(FolderName.CustomUI, $"{item}.txt")), 2);
                var result = @patch_json.Trim('[', ']').Split(new[] { ',' }).Select(x => x.Trim('"')).ToArray();
                for (int i = 0; i < result.Length; i++) //now we do not need to skip version
                {
                    if (!string.IsNullOrEmpty(result[i]))
                    {
                        if(File.Exists(GetFolder(FolderName.CustomUI, result[i])))
                            nonconflicts.Add(result[i]);
                    }
                }
            }

            return nonconflicts.Distinct().ToArray();
        }


        internal static ComboBox PopulateDLC1Combobox()
        {
            var cb = new ComboBox();
            if (!Directory.Exists(GetFolder(FolderName.DLC1Default)))
            {
                cb.Items.Add(StringLoader.GetText("lb_tweak_patch_none"));
                return cb;
            }
                  
            var defaultCourtLoadedList = Directory.GetFiles(GetFolder(FolderName.DLC1Default), "*.dlc1")
                .Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
            for (int i = 0; i < defaultCourtLoadedList.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(defaultCourtLoadedList[i]))
                {
                    cb.Items.Add(defaultCourtLoadedList[i]);
                }
            }

            if(cb.Items.Count <= 0)
                cb.Items.Add(StringLoader.GetText("lb_tweak_patch_none"));

            return cb;
        }

        internal static System.Drawing.Point GetGameCursor(IntPtr hWnd)
        {
            NativeMethods.RECT rc = new NativeMethods.RECT();
            NativeMethods.GetWindowRect(hWnd, ref rc);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(rc.left, rc.top, rc.right, rc.bottom);
            System.Drawing.Point p = Cursor.Position;

            var x = (Cursor.Position.X - rc.left);
            var y = (Cursor.Position.Y - rc.top);

            if (rect.Contains(p))
                return new System.Drawing.Point(x, y);
            else
                return new System.Drawing.Point(0, 0);
        }

        internal static long CleanUp()
        {
            long totalSize = 0;
            DirectoryInfo di = new DirectoryInfo(Path.Combine(UserSettings.PatcherPath, FolderName.TempFolder));

            foreach (FileInfo file in di.GetFiles())
            {
                totalSize += file.Length;
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            return totalSize;
        }
        internal static Stopwatch w = new Stopwatch();
        internal static void UnZipping(string downloadedFile, string extractDirectory, bool overwrite, bool deleteFileUponCompletion)
        {
            if (!File.Exists(downloadedFile))
            {
                Logger.Write("Failed to extract " + downloadedFile + " . Kat-code: Non-existence.");
                return;
            }

            using (ZipArchive archive = ZipFile.OpenRead(downloadedFile))
            {
                if (downloadedFile.Contains(KattoFileName.UILibrary) || downloadedFile.Contains(KattoFileName.UILibrary2))
                    Logger.Write("Extracting service library.");
                else
                    Logger.Write("Extracting " + downloadedFile);

                foreach (var entry in archive.Entries)
                {
                    var entryPath = Path.Combine(extractDirectory, entry.FullName).Replace("/", "\\");

                    // Ensure that the directory containing the file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(entryPath));

                    if (!entryPath.EndsWith("\\"))
                    {
                        if (overwrite)
                            entry.ExtractToFile(entryPath, true);
                        else if (!File.Exists(entryPath))
                            entry.ExtractToFile(entryPath);
                        // Optionally, you can use await Task.Run() here for parallel extraction.
                    }
                }

                Logger.Write("Finished extracting.");
            }

            if (deleteFileUponCompletion)
                File.Delete(downloadedFile);
        }


        internal static bool CheckIfMatchServiceCondition(Controls.Models.Service yes)
        {
            if (yes == null)
                return false;

            if (string.IsNullOrEmpty(yes.condition))
            {
                yes.isNotMatchedCondition = false;
                return true;
            }

            if (yes.condition.Split(':')[0] == "has_file")
            {
                var items = yes.condition.Split(':')[1].Split(';').ToArray();
                if(items != null && items.Length > 0)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (File.Exists(GetFolder(items[i])))
                        {
                            yes.isNotMatchedCondition = false;
                            return true;
                        }
                    }
                }
            }

            if (yes.condition.Split(':')[0] == "has_character")
            {
                var files = Directory.GetFiles(GetGameFolder(), "*.dat");
                var items = yes.condition.Split(':')[1].Split(';').ToArray();
                if(files.Length > 0)
                {
                    if (items != null && items.Length > 0)
                    {
                        foreach (var file in files)
                        {
                            if (File.Exists(file))
                            {
                                var fileInfo = new FileInfo(file);
                                if (fileInfo.Length >= 29 && fileInfo.Length < 1024)
                                {
                                    //read content of the file and check if it has the character
                                    var fileContent = File.ReadAllText(file);
                                    for (int i = 0; i < items.Length; i++)
                                    {
                                        if (fileContent.Contains(items[i]))
                                        {
                                            yes.isNotMatchedCondition = false;
                                            return true;
                                        }
                                    }                   
                                }
                            }
                        }
                    }
                }
                
            }

            yes.isNotMatchedCondition = true;
            return false;
        }

        internal static string GenerateStringWithoutNumber(int size)
        {
            var AlphabetWithoutNumber = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ\\][-+=)(*&^%$#@!{}/";
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = AlphabetWithoutNumber[new Random().Next(AlphabetWithoutNumber.Length)];
            }
            return new string(chars);
        }   

        internal static void TweakRestore()
        {
            //temporary lmao
            try
            {
                if(File.Exists(GetFolder("temp_" + FileName.UI)) && File.Exists(GetFolder(FileName.UI)))
                {
                    MoveFile(GetFolder(FileName.UI), GetFolder(FileName.UIModded), false);
                    MoveFile(GetFolder("temp_" + FileName.UI), GetFolder(FileName.UI), false);  
                }
            }
            catch (Exception e1)
            {
                Logger.Write(e1.ToString());
            }

            DirectoryInfo dir = new DirectoryInfo(GetGameFolder());
            FileInfo[] files = dir.GetFiles("temp_*", SearchOption.TopDirectoryOnly);
            foreach (var item in files)
            {
                string itemName1 = item.FullName;
                string itemName2 = item.FullName.Replace("temp_", "");
                try
                {
                    MoveFile(GetFolder(itemName1), GetFolder(itemName2), false);
                }
                catch (Exception e1) 
                { 
                    Logger.Write(e1.ToString()); 
                }               
            }
        }

        public static int CompareVersions(string version1, string version2)
        {
            string[] parts1 = version1.Split('.');
            string[] parts2 = version2.Split('.');

            for (int i = 0; i < Math.Max(parts1.Length, parts2.Length); i++)
            {
                int part1 = i < parts1.Length ? int.Parse(parts1[i]) : 0;
                int part2 = i < parts2.Length ? int.Parse(parts2[i]) : 0;

                if (part1 < part2)
                {
                    return -1; // version1 is lower
                }
                else if (part1 > part2)
                {
                    return 1; // version1 is higher
                }
            }

            return 0; // versions are equal
        }


        internal static int GetInt(string strRawData)
        {
            if (!CheckIfNumberValid(strRawData))
                return 0;

            int numba = Int32.Parse(Regex.Replace(strRawData, "[^0-9]", ""));
            return numba;
        }

        internal static bool CheckIfNumberValid(string strRawData)
        {
            try
            {
                int numba = Int32.Parse(Regex.Replace(strRawData, "[^0-9]", ""));
                return true;
            }
            catch 
            { 
                return false;
            }
        }

        //private static void Sound00Patch(bool _isReserved, string fileName, string oldText)
        //{          
        //    byte[] fileBytes = File.ReadAllBytes(fileName),
        //    oldBytes = !_isReserved ? Encoding.UTF8.GetBytes(oldText) : Encoding.UTF8.GetBytes("kat" + oldText.Substring(3)),
        //    newBytes = !_isReserved ? Encoding.UTF8.GetBytes("kat" + oldText.Substring(3)) : Encoding.UTF8.GetBytes(oldText);

        //    int index = IndexOfBytes(fileBytes, oldBytes);

        //    if (index < 0)
        //        return;

        //    byte[] newFileBytes = new byte[fileBytes.Length + newBytes.Length - oldBytes.Length];
        //    Buffer.BlockCopy(fileBytes, 0, newFileBytes, 0, index);
        //    Buffer.BlockCopy(newBytes, 0, newFileBytes, index, newBytes.Length);
        //    Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
        //        newFileBytes, index + newBytes.Length,
        //        fileBytes.Length - index - oldBytes.Length);

        //    File.WriteAllBytes(fileName, newFileBytes);
        //}

        //internal static void WriteBytesLargeFile(bool _isReserved, string fileName, string writeToLocation, params string[] toChange)
        //{
        //    if (toChange == null || toChange.Length <= 0 || !File.Exists(fileName))
        //    {
        //        Logger.Write("Failed to invoke WriteChunks method, either the file does not exist or no chunks were provided.");
        //        return;
        //    }

        //    const int BufSize = 32 * 1024; // 32K you can also increase this
        //    using (var fileStream = new FileStream(fileName, FileMode.Open))
        //    using (var fileStreamWrite = new FileStream(writeToLocation, FileMode.Append))
        //    {
        //        using (var reader = new BinaryReader(fileStream))
        //        {
        //            var chunk = new byte[BufSize];
        //            var ix = 0;
        //            var read = 0;
        //            while ((read = reader.Read(chunk, ix, BufSize)) > 0)
        //            {
        //                ix += read;

        //                for (int i = 0; i < toChange.Length; i++)
        //                {
        //                    var ekw = "\\" + KATEncryptor.Decrypt(toChange[i], 2).Trim();
        //                    if (ekw.Contains("loop_") || ekw.Contains("LOOP_"))
        //                    {
        //                        string ewk = ekw.Replace("LOOP_", "").Replace("loop_", "");
        //                        var oldBytes = !_isReserved ? Encoding.UTF8.GetBytes(ewk) : Encoding.UTF8.GetBytes("Kat" + ewk.Substring(3));
        //                        var newBytes = !_isReserved ? Encoding.UTF8.GetBytes("Kat" + ewk.Substring(3)) : Encoding.UTF8.GetBytes(ewk);
        //                        while (true)
        //                        {
        //                            int index = IndexOfBytes(chunk, oldBytes);
        //                            if (index > 0)
        //                            {
        //                                //isFileChanged = true;
        //                                //Buffer.BlockCopy(fileBytes, 0, fileBytes, 0, index);
        //                                Buffer.BlockCopy(newBytes, 0, chunk, index, newBytes.Length);
        //                                Buffer.BlockCopy(chunk, index + oldBytes.Length,
        //                                    chunk, index + newBytes.Length,
        //                                    chunk.Length - index - oldBytes.Length);

        //                                fileStreamWrite.Write(chunk, 0, chunk.Length);
        //                            }
        //                            else
        //                                break;
        //                        }
        //                    }
        //                    else if (!string.IsNullOrEmpty(ekw))
        //                    {
        //                        var oldBytes = !_isReserved ? Encoding.UTF8.GetBytes(ekw) : Encoding.UTF8.GetBytes("Kat" + ekw.Substring(3));
        //                        var newBytes = !_isReserved ? Encoding.UTF8.GetBytes("Kat" + ekw.Substring(3)) : Encoding.UTF8.GetBytes(ekw);

        //                        int index = IndexOfBytes(chunk, oldBytes);

        //                        if (index > 0)
        //                        {
        //                            toChange[i] = "";
        //                            //isFileChanged = true;
        //                            //Buffer.BlockCopy(fileBytes, 0, fileBytes, 0, index);
        //                            Buffer.BlockCopy(newBytes, 0, chunk, index, newBytes.Length);
        //                            Buffer.BlockCopy(chunk, index + oldBytes.Length,
        //                                chunk, index + newBytes.Length,
        //                                chunk.Length - index - oldBytes.Length);

        //                        }
        //                    }
        //                }

        //                fileStreamWrite.Write(chunk, 0, ix);
        //            }
        //        }
        //    }

        //}


        private static int IndexOfBytes(byte[] searchBuffer, byte[] bytesToFind)
        {
            if (searchBuffer.Length < bytesToFind.Length)
                return -1;

            for (int i = 0; i <= searchBuffer.Length - bytesToFind.Length; i++)
            {
                bool success = true;

                for (int j = 0; j < bytesToFind.Length; j++)
                {
                    if (searchBuffer[i + j] != bytesToFind[j])
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                    return i;
            }

            return -1;
        }

        internal static void WriteBytes(bool _isReserved, string fileName, string writeToLocation, params string[] toChange)
        {
            if (toChange == null || toChange.Length <= 0 || !File.Exists(fileName))
            {
                Logger.Write("Failed to invoke WriteChunks method, either the file does not exist or no chunks were found.");
                return;
            }


            byte[] fileBytes = File.ReadAllBytes(fileName);
            bool isFileChanged = false;

            foreach (var st in toChange)
            {
                //var ekw = "\\" + KATEncryptor.Decrypt(st, 2).Trim();
                var ekw = "\\" + st.Trim();
                if (ekw.ToLower().Contains("loop_"))
                {
                    string ewk = ekw.Replace("LOOP_", "").Replace("loop_", "");
                    var oldBytes = !_isReserved ? Encoding.UTF8.GetBytes(ewk) : Encoding.UTF8.GetBytes("Kat" + ewk.Substring(3));
                    var newBytes = !_isReserved ? Encoding.UTF8.GetBytes("Kat" + ewk.Substring(3)) : Encoding.UTF8.GetBytes(ewk);
                    while(true)
                    {
                        int index = IndexOfBytes(fileBytes, oldBytes);
                        if (index > 0)
                        {
                            isFileChanged = true;
                            Buffer.BlockCopy(fileBytes, 0, fileBytes, 0, index);
                            Buffer.BlockCopy(newBytes, 0, fileBytes, index, newBytes.Length);
                            Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
                                fileBytes, index + newBytes.Length,
                                fileBytes.Length - index - oldBytes.Length);
                        }
                        else
                            break;
                    }
                }
                else if (!string.IsNullOrEmpty(ekw))
                {
                    var oldBytes = !_isReserved ? Encoding.UTF8.GetBytes(ekw) : Encoding.UTF8.GetBytes("Kat" + ekw.Substring(3));
                    var newBytes = !_isReserved ? Encoding.UTF8.GetBytes("Kat" + ekw.Substring(3)) : Encoding.UTF8.GetBytes(ekw);

                    int index = IndexOfBytes(fileBytes, oldBytes);
                    
                    if (index > 0)
                    {
                        isFileChanged = true;
                        Buffer.BlockCopy(fileBytes, 0, fileBytes, 0, index);
                        Buffer.BlockCopy(newBytes, 0, fileBytes, index, newBytes.Length);
                        Buffer.BlockCopy(fileBytes, index + oldBytes.Length,
                            fileBytes, index + newBytes.Length,
                            fileBytes.Length - index - oldBytes.Length);
                    }
                }
            }


            try
            {
                if (!isFileChanged)
                {
                    Logger.Write($"Failed to write to {Path.GetFileName(fileName)}. Kat-code: Chunks-non-existence.");
                    return;
                }

                if (!string.IsNullOrEmpty(writeToLocation))
                    fileName = writeToLocation;

                File.WriteAllBytes(fileName, fileBytes);
            }
            catch (Exception msg) { Logger.Write($"Failed to apply patch(es) to {Path.GetFileName(fileName)}. Kat-code: " + msg.ToString()); }
            finally {
            }
        }
        
        private static string[] PopulateCharacterVoiceDataArray(string lang)
        {
            if (!Directory.Exists(GetFolder(FolderName.DLC5, lang)))
                return null;

            return Directory.GetFiles(GetFolder(FolderName.DLC5, lang), "*.dlc5")
                    .Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
        }
     
        private static void FontSwap(string fromFont, string toFont)
        {
            try
            {
                if(IsGameRunning_Alt())
                {
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.FontConfig, toFont)),
                        GetFolder(FolderName.Language, String.Format(FileName.FontConfig, toFont + "_kekw")), true);
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.FontConfig, fromFont)),
                        GetFolder(FolderName.Language, String.Format(FileName.FontConfig, toFont)), true);
                }
                else
                {
                    MoveFile(GetFolder(FolderName.Language, String.Format(FileName.FontConfig, toFont + "_kekw")), 
                        GetFolder(FolderName.Language, String.Format(FileName.FontConfig, toFont)), false);
                }

                Logger.Write($"Font swapped from {fromFont} to {toFont}");
            }
            catch (Exception msg) { Logger.Write("Failed to apply font. Kat-code: " + msg.ToString()); }
        }

        internal static bool IsModdedUIUpToDate()
        {
            if (!File.Exists(GetFolder(FileName.UIModded)))
                return false;

            try
            {
                FileInfo fileInfo1 = new FileInfo(GetFolder(FileName.UI));
                FileInfo fileInfo2 = new FileInfo(GetFolder(FileName.UIModded));

                if(fileInfo1.Length != fileInfo2.Length)
                {
                    File.Delete(GetFolder(FileName.UIModded));
                    File.Delete(GetFolder(KattoFileName.UIModded));
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Write($"An error occurred: {ex.Message}");
                return false;
            }
        }

        static string LoadValueToReplaceFromFiles(IEnumerable<string> filePaths, string nodeName)
        {
            string valueToReplace = "";

            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);

                    // Construct the start and end tags for the specified element, case-insensitive
                    string startTag = $"<{nodeName}>";
                    string endTag = $"</{nodeName}>";

                    // Extract the content between start and end tags
                    int startIndex = fileContent.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);
                    int endIndex = fileContent.IndexOf(endTag, StringComparison.OrdinalIgnoreCase);
                    while (startIndex >= 0 && endIndex >= 0)
                    {
                        string elementContent = fileContent.Substring(startIndex, endIndex - startIndex + endTag.Length);
                        valueToReplace += elementContent;

                        // Find the next occurrence, case-insensitive
                        startIndex = fileContent.IndexOf(startTag, endIndex, StringComparison.OrdinalIgnoreCase);
                        endIndex = fileContent.IndexOf(endTag, endIndex + endTag.Length, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }

            return valueToReplace;
        }


        static string LoadValueToReplaceFromFiles_(IEnumerable<string> filePaths)
        {
            string valueToReplace = "";
            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(fileContent))
                    {
                        valueToReplace += fileContent;
                    }
                }
            }

            return valueToReplace;
        }

        internal static bool ModTehUIItself()
        {
            string rootFolderPath = GetFolder(FolderName.CustomUI);

            swfFiles = new List<string>();
            FindFoldersWithOnlySWFFiles(rootFolderPath);
       
            if(!File.Exists(GetFolder(Strings.KattoFileName.UIModded)) && swfFiles != null && swfFiles.Count > 0)
            {
                File.WriteAllText(GetFolder(Strings.KattoFileName.UIModded), string.Join(Environment.NewLine, swfFiles));
                return true;
            }       
            else
            {
                string existingContent = File.Exists(GetFolder(Strings.KattoFileName.UIModded)) ? File.ReadAllText(GetFolder(Strings.KattoFileName.UIModded)) : null;
                string newContent = string.Join(Environment.NewLine, swfFiles);
                if (existingContent != newContent)
                {
                    if(swfFiles.Count <= 0)
                    {
                        File.Delete(GetFolder(Strings.KattoFileName.UIModded));
                    }
                    else
                    {
                        File.WriteAllText(GetFolder(Strings.KattoFileName.UIModded), string.Join(Environment.NewLine, swfFiles));
                    }
                    
                    return true;
                }
                else
                    return false;
            }
        }

        internal static bool ModTehFlashPath()
        {
            string rootFolderPath = GetFolder(FolderName.CustomUI);
            string[] validExtensions = new string[] { ".txt", ".xml", ".config", ".kat", "" };
            var filePaths = FindPatchFiles(rootFolderPath, validExtensions);

            if (!CheckFlashPathExist())
                return false;

            string MuXMLFile = KATEncryptor.ConvertB(PatcherSettings.ReturnPathFile(PatcherSettings.takatto12kat));

            string valueToReplace = LoadValueToReplaceFromFiles(filePaths, "Flash_Path");

            if (!string.IsNullOrEmpty(valueToReplace))
            {
                XmlDocument muXmlDoc = new XmlDocument();
               //Logger.Write(MuXMLFile);

                muXmlDoc.LoadXml(MuXMLFile);

                XmlDocument valueToReplaceDoc = new XmlDocument();

                try
                {
                    // Wrap the valueToReplace content in a root element
                    string wrappedValueToReplace = $"<Root>{valueToReplace}</Root>";
                    valueToReplaceDoc.LoadXml(wrappedValueToReplace);

                    XmlNodeList nodesToReplace = valueToReplaceDoc.SelectNodes("//Flash_Path");

                    foreach (XmlNode nodeToReplace in nodesToReplace)
                    {
                        XmlNode identifierNode = nodeToReplace.SelectSingleNode("Identifier");
                        XmlNode filePathNode = nodeToReplace.SelectSingleNode("FilePath");

                        if (identifierNode != null && filePathNode != null)
                        {
                            string identifierValue = identifierNode.InnerText;
                            string newFilePathValue = filePathNode.InnerText;

                            XmlNode matchingNode = muXmlDoc.SelectSingleNode($"//Flash_Path[Identifier='{identifierValue}']/FilePath");

                            if (matchingNode != null)
                            {
                                //if(!newFilePathValue.Contains(FolderName.Katto))
                                //    matchingNode.InnerText = FolderName.Katto + "\\\\" + newFilePathValue;
                                //else
                                    matchingNode.InnerText = newFilePathValue;
                            }
                            else
                            {
                                // If no matching node is found, add a new Flash_Path element
                                XmlNode flashPathNode = muXmlDoc.CreateElement("Flash_Path");
                                XmlNode identifierNodeCopy = muXmlDoc.CreateElement("Identifier");
                                identifierNodeCopy.InnerText = identifierValue;
                                flashPathNode.AppendChild(identifierNodeCopy);
                                XmlNode filePathNodeCopy = muXmlDoc.CreateElement("FilePath");

                                //if (!newFilePathValue.Contains(FolderName.Katto))
                                //    filePathNodeCopy.InnerText = FolderName.Katto + "\\\\" + newFilePathValue;
                                //else
                                    filePathNodeCopy.InnerText = newFilePathValue;

                                flashPathNode.AppendChild(filePathNodeCopy);
                                muXmlDoc.DocumentElement.AppendChild(flashPathNode);
                            }
                        }
                    }

                    string updatedMuXMLFile = muXmlDoc.OuterXml;

                    //Console.WriteLine(updatedMuXMLFile);
                    KATEncryptor.ConvertBFromString(updatedMuXMLFile, GetFolder(FolderName.UI, FileName.FLASH_PATH));
                    MegaHideFile(Methods.GetFolder(FolderName.UI, FileName.FLASH_PATH));

                    return true;
                }
                catch (XmlException ex)
                {
                    Logger.Write($"Error: The ValueToReplace content is not valid XML. {ex.Message}");
                    return false;
                }
            }
            else
            {
                Logger.Write("Error: ValueToReplace is empty or all files are empty or have incorrect format.");
                return false;
            }
        }

        internal static bool CheckFlashPathExist()
        {
            return !string.IsNullOrEmpty(PatcherSettings.ReturnPathFile(PatcherSettings.takatto12kat));
        }

        private static void LanguageSwap(string fromLanguage, string toLanguage)
        {
            if (fromLanguage == toLanguage)
                return;
            
            try
            {
                if(IsGameRunning_Alt())
                {
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.StringData, toLanguage)),
                        GetFolder(FolderName.Language, $"{toLanguage}.dat"), true);
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.StringDataItem, toLanguage)),
                        GetFolder(FolderName.Language, $"{toLanguage}_item.dat"), true);
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.StringData, fromLanguage)),
                        GetFolder(FolderName.Language, String.Format(FileName.StringData, toLanguage)), true);
                    File.Copy(GetFolder(FolderName.Language, String.Format(FileName.StringDataItem, fromLanguage)),
                        GetFolder(FolderName.Language, String.Format(FileName.StringDataItem, toLanguage)), true);

                    Logger.Write($"Game language swapped from {fromLanguage} to {toLanguage}");
                    return;
                }

                MoveFile(GetFolder(FolderName.Language, $"{toLanguage}.dat"),
                        GetFolder(FolderName.Language, String.Format(FileName.StringData, toLanguage)), false);
                MoveFile(GetFolder(FolderName.Language, $"{toLanguage}_item.dat"),
                    GetFolder(FolderName.Language, String.Format(FileName.StringDataItem, toLanguage)), false);
            }
            catch (Exception msg) { Logger.Write("Failed to auto switch language. Have you installed language patch? Kat-code: " + msg.ToString()); }
        }

        internal static void MoveFile(string source, string dest, bool keepSourceFile)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest) || !File.Exists(source))
                return;

            if (File.Exists(dest))
                File.Delete(dest);

            if(!keepSourceFile)
                File.Move(source, dest);
            else
                File.Copy(source, dest, true);
        }
        
        private static void UISwap(string path, string[] list)
        {
            foreach (var item in list)
            {
                if (File.Exists(GetFolder(path, item)))
                {
                    var st = item;
                    if (!Path.HasExtension(GetFolder(path, item)))
                        st = st + ".swf";
                    

                    MoveFile(GetFolder(path, item), GetFolder(FolderName.PATHC_UI, st), true); //copy

                    MegaHideFile(GetFolder(FolderName.PATHC_UI, st));
                }
            }
        }

        private static void UISwapZacardo(string path, string[] list)
        {
            foreach (var item in list)
            {
                if (File.Exists(GetFolder(path, item)))
                {
                    var st = KATEncryptor.Decrypt(item, 2);                        
                    
                    MoveFile(GetFolder(path, item), GetFolder(FolderName.PATHC_UI, st), false);

                    MegaHideFile(GetFolder(FolderName.PATHC_UI, st));

                    try { File.Delete(GetFolder(path, item)); }
                    catch { }
                }
            }
        }

        private static void UIRevert(string path1, string path2, string[] list)
        {
            Logger.Write("Reverting interface mods...");
            int iteem = 0;
            foreach (var item in list)
            {
                string st = item;
                if (File.Exists(GetFolder(path1, st)))
                {
                    iteem++;
                    if (!Path.HasExtension(GetFolder(path1, item)))
                        st = st + ".swf";

                    if (File.Exists(GetFolder(path2, st)))
                    {
                        try
                        {
                            File.Delete(GetFolder(path2, st));
                        }
                        catch (Exception msg) { Logger.Write("Failed to delete file. Kat-code: " + msg.ToString()); }
                    }
                }
            }
            Logger.Write("Interface mods reverted. " + iteem.ToString() + " item(s) involved.");
        }

        internal static void UIRevertZacardo()
        {
            if (Tweaks.zacardolist == null && Tweaks.zacardolist.Length <= 0)
                return;

            foreach (var item in Tweaks.zacardolist)
            {
                var st = KATEncryptor.Decrypt(item, 2);
                try { File.Delete(GetFolder(FolderName.PATHC_UI, st)); }
                catch { }
            }
        }

        
        internal class Tweaks
        {
            internal static void ModTehUI()
            {
                try
                {
                    var takaoo = ModTehFlashPath();
                    var takatto = ModTehUIItself();

                    if (!takaoo)
                    {
                        Logger.Write("No UI patch that uses the FLASH_PATH metadata installed, or there is incorrect metadata. FLASH_PATH has remained unchanged");

                        var MuXMLFile = KATEncryptor.ConvertB(PatcherSettings.ReturnPathFile(PatcherSettings.takatto12kat));
                        KATEncryptor.ConvertBFromString(MuXMLFile, GetFolder(FolderName.UI, FileName.FLASH_PATH));

                        MegaHideFile(Methods.GetFolder(FolderName.UI, FileName.FLASH_PATH));
                    }

                    if (!IsModdedUIUpToDate() || takatto)
                    {
                        if (CheckFlashPathExist()) //&&takao)
                            swfFiles.Add("Flash_Path");

                        WriteBytes(false, GetFolder(FileName.UI), GetFolder(FileName.UIModded), swfFiles.ToArray());
                    }
                }
                catch (Exception e1)
                {
                    Logger.Write(e1.ToString());
                }
                finally
                {
                    if (File.Exists(GetFolder(FileName.UIModded)))
                    {
                        MoveFile(GetFolder(FileName.UI), GetFolder("temp_" + FileName.UI), false);
                        MoveFile(GetFolder(FileName.UIModded), GetFolder(FileName.UI), false);
                    }
                }
            }

            internal static void InterfaceTweak(bool isZacardoApplied, bool isAltcardoApplied, bool customTexture)
            {
                var list = InterfaceLAddonList(PopulateCustomUIList(null), customTexture);

                bool isListExist = false;
                if (list != null && list.Length > 0)
                    isListExist = true;

                if (!isListExist)
                    if (!isAltcardoApplied && !isZacardoApplied || zacardolist == null || zacardolist.Length <= 0)
                            if (string.IsNullOrEmpty(UserSettings.UILaunchOption) || string.IsNullOrWhiteSpace(UserSettings.UILaunchOption) || !UserSettings.UILaunchOption.Contains('-') || UserSettings.UILaunchOption.Length < 3)
                            return;

                if (!IsGameRunning_Alt())
                {
                    if (isListExist)
                    {
                        UIRevert(FolderName.CustomUI, FolderName.PATHC_UI, list);
                    }

                    return;
                }

                if(list != null && list.Length > 0)
                    Logger.Write(list.Count().ToString() + " interface mod(s) were populated");
               
                var list1 = new System.Collections.Generic.List<string>();
                if (isListExist)
                    list1.AddRange(list);

                string[] listLaunch = null;
                if (UserSettings.UILaunchOption.Contains('-') && UserSettings.UILaunchOption.Length > 3)
                    listLaunch = UserSettings.UILaunchOption.Split('-').ToArray();

                if (listLaunch != null && listLaunch.Length > 0)
                    list1.AddRange(listLaunch);

                if ((isZacardoApplied || isAltcardoApplied) && zacardolist != null && zacardolist.Length > 1)
                    list1.AddRange(zacardolist);

                var z = list1.ToArray();

                if (z == null || z.Length <= 0)
                    return;

                switch (isZacardoApplied | isAltcardoApplied)
                {
                    case true:
                        if (File.Exists(GetFolder("temp_" + FileName.UI))) //&& File.Exists(GetFolder(FileName.UI)))
                            WriteBytes(false, GetFolder("temp_" + FileName.UI), GetFolder(FileName.UI), z);

                        if (isListExist)
                            UISwap(FolderName.CustomUI, list);

                        break;

                    case false:
                        if (!File.Exists(GetFolder("temp_" + FileName.UI)))
                            MoveFile(GetFolder(FileName.UI), GetFolder("temp_" + FileName.UI), false);
                 
                        WriteBytes(false, GetFolder("temp_" + FileName.UI), GetFolder(FileName.UI), z);

                        if (isListExist)
                            UISwap(FolderName.CustomUI, list);
                        
                        break;
                }

                Logger.Write("Interface tweak applied");

                //if(customTexture)
                //{
                //    if (IsCustomTextureInstalled())
                //    {
                //        try
                //        {
                //            MakeSureFolderExists(GetFolder(FolderName.Image, FolderName.Katto));

                //            if (File.Exists(GetFolder(FolderName.Data, KattoFileName.KattoLoadingPNG)))
                //            {
                //                File.Copy(GetFolder(FolderName.Data, KattoFileName.KattoLoadingPNG),
                //                    GetFolder(FolderName.Image, FolderName.Katto, KattoFileName.KattoLoadingPNG), true);
                //            }
                //        }
                //        catch (Exception msg) { Logger.Write(msg.ToString()); }
                //    }
                //}
            }
            
            //internal static void CameraTweak()
            //{
            //    Logger.Write("Camera tweak applied");

            //    if (File.Exists(@"D:\FreeStyle2\Script\camera\camera.lub"))
            //        File.Delete(@"D:\FreeStyle2\Script\camera\camera.lub");

            //    bool done = false;
            //    try
            //    {
            //        KATEncryptor.ConvertBean(@"D:\FreeStyle2\Script\camera\camera.txt",
            //        @"D:\FreeStyle2\Script\camera\camera.lub");
                    
            //        done = true;
            //    }
            //    catch (Exception msg) { Logger.Write(msg.ToString()); }
            //    finally
            //    {
            //        if (done)
            //            WriteBytes(false, GetFolder("script.pak"), "", "camera.lub");
            //    } 
            //}

            internal static void ActionSoundTweak()
            {
                if (!File.Exists(GetFolder("temp_" + FileName.Sound00)))
                    File.Copy(GetFolder(FileName.Sound00), GetFolder("temp_" + FileName.Sound00), true);

                string script = ActionSound.body;
                string script2 = EnvSound.body;

                if (File.Exists(GetFolder(FolderName.ActionSound, FileName.ActionSoundResXML)))
                {
                    var text = File.ReadAllText(GetFolder(FolderName.ActionSound, FileName.ActionSoundResXML));
                    if(!string.IsNullOrEmpty(text))
                        script = text;
                }
                    
                if (File.Exists(GetFolder(FolderName.ActionSound, FileName.ActionSoundRes)))
                {
                    var text = File.ReadAllText(GetFolder(FolderName.ActionSound, FileName.ActionSoundRes));
                    if (!string.IsNullOrEmpty(text))
                        script = KATEncryptor.ConvertBFromStringToString(text);
                }

                if (File.Exists(GetFolder(FolderName.ActionSound, FileName.EnvSoundResXML)))
                {
                    var text = File.ReadAllText(GetFolder(FolderName.ActionSound, FileName.EnvSoundResXML));
                    if (!string.IsNullOrEmpty(text))
                        script2 = text;
                }

                if (File.Exists(GetFolder(FolderName.ActionSound, FileName.EnvSoundRes)))
                {
                    var text = File.ReadAllText(GetFolder(FolderName.ActionSound, FileName.EnvSoundRes));
                    if (!string.IsNullOrEmpty(text))
                        script2 = KATEncryptor.ConvertBFromStringToString(text);
                }

                bool done = false;

                bool takattoexist = Directory.Exists(GetFolder(FolderName.ActionSound));

                if (takattoexist)
                {
                    script = script.Replace("Sound\\\\Action_SOUND", FolderName.ActionSound.Replace("\\", "\\\\"));
                    script2 = script2.Replace("Sound\\\\Env_SOUND", FolderName.ActionSound.Replace("\\", "\\\\"));

                    script = script.Replace("[DEFAULT_PATH]", FolderName.ActionSound.Replace("\\","\\\\"));
                    script = script.Replace("[MUTE_PATH]", FolderName.ActionSound.Replace("\\", "\\\\"));

                    script2 = script2.Replace("[DEFAULT_PATH]", FolderName.ActionSound.Replace("\\", "\\\\"));
                }
                else
                    script = script.Replace("[DEFAULT_PATH]", ActionSound.default_path);


                try
                {
                    KATEncryptor.ConvertBFromString(script, Methods.GetFolder(FolderName.Sound, FileName.ActionSoundRes));
                    MegaHideFile(Methods.GetFolder(FolderName.Sound, FileName.ActionSoundRes));

                    if (takattoexist)
                    {
                        KATEncryptor.ConvertBFromString(script2, Methods.GetFolder(FolderName.Sound, FileName.EnvSoundRes));
                        MegaHideFile(Methods.GetFolder(FolderName.Sound, FileName.EnvSoundRes));
                    }

                    done = true;
                }
                catch (Exception msg) { Logger.Write(msg.ToString()); }
                finally
                {
                    if (done)
                    {
                        if(!takattoexist)
                            WriteBytes(false, GetFolder(FileName.Sound00), "", FileName.ActionSoundRes);
                        else
                            WriteBytes(false, GetFolder(FileName.Sound00), "", new string[] { FileName.ActionSoundRes, FileName.EnvSoundRes });
                    }
                }
            }

            internal static void JukeboxTweak()
            {
                if (!File.Exists(GetFolder("temp_" + FileName.Sound00)))
                    File.Copy(GetFolder(FileName.Sound00), GetFolder("temp_" + FileName.Sound00), true);

                bool done = false;

                try
                {
                    KATEncryptor.ConvertB(GetFolder(FolderName.Data, KattoFileName.BGMKatto), GetFolder(FolderName.Sound, FileName.BGMSoundRes));
                    
                    MegaHideFile(GetFolder(FolderName.Sound, FileName.BGMSoundRes));

                    //MoveFile(GetFolder(FileName.Sound00), GetFolder("temp_" + FileName.Sound00), false);

                    done = true;
                }
                catch (Exception msg) { Logger.Write(msg.ToString()); }
                finally
                {
                    if (done)
                    {
                        WriteBytes(false, GetFolder(FileName.Sound00), "", FileName.BGMSoundRes);
                        Logger.Write("Jukebox tweak applied");
                    }                   
                }
            }

            internal static bool TextMacroTweak() {
                if (!File.Exists(GetFolder("temp_" + FileName.Curse)))
                    File.Copy(GetFolder(FileName.Curse), GetFolder("temp_" + FileName.Curse), true);

                try
                {
                    string newData = "placementdodo1\tplacementdodo2"; //for some reason it ignores the last row when converting, so my workaround is to add a new useless row at the end
                    var data = UserSettings.TextMacroTweakData + Environment.NewLine + newData;
                    KATEncryptor.ConvertBFromString(data, GetFolder(FileName.Curse));
                        
                    return true;
                }
                catch (Exception msg) { Logger.Write(msg.ToString()); return false; }
            }


            internal static void CustomPatchTweak()
            {

                string customPatchFolder = GetFolder(FolderName.CustomP4tch);

                if (!Directory.Exists(customPatchFolder))
                {
                    Logger.Write("No custom patch has found.");
                    return;
                }
               
                var customPatchLoadedList = FindFilesInFolder(customPatchFolder, "patch");

                int item = 0;

                for (int i = 0; i < customPatchLoadedList.Count; i++)
                {
                    if (File.Exists(GetFolder(Path.GetFileName(customPatchLoadedList[i]))))
                    {
                        try
                        {
                            MoveFile(GetFolder(Path.GetFileName(customPatchLoadedList[i])),
                                GetFolder("temp_" + Path.GetFileName(customPatchLoadedList[i])), false);
                        }
                        catch (Exception msg) { Logger.Write(msg.ToString()); }
                        finally
                        {
                            MoveFile(customPatchLoadedList[i],
                                GetFolder(Path.GetFileName(customPatchLoadedList[i])), true);
                        }
                    }
                    else if (Path.GetExtension(customPatchLoadedList[i]) == ".exe"
                        || Path.GetExtension(customPatchLoadedList[i]) == ".bat"
                        || Path.GetExtension(customPatchLoadedList[i]) == ".lnk")
                    {
                        try
                        {
                            Run(customPatchLoadedList[i]);

                            item++;
                        }
                        catch (Exception msg) { Logger.Write(msg.ToString()); }
                    }
                }


                var removeLib = Directory.GetFiles(GetFolder(FolderName.CustomP4tch), "*.rmv", SearchOption.AllDirectories)
                    //.Select(file => Path.GetFullPath(file))
                    .ToArray();

                if (removeLib == null || removeLib.Length <= 0)
                {
                    if (item > 0)
                        Logger.Write(item.ToString() + " custom patch(es) applied");

                    return;
                }


                for (int i = 0; i < removeLib.Length; i++)
                {
                    item++;
                    var toRemoveList = File.ReadLines(removeLib[i]).ToArray();
                    for (int i2 = 0; i2 < toRemoveList.Length; i2++)
                    {
                        if (!string.IsNullOrEmpty(toRemoveList[i2]))
                        {
                            try
                            {
                                MoveFile(GetFolder(toRemoveList[i2]), GetFolder("temp_" + toRemoveList[i2]), false);
                            }
                            catch (Exception msg) { Logger.Write(msg.ToString()); }
                        }
                    }
                }


                Logger.Write(item.ToString() + " custom patch(es) applied");
            }

            //internal static void CustomPatchTweak_Old()
            //{
            //    customePatchLoadedList = Directory.GetFiles(GetFolder(FolderName.CustomPatch)).Select(file => Path.GetFileName(file)).ToArray();
               
            //    int item = 0;
                
            //    for (int i = 0; i < customePatchLoadedList.Length; i++)
            //    {
            //        if (File.Exists(GetFolder(customePatchLoadedList[i])))
            //        {
            //            try
            //            {
            //                MoveFile(GetFolder(customePatchLoadedList[i]),
            //                    GetFolder("temp_" + customePatchLoadedList[i]), false);
            //            }
            //            catch (Exception msg) { Logger.Write(msg.ToString()); }
            //            finally
            //            {
            //                try
            //                {
            //                    File.Copy(GetFolder(FolderName.CustomPatch, customePatchLoadedList[i]),
            //                        GetFolder(customePatchLoadedList[i]), true);

            //                    item++;
            //                }
            //                catch (Exception msg) { Logger.Write(msg.ToString()); }
            //            }
            //        }
            //        else if (Path.GetExtension(GetFolder(FolderName.CustomPatch, customePatchLoadedList[i])) == ".exe"
            //            || Path.GetExtension(GetFolder(FolderName.CustomPatch, customePatchLoadedList[i])) == ".bat"
            //            || Path.GetExtension(GetFolder(FolderName.CustomPatch, customePatchLoadedList[i])) == ".lnk")
            //        {
            //            try
            //            {
            //                Run(GetFolder(FolderName.CustomPatch, customePatchLoadedList[i]));

            //                item++;
            //            }
            //            catch (Exception msg) { Logger.Write(msg.ToString()); }
            //        }
            //    }

            //    //var removeLib = Directory.GetFiles(GetFolder(FolderName.CustomPatch), "*.rmv")
            //    //    .Select(file => Path.GetFileName(file)).ToArray();

            //    var removeLib = Directory.GetFiles(GetFolder(FolderName.CustomPatch), "*.rmv", SearchOption.AllDirectories)
            //        //.Select(file => Path.GetFullPath(file))
            //        .ToArray();

            //    if (removeLib == null || removeLib.Length <= 0)
            //    {
            //        if(item > 0)
            //            Logger.Write(item.ToString() + " custom patch(es) applied");

            //        return;
            //    }
                    

            //    for (int i = 0; i < removeLib.Length; i++)
            //    {
            //        item++;
            //        var toRemoveList = File.ReadLines(removeLib[i]).ToArray();
            //        for (int i2 = 0; i2 < toRemoveList.Length; i2++)
            //        {
            //            if (!string.IsNullOrEmpty(toRemoveList[i2]))
            //            {
            //                try
            //                {
            //                    MoveFile(GetFolder(toRemoveList[i2]), GetFolder("temp_" + toRemoveList[i2]), false);
            //                }
            //                catch (Exception msg) { Logger.Write(msg.ToString()); }
            //            }
            //        }
            //    }

            //    Logger.Write(item.ToString() + " custom patch(es) applied");
            //}

            internal static string[] zacardolist = null;
            internal static void CardViewTweak(bool isCustomUIENABLED, string zacardo_file_list, bool isZacardo, bool isAltCardo)
            {
                switch (IsGameRunning_Alt())
                {
                    case true:
                        try
                        {
                            MoveFile(GetFolder(FileName.UI), GetFolder("temp_" + FileName.UI), false);
                            //MoveFile(GetFolder(FileName.UI), GetFolder("temp_" + FileName.UI));
                        }
                        catch (Exception msg) { Logger.Write(msg.ToString()); }

                        finally
                        {
                            
                            zacardolist = zacardo_file_list.Split('\\').Where(x => !string.IsNullOrEmpty(x)).ToArray();


                            if (zacardolist != null && zacardolist.Length > 1)
                            {
                                if(isZacardo)
                                    UnZipping(GetFolder(FolderName.Data, KattoFileName.UILibrary), GetGameFolder(), true, false);

                                if (isAltCardo)
                                    UnZipping(GetFolder(FolderName.Data, KattoFileName.UILibrary2), GetGameFolder(), true, false);

                                UISwapZacardo(FolderName.Data, zacardolist);

                                if (!isCustomUIENABLED)
                                    WriteBytes(false, GetFolder("temp_" + FileName.UI), GetFolder(FileName.UI), zacardolist);
                            }
                            
                            //if (isTextureModEnabled)
                            //{
                            //    try
                            //    {
                            //        if (File.Exists(GetFolder(FolderName.Data, KattoFileName.KattoLoadingPNG)))
                            //        {
                            //            File.Copy(GetFolder(FolderName.Data, KattoFileName.KattoLoadingPNG),
                            //                GetFolder(FolderName.Image, FolderName.Katto, KattoFileName.KattoLoadingPNG), true);
                            //        }
                            //    }
                            //    catch (Exception msg) { Logger.Write(msg.ToString()); }
                            //}
                        }

                        break;

                    case false:
                        //try
                        //{
                        //    MoveFile(GetFolder("temp_" + FileName.UI), GetFolder(FileName.UI));
                        //}
                        //catch (Exception msg) { Logger.Write(msg.ToString()); }
                        //finally
                        //{
                        //    if (isTextureModEnabled)
                        //    {
                        //        try
                        //        {
                        //            if (File.Exists(GetFolder(FolderName.Data, KattoFileName.KattoLoadingPNG)))
                        //            {
                        //                File.Copy(GetFolder(FolderName.Image, FolderName.Katto, KattoFileName.KattoLoadingPNGDefault),
                        //                    GetFolder(FolderName.Image, FolderName.Katto, KattoFileName.KattoLoadingPNG), true);
                        //            }
                        //        }
                        //        catch (Exception msg) { Logger.Write(msg.ToString()); }
                        //    }
                        //}
                        break;
                }
            }      

            internal static void DLC5Swap(string _yes)
            {
                if (string.IsNullOrEmpty(_yes))
                    return;

                //Logger.Write("Character voice tweak has applied");
                
                //var arraySome = PopulateCharacterVoiceDataArray(_yes);
                //if (arraySome is null || arraySome.Length <= 0)
                //{
                //    Logger.Write("Character voice data array is null, could not apply the tweak");
                //    return;
                //}

                if (!File.Exists(GetFolder("temp_" + FileName.Sound00)))
                    File.Copy(GetFolder(FileName.Sound00), GetFolder("temp_" + FileName.Sound00), true);

                bool done = false;

                try
                {
                    if(File.Exists(GetFolder(FolderName.DLC5, _yes, FileName.VoiceSoundResXML)))
                    {
                        KATEncryptor.ConvertB(GetFolder(FolderName.DLC5, _yes, FileName.VoiceSoundResXML), GetFolder(FolderName.Sound, FileName.VoiceSoundRes));
                    }
                    else if (File.Exists(GetFolder(FolderName.DLC5, _yes, FileName.VoiceSoundRes)))
                    {
                        MoveFile(GetFolder(FolderName.DLC5, _yes, FileName.VoiceSoundRes), GetFolder(FolderName.Sound, FileName.VoiceSoundRes), true);
                    }

                    MegaHideFile(GetFolder(FolderName.Sound, FileName.VoiceSoundRes));
               
                    done = true;
                }
                catch (Exception msg) { Logger.Write(msg.ToString()); }
                finally
                {
                    if(done)
                    {
                        WriteBytes(false, GetFolder(FileName.Sound00), "", FileName.VoiceSoundRes);
                        Logger.Write("Character voice tweak applied");
                    }
                }
            }

            internal static void StandalFontSwap(string defaultLanguage)
            {
                try
                {
                    var configData = File.ReadAllText(GetFolder(FileName.Nation));
                    var toFont = NationNumberToCountry(GetInt(configData));
                    var fromFont = "takatto";
                    if (IsGameRunning_Alt())
                    {

                        if (IsFontInstalled() && UserSettings.GameFontSetting)
                            FontSwap(fromFont, toFont);

                        if (defaultLanguage == "CHN" && IsChinaClient() && toFont == "TWN")
                        {
                            LanguageSwap("CHN", toFont);   
                        }
                        else
                            LanguageSwap(defaultLanguage, toFont);
                        
                        return;
                    }

                    if (IsFontInstalled() && UserSettings.GameFontSetting)
                        FontSwap("takatto", toFont);
                    
                    LanguageSwap(defaultLanguage, toFont);
                }
                catch (Exception msg) { Logger.Write("Failed to apply language. Kat-code: " + msg.ToString()); }
            }

            internal static void DLC6Swap(string dlc6Language) //int languageValue, string defaultLanguage, int defaultNation, bool disableFont
            {
                if (string.IsNullOrEmpty(dlc6Language))
                {
                    Logger.Write("MC voice tweak failed to apply. Kat-code: Code-non-existence");
                    return;
                }

                if (!File.Exists(GetFolder("temp_" + FileName.Sound00)))
                    File.Copy(GetFolder(FileName.Sound00), GetFolder("temp_" + FileName.Sound00), true);

                string[] files1 = Directory.GetFiles(GetFolder(FolderName.DLC6, dlc6Language), "*.bml").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
                string[] files2 = Directory.GetFiles(GetFolder(FolderName.DLC6, dlc6Language), "*.xml").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
                var files = files1.Union(files2).ToArray();
                //if files length is 0, it means that the language is not supported.
                if (files.Length > 0)
                {
                    int error = 0;
                    foreach (var file in files)
                    {
                        try
                        {
                            if (File.Exists(GetFolder(FolderName.DLC6, dlc6Language, file + "*.xml")))
                            {
                                KATEncryptor.ConvertB(GetFolder(FolderName.DLC6, dlc6Language, file + "*.xml"), GetFolder(FolderName.Sound, file + ".bml"));
                            }
                            else if (File.Exists(GetFolder(FolderName.DLC6, dlc6Language, file + ".bml")))
                            {
                                MoveFile(GetFolder(FolderName.DLC6, dlc6Language, file + ".bml"), GetFolder(FolderName.Sound, file + ".bml"), true);
                            }
                        }
                        catch (Exception e) { error++; Logger.Write(e.ToString()); }

                        //MoveFile(GetFolder(FolderName.DLC6, dlc6Language, file),
                        //    GetFolder(FolderName.Sound, file), true);

                        MegaHideFile(GetFolder(FolderName.Sound, file + ".bml"));
                    }

                    WriteBytes(false, GetFolder(FileName.Sound00), "", files);

                    if(error > 0)
                        Logger.Write("MC voice tweak applied with " + error.ToString() + " error(s)");
                    else if (error >= files.Length)
                        Logger.Write("MC voice tweak could not be applied. " + error.ToString() + " error(s) occurred");
                    else
                        Logger.Write("MC voice tweak applied");
                }
            }

            internal static void WriteGameSettings()
            {
                bool isCustomSettingApplied = UserSettings.CustomSetting;
                if (isCustomSettingApplied)
                {
                    try
                    {
                        int widthGame = UserSettings.GameWidth;
                        int heightGame = UserSettings.GameHeight;
                        //int graphicsetting = takattoFS2.Properties.Settings.Default.RenderQuality;

                        string configPathOption = GetFolder(FileName.Option);
                        var configDataOption = File.ReadAllText(configPathOption);

                        var changedConfigOption = Regex.Replace(configDataOption, @"FullMode=\d", "FullMode=0");
                        var changedConfigOption2 = Regex.Replace(changedConfigOption, @"VideoMode_Width=\d+", $"VideoMode_Width={widthGame}");
                        var changedConfigOption3 = Regex.Replace(changedConfigOption2, @"VideoMode_Height=\d+", $"VideoMode_Height={heightGame}");
                        //var changedConfigOption4 = Regex.Replace(changedConfigOption3, @"Quality=\d", $"Quality={graphicsetting}");
                        File.WriteAllText(configPathOption, changedConfigOption3);
                        Logger.Write("Custom game settings applied");
                    }
                    catch (Exception e) { Logger.Write("Custom game settings have failed to apply. Kat-code: " + e.ToString()); }
                }

            }

            internal static void CourtSwap(string path)
            {
                try
                {
                    File.Move(GetFolder(FileName.StageData), GetFolder("temp_" + FileName.StageData)); // dont change this part
                }
                catch { } //eat it
                finally
                {
                    try
                    {
                        if (!IsTiancityFS2())
                            File.Copy(GetFolder(FolderName.DLC1, path),
                                GetFolder(FileName.StageData), true);
                        else 
                        {
                            if (File.Exists(GetFolder(FolderName.DLC1, path.Replace(".pak", "_CHN.pak"))))
                                File.Copy(GetFolder(FolderName.DLC1, path.Replace(".pak", "_CHN.pak")),
                                  GetFolder(FileName.StageData), true);
                            else
                                throw new Exception();
                        }
                           
                    }
                    catch (Exception msg) { Logger.Write("Failed to apply court. Kat-code: " + msg.ToString()); }
                }

                Logger.Write(path.Replace(".dat", "").Replace(".zip", "") + " court applied");
            }

            //internal static void CourtSwap(string path, string pathCN)
            //{
            //    try
            //    {
            //        File.Move(GetFolder(FileName.StageData), GetFolder("temp_" + FileName.StageData)); // dont change this part
            //    }
            //    catch { } //eat it
            //    finally
            //    {
            //        try
            //        {
            //            if (!IsTiancityFS2())
            //                File.Copy(GetFolder(FolderName.Data, path),
            //                    GetFolder(FileName.StageData), true);
            //            else
            //                File.Copy(GetFolder(FolderName.Data, pathCN),
            //                    GetFolder(FileName.StageData), true);
            //        }
            //        catch (Exception msg) { Logger.Write("Failed to apply court. Kat-code: " + msg.ToString()); }
            //    }

            //    Logger.Write(path.Replace(".dat", "") + " has applied");
            //}

            internal static void DefaultCourtSwap(string defaCourtName)
            {
                try
                {
                    File.Move(GetFolder(FileName.StageData), GetFolder("temp_" + FileName.StageData)); // dont change this part

                }
                catch (Exception msg) { Logger.Write(msg.ToString()); }
                finally
                {
                    try
                    {
                        if (!IsTiancityFS2())
                            File.Copy(GetFolder(FolderName.DLC1Default,
                                String.Format(KattoFileName.DLC1Default, defaCourtName)), GetFolder(FileName.StageData), true);
                        else
                            File.Copy(GetFolder(FolderName.DLC1Default,
                                String.Format(KattoFileName.DLC1Default, defaCourtName + "_CHN")), GetFolder(FileName.StageData), true);
                    }
                    catch (Exception msg) { Logger.Write("Failed to apply default court. Kat-code: " + msg.ToString()); }
                }

                Logger.Write(defaCourtName + " court applied");
            }

            internal static void temp(string language, bool _revert)
            {
                switch (_revert)
                {
                    case false:

                        break;

                    case true:

                        break;
                }
            }
        }
    }
}
