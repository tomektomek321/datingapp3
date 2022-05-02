using datingapp1.Application.Functions.Likes.Commands.ToggleLikeUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LikeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("LikeUser")]
    public async Task<ActionResult<ToggleLikeUserCommandResponse>> ToggleLikeUser(ToggleLikeUserCommand toggleLikeUserCommand)
    {
        var user = await _mediator.Send(toggleLikeUserCommand);
        Console.WriteLine(user);
        return Ok(user);
    }
}


