using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Commands.Register;
public class RegisterCommandHandlerResponse<T>: BaseResponse
{
    public T Data { get; set; }

    public RegisterCommandHandlerResponse(string message, bool success) : base(message, success) 
    { }

    public RegisterCommandHandlerResponse(ValidationResult validationResult) : base(validationResult)
    { }

    public RegisterCommandHandlerResponse(T user) : base()
    {
        Data = user;
    }
}

