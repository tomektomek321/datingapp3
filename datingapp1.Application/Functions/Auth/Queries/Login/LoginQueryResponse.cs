using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Queries.Login;
public class LoginQueryResponse<T> : BaseResponse
{
    public T Data { get; set; }

    public LoginQueryResponse(): base()
    { }

    public LoginQueryResponse(ValidationResult validationResult): base(validationResult)
    { }

    public LoginQueryResponse(string message): base(message)
    { }

    public LoginQueryResponse(string message, bool success): base(message, success)
    { }

    public LoginQueryResponse(T Data_): base()
    {
        Data = Data_;
    }
}

