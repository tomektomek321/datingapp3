using datingapp1.Application.Contracts.Identity;
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
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandHandlerResponse<LoginDto>>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(IAppUserRepository appUserRepository, ICityRepository cityRepository, 
        ICountryRepository countryRepository, ITokenService tokenService)
    {
        _appUserRepository = appUserRepository;
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
        _tokenService = tokenService;
    }

    public async Task<RegisterCommandHandlerResponse<LoginDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool userExists = await _appUserRepository.DoesUserNameAlreadyExists(request.Username);

        City city = await _cityRepository.GetById(request.City);
        Country country = await _countryRepository.GetById(request.City);

        if (userExists) return new RegisterCommandHandlerResponse<LoginDto>("User already exists", false);

        var validator = new RegisterCommandHandlerValidator(_appUserRepository);
        var validatorResult = await validator.ValidateAsync(request);

        if (!validatorResult.IsValid)
        {
            return new RegisterCommandHandlerResponse<LoginDto>(validatorResult);
        }

        using var hmac = new HMACSHA512();

        var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

        AppUser user = new AppUser()
        {
            UserName = request.Username,
            KnownAs = request.KnownAs,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth.ToUniversalTime(),
            City = city,
            Country = country,
            PasswordHash = password,
            PasswordSalt = hmac.Key,
        };

        await _appUserRepository.Add(user);

        LoginDto loginDto = new LoginDto()
        {
            Username = request.Username,
            KnownAs = user.KnownAs,
            Gender = user.Gender,
            Token = _tokenService.CreateToken(user),
        };

        return new RegisterCommandHandlerResponse<LoginDto>(loginDto);
    }
}

