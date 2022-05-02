using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Queries.GetProfile;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, TBaseResponse<AppUserDto>>
{
    private readonly IAppUserRepository _appUserRepository;

    public GetProfileQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }
    public Task<TBaseResponse<AppUserDto>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        AppUserDto returnDto = _appUserRepository.GetUserProfile(request.UserId).Result;

        return Task.FromResult(new TBaseResponse<AppUserDto>(returnDto));
    }
}

