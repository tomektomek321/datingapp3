using Microsoft.AspNetCore.Mvc;
using MediatR;
using datingapp1.Domain.Entities;
using datingapp1.Application.Functions.Cities;
using datingapp1.Application.Functions.Cities.Queries.GetCitiesByText;
using datingapp1.Application.Functions.Cities.Queries.GetAllCities;
using datingapp1.Application.Functions.Cities.Queries.GetCityById;
using datingapp1.Application.Functions.Cities.Commands.BasicSeed;

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

    [HttpGet("getById/{id}")]
    public async Task<ActionResult<IEnumerable<City>>> GetById(int id)
    {
        var cities = await _mediator.Send(new GetCityByIdQuery() { CityId = id });

        return Ok(cities);
    }

    [HttpGet("searchByText/{text}")]
    public async Task<ActionResult<IEnumerable<City>>> SearchByText(string text)
    {
        var cities = await _mediator.Send(new GetCitiesByTextQuery() { searchText = text });

        return Ok(cities);
    }

    [HttpGet("basicSeed")]
    public async Task<ActionResult<IEnumerable<City>>> BasicSeed()
    {
        var cities = await _mediator.Send(new BasicSeedCitiesCommand());

        return Ok(cities);
    }





}
