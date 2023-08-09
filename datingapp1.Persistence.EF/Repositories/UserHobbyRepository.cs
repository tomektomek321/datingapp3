using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto.Hobbies;
using datingapp1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace datingapp1.Persistence.EF.Repositories;
public class UserHobbyRepository : BaseRepository<UserHobby>, IUserHobbyRepository
{
    public UserHobbyRepository(DatingAppContext dbContext) : base(dbContext)
    { }

    public UserHobby GetUserHobbyByUserIdAndHobbyId(int UserId, int HobbyId)
    {
        var hobby = _dbContext.UserHobbies
                .Where(hobby_ => 
                    hobby_.HobbyId == HobbyId && 
                    hobby_.AppUserId == UserId)
                .FirstOrDefault();

        return hobby;
    }

    public async Task<List<HobbyDto>> GetUserHobbiesByUserId(int UserId)
    {
        var hobby = await _dbContext.UserHobbies
                .Include(u => u.Hobby)
                .Where(hobby_ => hobby_.AppUserId == UserId)
                .Select(h => new HobbyDto() {
                    Id = h.HobbyId,
                    Name = h.Hobby.Name,
                })
                .ToListAsync();

        return hobby;
    }
}
