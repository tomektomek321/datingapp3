using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.Auth.Queries.Login;
using datingapp1.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
{
    private readonly IAppUserRepository _appUserRepository;

    public LoginQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }
    public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = _appUserRepository.GetUserByUsername(request.Username).Result;


        if (user == null) return new LoginQueryResponse("No Such User", false);

        var validator = new LoginQueryHandlerValidator(_appUserRepository, user, request.Password);
        var validatorResult = await validator.ValidateAsync(request);

        if (!validatorResult.IsValid)
        {
            return new LoginQueryResponse(validatorResult);
        }

        return new LoginQueryResponse(user.Id);
    }
}

