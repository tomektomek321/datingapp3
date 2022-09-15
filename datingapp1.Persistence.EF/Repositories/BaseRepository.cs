using datingapp1.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace datingapp1.Persistence.EF.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DatingAppContext _dbContext;

    public BaseRepository(DatingAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Add(T entity)
    {
        EntityEntry e1 = _dbContext.Set<T>().Add(entity);
        var x = await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();

    }

    public async Task<T> GetById(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}