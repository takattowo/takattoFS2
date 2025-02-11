using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takattoFS2.Controls
{
    public class StringTheory
    {
        [JsonProperty(PatcherSettings.UniversalSettings)]
        public UniversalSettings Universal { get; set; }
        [JsonProperty(PatcherSettings.SweetSettings)]
        public SweetSettings Sweet { get; set; }
    }
}
