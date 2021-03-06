using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EditProfileRepository: IEditProfileRepository
    {
        private readonly DataContext _context;
        public EditProfileRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Hobby> getHobbyHint(string text, string username)
        {
            var user = _context.Users
                .Include(user => user.UserHobbies)
                    .ThenInclude(x => x.Hobby)
                .Where(user => user.UserName == username)
                .FirstOrDefault();

            var f = _context.Hobbies
                .Where(x => x.Name.ToLower().Contains(text.ToLower()))
                .ToList();

            return f;
        }

        public bool addHobby(AddHobbyDto hobbyDto)
        {
            int userId = this._context.Users.FirstOrDefault(x => x.UserName == hobbyDto.username).Id;

            var x = this._context.Users
                .Include(x => x.UserHobbies)
                    .ThenInclude(x => x.Hobby)
                .FirstOrDefault(x => x.UserName == hobbyDto.username);

            var hobbies = x.UserHobbies.ToList();

            var y = x.UserHobbies.Any(x => x.Hobby.Name == hobbyDto.hobbyname);

            if(y) { return false; }

            var hobbyToAdd = _context.Hobbies.Find(hobbyDto.hobbyId);

            this._context.UserHobbies.Add(new UserHobby() {
                AppUserId = userId,
                Hobby = hobbyToAdd
            });

            if(this._context.SaveChanges() > 0) {
                return true;
            } else {
                return false;
            }

        }

        public bool removeHobby(AddHobbyDto hobbyDto) {

            int userId = this._context.Users.FirstOrDefault(x => x.UserName == hobbyDto.username).Id;

            var x = this._context.UserHobbies
                .Where(hobby_ => hobby_.Id == hobbyDto.hobbyId)
                .First();

            this._context.UserHobbies.Remove(x);

            if(this._context.SaveChanges() > 0) {
                return true;
            } else {
                return false;
            }
        }

    }
}