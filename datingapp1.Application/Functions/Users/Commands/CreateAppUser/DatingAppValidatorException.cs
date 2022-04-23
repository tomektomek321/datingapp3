using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace datingapp1.Application.Functions.Users.Commands.CreateAppUser
{
    public class DatingAppValidatorException: ApplicationException
    {
        public List<string> ErrorMessages { get; set; }

        public DatingAppValidatorException(ValidationResult validationResult) {

            ErrorMessages = new List<string>();

            foreach (var item in validationResult.Errors)
            {
                ErrorMessages.Add(item.ErrorMessage);
            }
        }

    }
}