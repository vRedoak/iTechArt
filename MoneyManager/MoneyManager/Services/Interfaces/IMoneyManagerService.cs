using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyManager.Repositories;

namespace MoneyManager.Services
{
    public interface IMoneyManagerService
    {
        IUserRepository UserRepository { get; }
        IAssetRepository AssetRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        List<object> GetUserBalance(int userId);
    }
}
