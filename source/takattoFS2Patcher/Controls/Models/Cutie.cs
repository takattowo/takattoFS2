using Newtonsoft.Json;
using System.Collections.Generic;
using takattoFS2.Helpers.GlobalVariables;

namespace takattoFS2.Controls.Models
{
    public class Cutie
    {
        public bool isEnabled { get; set; }

        public string altName { get; set; }

        public int baseLoveChance { get; set; }

        public string normalState { get; set; }

        public string happiState { get; set; }

        public string angeriiiiiState { get; set; }

        public string background { get; set; }

        public int stateLayout { get; set; }

        public int backgroundLayout { get; set; }

        public string dominantColor { get; set; }

        public string eventMessage { get; set; }

        public List<string> noise { get; set; }
    }
}
