using System;
using System.Globalization;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Helpers
{
    internal static class StringLoader
    {
        internal static string GetText(string name)
        {
            return GetText(name, UserSettings.UILanguageCode);
        }

        internal static string GetText(string name, params object[] args)
        {
            return String.Format(GetText(name, UserSettings.UILanguageCode), args);
        }

        private static string GetText(string name, string languageCode)
        {
            switchagain:
            switch (languageCode)
            {
                case "default":
                    languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                    goto switchagain;
                case "en":
                    return Resources.en.ResourceManager.GetString(name);
                case "ko":
                    return Resources.ko.ResourceManager.GetString(name);
                case "zh":
                    return Resources.zh.ResourceManager.GetString(name);
                default:
                    return Resources.en.ResourceManager.GetString(name);
            }
        }
    }
}
