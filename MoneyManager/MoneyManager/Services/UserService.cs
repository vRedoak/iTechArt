using MoneyManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                throw;
            }
        }
        public User GetUser(int id)
        {
            try
            {
                return GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
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
                throw;
            }
        }

        public void Add(User user)
        {
            try
            {
                _userRepository.Create(user);
            }
            catch
            {
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _userRepository.Delete(id);
            }
            catch { throw; }
        }

        public void Update(User user)
        {
            try
            {
                _userRepository.Update(user);
            }
            catch { throw; }
        }

        public IEnumerable<User> GetList()
        {
            try
            {
                return _userRepository.GetList();
            }
            catch { throw; }
        }

        public void Save()
        {
            try
            {
                _userRepository.Save();
            }
            catch { throw; }
        }
    }
}
