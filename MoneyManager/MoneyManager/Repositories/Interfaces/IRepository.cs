﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IRepository<T>: IDisposable
    {
        T Get(int id);
        IEnumerable<T> GetList();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
