using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Commands.Register
{
    public class RegisterCommandHandlerResponse: BaseResponse
    {
        public string _KnownAs { get; set; }

        public RegisterCommandHandlerResponse(string knownAs): base()
        {
            _KnownAs = knownAs;
        }

        public RegisterCommandHandlerResponse(string message, bool success) : base(message, success) 
        { }

        public RegisterCommandHandlerResponse(ValidationResult validationResult) : base(validationResult)
        { }

    }
}
