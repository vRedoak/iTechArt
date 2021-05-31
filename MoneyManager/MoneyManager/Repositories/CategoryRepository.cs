using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class CategoryRepository:IRepository<Category>, ICategoryRepository
    {
        private MoneyManagerContext db;

        public CategoryRepository(MoneyManagerContext context)
        {
            db = context;
        }

        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetList()
        {
            return db.Categories;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            db.Categories.Update(item);
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
