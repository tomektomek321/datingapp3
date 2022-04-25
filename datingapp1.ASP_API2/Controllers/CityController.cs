using Microsoft.AspNetCore.Mvc;
using MediatR;
using datingapp1.Domain.Entities;
using datingapp1.Application.Functions.Cities;

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
        var cities = await _mediator.Send(new GetCityByIdQuery());

        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<City>>> GetById(int id)
    {
        var cities = await _mediator.Send(new GetCityByIdQuery());

        return Ok(cities);
    }
}
