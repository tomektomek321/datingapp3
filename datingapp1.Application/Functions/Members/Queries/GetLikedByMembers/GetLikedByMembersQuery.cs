using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetLikedByMembers;

public class GetLikedByMembersQuery : IRequest<GetLikedByMembersQueryResponse>
{
    public int UserId { get; set; }
}

