using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using MediatR;

namespace datingapp1.Application.Functions.Messages.Queries.GetMessageThread
{
    public class GetMessageThreadQueryHandler : IRequestHandler<GetMessageThreadQuery, TBaseResponse<List<MessageDto>>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IAppUserRepository _appUserRepository;

        public GetMessageThreadQueryHandler(IMessageRepository messageRepository, IAppUserRepository appUserRepository)
        {
            _messageRepository = messageRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<TBaseResponse<List<MessageDto>>> Handle(GetMessageThreadQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetMessageThread(request.currentUsername, request.recipientUsername);

            return new TBaseResponse<List<MessageDto>>(messages);
        }
    }
}