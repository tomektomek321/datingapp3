using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Persistence.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using datingapp1.Application.Contracts.Identity;
using datingapp1.Persistence.EF.Configuration;

namespace datingapp1.Persistence.EF;

public static class PersistenceWithEFRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config) {

        services.AddScoped<ITokenService, TokenService>();

        services.AddDbContext<DatingAppContext>(options => {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IHobbyRepository, HobbyRepository>();
        services.AddScoped<IHobbiesCategoryRepository, HobbiesCategoryRepository>();
        services.AddScoped<IUserHobbyRepository, UserHobbyRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();

        return services;
    }
}

