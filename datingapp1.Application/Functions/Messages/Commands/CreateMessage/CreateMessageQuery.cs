using MediatR;

namespace datingapp1.Application.Functions.Messages.Commands.CreateMessage;

public class CreateMessageQuery : IRequest<BaseResponse>
{
    public string SenderUsername { get; set; }
    public string RecipientUsername { get; set; }
    public string Content { get; set; }
}
