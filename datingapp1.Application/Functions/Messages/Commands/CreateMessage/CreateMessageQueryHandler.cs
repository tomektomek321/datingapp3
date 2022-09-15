using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Messages.Commands.CreateMessage;

public class CreateMessageQueryHandler : IRequestHandler<CreateMessageQuery, BaseResponse>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IAppUserRepository _appUserRepository;

    public CreateMessageQueryHandler(IMessageRepository messageRepository, IAppUserRepository appUserRepository)
    {
        _messageRepository = messageRepository;
        _appUserRepository = appUserRepository;
    }

    public async Task<BaseResponse> Handle(CreateMessageQuery request, CancellationToken cancellationToken)
    {
        AppUser userSender =  await _appUserRepository.GetUserByUsername(request.SenderUsername);

        var userRecipient = await _appUserRepository.GetUserByUsername(request.RecipientUsername);

        var message = new Message
        {
            SenderId = userSender.Id,
            Sender = userSender,
            SenderUsername = request.SenderUsername,
            Recipient = userRecipient,
            RecipientId = userRecipient.Id,
            RecipientUsername = request.RecipientUsername,
            Content = request.Content,
            DateRead = DateTime.Now,
        };

        var  x  = await _messageRepository.AddMessage(message);

        return new BaseResponse();
    }
}
