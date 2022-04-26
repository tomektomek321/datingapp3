using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(DatingAppContext dbContext) : base(dbContext)
        { }

        public List<Country> GetCountriesByText(string text)
        {
            var countries = _dbContext
                .Countries
                .Where(country_ => country_.Name.ToLower().Contains(text.ToLower()))
                .ToList();

            return countries;
        }
    }
}
