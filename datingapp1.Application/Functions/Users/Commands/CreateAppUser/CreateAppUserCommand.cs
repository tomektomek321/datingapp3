using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace datingapp1.Application.Functions.Users.Commands.CreateAppUser
{
    public class CreateAppUserCommand: IRequest<int>
    {
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public int City { get; set; }
        public int Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

    }
}
