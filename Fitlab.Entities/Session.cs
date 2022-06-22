using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitlab.Entities
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public IList<Diet> Diets { get; set; } = new List<Diet>();
        public IList<Progress> Progresses { get; set; } = new List<Progress>();
    }
}
