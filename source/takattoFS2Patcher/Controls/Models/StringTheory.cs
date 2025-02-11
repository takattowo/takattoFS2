using Newtonsoft.Json;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Controls.Models
{
    [System.Serializable]
    public class StringTheory
    {
        [JsonProperty("UniversalSettings")]
        public static UniversalSettings Universal = UniversalSettings.UniversalSettingsInstance;

        [JsonProperty("SweetSettings")]
        public static SweetSettings Sweet = SweetSettings.SweetSettingsInstance;
    }
}
