using datingapp1.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string KnownAs { get; set; }
        public int City { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
