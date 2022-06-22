using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
