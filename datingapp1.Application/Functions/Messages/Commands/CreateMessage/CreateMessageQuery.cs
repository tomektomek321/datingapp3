using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Messages.Commands.CreateMessage
{
    public class CreateMessageQuery : IRequest<BaseResponse>
    {
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public string Content { get; set; }
    }
}