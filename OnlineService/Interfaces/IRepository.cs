using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineService.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(uint id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(uint id);
    }
}

