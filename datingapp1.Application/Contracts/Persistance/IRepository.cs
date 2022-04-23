using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp1.Application.Contracts.Persistance
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task Update(T entity);
        Task<T> Add(T entity);
        Task Delete(T entity);
    }
}