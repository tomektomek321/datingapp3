using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Dto;
using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.GetProfileByUsername
{
    public class GetProfileByUsernameQuery : IRequest<TBaseResponse<MemberDto>>
    {
        public string Username { get; set; }
    }
}
