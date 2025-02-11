using System;

namespace takattoFS2.Controls.Models
{
    public class TweaksItIs
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool isSomething { get; set; }

        public bool isNeedToDownload { get; set; }

        public bool isApplied { get; set; }

        public TweaksItIs() { Id = Guid.NewGuid().ToString(); }

        public TweaksItIs(string _buttonName, bool _isSomething, bool _isNeedToDownload)
        {
            Name = _buttonName;
            isSomething = _isSomething;
            isNeedToDownload = _isNeedToDownload;
        }
    }
}
