using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Domain.Dto;

public class LoginDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string KnownAs { get; set; }
    public int Gender { get; set; }
    public string Token { get; set; }
    public ICollection<UserLike> LikedUsers { get; set; }
}

