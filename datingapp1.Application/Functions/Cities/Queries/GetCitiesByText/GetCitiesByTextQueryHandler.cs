using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Countries.Queries.GetCountriesByText
{
    public class GetCountriesByTextQueryHandler : IRequestHandler<GetCountriesByTextQuery, List<Country>>
    {
        private readonly ICountryRepository _countryRepository;

        public GetCountriesByTextQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Task<List<Country>> Handle(GetCountriesByTextQuery request, CancellationToken cancellationToken)
        {
            var cities = _countryRepository.GetCountriesByText(request.searchText);
            return Task.FromResult(cities);
        }
    }
}
