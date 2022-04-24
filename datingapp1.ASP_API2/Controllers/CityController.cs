using Microsoft.AspNetCore.Mvc;
using MediatR;
using datingapp1.Domain.Entities;
using datingapp1.Application.Functions.Cities;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCities")]
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        var cities = await _mediator.Send(new GetCitiesListQuery());

        return Ok(cities);
    }
}
