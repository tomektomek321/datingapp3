using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Domain.Dto
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public int Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime LastActive { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
        public int Age { get; set; }

        public int GetAge(DateTime dob)
        {
            return  DateTime.Now.Year - dob.Year;
        }
    }
}
