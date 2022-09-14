using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Extensions;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
                        .Include(x => x.LikedUsers)
                        .Where(x => x.UserName == username)
                        .FirstOrDefault();
        return user;
    }

    public Task<List<AppUser>> GetAppUsersList()
    {
        throw new NotImplementedException();
    }

    public async Task<List<AppUser>> GetAppUsersByFilter(DateTime MinAge, DateTime MaxAge, int Gender, string OrderBy, int[] cities)
    {
        List<AppUser> users = _dbContext.AppUsers
            .Include(user => user.City)
            .ToList();

        users = users.Where(user => user.Gender == Gender).ToList();

        users = users.Where(user => user.DateOfBirth > MinAge && user.DateOfBirth <= MaxAge).ToList();

        if(cities?.Length > 0)
        {
            users = users.Where(u => cities.Contains(u.City.Id)).ToList();
        }

        return users;
    }

    public Task<List<MemberDto>> GetLikedMembers(int UserId)
    {
        AppUser user = _dbContext.AppUsers
            .Include(u => u.LikedUsers)
            .Where(user_ => user_.Id == UserId)
            .FirstOrDefault();

        List<MemberDto> returnMembers = new List<MemberDto>();

        foreach (var user_ in user.LikedUsers)
        {
            var likedUser = _dbContext.AppUsers
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
        AppUser user = _dbContext.AppUsers
            .Include(u => u.LikedByUsers)
            .Where(user_ => user_.Id == UserId)
            .FirstOrDefault();

        List<MemberDto> returnMembers = new List<MemberDto>();

        foreach (var user_ in user.LikedByUsers)
        {
            var likedUser = _dbContext.AppUsers
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
        AppUser user = _dbContext.AppUsers
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
        AppUser user = _dbContext.AppUsers
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
        AppUser user = _dbContext.AppUsers
            .Include(u => u.City)
            .Where(user_ => user_.Id == UserId)
            .FirstOrDefault();

        return Task.FromResult(user);
    }
}

