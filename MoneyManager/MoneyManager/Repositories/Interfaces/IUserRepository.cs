namespace MoneyManager.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUser(int id);
        User GetUser(string email);
    }
}
