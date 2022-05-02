using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Contracts.Persistance
{
    public interface ILikeRepository
    {
        Task<bool> ToggleLike(int sourceUserId, int targetUserId);
    }
}
