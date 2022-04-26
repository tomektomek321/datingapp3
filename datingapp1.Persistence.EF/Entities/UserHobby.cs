using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Entities;
public class UserHobby
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int HobbyId { get; set; }
    public Hobby Hobby { get; set; }
}

