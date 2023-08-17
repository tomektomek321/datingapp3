namespace datingapp1.Domain.Entities;

public class HobbiesCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Hobby> Hobbies { get; set; }
}
