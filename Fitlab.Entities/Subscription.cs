using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
