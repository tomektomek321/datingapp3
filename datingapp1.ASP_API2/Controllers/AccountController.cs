using datingapp1.Application.Functions.Auth.Commands.Register;
using datingapp1.Application.Functions.Auth.Queries.Login;
using datingapp1.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterCommand registerCommand)
        {
            var user = await _mediator.Send(registerCommand);

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginQueryResponse>> Login(LoginQuery loginQuery)
        {
            var user = await _mediator.Send(loginQuery);

            return Ok(user);
        }
    }
}
