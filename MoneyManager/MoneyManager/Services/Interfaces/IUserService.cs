using System;
using System.Text;
using MoneyManager.Repositories;
using System.Collections.Generic;

namespace MoneyManager.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        User GetUser(string email);
        IEnumerable<User> GetList();
        void Add(User item);
        void Update(User item);
        void Remove(int id);
        void Save();
    }
}
