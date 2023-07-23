using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Persistence.EF.Repositories;

public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
{
    public HobbyRepository(DatingAppContext dbContext) : base(dbContext) { }

    public List<Hobby> GetHobbiesByText(string text)
    {
        List<Hobby> returnList = _dbContext.Hobbies.Where(hobby_ => hobby_.Name.ToLower().Contains(text.ToLower())).ToList();
        return returnList;
    }

    public Task<bool> BasicSeed()
    {
        List<Hobby> hobbies = new List<Hobby>();

        hobbies.Add(new Hobby() { Name = "Ksiazki" });
        hobbies.Add(new Hobby() { Name = "Pilka nozna" });
        hobbies.Add(new Hobby() { Name = "Plywanie" });
        hobbies.Add(new Hobby() { Name = "Tenis" });
        hobbies.Add(new Hobby() { Name = "Bieganie" });
        hobbies.Add(new Hobby() { Name = "Matematyka" });
        hobbies.Add(new Hobby() { Name = "Fizyka" });
        hobbies.Add(new Hobby() { Name = "Medycyna" });
        hobbies.Add(new Hobby() { Name = "Polityka" });
        hobbies.Add(new Hobby() { Name = "Gry komputerowe" });
        hobbies.Add(new Hobby() { Name = "Psychologia" });
        hobbies.Add(new Hobby() { Name = "Kino" });
        hobbies.Add(new Hobby() { Name = "Ekonomia" });
        hobbies.Add(new Hobby() { Name = "Ekologia" });
        hobbies.Add(new Hobby() { Name = "Chemia" });
        hobbies.Add(new Hobby() { Name = "Astronomia" });
        hobbies.Add(new Hobby() { Name = "Motoryzacja" });
        hobbies.Add(new Hobby() { Name = "Programowanie" });
        hobbies.Add(new Hobby() { Name = "Komputery" });


        _dbContext.Hobbies.AddRange(hobbies);
        _dbContext.SaveChanges();

        return Task.FromResult(true);
    }





}

