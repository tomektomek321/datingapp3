using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Extensions;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace datingapp1.Persistence.EF.Repositories;

public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
{
  private readonly UserManager<AppUser> _userManager;
  private readonly SignInManager<AppUser> _signInManager;

  public AppUserRepository(
      UserManager<AppUser> userManager,
      SignInManager<AppUser> signInManager,
      DatingAppContext dbContext
  ) : base(dbContext) {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  public Task<bool> DoesUserNameAlreadyExists(string UserName)
  {
    bool user = _userManager.Users.Any(x => x.UserName == UserName);
    return Task.FromResult(user);
  }

  public async Task<AppUser> GetUserByUsername(string username)
  {
    AppUser user = await _userManager
                    .Users
                    .Include(x => x.LikedUsers)
                    .Where(x => x.UserName == username)
                    .FirstOrDefaultAsync();
    return user;
  }

  public async Task<IdentityResult> RegisterAsync(AppUser user_, string password_)
  {
    IdentityResult result = await _userManager.CreateAsync(user_, password_);

    return result;
  }

  public async Task<bool> CheckPasswordSignInAsync(AppUser user_, string password_)
  {
    var result = await _signInManager.CheckPasswordSignInAsync(user_, password_, false);

    if (result.Succeeded)
    {
      return true;
    }

    return false;
  }

  public Task<List<AppUser>> GetAppUsersList()
  {
    throw new NotImplementedException();
  }

  public async Task<List<AppUser>> GetAppUsersByFilter(
    DateTime MinAge,
    DateTime MaxAge,
    int Gender,
    string OrderBy,
    int[] cities,
    int[] hobbies,
    int userId,
    string UserName
  ) {
    List<AppUser> users = await _userManager.Users
      .Include(user => user.City)
      .Include(user => user.LikedByUsers)
      .ToListAsync();

    var x = users.SelectMany(r => r.LikedUsers, (u, l) => new
    {
      user = u.Email,
      Liked = l.LikedUser.Email,
    });

    users = users.Where(user => user.Gender == Gender).ToList();

    users = users.Where(user =>
      user.DateOfBirth > MinAge &&
      user.DateOfBirth <= MaxAge).ToList();

    if (cities?.Length > 0)
    {
      users = users.Where(u => cities.Contains(u.City.Id)).ToList();
    }

    /*if(hobbies?.Length > 0)
    {
        foreach(var h in hobbies) {
            users = users.Where(u => u.UserHobbies.Any(h => hobbies.Contains(h.Id))).ToList();
        }
    }*/

    users = users.Where(u =>
        u.LikedByUsers.Where(l => l.SourceUserId == userId).ToList().Count == 0
    ).ToList();

    return users;
  }

  public Task<List<MemberDto>> GetLikedMembers(int UserId)
  {
    AppUser user = _userManager.Users
        .Include(u => u.LikedUsers)
        .Where(user_ => user_.Id == UserId)
        .FirstOrDefault();

    List<MemberDto> returnMembers = new List<MemberDto>();

    foreach (var user_ in user.LikedUsers)
    {
      var likedUser = _userManager.Users
          .Include(u => u.City)
          .Where(u => u.Id == user_.LikedUserId).FirstOrDefault();

      returnMembers.Add(new MemberDto()
      {
        Id = likedUser.Id,
        Username = likedUser.UserName,
        KnownAs = likedUser.KnownAs,
        Gender = likedUser.Gender,
        City = likedUser.City.Name,
      });
    }

    return Task.FromResult(returnMembers);
  }

  public Task<List<MemberDto>> GetLikedByMembers(int UserId)
  {
    AppUser user = _userManager.Users
        .Include(u => u.LikedByUsers)
        .Where(user_ => user_.Id == UserId)
        .FirstOrDefault();

    List<MemberDto> returnMembers = new List<MemberDto>();

    foreach (var user_ in user.LikedByUsers)
    {
      var likedUser = _userManager.Users
          .Include(u => u.City)
          .Where(u => u.Id == user_.SourceUserId)
          .FirstOrDefault();

      returnMembers.Add(new MemberDto()
      {
        Id = likedUser.Id,
        Username = likedUser.UserName,
        KnownAs = likedUser.KnownAs,
        Gender = likedUser.Gender,
        City = likedUser.City.Name,
      });
    }

    return Task.FromResult(returnMembers);
  }

  public Task<AppUserDto> GetUserProfile(int UserId)
  {
    AppUser user = _userManager.Users
        .Include(u => u.City)
        .Include(u => u.Country)
        .Include(u => u.UserHobbies)
            .ThenInclude(h => h.Hobby)
        .Where(user_ => user_.Id == UserId)
        .FirstOrDefault();

    List<Hobby> hobbies = new List<Hobby>();

    foreach (var hobby_ in user.UserHobbies)
    {
      hobbies.Add(hobby_.Hobby);
    }

    AppUserDto returnUserDto = new AppUserDto()
    {
      UserName = user.UserName,
      KnownAs = user.KnownAs,
      Gender = user.Gender,
      City = user.City.Name,
      Country = user.Country.Name,
      Hobbies = hobbies,
      LastActive = user.LastActive,
      Age = user.DateOfBirth.ToUniversalTime().CalculateAge(),
    };

    return Task.FromResult(returnUserDto);
  }

  public Task<MemberDto> GetUserProfileByUsername(string Username)
  {
    AppUser user = _userManager.Users
        .Include(u => u.City)
        .Include(u => u.Country)
        .Include(u => u.UserHobbies)
            .ThenInclude(h => h.Hobby)
        .Include(u => u.LikedUsers)
        .Where(user_ => user_.UserName == Username)
        .FirstOrDefault();

    /*if(user == null) {
        return null;
    }*/

    List<Hobby> hobbies = new List<Hobby>();

    foreach (var hobby_ in user.UserHobbies)
    {
      hobbies.Add(hobby_.Hobby);
    }

    MemberDto returnUserDto = new MemberDto()
    {
      Id = user.Id,
      Username = user.UserName,
      KnownAs = user.KnownAs,
      Gender = user.Gender,
      City = user.City.Name,
      Hobbies = hobbies,
      Age = user.DateOfBirth.ToUniversalTime().CalculateAge(),
    };

    return Task.FromResult(returnUserDto);
  }

  public Task<AppUser> GetUserWithCity(int UserId)
  {
    AppUser user = _userManager.Users
        .Include(u => u.City)
        .Where(user_ => user_.Id == UserId)
        .FirstOrDefault();

    return Task.FromResult(user);
  }

  public Task<AppUser> GetLastUserId()
  {
    AppUser user = _userManager.Users
        .OrderByDescending(u => u.Id)
        .First();

    return Task.FromResult(user);
  }

  public Task<AppUser> GetLastUserIdBySex(int s)
  {
    AppUser user = _userManager.Users
        .OrderByDescending(u => u.Id)
        // .Where(u => u.Gender == s)
        .First();

    return Task.FromResult(user);
  }
}
