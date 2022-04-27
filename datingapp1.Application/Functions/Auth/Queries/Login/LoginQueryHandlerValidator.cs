using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Queries.Login;
public class LoginQueryHandlerValidator : AbstractValidator<LoginQuery>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly AppUser _user;
    private readonly string _password;

    public LoginQueryHandlerValidator(IAppUserRepository appUserRepository, AppUser user, string password)
    {
        _appUserRepository = appUserRepository;
        _user = user;
        _password = password;

        RuleFor(p => p.Username)
            .NotEmpty();

        RuleFor(p => p.Password)
            .NotEmpty();

        RuleFor(p => p)
            .MustAsync(IsPasswordCorrect)
                .WithMessage("Password is not correct");

    }

    private Task<bool> IsUserNull(LoginQuery e, CancellationToken token)
    {
        return Task.FromResult(_user == null);
    }

    private Task<bool> IsPasswordCorrect(LoginQuery e, CancellationToken token)
    {
        using var hmac = new HMACSHA512(_user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != _user.PasswordHash[i]) return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }



}

