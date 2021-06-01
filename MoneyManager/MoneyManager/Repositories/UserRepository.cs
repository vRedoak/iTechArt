using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class UserRepository : IRepository<User>, IUserRepository
    {
        private MoneyManagerContext db;

        public UserRepository(MoneyManagerContext context)
        {
            db = context;
        }
        public User GetUser(int id)
        {
            return GetList().Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUser(string email)
        {
            return GetList().Where(x => x.Email == email).FirstOrDefault();
        }


        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetList()
        {
            return db.Users.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Users.Update(item);
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
