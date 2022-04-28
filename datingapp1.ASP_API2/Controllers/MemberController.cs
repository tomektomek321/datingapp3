using datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;
using datingapp1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("FilterMembers")]
    public async Task<ActionResult<IEnumerable<List<AppUser>>>> FilterMembers(GetMembersByFilterQuery _filter)
    {
        Console.WriteLine(_filter.gender);
        var cities = await _mediator.Send(_filter);

        return Ok(cities);
    }

}
