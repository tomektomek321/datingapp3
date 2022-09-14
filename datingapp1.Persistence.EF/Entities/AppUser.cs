using System;
using System.Collections.Generic;

namespace datingapp1.Persistence.EF.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
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
}
