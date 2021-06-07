using MoneyManager.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public interface IMoneyManagerService
    {
        object GetUserBalance(int userId);
        void DeleteAllTransactionInMonth(int userId);
        IQueryable<Transaction> GetUserTransactions(int userId);
        IQueryable<object> GetUserTransactionWithSort(int userId);
        IQueryable<object> GetUserAssetWithSort(int userId);
        object GetUserIncomeAndExpenses(int userId, DateTime startDate, DateTime endDate);
        IQueryable<object> GetCategoryBalance(int userId, OperationType operationType);
        Task DeleteAllTransactionInMonthAsync(int userId);
        Task<object> GetUserIncomeAndExpensesAsync(int userId, DateTime startDate, DateTime endDate);
    }
}
