using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories;

public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
{
    public HobbyRepository(DatingAppContext dbContext) : base(dbContext) { }

    public List<Hobby> GetHobbiesByText(string text)
    {
        List<Hobby> returnList = _dbContext.Hobbies.Where(hobby_ => hobby_.Name.ToLower().Contains(text.ToLower())).ToList();
        return returnList;
    }
}

