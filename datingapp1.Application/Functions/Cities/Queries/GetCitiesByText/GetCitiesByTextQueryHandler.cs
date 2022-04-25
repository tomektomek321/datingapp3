using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetCitiesByText
{
    public class GetCitiesByTextQueryHandler : IRequestHandler<GetCitiesByTextQuery, List<City>>
    {
        private readonly ICityRepository _cityRepository;

        public GetCitiesByTextQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public Task<List<City>> Handle(GetCitiesByTextQuery request, CancellationToken cancellationToken)
        {
            var cities = _cityRepository.GetCitiesByText(request.searchText);
            return Task.FromResult(cities);
        }
    }
}
