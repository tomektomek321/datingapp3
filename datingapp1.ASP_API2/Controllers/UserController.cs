using datingapp1.Application.Functions.Users.Queries.MyFIlterSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using datingapp1.Domain.Extensions;

namespace datingapp1.ASP_API2.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    


}
