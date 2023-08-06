using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace datingapp1.Application.Functions.Cities.Commands.BasicSeed
{
    public class BasicSeedCitiesHandler : IRequestHandler<BasicSeedCitiesCommand, BaseResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;

        public BasicSeedCitiesHandler(
            ICityRepository cityRepository, 
            ICountryRepository countryRepository, 
            IAppUserRepository appUserRepository, 
            UserManager<AppUser> userManager
        ) {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _appUserRepository = appUserRepository;
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(BasicSeedCitiesCommand request, CancellationToken cancellationToken)
        {
            var name = "Ewa";
            var namePass = "Ewa";
            var s = 0;

            // var respo = _cityRepository.BasicSeed();
            var random = new Random();

            var lastUser = await _appUserRepository.GetLastUserIdBySex(s);

            for (int i = lastUser.Id; i < (lastUser.Id + 55); i++)
            {
                var city = await _cityRepository.GetById(random.Next(1, 10));
                var country = await _countryRepository.GetById(1);

                var user = new AppUser() {
                    UserName = name + "" + i,
                    DateOfBirth = new DateTime(random.Next(1960, 2005), random.Next(1, 12), random.Next(1, 25)),
                    Gender = s,
                    KnownAs = name + "" + i,
                    EmailConfirmed = true,
                    Email = name + "" + i + "@wp.pl",
                    City = city,
                    Country = country,
                };

                IdentityResult result = await _userManager.CreateAsync(user, namePass + "" + i);
            }

            return new BaseResponse();
        }
    }
}
