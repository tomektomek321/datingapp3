using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using MediatR;

namespace datingapp1.Application;

public static class ApplicationInstallation
{
    public static IServiceCollection DatingAppInstallation(this IServiceCollection services) {

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;

    }
}
