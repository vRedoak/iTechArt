using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
        Task<IEnumerable<T>> GetListAsync();
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
