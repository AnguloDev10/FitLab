using System.ComponentModel.DataAnnotations;

namespace Fitlab.Entities
{
   
    public class Subscription
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        /*
        public User User { get; set; }
        */

    }
}

