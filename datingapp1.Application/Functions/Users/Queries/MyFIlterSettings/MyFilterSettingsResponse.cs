using datingapp1.Domain.Dto.Hobbies;
using datingapp1.Domain.Entities;

namespace datingapp1.Application.Functions.Users.Queries.MyFIlterSettings
{
    public class MyFilterSettingsResponse
    {
        public List<HobbyDto> UserHobbies { get; set; }
        public List<HobbyCategoryDto> CategoriesWithHobbies { get; set; }
    }
}