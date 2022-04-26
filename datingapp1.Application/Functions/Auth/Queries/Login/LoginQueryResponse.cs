using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Queries.Login;
public class LoginQueryResponse : BaseResponse
{
    public int? AppUserId { get; set; }

    public LoginQueryResponse() : base()
    { }

    public LoginQueryResponse(ValidationResult validationResult) : base(validationResult)
    { }

    public LoginQueryResponse(string message) : base(message)
    { }

    public LoginQueryResponse(string message, bool success) : base(message, success)
    { }

    public LoginQueryResponse(int _AppUserId)
    {
        AppUserId = _AppUserId;
    }
}

