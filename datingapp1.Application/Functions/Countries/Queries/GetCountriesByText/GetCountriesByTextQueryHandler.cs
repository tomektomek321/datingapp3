using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.Countries.Queries.GetCountriesByText;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetCitiesByText;

public class GetCountriesByTextQueryHandler : IRequestHandler<GetCountriesByTextQuery, TBaseResponse<List<Country>>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountriesByTextQueryHandler(ICountryRepository cityRepository)
    {
        _countryRepository = cityRepository;
    }
    public Task<TBaseResponse<List<Country>>> Handle(GetCountriesByTextQuery request, CancellationToken cancellationToken)
    {
        var cities = _countryRepository.GetCountriesByText(request.searchText);
        return Task.FromResult(new TBaseResponse<List<Country>>(cities));
    }
}

