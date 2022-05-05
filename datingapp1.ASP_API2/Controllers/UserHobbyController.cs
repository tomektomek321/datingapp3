using datingapp1.Application.Functions.UserHobbies.Commands.AddUserHobby;
using datingapp1.Application.Functions.UserHobbies.Commands.RemoveUserHobby;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;
[ApiController]
[Route("[controller]")]
public class UserHobbyController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserHobbyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddUserHobby")]
    public async Task<ActionResult<int>> AddUserHobby(AddUserHobbyCommand addHobbyCommand_)
    {
        var user = await _mediator.Send(new AddUserHobbyCommand() { HobbyId = addHobbyCommand_.HobbyId, UserId = addHobbyCommand_.UserId });

        return Ok(user);
    }

    [HttpPost("RemoveUserHobby")]
    public async Task<ActionResult<int>> RemoveUserHobby(RemoveUserHobbyCommand removeHobbyCommand_)
    {
        var user = await _mediator.Send(new RemoveUserHobbyCommand() { HobbyId = removeHobbyCommand_.HobbyId, UserId = removeHobbyCommand_.UserId });

        return Ok(user);
    }
}

