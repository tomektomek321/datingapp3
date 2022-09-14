using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.GetProfileByUsername
{
    public class GetProfileByUsernameHandler : IRequestHandler<GetProfileByUsernameQuery, TBaseResponse<MemberDto>>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetProfileByUsernameHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public Task<TBaseResponse<MemberDto>> Handle(GetProfileByUsernameQuery request, CancellationToken cancellationToken)
        {
            MemberDto returnDto = _appUserRepository.GetUserProfileByUsername(request.Username).Result;

            /*if(returnDto -= null) {
                Task.FromResult(new TBaseResponse<string>("No such user"));
            }*/

            return Task.FromResult(new TBaseResponse<MemberDto>(returnDto));
        }
    }
}

