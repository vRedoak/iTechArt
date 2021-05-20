using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    interface IRepository<T> : IDisposable 
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetList();
        Task<IEnumerable<T>> GetListAsync();
        void Create(T item);
        Task CreateAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
