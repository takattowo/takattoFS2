namespace takattoFS2.Controls.Models
{
    public class Patches
    {
        public string id { get;  set; }

        public string name { get;  set; }

        //smarter me > type "ui", "std", "ad", "bm"
        public string type { get; set; }

        public string version { get;  set; }

        //public bool isExtension { get; set; }

        //public bool isStandalone { get;  set; }

        //public bool isAdditional { get; set; }

        //public bool isUI { get; set; }

        //public bool isBinaryModification { get; set; }

        public bool isExtension2 { get; set; } 

        public bool isStandalone2 { get;  set; } 

        public bool isAdditional2 { get; set; }

        public bool isUI2 { get; set; } 
        public bool isBM2 { get; set; }

        public bool isObsolete { get; set; }

        public string obsoleteNote { get; set; }

        public bool isWorkingInProcess { get; set; }

        public string workingInProcessNote { get; set; }

        public string description { get;  set; }

        public string note { get;  set; }

        public string createdAt { get;  set; }

        public string updatedAt { get;  set; }

        public bool isDownloadableViaDirectUri { get; set; }

        public string directURI { get; set; }

        public bool isHavingPicture { get; set; }

        public string directPictureURI { get; set; }
    }
}
