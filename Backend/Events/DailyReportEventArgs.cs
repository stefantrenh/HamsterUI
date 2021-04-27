using System;
using System.Collections.Generic;
using System.Linq;
using HamsterData;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Events
{
   public class DailyReportEventArgs
    {
        public List<Hamster> Hamsters { get; set; }
        public List<HistoryLog> Logs { get; set; }
        public int Ticks { get; set; }
        public DateTime Date { get; set; }
        public DailyReportEventArgs(List<Hamster> hamsterlist, List<HistoryLog> logs,int ticks, DateTime date)
        {
            this.Hamsters = hamsterlist;
            this.Logs = logs;
            this.Ticks = ticks;
            this.Date = date;
        }
    }

}
