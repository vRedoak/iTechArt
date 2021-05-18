using System;
using System.Collections.Generic;

namespace FromCsvToDatabase.Repository
{
    interface IRepository<T> : IDisposable 
    {
        T Get(int id);
        IEnumerable<T> GetList();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
