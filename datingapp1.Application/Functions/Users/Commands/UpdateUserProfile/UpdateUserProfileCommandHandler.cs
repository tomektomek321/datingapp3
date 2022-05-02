using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICityRepository _cityRepository;

    public UpdateUserProfileCommandHandler(IAppUserRepository appUserRepository, ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
        _appUserRepository = appUserRepository;
    }

    public Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {

        AppUser user = _appUserRepository.GetUserByUsername(request.AppUserDto.UserName).Result;

        City city = _cityRepository.GetCityByName(request.AppUserDto.City);

        user.City = city;
        user.UserHobbies = (ICollection<UserHobby>)request.AppUserDto.Hobbies;





        throw new NotImplementedException();
    }
}

