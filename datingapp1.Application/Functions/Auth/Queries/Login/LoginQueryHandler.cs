using datingapp1.Application.Contracts.Identity;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.Auth.Queries.Login;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse<LoginDto>>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ITokenService _tokenService;

    public LoginQueryHandler(IAppUserRepository appUserRepository, ITokenService tokenService)
    {
        _appUserRepository = appUserRepository;
        _tokenService = tokenService;
    }
    public async Task<LoginQueryResponse<LoginDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = _appUserRepository.GetUserByUsername(request.Username).Result;


        if (user == null) return new LoginQueryResponse<LoginDto>("No Such User", false);

        var validator = new LoginQueryHandlerValidator(_appUserRepository, user, request.Password);
        var validatorResult = await validator.ValidateAsync(request);

        if (!validatorResult.IsValid)
        {
            return new LoginQueryResponse<LoginDto>(validatorResult);
        }

        LoginDto loginDto = new LoginDto() {
            Id = user.Id,
            Username = user.UserName,
            Gender = user.Gender,
            KnownAs = user.KnownAs,
            Token = _tokenService.CreateToken(user),
            LikedUsers = user.LikedUsers,
        };

        return new LoginQueryResponse<LoginDto>(loginDto);
    }
}

