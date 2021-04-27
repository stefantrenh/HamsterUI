using System.Collections.Generic;

namespace HamsterData
{
    public class Activity
    {
        public Activity()
        {
            HistoryLogs = new HashSet<Hamster>();
        }
        public int ActivityId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Hamster> HistoryLogs { get; set; }
    }
}
