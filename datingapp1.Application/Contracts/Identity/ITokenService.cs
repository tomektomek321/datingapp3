using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Contracts.Identity
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
