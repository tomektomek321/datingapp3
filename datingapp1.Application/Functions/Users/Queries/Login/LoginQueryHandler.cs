using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AppUser>
    {
        private readonly IAppUserRepository _appUserRepository;

        public LoginQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        public Task<AppUser> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
