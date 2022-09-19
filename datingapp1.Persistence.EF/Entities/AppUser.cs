using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace datingapp1.Persistence.EF.Entities;

public class AppUser : IdentityUser<int>
{
    public DateTime DateOfBirth { get; set; }
    public string KnownAs { get; set; }
    public int Gender { get; set; }
    public City City { get; set; }
    public Country Country { get; set; }
    public ICollection<UserHobby> UserHobbies { get; set; }
    public ICollection<UserLike> LikedByUsers { get; set; }
    public ICollection<UserLike> LikedUsers { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastActive { get; set; } = DateTime.Now;

    public ICollection<Message> MessagesSent { get; set; }
    public ICollection<Message> MessagesReceived { get; set; }

    public ICollection<AppUserRole> UserRoles { get; set; }
}
