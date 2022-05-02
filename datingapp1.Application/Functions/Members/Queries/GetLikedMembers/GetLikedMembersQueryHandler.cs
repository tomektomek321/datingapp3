using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetLikedMembers;

public class GetLikedMembersQueryHandler : IRequestHandler<GetLikedMembersQuery, GetLikedMembersQueryResponse>
{
    private readonly ILikeRepository _likeRepository;

    private readonly IAppUserRepository _appUserRepository;

    public GetLikedMembersQueryHandler(ILikeRepository likeRepository, IAppUserRepository appUserRepository)
    {
        _likeRepository = likeRepository;
        _appUserRepository = appUserRepository;
    }

    public Task<GetLikedMembersQueryResponse> Handle(GetLikedMembersQuery request, CancellationToken cancellationToken)
    {
        List<MemberDto> members = _appUserRepository.GetLikedMembers(request.UserId).Result;

        return Task.FromResult(new GetLikedMembersQueryResponse(members));
    }
}

