using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetLikedByMembers;

public class GetLikedByMembersQueryHandler : IRequestHandler<GetLikedByMembersQuery, GetLikedByMembersQueryResponse>
{
    private readonly IAppUserRepository _appUserRepository;

    public GetLikedByMembersQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public Task<GetLikedByMembersQueryResponse> Handle(GetLikedByMembersQuery request, CancellationToken cancellationToken)
    {
        List<MemberDto> members = _appUserRepository.GetLikedByMembers(request.UserId).Result;
        return Task.FromResult(new GetLikedByMembersQueryResponse(members));
    }
}

