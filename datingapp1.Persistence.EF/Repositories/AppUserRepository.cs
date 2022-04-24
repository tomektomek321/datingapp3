using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DatingAppContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> DoesUserNameAlreadyExists(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAppUsersList()
        {
            throw new NotImplementedException();
        }
    }
}
