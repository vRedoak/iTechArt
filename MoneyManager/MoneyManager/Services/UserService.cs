using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using MoneyManager.Repositories;

namespace MoneyManager.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public IEnumerable<object> SortByName()
        {
            return (from user in _userRepository.GetList()
                   orderby user.Name
                   select new { Id = user.Id, Name = user.Name, Email = user.Email }).ToList<object>();
        }

        public void Add(User user)
        {
            _userRepository.Create(user);
        }

        public void Remove(int id)
        {
            _userRepository.Delete(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public IEnumerable<User> GetList()
        {
            return _userRepository.GetList();
        }

        public void Save()
        {
            _userRepository.Save();
        }
    }
}
