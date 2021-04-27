using System;

namespace HamsterData
{
    public class Hamster
    {
        public int HamsterId { get; set; }
        public int OwnerId { get; set; }
        public int? CageId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Cage Cage { get; set; }
        public DateTime? CheckedIn { get; set; }
        public TimeSpan? TimeWaited { get; set; }
        public string Name { get; set; }
        public int? WellnessCenterId { get; set; }
        public int? ActivityId { get; set; }
        public virtual WellnessCenter WellnessCenter { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool HasWorkedOut { get; set; }
    }
}
