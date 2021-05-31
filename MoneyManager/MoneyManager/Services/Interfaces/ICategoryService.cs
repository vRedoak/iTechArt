using System;
using System.Collections.Generic;
using MoneyManager.Repositories;
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
    }
}
