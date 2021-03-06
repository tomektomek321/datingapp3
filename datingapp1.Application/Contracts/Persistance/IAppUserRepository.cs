using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace datingapp1.Application.Contracts.Persistance;

public interface IAppUserRepository: IRepository<AppUser>
{
    Task<List<AppUser>> GetAppUsersList();
    Task<bool> DoesUserNameAlreadyExists(string UserName);
    Task<AppUser> GetUserByUsername(string username);
    Task<List<AppUser>> GetAppUsersByFilter(DateTime MingAge, DateTime MaxAge, int Gender, string OrderBy, int[] cities);
    Task<List<MemberDto>> GetLikedMembers(int UserId);
    Task<List<MemberDto>> GetLikedByMembers(int UserId);
    Task<AppUserDto> GetUserProfile(int UserId);
    Task<AppUser> GetUserWithCity(int UserId);
}
