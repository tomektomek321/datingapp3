using Microsoft.AspNetCore.Mvc;
using MediatR;
using datingapp1.Domain.Entities;
using datingapp1.Application.Functions.Messages.Commands.CreateMessage;
using datingapp1.Application.Functions.Messages.Queries.GetMessageThread;
using datingapp1.Domain.Dto;

namespace datingapp1.ASP_API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateMessage")]
        public async Task<ActionResult<IEnumerable<Message>>> CreateMessage(CreateMessageQuery message)
        {
            var messageDto = await _mediator.Send(message);
            return Ok(messageDto);
        }

        [HttpPost("GetMessageThread")]
        public async Task<ActionResult<List<MessageDto>>> GetMessageThread(GetMessageThreadQuery usersDto)
        {
            var messageDto = await _mediator.Send(usersDto);
            return Ok(messageDto);
        }

    }

}