using MoneyManager.Models;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUser(int id);
        Task<User> GetUserAsync(int id);
    }
}
