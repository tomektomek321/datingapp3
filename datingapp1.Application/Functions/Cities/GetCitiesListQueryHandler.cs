using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Cities;

public class GetCitiesListQueryHandler : IRequestHandler<GetCityByIdQuery, List<City>>
{
    private readonly IRepository<City> _cityRepository;

    public GetCitiesListQueryHandler(IRepository<City> cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<City>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var allCities = await _cityRepository.GetAll();

        return (List<City>)allCities;
    }
}
