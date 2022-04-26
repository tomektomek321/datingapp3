using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories;
public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(DatingAppContext dbContext) : base(dbContext)  
    { }

    public Task<bool> DoesUserNameAlreadyExists(string UserName)
    {
        bool user = _dbContext.AppUsers.Any(x => x.UserName == UserName);
        return Task.FromResult(user);
    }

    public async Task<AppUser> GetUserByUsername(string username)
    {
        AppUser user = _dbContext
                        .AppUsers
                        .Where(x => x.UserName == username)
                        .FirstOrDefault();
        return user;  
    }

    public Task<List<AppUser>> GetAppUsersList()
    {
        throw new NotImplementedException();
    }
}

