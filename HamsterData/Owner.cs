using System.Collections.Generic;

namespace HamsterData
{
    public class Owner
    {

        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; }
    }
}
