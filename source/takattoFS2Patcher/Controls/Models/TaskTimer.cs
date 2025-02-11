using System;
using System.Timers;

namespace takattoFS2.Controls.Models
{
    public class TaskTimer : Timer
    {
        public Guid taskID { get; set; }
    }
}
