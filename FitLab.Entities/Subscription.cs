using System.ComponentModel.DataAnnotations;

namespace Fitlab.Entities
{
   
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int MaxSessions { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int UserId { get; set; }
        /*
         
        public User User { get; set; }
        */

    }
}

