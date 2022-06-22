using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public bool State { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }    
    }
}
