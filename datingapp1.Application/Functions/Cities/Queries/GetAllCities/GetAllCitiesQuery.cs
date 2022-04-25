using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetAllCities;
public class GetAllCitiesQuery : IRequest<List<City>>
{
}

