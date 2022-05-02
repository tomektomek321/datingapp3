using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace datingapp1.Domain.Entities;

public class UserLike
{
    [JsonIgnore]
    public AppUser SourceUser { get; set; }
    public int SourceUserId { get; set; }
    [JsonIgnore]
    public AppUser LikedUser { get; set; }
    public int LikedUserId { get; set; }
}

