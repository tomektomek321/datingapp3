using datingapp1.Application.Functions.Users.Commands.Register;
using datingapp1.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Accountontroller : ControllerBase 
    {
        private readonly IMediator _mediator;

        public Accountontroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterCommand registerCommand)
        {
            var user = await _mediator.Send(registerCommand);

            return Ok(user);
        }
    }
}
