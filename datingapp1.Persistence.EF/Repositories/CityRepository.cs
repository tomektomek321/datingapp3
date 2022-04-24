using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;
using datingapp1.Application.Contracts.Persistance;

namespace datingapp1.Persistence.EF.Repositories;

public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(DatingAppContext dbContext) : base(dbContext)
    { }

    public Task<bool> IsNameAndAuthorAlreadyExist(string name)
    {
        var matches = _dbContext.City.
            Any(a => a.Name.Equals(name));

        return Task.FromResult(matches);
    }
}
