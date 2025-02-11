using Newtonsoft.Json;
using System.Collections.Generic;

namespace takattoFS2.Controls.Models
{
    [System.Serializable]
    public class NobodyLoveYou
    {
        private NobodyLoveYou()
        { }

        public static NobodyLoveYou PATCHES = null;

        public static NobodyLoveYou PATCHESInstance
        {
            get
            {
                if (PATCHES == null)
                    PATCHES = new NobodyLoveYou();

                return PATCHES;
            }
        }

        [JsonProperty("Patches")]
        public List<Patches> Patches { get; set; }

        [JsonProperty("PatchExtension")]
        public string PatchExtension { get; set; }

        [JsonProperty("ServerUri")]
        public string ServerUri { get; set; }

        [JsonProperty("ServerName")]
        public string ServerName { get; set; }

        [JsonProperty("GithubId")]
        public string GithubId { get; set; }
    }
}
