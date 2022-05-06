using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.UserHobbies.Commands.AddUserHobby;

public class AddUserHobbyCommand: IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public int HobbyId { get; set; }
}

