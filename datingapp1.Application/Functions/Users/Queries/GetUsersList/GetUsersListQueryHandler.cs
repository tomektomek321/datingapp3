using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Users.Queries.GetUsersList;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<AppUser>>
{
    private readonly IRepository<AppUser> _appUserRepository;

    public GetUsersListQueryHandler(IRepository<AppUser> appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public Task<List<AppUser>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var users = _appUserRepository.GetAll();

        throw new NotImplementedException();
    }
}
