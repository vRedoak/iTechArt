using MoneyManager.Models;
using MoneyManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(UnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
        }

        public IEnumerable<object> SortByName()
        {
            try
            {
                return (from user in _userRepository.GetList()
                        orderby user.Name
                        select new { user.Id, user.Name, user.Email }).ToList<object>();
            }
            catch
            {
                Console.WriteLine("User sort error");
                throw;
            }
        }

        public async Task<IEnumerable<object>> SortByNameAsync()
        {
            try
            {
               return await (from user in _userRepository.GetList()
                        orderby user.Name
                        select new { user.Id, user.Name, user.Email }).AsQueryable().ToListAsync();
            }
            catch
            {
                Console.WriteLine("User sort error");
                throw;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return GetList().FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                Console.WriteLine("Error getting user");
                throw;
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                return await GetList().Where(x => x.Id == id).AsQueryable().FirstOrDefaultAsync();
            }
            catch
            {
                Console.WriteLine("Error getting user");
                throw;
            }
        }

        public User GetUser(string email)
        {
            try
            {
                return GetList().Where(x => x.Email == email).FirstOrDefault();
            }
            catch
            {
                Console.WriteLine("Error getting user");
                throw;
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            try
            {
                return await GetList().Where(x => x.Email == email).AsQueryable().FirstOrDefaultAsync();
            }
            catch
            {
                Console.WriteLine("Error getting user");
                throw;
            }
        }

        public void Add(User item)
        {
            try
            {
                _userRepository.Create(item);
            }
            catch
            {
                Console.WriteLine("Error adding user");
                throw;
            }
        }

        public async Task AddAsync(User item)
        {
            try
            {
               await _userRepository.CreateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error adding user");
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch
            {
                Console.WriteLine("User deletion error");
                throw; 
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
            }
            catch
            {
                Console.WriteLine("User deletion error");
                throw;
            }
        }

        public void Update(User item)
        {
            try
            {
                _userRepository.Update(item);
            }
            catch 
            {
                Console.WriteLine("User update error");
                throw;
            }
        }

        public async Task UpdateAsync(User item)
        {
            try
            {
                await _userRepository.UpdateAsync(item);
            }
            catch
            {
                Console.WriteLine("User update error");
                throw;
            }
        }

        public IEnumerable<User> GetList()
        {
            try
            {
                return _userRepository.GetList();
            }
            catch
            {
                Console.WriteLine("Error getting users");
                throw; 
            }
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            try
            {
                return await _userRepository.GetListAsync();
            }
            catch
            {
                Console.WriteLine("Error getting users");
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _userRepository.Save();
            }
            catch
            {
                Console.WriteLine("Save error");
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _userRepository.SaveAsync();
            }
            catch
            {
                Console.WriteLine("Save error");
                throw;
            }
        }
    }
}
