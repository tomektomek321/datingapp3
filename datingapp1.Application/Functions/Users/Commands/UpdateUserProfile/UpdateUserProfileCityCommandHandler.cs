using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;

public class UpdateUserProfileCityCommandHandler : IRequestHandler<UpdateUserProfileCityCommand, BaseResponse>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICityRepository _cityRepository;

    public UpdateUserProfileCityCommandHandler(IAppUserRepository appUserRepository, ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
        _appUserRepository = appUserRepository;
    }

    public async Task<BaseResponse> Handle(UpdateUserProfileCityCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _appUserRepository.GetUserWithCity(request.UserId);

        City city = await _cityRepository.GetById(request.CityId);

        user.City = city;

        await _appUserRepository.Update(user);

        return new BaseResponse();
    }
}

