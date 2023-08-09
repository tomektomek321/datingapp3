using datingapp1.Domain.Dto.Hobbies;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Contracts.Persistance;

public interface IUserHobbyRepository : IRepository<UserHobby>
{
    UserHobby GetUserHobbyByUserIdAndHobbyId(int UserId, int HobbyId);
    Task<List<HobbyDto>> GetUserHobbiesByUserId(int UserId);
}

