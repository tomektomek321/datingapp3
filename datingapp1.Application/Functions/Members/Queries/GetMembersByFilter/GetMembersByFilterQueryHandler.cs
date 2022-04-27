using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;

public class GetMembersByFilterQueryHandler : IRequestHandler<GetMembersByFilterQuery, GetMembersByFilterQueryResponse>
{
    public Task<GetMembersByFilterQueryResponse> Handle(GetMembersByFilterQuery request, CancellationToken cancellationToken)
    {



        throw new NotImplementedException();
    }
}

