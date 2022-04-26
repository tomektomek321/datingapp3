using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;

namespace datingapp1.Application.Contracts.Persistance
{
    public interface ICountryRepository : IRepository<Country>
    {
        List<Country> GetCountriesByText(string text);
    }
}
