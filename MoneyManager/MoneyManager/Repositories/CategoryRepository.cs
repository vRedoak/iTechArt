using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly MoneyManagerContext _db;

        public CategoryRepository(MoneyManagerContext context)
        {
            _db = context;
        }

        public void Create(Category item)
        {
            _db.Categories.Add(item);
        }
        public async Task CreateAsync(Category item)
        {
            await _db.Categories.AddAsync(item);
        }

        public void Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
                _db.Categories.Remove(category);
        }

        public IEnumerable<Category> GetList()
        {
            return _db.Categories;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(Category item)
        {
            _db.Categories.Update(item);
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
