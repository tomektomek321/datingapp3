using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;

public class GetMembersByFilterQueryHandler : IRequestHandler<GetMembersByFilterQuery, GetMembersByFilterQueryResponse>
{
    private readonly IAppUserRepository _appUserRepository;

    public GetMembersByFilterQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public async Task<GetMembersByFilterQueryResponse> Handle(GetMembersByFilterQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> users = _appUserRepository.GetAppUsersByFilter(request.minAge, request.maxAge, request.gender, request.orderBy).Result;

        return new GetMembersByFilterQueryResponse(users);

        throw new NotImplementedException();
    }
}

