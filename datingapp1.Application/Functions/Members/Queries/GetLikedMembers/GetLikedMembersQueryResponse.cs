using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetLikedMembers;

public class GetLikedMembersQueryResponse: BaseResponse
{
    public List<MemberDto> Data { get; set; }
    public GetLikedMembersQueryResponse(List<MemberDto> user): base()
    {
        Data = user;
    }

}
