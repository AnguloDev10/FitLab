using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Request
{
    public class ScheduleDTO
    {
        [Required]
        [MaxLength(500)]
        public string StartAt { get; set; }

        [Required]
        [MaxLength(500)]
        public string EndAt { get; set; }

        public bool State { get; set; }

        public int UserId { get; set; }
    }
}
