using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;

namespace datingapp1.Persistence.EF.Repositories;

public class LikeRepository : BaseRepository<UserLike>, ILikeRepository
{
  public LikeRepository(DatingAppContext dbContext) : base(dbContext)
  { }

  public Task<bool> ToggleLike(int sourceUserId, int targetUserId)
  {
    bool x = _dbContext.UserLikes.Where(like =>
                like.SourceUserId == sourceUserId
                && like.LikedUserId == targetUserId)
            .Any();

    if (x)
    {
      _dbContext.UserLikes.Remove(new UserLike()
      {
        SourceUserId = sourceUserId,
        LikedUserId = targetUserId
      });
    }
    else
    {
      _dbContext.UserLikes.Add(new UserLike()
      {
        SourceUserId = sourceUserId,
        LikedUserId = targetUserId
      });
    }

    return Task.FromResult(_dbContext.SaveChanges() > 0);
  }

  /*public Task<List<MemberDto>> GetLikedMembers(int UserId)
  {
      var users = _dbContext.UserLikes.Where(like_ => like_.SourceUserId == UserId).ToList();

      List<MemberDto> returnMembers = new List<MemberDto>();

      foreach (var user in users)
      {
          returnMembers.Add(new MemberDto()
          {
              Id = user.I
          }
      }



      return Task.FromResult(users);



      throw new NotImplementedException();
  }*/
}

