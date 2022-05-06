using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.Cities.Queries.GetCitiesByText;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Countries.Queries.GetCountriesByText;

public class GetCitiesByTextQueryHandler : IRequestHandler<GetCitiesByTextQuery, TBaseResponse<List<City>>>
{
    private readonly ICityRepository _cityRepository;

    public GetCitiesByTextQueryHandler(ICityRepository countryRepository)
    {
        _cityRepository = countryRepository;
    }
    public Task<TBaseResponse<List<City>>> Handle(GetCitiesByTextQuery request, CancellationToken cancellationToken)
    {
        var cities = _cityRepository.GetCitiesByText(request.searchText);
        return Task.FromResult(new TBaseResponse<List<City>>(cities));
    }

}

