using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Request
{
    public class SubscriptionDTO
    {
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }
    }
}
