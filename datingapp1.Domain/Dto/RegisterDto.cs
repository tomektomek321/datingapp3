using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Domain.Dto
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string KnownAs { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int City { get; set; }
        public string Password { get; set; }
    }
}
