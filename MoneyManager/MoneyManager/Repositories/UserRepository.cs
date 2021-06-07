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
            return _db.Users.Find(id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _db.Users.FindAsync(id);
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
            await _db.SaveChangesAsync();
        }

        public IEnumerable<User> GetList()
        {
            return _db.Users.AsQueryable();
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }

        public void Update(User item)
        {
            _db.Users.Update(item);
        }

        public async Task UpdateAsync(User item)
        {
            _db.Users.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
