namespace takattoFS2.Controls.Models
{
    public class Service
    {
        public string id { get;  set; }

        public string name { get;  set; }

        public string version { get;  set; }

        public string toDo { get;  set; }

        public string message { get;  set; }

        public string cmd { get;  set; }

        public string condition { get; set; }

        public bool ignoreGameRunning { get; set; } = false;

        [Newtonsoft.Json.JsonIgnore]
        public bool isNotMatchedCondition { get; set; } = false;
    }
}
