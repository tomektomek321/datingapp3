namespace datingapp1.Domain.Dto.Hobbies
{
    public class HobbyCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HobbyDto> Hobbies { get; set; }
    }
}