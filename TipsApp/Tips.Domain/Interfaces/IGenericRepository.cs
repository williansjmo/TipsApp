using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tips.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(object Id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(object Id);
    }
}
