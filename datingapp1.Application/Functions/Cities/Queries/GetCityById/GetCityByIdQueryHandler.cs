using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetCityById;
public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, City>
{
    private readonly IRepository<City> _cityRepository;

    public GetCityByIdQueryHandler(IRepository<City> cityRepository)
    {
        _cityRepository = cityRepository;
    }
    public Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = _cityRepository.GetById(request.CityId);
        
        return city;
    }
}
