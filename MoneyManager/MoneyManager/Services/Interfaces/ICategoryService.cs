using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface ICategoryService
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetList();
        void Add(Category item);
        void Update(Category item);
        void Remove(int id);
        void Save();
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetListAsync();
        Task AddAsync(Category item);
        Task UpdateAsync(Category item);
        Task RemoveAsync(int id);
        Task SaveAsync();
    }
}
