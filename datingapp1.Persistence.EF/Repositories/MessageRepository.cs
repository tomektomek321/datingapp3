using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using datingapp1.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace datingapp1.Persistence.EF.Repositories
{
    public class MessageRepository: BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(DatingAppContext dbContext) : base(dbContext)
        { }

        public async Task<int> AddMessage(Message message)
        {
            var r = await Add(message);
            return 1;
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            var messages = await _dbContext.Messages
                    .Include(u => u.Sender)
                    .Include(u => u.Recipient)
                    .Where(m => m.Recipient.UserName == currentUsername && m.RecipientDeleted == false
                            && m.Sender.UserName == recipientUsername
                            || m.Recipient.UserName == recipientUsername
                            && m.Sender.UserName == currentUsername && m.SenderDeleted == false
                    )
                    .OrderBy(m => m.MessageSent)
                    .ToListAsync();

            List<MessageDto> returnList = new List<MessageDto>();

            foreach(var message in messages) {
                returnList.Add(new MessageDto() {
                    Id = message.Id,
                    Content = message.Content,
                    MessageSent = message.MessageSent,
                    SenderId = message.SenderId,
                    SenderUsername = message.SenderUsername,
                    RecipientId = message.RecipientId,
                    RecipientUsername = message.RecipientUsername,
                });
            }

            return returnList;
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}