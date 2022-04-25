using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            bool user = _dbContext.AppUser.Any(x => x.UserName == UserName);
            return Task.FromResult(user);

        }

        public Task<AppUser> GetAppUser(RegisterDto loginDto)
        {
            AppUser user = _dbContext
                            .AppUser
                            .Where(x => x.UserName == loginDto.Username)
                            .FirstOrDefault();

            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            return Task.FromResult(user);

            
        }

        public Task<List<AppUser>> GetAppUsersList()
        {
            throw new NotImplementedException();
        }
    }
}
