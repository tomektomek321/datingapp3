using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using FluentValidation;

namespace datingapp1.Application.Functions.Users.Commands.CreateAppUser;

public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
{
    private readonly IAppUserRepository _appUserRepository;

    public CreateAppUserCommandValidator(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
                .WithMessage("Password needs at least 4 characters")
            .MaximumLength(12)
                .WithMessage("Password needs max 12 characters");

        RuleFor(p => p.KnownAs)
            .NotEmpty();

        RuleFor(p => p.UserName)
            .NotEmpty()
            .MinimumLength(4)
                .WithMessage("Username needs at least 4 characters")
            .MaximumLength(12)
                .WithMessage("Username needs max 12 characters");

        RuleFor(p => p)
            .MustAsync(DoesUserNameAlreadyExists)
                .WithMessage("Username already exists");

    }

    private async Task<bool> DoesUserNameAlreadyExists(CreateAppUserCommand e, CancellationToken cancellationToken) {
        var check = await _appUserRepository.DoesUserNameAlreadyExists(e.UserName);

        return true;
    }
}
