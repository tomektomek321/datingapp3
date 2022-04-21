using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<UserHobby, HobbyDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Hobby.Name));
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
        }
    }
}