using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("testUsers")]
        public void testUsers()
        {

            var random = new Random();

            int maleLogin = 120000;
            int famaleLogin = 120000;



            for (int i = 0; i < 257000; i++)
            {
                AppUser registerDto;

                int plecRand = random.Next(1, 2);

                int cityRand = random.Next(1, 16);
                //Console.WriteLine("cityRand");
                //Console.WriteLine(cityRand);

                int yearRand = random.Next(1972, 2005);
                int yearMonth = random.Next(1, 13);
                int yearDay = random.Next(1, 27);

                //Console.WriteLine("yearRand");
                //Console.WriteLine(yearRand);

                    string username = plecRand == 0 ? "tom" + maleLogin : "ana" + famaleLogin;
                    string knownAs = plecRand == 0 ? "tom" + maleLogin : "ana" + famaleLogin;
                    string passwird = plecRand == 0 ? "tom" + maleLogin++ : "ana" + famaleLogin++;

                    var cityToAdd = _context.Cities.Find(cityRand);
                    var countryToAdd = _context.Countries.Find(1);


                    using var hmac = new HMACSHA512();

                    registerDto = new AppUser() {
                        UserName = username.ToLower(),
                        KnownAs = knownAs,
                        City = cityToAdd,
                        Country = countryToAdd,
                        DateOfBirth = new DateTime(yearRand, yearMonth, yearDay),
                        Gender = plecRand == 0 ? "male" : "female",
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username)),
                        PasswordSalt = hmac.Key,
                    };

                    _context.Users.Add(registerDto);


            }

            _context.SaveChanges();

        }



        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            var cityToAdd = _context.Cities.Find(registerDto.City);
            var countryToAdd = _context.Countries.Find(registerDto.Country);

            using var hmac = new HMACSHA512();

            AppUser user = new AppUser() {
                UserName = registerDto.Username.ToLower(),
                KnownAs = registerDto.KnownAs,
                City = cityToAdd,
                Country = countryToAdd,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }

        [HttpGet("hintsForCities/{text}")]
        public List<City> getHintsForCities(string text) {

            var cities = _context.Cities.Where(x => x.Name.ToLower().Contains(text.ToLower())).ToList();

            return cities;
        }

        [HttpGet("hintsForCountries/{text}")]
        public List<Country> getHintsForCountries(string text) {

            var countries = _context.Countries.Where(x => x.Name.ToLower().Contains(text.ToLower())).ToList();

            return countries;
        }




        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }



        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}