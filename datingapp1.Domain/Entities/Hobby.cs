namespace datingapp1.Domain.Entities;
public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HobbiesCategoryId { get; set; }
    public HobbiesCategory HobbiesCategory { get; set; }
}
