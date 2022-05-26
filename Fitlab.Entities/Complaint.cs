using System.ComponentModel.DataAnnotations;

namespace Fitlab.Entities
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Subject { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}