using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitlab.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}