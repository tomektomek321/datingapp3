using datingapp1.Domain.Entities;

namespace datingapp1.Domain.Dto.Hobbies
{
    public class UserHobbiesDto
    {
        public List<Hobby> UserHobbies { get; set; }
        public List<HobbyCategoryDto> HobbyWithCategories { get; set; }
    }
}