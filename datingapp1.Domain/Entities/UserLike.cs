using System.Text.Json.Serialization;

namespace datingapp1.Domain.Entities;

public class UserLike
{
    [JsonIgnore]
    public AppUser SourceUser { get; set; }
    public int SourceUserId { get; set; }
    [JsonIgnore]
    public AppUser LikedUser { get; set; }
    public int LikedUserId { get; set; }
    public bool IsLiked { get; set; }
}

