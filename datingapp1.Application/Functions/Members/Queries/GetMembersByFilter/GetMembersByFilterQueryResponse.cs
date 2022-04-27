using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;

public class GetMembersByFilterQueryResponse : BaseResponse
{
    public List<AppUser> Data { get; set; }
    public GetMembersByFilterQueryResponse(List<AppUser> Data_) : base()
    {
        Data = Data_;
    }
}

