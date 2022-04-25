using System;
using System.Collections.Generic;

namespace datingapp1.Domain.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string KnownAs { get; set; }
    public string Gender { get; set; }
    public City City { get; set; }
}
