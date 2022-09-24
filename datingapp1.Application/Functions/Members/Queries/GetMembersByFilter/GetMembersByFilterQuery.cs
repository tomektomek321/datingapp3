using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;
public class GetMembersByFilterQuery: IRequest<GetMembersByFilterQueryResponse>
{
    public int minAge { get; set; }
    public int maxAge { get; set; }
    public int gender { get; set; }
    public string orderBy { get; set; }
    public string cities { get; set; }
    public string hobbies { get; set; }
}

