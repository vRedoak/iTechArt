using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.Repositories;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetCategory(int id)
        {
            return _categoryRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Remove(int id)
        {
            _categoryRepository.Delete(id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }

        public IEnumerable<Category> GetList()
        {
            return _categoryRepository.GetList();
        }

        public void Save()
        {
            _categoryRepository.Save();
        }
    }
}
