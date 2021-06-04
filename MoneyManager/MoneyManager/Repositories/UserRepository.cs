using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly MoneyManagerContext _db;

        public UserRepository(MoneyManagerContext context)
        {
            _db = context;
        }

        public User GetUser(int id)
        {
            return _db.Users.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _db.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public User GetUser(string email)
        {
            return _db.Users.AsQueryable().FirstOrDefault(x => x.Email == email);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _db.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public async Task CreateAsync(User item)
        {
           await _db.Users.AddAsync(item);
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
                _db.Users.Remove(user); 
        }

        public IEnumerable<User> GetList()
        {
            return _db.Users.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User item)
        {
            _db.Users.Update(item);
        }
    }
}
