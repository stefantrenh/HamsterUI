using HamsterData;
using System;
using System.Collections.Generic;

namespace Backend.Events
{
    public class HamsterDayCareInfoEventArgs
    {
        public List<Hamster> Hamsters { get; set; }
        public DateTime Date { get; set; }
        public int DayTicker { get; set; }
        public HamsterDayCareInfoEventArgs(List<Hamster> hamsters, int dayticker, DateTime date)
        {
            this.Hamsters = hamsters;
            this.DayTicker = dayticker;
            this.Date = date;
        }
    }
}
