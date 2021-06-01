using System.Collections.Generic;

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
    }
}
