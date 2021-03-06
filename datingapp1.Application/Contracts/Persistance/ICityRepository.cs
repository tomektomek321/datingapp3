using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;

namespace datingapp1.Application.Contracts.Persistance;

public interface ICityRepository: IRepository<City>
{
    List<City> GetCitiesByText(string text);
    City GetCityByName(string text);
}
