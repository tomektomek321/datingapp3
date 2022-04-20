using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AddHobbyDto
    {
        public int hobbyId { get; set; }
        public string hobbyname { get; set; }
        public string username { get; set; }
    }
}