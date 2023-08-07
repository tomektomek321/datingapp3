using datingapp1.Domain.Entities;

namespace datingapp1.Application.Contracts.Persistance
{
    public interface IHobbiesCategoryRepository : IRepository<HobbiesCategory>
    {
        Task<bool> BasicSeed();
        Task<List<HobbiesCategory>> GetHobbiesCategories();
    }
}