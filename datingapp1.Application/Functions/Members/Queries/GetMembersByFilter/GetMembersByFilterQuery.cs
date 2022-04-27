using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;
public class GetMembersByFilterQuery: IRequest<GetMembersByFilterQueryResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int Gender { get; set; }
    public string OrderBy { get; set; }
}

