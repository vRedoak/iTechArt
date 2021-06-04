using MoneyManager.Models;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUser(int id);
        Task<User> GetUser(string email);
    }
}
