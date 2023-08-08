using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace datingapp1.Persistence.EF.Repositories;
public class HobbiesCategoryRepository : BaseRepository<HobbiesCategory>, IHobbiesCategoryRepository
{
    public HobbiesCategoryRepository(DatingAppContext dbContext) : base(dbContext) { }

    public Task<bool> BasicSeed()
    {
        List<HobbiesCategory> hobbies = new()
        {
            new HobbiesCategory() { Name = "Sport" },
            new HobbiesCategory() { Name = "Hobby" },
            new HobbiesCategory() { Name = "Zwierzeta" },
            new HobbiesCategory() { Name = "Cos Ambitnego" },
            new HobbiesCategory() { Name = "TV" }, // 5
            new HobbiesCategory() { Name = "Osobowosc" },
            new HobbiesCategory() { Name = "Inne" },
        };

        _dbContext.HobbiesCategories.AddRange(hobbies);
        _dbContext.SaveChanges();

        return Task.FromResult(true);
    }
    public async Task<List<HobbiesCategory>> GetHobbiesCategories() {
        return await _dbContext.HobbiesCategories.ToListAsync();
    }  
}
