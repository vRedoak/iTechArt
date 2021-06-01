using System;
using System.Collections.Generic;

namespace MoneyManager.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
