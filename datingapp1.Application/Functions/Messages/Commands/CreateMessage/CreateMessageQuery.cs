using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Messages.Commands.CreateMessage;

public class CreateMessageQuery : IRequest<TBaseResponse<MessageDto>>
{
    public string SenderUsername { get; set; }
    public string RecipientUsername { get; set; }
    public string Content { get; set; }
}
