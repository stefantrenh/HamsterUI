using System.Collections.Generic;

namespace HamsterData
{
    public class WellnessCenter
    {
        public WellnessCenter()
        {

        }
        public int WellnessCenterId { get; set; }
        public int Size { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
