using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Request
{
    public class SessionDTO
    {
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link { get; set; }

        public int UserId { get; set; }
    }
}
