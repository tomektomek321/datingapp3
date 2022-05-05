using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories;
public class UserHobbyRepository : BaseRepository<UserHobby>, IUserHobbyRepository
{
    public UserHobbyRepository(DatingAppContext dbContext) : base(dbContext)
    { }


    public UserHobby GetUserHobbyByUserIdAndHobbyId(int UserId, int HobbyId)
    {
        var hobby = _dbContext.UserHobbies
                .Where(hobby_ => hobby_.HobbyId == HobbyId && hobby_.AppUserId == UserId)
                .FirstOrDefault();

        return hobby;
    }


}

