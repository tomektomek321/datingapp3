using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace datingapp1.Application.Functions.Users.Commands.DeleteAppUser
{
    public class DeleteAppUserCommand: IRequest
    {
        public int AppUserId { get; set; }
    }
}