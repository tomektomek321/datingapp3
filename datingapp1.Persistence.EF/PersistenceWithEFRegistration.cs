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

namespace datingapp1.Persistence.EF;

public static class PersistenceWithEFRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config) {
        services.AddDbContext<DatingAppContext>(options => {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        //services.AddScoped<IWebinaryRepository, WebinaryRepository>();
        //services.AddScoped<IPostRepository, IPostRepository>();

        return services;
    }
}

