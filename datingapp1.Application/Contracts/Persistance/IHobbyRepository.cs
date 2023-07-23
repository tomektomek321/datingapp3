using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Contracts.Persistance;

public interface IHobbyRepository : IRepository<Hobby>
{
    List<Hobby> GetHobbiesByText(string text);
    Task<bool> BasicSeed();
}

