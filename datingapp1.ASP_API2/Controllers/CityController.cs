using Microsoft.AspNetCore.Mvc;
using MediatR;
using datingapp1.Domain.Entities;
using datingapp1.Application.Functions.Cities;
using datingapp1.Application.Functions.Cities.Queries.GetCitiesByText;
using datingapp1.Application.Functions.Cities.Queries.GetAllCities;
using datingapp1.Application.Functions.Cities.Queries.GetCityById;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<City>>> GetAll()
    {
        var cities = await _mediator.Send(new GetAllCitiesQuery());

        return Ok(cities);
    }

    [HttpGet("getById")]
    public async Task<ActionResult<IEnumerable<City>>> GetById(int id)
    {
        var cities = await _mediator.Send(new GetCityByIdQuery() { CityId = id });

        return Ok(cities);
    }

    [HttpGet("searchByText")]
    public async Task<ActionResult<IEnumerable<City>>> SearchByText(string _searchText)
    {
        var cities = await _mediator.Send(new GetCitiesByTextQuery() { searchText = _searchText });

        return Ok(cities);
    }

}
