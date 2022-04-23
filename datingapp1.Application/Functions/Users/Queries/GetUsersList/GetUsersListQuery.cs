using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.GetUsersList
{
    public class GetUsersListQuery: IRequest<List<AppUser>>
    {
        //public
    }
}