using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandHandlerResponse>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICityRepository _cityRepository;

    public RegisterCommandHandler(IAppUserRepository appUserRepository, ICityRepository cityRepository)
    {
        _appUserRepository = appUserRepository;
        _cityRepository = cityRepository;
    }

    public async Task<RegisterCommandHandlerResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool userExists = await _appUserRepository.DoesUserNameAlreadyExists(request.Username);

        City city = await _cityRepository.GetById(request.City);

        if(userExists) return new RegisterCommandHandlerResponse("User already exists", false);

        var validator = new RegisterCommandHandlerValidator(_appUserRepository/*, request.Password*/);
        var validatorResult = await validator.ValidateAsync(request);

        if (!validatorResult.IsValid)
        {
            return new RegisterCommandHandlerResponse(validatorResult);
        }

        using var hmac = new HMACSHA512();

        var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

        AppUser user = new AppUser()
        {
            UserName = request.Username,
            KnownAs = request.KnownAs,
            DateOfBirth = request.DateOfBirth.ToUniversalTime(),
            City = city,
            PasswordHash = password,
            PasswordSalt = hmac.Key,
        };

        await _appUserRepository.Add(user);

        return new RegisterCommandHandlerResponse(request.KnownAs);
    }
}

