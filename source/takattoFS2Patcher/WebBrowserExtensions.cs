using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace takattoFS2
{
    public static class WebBrowserExtensions
    {
        public static Dictionary<string, string> GetCookies(this WebBrowser webBrowser)
        {
            var result = new Dictionary<string, string>();

            string[] cookieStrings = webBrowser.Document?.Cookie?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (cookieStrings != null)
            {
                for (int i = 0; i < cookieStrings.Length; i++)
                {
                    string cookieString = cookieStrings[i].Trim();
                    int index = cookieString.IndexOf('=');
                    if (index > 0)
                    {
                        string key = cookieString.Substring(0, index);
                        string value = cookieString.Substring(index + 1);

                        result.Add(key, value);
                    }
                }
            }

            return result;
        }
    }
}
