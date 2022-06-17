using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }

        [Required]
        [StringLength(15)]
        public string Rol { get; set; }

        public Account Account { get; set; }

        public IList<Session> Sessions { get; set; } = new List<Session>();
        public IList<Experience> Experiences { get; set; } = new List<Experience>();
        public IList<Schedule> Schedules { get; set; } = new List<Schedule>();
        public IList<Complaint> Complaints { get; set; } = new List<Complaint>();
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
