using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyManager.Repositories;

namespace MoneyManager.Services
{
    public interface IMoneyManagerService
    {
        object GetUserBalance(int userId);
        void DeleteAllTransactionInMonth(int userId);
        IEnumerable<Transaction> GetUserTransactions(int userId);
        IEnumerable<object> GetUserTransactionWithSort(int userId);
        IEnumerable<object> GetUserAssetWithSort(int userId);
        object GetUserIncomeAndExpenses(int userId, DateTime startDate, DateTime endDate);
        IEnumerable<object> GetCategoryBalance(int userId, OperationType operationType);
    }
}
