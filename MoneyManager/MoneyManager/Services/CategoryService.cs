using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using MoneyManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _categoryRepository = unitOfWork.CategoryRepository;
        }

        public Category GetCategory(int id)
        {
            try
            {
                return _categoryRepository.GetList().FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                Console.WriteLine("Error getting category");
                throw;
            }
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetList().AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                Console.WriteLine("Error getting category");
                throw;
            }
        }

        public void Add(Category item)
        {
            try
            {
                _categoryRepository.Create(item);
            }
            catch
            {
                Console.WriteLine("Error adding category");
                throw;
            }
        }
        public async Task AddAsync(Category item)
        {
            try
            {
                await _categoryRepository.CreateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error adding category");
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch
            {
                Console.WriteLine("Error deletion category");
                throw;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                await _categoryRepository.DeleteAsync(id);
            }
            catch
            {
                Console.WriteLine("Error deletion category");
                throw;
            }
        }

        public void Update(Category item)
        {
            try
            {
                _categoryRepository.Update(item);
            }
            catch
            {
                Console.WriteLine("Error update category");
                throw;
            }
        }

        public async Task UpdateAsync(Category item)
        {
            try
            {
                await _categoryRepository.UpdateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error update category");
                throw;
            }
        }

        public IEnumerable<Category> GetList()
        {
            try
            {
                return _categoryRepository.GetList();
            }
            catch
            {
                Console.WriteLine("Error getting category");
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetListAsync()
        {
            try
            {
                return await _categoryRepository.GetListAsync();
            }
            catch
            {
                Console.WriteLine("Error getting category");
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _categoryRepository.Save();
            }
            catch
            {
                Console.WriteLine("Save Error");
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _categoryRepository.SaveAsync();
            }
            catch
            {
                Console.WriteLine("Save Error");
                throw;
            }
        }
    }
}
