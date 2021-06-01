using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUser(int id);
        User GetUser(string email);
    }
}
