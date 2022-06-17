using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLab.Dto.Request
{
    public class ProfileDTO
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }
    }
}
