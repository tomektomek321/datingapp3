using datingapp1.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetLikedByMembers;
public class GetLikedByMembersQueryResponse
{
    public List<MemberDto> Data { get; set; }
    public GetLikedByMembersQueryResponse(List<MemberDto> user) : base()
    {
        Data = user;
    }
}

