using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetAllCities;

public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<City>>
{
    private readonly ICityRepository _cityRepository;

    public GetAllCitiesQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        List<City> cities = (List<City>)await _cityRepository.GetAll();

        return cities;
    }
}

