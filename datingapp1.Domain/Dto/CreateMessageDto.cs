using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp1.Domain.Dto
{
    public class CreateMessageDto
    {
        public string RecipientUsername { get; set; }
        public string Content { get; set; }
    }
}