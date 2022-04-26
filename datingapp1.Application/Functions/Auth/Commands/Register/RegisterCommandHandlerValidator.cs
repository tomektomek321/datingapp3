using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.Users.Queries.Login;
using datingapp1.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Commands.Register;
public class RegisterCommandHandlerValidator : AbstractValidator<RegisterCommand>
{
    private readonly IAppUserRepository _appUserRepository;

    public RegisterCommandHandlerValidator(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;

        RuleFor(p => p).NotNull().NotEmpty();

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
                .WithMessage("Password needs at least 4 characters")
            .MaximumLength(12)
                .WithMessage("Password needs max 12 characters");

        RuleFor(p => p.KnownAs)
            .NotEmpty()
            .MinimumLength(4)
                .WithMessage("KnownAs needs at least 4 characters")
            .MaximumLength(12)
                .WithMessage("KnownAs needs max 12 characters");

        RuleFor(p => p.Username)
            .NotEmpty()
            .MinimumLength(4)
                .WithMessage("Username needs at least 4 characters")
            .MaximumLength(12)
                .WithMessage("Username needs max 12 characters");

    }

}

