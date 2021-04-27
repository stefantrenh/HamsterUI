using System.Collections.Generic;

namespace HamsterData
{
    public class Cage
    {
        public Cage()
        {
            Hamsters = new HashSet<Hamster>();
        }
        public int CageId { get; set; }
        public int Size { get; set; }
        public bool IsMale { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }

    }
}
