using datingapp1.Application.Functions.Users.Queries.MyFIlterSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using datingapp1.Domain.Extensions;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class MySettingsAndFiltersController : ControllerBase
{
  private readonly IMediator _mediator;

  public MySettingsAndFiltersController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("GetMyFilterSettings")]
  public async Task<ActionResult<MyFilterSettingsResponse>> GetMyFilterSettings()
  {
    var userId = User.GetUserId();
    var user = await _mediator.Send(new MyFilterSettingsQuery()
    {
      UserId = userId,
    });
    return Ok(user);
  }

  [HttpPost("ToggleHobby")]
  public async Task<ActionResult<MyFilterSettingsResponse>> ToggleHobby(int hobbyId)
  {
    var userId = User.GetUserId();
    if(userId == 0) {
      return Unauthorized();
    }
    var user = await _mediator.Send(new MyFilterSettingsQuery()
    {
      UserId = userId,
      HobbyId = hobbyId,
    });
    return Ok(user);
  }
}
