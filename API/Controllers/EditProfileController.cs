using System;
using System.Collections.Generic;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EditProfileController : BaseApiController
    {
        private readonly IEditProfileRepository _editProfileRepository;
        public EditProfileController(IEditProfileRepository editProfileRepository)
        {
            _editProfileRepository = editProfileRepository;
        }

        [HttpGet("{text}")]
        public IEnumerable<Hobby> getHobbyHint(string text)
        {
            return _editProfileRepository.getHobbyHint(text);
        }


        [HttpPost("addhobby")]
        public ActionResult<bool> addHobby(AddHobbyDto hobby)
        {
            bool isAdded = _editProfileRepository.addHobby(hobby);

            if(isAdded) return Ok(isAdded);

            return Unauthorized(false);

        }


    }
}