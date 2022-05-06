using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;

public class UpdateUserProfileCountryCommandHandler : IRequestHandler<UpdateUserProfileCountryCommand, BaseResponse>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICountryRepository _countryRepository;

    public UpdateUserProfileCountryCommandHandler(IAppUserRepository appUserRepository, ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
        _appUserRepository = appUserRepository;
    }

    public Task<BaseResponse> Handle(UpdateUserProfileCountryCommand request, CancellationToken cancellationToken)
    {
        AppUser user = _appUserRepository.GetById(request.UserId).Result;

        Country country = _countryRepository.GetById(request.CountryId).Result;

        user.Country = country;

        _appUserRepository.Update(user);

        return Task.FromResult(new BaseResponse());
    }
}

