using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;

public class GetMembersByFilterQueryResponse : BaseResponse
{
    public List<MemberDto> Data { get; set; }
    public GetMembersByFilterQueryResponse(List<MemberDto> Data_) : base()
    {
        Data = Data_;
    }
}

