using datingapp1.Application.Functions.Countries.Queries.GetCountriesByText;
using datingapp1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("searchByText/{text}")]
    public async Task<ActionResult<IEnumerable<Country>>> SearchByText(string text)
    {
        var countries = await _mediator.Send(new GetCountriesByTextQuery() { searchText = text });

        return Ok(countries);
    }
}

