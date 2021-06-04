using MoneyManager.Models;
using MoneyManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Services
{
    class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetCategory(int id)
        {
            try
            {
                return _categoryRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void Add(Category item)
        {
            try
            {
                _categoryRepository.Create(item);
            }
            catch { throw; }
        }

        public void Remove(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch { throw; }
        }

        public void Update(Category item)
        {
            try
            {
                _categoryRepository.Update(item);
            }
            catch { throw; }
        }

        public IEnumerable<Category> GetList()
        {
            try
            {
                return _categoryRepository.GetList();
            }
            catch { throw; }
        }

        public void Save()
        {
            try
            {
                _categoryRepository.Save();
            }
            catch { throw; }
        }
    }
}
