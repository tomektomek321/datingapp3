using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Dto;
using MediatR;

namespace datingapp1.Application.Functions.Messages.Queries.GetMessageThread
{
    public class GetMessageThreadQuery : IRequest<TBaseResponse<List<MessageDto>>>
    {
        public string CurrentUsername { get; set; }
        public string RecipientUsername { get; set; }
    }
}


