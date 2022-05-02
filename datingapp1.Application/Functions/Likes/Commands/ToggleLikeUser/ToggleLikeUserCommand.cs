using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Likes.Commands.ToggleLikeUser;

public class ToggleLikeUserCommand: IRequest<ToggleLikeUserCommandResponse>
{
    public int SourceUserId { get; set; }
    public int TargetUserId { get; set; }
}

