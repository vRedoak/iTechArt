using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Repositories
{
    class UserRepository : IRepository<User>, IUserRepository
    {
        private readonly MoneyManagerContext db;

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
            var user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
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
        }
    }
}
