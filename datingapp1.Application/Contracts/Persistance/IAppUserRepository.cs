using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace datingapp1.Application.Contracts.Persistance;

public interface IAppUserRepository: IRepository<AppUser>
{
    Task<List<AppUser>> GetAppUsersList();
    Task<bool> DoesUserNameAlreadyExists(string UserName);
    Task<AppUser> GetUserByUsername(string username);
    Task<List<AppUser>> GetAppUsersByFilter(DateTime MingAge, DateTime MaxAge, int Gender, string OrderBy, int[] cities, int[] hobbies, int userId, string userName);
    Task<List<MemberDto>> GetLikedMembers(int UserId);
    Task<List<MemberDto>> GetLikedByMembers(int UserId);
    Task<AppUserDto> GetUserProfile(int UserId);
    Task<MemberDto> GetUserProfileByUsername(string Username);
    Task<AppUser> GetUserWithCity(int UserId);
    public Task<bool> CheckPasswordSignInAsync(AppUser user_, string password_);
    public Task<IdentityResult> RegisterAsync(AppUser user_, string password_);
    Task<AppUser> GetLastUserId();
    Task<AppUser> GetLastUserIdBySex(int s);
}
