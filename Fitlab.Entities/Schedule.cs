using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public bool State { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }    
    }
}
