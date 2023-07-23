using datingapp1.Application;
using datingapp1.Application.Functions.Auth.Commands.Register;
using datingapp1.Application.Functions.Auth.Queries.Login;
using datingapp1.Application.Functions.Hobbies.Commands;
using datingapp1.Application.Functions.Hobbies.Queries.GetHobbiesByTest;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class HobbyController : ControllerBase
{
    private readonly IMediator _mediator;

    public HobbyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("searchByText")]
    public async Task<ActionResult<TBaseResponse<Hobby>>> SearchByText(string _searchText)
    {
        var hobbies = await _mediator.Send(new GetHobbiesByTextQuery() { searchText = _searchText });

        return Ok(hobbies);
    }

    [HttpGet("basicSeed")]
    public async Task<ActionResult<IEnumerable<City>>> BasicSeed()
    {
        var cities = await _mediator.Send(new BasicSeedHobbiesCommand());

        return Ok(cities);
    }
}