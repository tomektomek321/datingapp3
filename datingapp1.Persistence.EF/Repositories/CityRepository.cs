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

    public List<City> GetCitiesByText(string text)
    {
        var cities = _dbContext
            .Cities
            .Where(city_ => city_.Name.ToLower().Contains(text.ToLower()))
            .ToList();

        return cities;
    }

    public City GetCityByName(string text)
    {
        var city = _dbContext
            .Cities
            .Where(city_ => city_.Name.ToLower() == text.ToLower())
            .FirstOrDefault();

        return city;
    }

    public Task<bool> IsNameAndAuthorAlreadyExist(string name)
    {
        var matches = _dbContext.Cities.
            Any(a => a.Name.Equals(name));

        return Task.FromResult(matches);
    }
}
