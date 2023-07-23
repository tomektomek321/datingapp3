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

    public async Task<bool> BasicSeed()
    {
        // List<Country> Countries = new List<Country>();

        // Countries.Add(new Country() { Name = "Poland" });
        // Countries.Add(new Country() { Name = "Germany" });
        // cities.Add(new City() { Name = "Wroclaw" });
        // cities.Add(new City() { Name = "Gdynia" });
        // cities.Add(new City() { Name = "Opole" });
        // cities.Add(new City() { Name = "Krakow" });
        // cities.Add(new City() { Name = "Szczecin" });
        // cities.Add(new City() { Name = "Sopot" });
        // cities.Add(new City() { Name = "Torun" });
        // cities.Add(new City() { Name = "Bydgoszcz" });
        // cities.Add(new City() { Name = "Szczecin" });

        // _dbContext.Countries.AddRange(Countries);
        // await _dbContext.SaveChangesAsync();

        return true;
    }
}
