using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IEditProfileRepository
    {
        IEnumerable<Hobby> getHobbyHint(string text, string username);
        bool addHobby(AddHobbyDto hobby);
        bool removeHobby(AddHobbyDto hobby);
    }
}