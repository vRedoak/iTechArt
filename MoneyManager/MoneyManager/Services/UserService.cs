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

        public User GetUser(int id)
        {
            return _userRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUser(string email)
        {
            return _userRepository.GetList().Where(x => x.Email == email).FirstOrDefault();
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
