using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace datingapp1.Application;

public class CreateAppUserCommandResponse: BaseResponse
{
    public int? AppUserId { get; set; }

    public CreateAppUserCommandResponse() : base()
    { }

    public CreateAppUserCommandResponse(ValidationResult validationResult): base(validationResult)
    { }

    public CreateAppUserCommandResponse(string message): base(message)
    { }

    public CreateAppUserCommandResponse(string message, bool success): base(message, success)
    { }

    public CreateAppUserCommandResponse(int _AppUserId)
    {
        AppUserId = _AppUserId;
    }

}
