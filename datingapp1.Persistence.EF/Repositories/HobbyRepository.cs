using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;

namespace datingapp1.Persistence.EF.Repositories;

public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
{
    public HobbyRepository(DatingAppContext dbContext) : base(dbContext) { }

    public List<Hobby> GetHobbiesByText(string text)
    {
        List<Hobby> returnList = _dbContext.Hobbies.Where(hobby_ => 
            hobby_.Name.ToLower().Contains(text.ToLower())
        ).ToList();
        return returnList;
    }

    public Task<bool> BasicSeed()
    {
        List<Hobby> hobbies = new()
        {
            new Hobby() { Name = "Pilka nozna", HobbiesCategoryId = 1 },
            new Hobby() { Name = "Tenis", HobbiesCategoryId = 1 },
            new Hobby() { Name = "Plywanie", HobbiesCategoryId = 1 },
            new Hobby() { Name = "Bieganie", HobbiesCategoryId = 1 },
            new Hobby() { Name = "Ksiazki", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Polityka", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Gry komputerowe", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Psychologia", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Motoryzacja", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Programowanie", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Komputery", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Kino", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Astronomia", HobbiesCategoryId = 2 },
            new Hobby() { Name = "Piesełki", HobbiesCategoryId = 3 },
            new Hobby() { Name = "Kocie", HobbiesCategoryId = 3 },
            new Hobby() { Name = "Rybki", HobbiesCategoryId = 3 },
            new Hobby() { Name = "Fretka", HobbiesCategoryId = 3 },
            new Hobby() { Name = "Chomik", HobbiesCategoryId = 3 },
            new Hobby() { Name = "Fizyka", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Matematyka", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Medycyna", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Ekonomia", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Ekologia", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Chemia", HobbiesCategoryId = 4 },
            new Hobby() { Name = "Breaking Bad", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Suits", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Black Mirror", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Wiedzmin", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Game of Thrones", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Peaky Blinders", HobbiesCategoryId = 5 },
            new Hobby() { Name = "The walking dead", HobbiesCategoryId = 5 },
            new Hobby() { Name = "MD House", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Godfather", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Mroczny Rycerz", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Pulp fiction", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Wladca pierscieni", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Forrest Gump", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Matrix", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Zielona mila", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Gladiator", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Joker", HobbiesCategoryId = 5 },
            new Hobby() { Name = "Zawsze na luzie", HobbiesCategoryId = 6 },
            new Hobby() { Name = "A w ryj chcesz?", HobbiesCategoryId = 6 },
            new Hobby() { Name = "Nie umiem tego naprawić", HobbiesCategoryId = 6 },
            new Hobby() { Name = "Potrzymaj mi piwo", HobbiesCategoryId = 6 }
        };

        _dbContext.Hobbies.AddRange(hobbies);
        _dbContext.SaveChanges();

        return Task.FromResult(true);
    }
}

