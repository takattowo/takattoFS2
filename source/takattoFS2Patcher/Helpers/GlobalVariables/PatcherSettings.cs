using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using takattoFS2.Controls.Models;
using takattoFS2.Helpers;

namespace takattoFS2.Helpers.GlobalVariables
{
    static class PatcherSettings
    {
        internal static float fontOffset1 = 1; //normal 
        internal static float fontOffset2 = 0; //normal text button
        internal static float fontOffset3 = 0; //font freude
        internal static float fontOffset4 = 0; //big textfont freude
        internal static int fontOffsetWidth = 3; //width offset location

        internal static string hikariName;
        internal static string yuzukiName;
        internal static string nakoName;

        internal static string[] msgStrHikariWelcome;
        internal static string[] msgStrHikari;
        internal static string[] msgStrHikariLove;
        internal static string[] msgStrHikariLoved;
        internal static string[] msgStrHikariAngry;
        internal static string[] msgStrYuzuki;
        internal static string[] msgStrYuzukiLove;
        internal static string[] msgStrYuzukiLoved;
        internal static string[] msgStrYuzukiAngry;
        internal static string[] msgStrNako;
        internal static string[] msgStrNakoLove;
        internal static string[] msgStrNakoLoved;
        internal static string[] msgStrNakoAngry;
        internal static string[] msgStrNakoWelcome;

        //internal static string AppDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "takattoFS2");
        //internal static string PatchDir = Path.Combine(AppDir, Strings.FolderName.AppData);
        //internal static string TempDir = Path.Combine(PatchDir, Strings.FolderName.Temp);
        //internal static string SweetLetterDir = Path.Combine(PatchDir, Strings.FolderName.SweetLetter);

        internal const string takatto29kat = nameof(takatto29kat); //UNIVERSAL DATA
        internal const string takatto12kat = nameof(takatto12kat); //FLASHPATH
        //internal const string takatto00004 = nameof(takatto00004); //LAUNCHER_TAB
        //internal const string takatto00001 = nameof(takatto00001); //GAME_FOLDER
        //internal const string takatto00003 = nameof(takatto00003); //GAME_LANGUAGE
        internal const string takatto29022 = nameof(takatto29022); //LOVELETTER|HIKARIHEART|YUZUKIHEART|NAKOHEART|COUNT|ISHI|ISYU|ISNA|
        internal const string takatto00000 = nameof(takatto00000); //FIRST_RUN
        internal const string takatto00002 = nameof(takatto00002); //LAUNCHER_SETTINGS
        //internal const string takatto00028 = nameof(takatto00028); //REMEMBER_PASSWORD
        //internal const string takatto00038 = nameof(takatto00038); //REMEMBER_CREDENTIALS
        //internal const string takatto00029 = nameof(takatto00029); //BROWSER_NEXON_OR_JOYCITY

        internal const string takatto11000 = nameof(takatto11000); //msgStrHikariWelcome\msgStrHikari\msgStrYuzuki\msgStrNako\msgStrHikariLove\msgStrYuzukiLove\msgStrNakoLove\msgStrHikariAngry\msgStrYuzukiAngry\msgStrNakoAngry\hikariloved\yuzukiloved\nakoloved

        internal static string GetDefault(string name)
        {
            switch(name)
            {
                default:
                    return null;
            }
        }

        internal static string GetValue(string name)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");
            string defaultValue = GetDefault(name);

            if (File.Exists(tentativeFile))
            {
                var ww = File.ReadAllText(tentativeFile).ToString().Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<br>", "\n");
                return KATEncryptor.DecryptSwapping(ww);
            }            
            else
                return defaultValue;
        }

        internal static void SetValue(string name, string value)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");
            try
            {
                string encryptedStr = KATEncryptor.EncryptSwapping(value);
                File.WriteAllText(tentativeFile, Utf8Encoder.GetString(Utf8Encoder.GetBytes(encryptedStr)));
            }
            catch (Exception e)
            {
                MsgBoxs.Warning.Error(e.ToString());            }
        }

        internal static void SetValueWithoutCrypting(string name, string value)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");
            try
            {
                File.WriteAllText(tentativeFile, value);
            }
            catch (Exception e)
            {
                MsgBoxs.Warning.Error(e.ToString());
            }
        }

        internal static void SetValueWithoutCrypting(string name, byte[] value)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");
            try
            {
                File.WriteAllBytes(tentativeFile, value);
            }
            catch (Exception e)
            {
                MsgBoxs.Warning.Error(e.ToString());
            }
        }

        internal static string ReturnPathFile(string name)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");

            if (File.Exists(tentativeFile))
            {
                if (!string.IsNullOrEmpty(GetValueWithoutCrypting(name)))
                    return tentativeFile;
            }

            return null;
        }

        internal static string GetValueWithoutCrypting(string name)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");
            string defaultValue = GetDefault(name);

            if (File.Exists(tentativeFile))
                return File.ReadAllText(tentativeFile).ToString().Replace("<br/>", "\n").Replace("<br />", "\n").Replace("<br>", "\n");
            else
                return defaultValue;
        }

        internal static readonly Encoding Utf8Encoder = Encoding.GetEncoding(
            "UTF-8",
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
        );

        internal static void DeleteValue(string name)
        {
            string tentativeFile = Path.Combine(UserSettings.PatcherPath, Strings.FolderName.AppData, $"{name}.dat");

            try
            {
                if (File.Exists(tentativeFile))
                    File.Delete(tentativeFile);
            }
            catch (Exception e)
            {
                MsgBoxs.Warning.Error(e.ToString());            
            }
        }

    }
}
