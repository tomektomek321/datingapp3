using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Likes.Commands.ToggleLikeUser;

public class ToggleLikeUserCommandResponse: BaseResponse
{
    public ToggleLikeUserCommandResponse(): base()
    { }

    public ToggleLikeUserCommandResponse(string message, bool success): base(message, success)
    { }

}

