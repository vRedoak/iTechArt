using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyManager.Repositories;

namespace MoneyManager.Services
{
    public interface IMoneyManagerService
    {
        List<object> GetUserBalance(int userId);
        void DeleteAllTransactionInMonth(int userID);
    }
}
