using datingapp1.Application.Contracts.Identity;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace datingapp1.Application.Functions.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandHandlerResponse<LoginDto>>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(
        IAppUserRepository appUserRepository, 
        ICityRepository cityRepository, 
        UserManager<AppUser> userManager,
        ICountryRepository countryRepository, 
        ITokenService tokenService
    ) {
        _appUserRepository = appUserRepository;
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<RegisterCommandHandlerResponse<LoginDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool userExists = await _appUserRepository.DoesUserNameAlreadyExists(request.Username);
        if (userExists) return new RegisterCommandHandlerResponse<LoginDto>("User already exists", false);

        City city = await _cityRepository.GetById(request.City);
        Country country = await _countryRepository.GetById(request.City);

        var validator = new RegisterCommandHandlerValidator(_appUserRepository);
        var validatorResult = await validator.ValidateAsync(request);

        if (!validatorResult.IsValid)
        {
            return new RegisterCommandHandlerResponse<LoginDto>(validatorResult);
        }

        AppUser newUser = new AppUser() {
            UserName = request.Username,
            KnownAs = request.KnownAs,
            Email = request.Username + "@wp.pl",
            City = city,
            Country = country,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
        };

        IdentityResult created = await _appUserRepository.RegisterAsync(newUser, request.Password);
        List<string> listOfErrors = new List<string>();
        if(!created.Succeeded) {

            foreach(var erorr in created.Errors) {
                listOfErrors.Add(erorr.Description);
            }

            return new RegisterCommandHandlerResponse<LoginDto>(listOfErrors);
        }

        var justRegisteredUser = await _appUserRepository.GetUserByUsername(request.Username);

        newUser.Id = justRegisteredUser.Id;

        LoginDto loginDto = new LoginDto()
        {
            Id = justRegisteredUser.Id,
            Username = request.Username,
            KnownAs = request.KnownAs,
            Gender = request.Gender,
            Token = await _tokenService.CreateToken(newUser),
        };

        return new RegisterCommandHandlerResponse<LoginDto>(loginDto);
    }
}

