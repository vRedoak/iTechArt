using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface IUserService
    {
        IEnumerable<object> SortByName();
        IEnumerable<User> GetList();
        void Add(User item);
        void Update(User item);
        void Remove(int id);
        void Save();
        User GetUser(int id);
        User GetUser(string email);
        Task<IEnumerable<object>> SortByNameAsync();
        Task<IEnumerable<User>> GetListAsync();
        Task AddAsync(User item);
        Task UpdateAsync(User item);
        Task RemoveAsync(int id);
        Task SaveAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string email);
    }
}
