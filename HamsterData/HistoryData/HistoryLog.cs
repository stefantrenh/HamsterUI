
using System;

namespace HamsterData
{
    public class HistoryLog
    {
        public HistoryLog()
        {

        }
        public int HistoryLogId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public int HamsterId { get; set; }
        public int ActivityId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
