using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using MoneyManager.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public enum OperationType
    {
        Income,
        Expenses
    }

    public class MoneyManagerService : IMoneyManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MoneyManagerService(UnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
            _assetRepository = unitOfWork.AssetRepository;
            _transactionRepository = unitOfWork.TransactionRepository;
            _categoryRepository = unitOfWork.CategoryRepository;
        }

        public object GetUserBalance(int userId)
        {
            try
            {
                var income = GetUserTransactionsByType(userId, 1).Sum(inc => inc.Amount);
                var expenses = GetUserTransactionsByType(userId, 0).Sum(exp => exp.Amount);
                var user = _userRepository.GetUser(userId);
                return new { UserId = userId, UserEmail = user.Email, UserName = user.Name, Balance = income - expenses };
            }
            catch
            {
                Console.WriteLine("Error getting user balance");
                throw;
            }

        }

        public IQueryable<object> GetUserAssetWithSort(int userId)
        {
            try
            {
                return (from asset in _assetRepository.GetList()
                        join user in _userRepository.GetList() on asset.UserId equals user.Id
                        where user.Id == userId
                        select new
                        {
                            AssetId = asset.Id,
                            AssetName = asset.Name,
                            Balance = (from transaction in GetUserTransactionsByType(userId, 1)
                                       where transaction.AssetId == asset.Id
                                       select transaction
                                       ).ToList().Sum(x => x.Amount) -
                                       (from transaction in GetUserTransactionsByType(userId, 0)
                                        where transaction.AssetId == asset.Id
                                        select transaction
                                       ).ToList().Sum(x => x.Amount)
                        }).OrderBy(x => x.AssetName).AsQueryable();
            }
            catch
            {
                Console.WriteLine("Error getting user asset with sort");
                throw;
            }
        }

        private IQueryable<Transaction> GetUserTransactionsByType(int userId, int type)
        {
            try
            {
                return (from transaction in GetUserTransactions(userId)
                        join category in _categoryRepository.GetList() on transaction.CategoryId equals category.Id
                        where category.Type == type
                        select transaction).AsQueryable();
            }
            catch
            {
                Console.WriteLine("Error getting user transaction by type");
                throw;
            }
        }

        public IQueryable<Transaction> GetUserTransactions(int userId)
        {
            try
            {
                return (from tran in _transactionRepository.GetList()
                        join asset in _assetRepository.GetList() on tran.AssetId equals asset.Id
                        where asset.UserId == userId
                        select tran).AsQueryable();
            }
            catch
            {
                Console.WriteLine("Error getting user transactions");
                throw;
            }
        }

        public IQueryable<object> GetUserTransactionWithSort(int userId)
        {
            try
            {
                return (from transaction in _transactionRepository.GetList()
                        join asset in _assetRepository.GetList() on transaction.AssetId equals asset.Id
                        where asset.UserId == userId
                        join category in _categoryRepository.GetList() on transaction.CategoryId equals category.Id
                        orderby _transactionRepository.GetDate(transaction) descending
                        orderby asset.Name, category.Name
                        select new { AssetName = asset.Name, CategoryName = category.Name, CategoryParentName = category.Parent?.Name, TransactionAmount = transaction.Amount, TransactionDate = _transactionRepository.GetDate(transaction), TransactionComment = transaction.Comment }).AsQueryable();
            }
            catch
            {
                Console.WriteLine("Error getting user transaction with sort");
                throw;
            }
        }

        public object GetUserIncomeAndExpenses(int userId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var dates = GetDates(startDate, endDate);
                return new
                {
                    TotalIncome = GetUserTransactionsByType(userId, 1).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).ToList().Sum(x => x.Amount),
                    TotalExpenses = GetUserTransactionsByType(userId, 0).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).ToList().Sum(x => x.Amount),
                    Monthly = from date in dates
                              select new
                              {
                                  MonthName = date[0].ToString("MMMM", new CultureInfo("ru-RU")),
                                  TotalIncome = GetUserTransactionsByType(userId, 1).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).ToList().Sum(x => x.Amount),
                                  TotalExpenses = GetUserTransactionsByType(userId, 0).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).ToList().Sum(x => x.Amount),
                              }
                };
            }
            catch
            {
                Console.WriteLine("Error getting user income and expenses");
                throw;
            }
        }

        public async Task<object> GetUserIncomeAndExpensesAsync(int userId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var dates = GetDates(startDate, endDate);
                var incomeTransactions = await GetUserTransactionsByType(userId, 1).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).AsQueryable().ToListAsync();
                var expensesTransaction = await GetUserTransactionsByType(userId, 0).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).AsQueryable().ToListAsync();
                return new
                {
                    TotalIncome = incomeTransactions.Sum(x => x.Amount),
                    TotalExpenses = expensesTransaction.Sum(x => x.Amount),
                    Monthly = from date in dates
                              select new
                              {
                                  MonthName = date[0].ToString("MMMM", new CultureInfo("ru-RU")),
                                  TotalIncome = GetUserTransactionsByType(userId, 1).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).AsQueryable().ToListAsync().Result.Sum(x => x.Amount),
                                  TotalExpenses = GetUserTransactionsByType(userId, 0).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).AsQueryable().ToListAsync().Result.Sum(x => x.Amount),
                              }
                };
            }
            catch
            {
                Console.WriteLine("Error getting user income and expenses");
                throw;
            }
        }

        public IQueryable<object> GetCategoryBalance(int userId, OperationType operationType)
        {
            try
            {
                if (operationType == OperationType.Income)
                    return GetCategoryBalance(userId, 1);
                else
                    return GetCategoryBalance(userId, operationType == OperationType.Income ? 1 : 0);
            }
            catch
            {
                Console.WriteLine("Error getting category balance");
                throw;
            }
        }

        private IQueryable<object> GetCategoryBalance(int userId, int type)
        {
            try
            {
                return (from category in _categoryRepository.GetList()
                        where category.ParentId == null
                        select new
                        {
                            CategoryName = category.Name,
                            Amount = (category.Categories.Count == 0) ? GetTransactionSum(userId, category, type) : category.Categories.Sum(x => GetTransactionSum(userId, x, type)),
                        }).OrderByDescending(x => x.Amount).OrderBy(y => y.CategoryName).AsQueryable();
            }
            catch
            {
                Console.WriteLine("Error getting category balance in private method");
                throw;
            }
        }

        private decimal GetTransactionSum(int userId, Category category, int type)
        {
            try
            {
                return (from transaction in GetUserTransactionsByType(userId, type).ToList()
                        where transaction.CategoryId == category.Id
                        select transaction).ToList().Sum(x => x.Amount);
            }
            catch
            {
                Console.WriteLine("Error getting transaction sum");
                throw;
            }
        }

        private static bool DateCompare(DateTime date, DateTime minDate, DateTime maxDate)
        {
            return date >= minDate && date <= maxDate;
        }

        public void DeleteAllTransactionInMonth(int userId)
        {
            try
            {
                var dateNow = DateTime.Now;
                var startDate = StartDayOfMonth(dateNow);
                var endDate = EndDayOfMonth(dateNow);
                foreach (var transaction in GetUserTransactions(userId))
                {
                    var transactionDate = _transactionRepository.GetDate(transaction);
                    if (DateCompare(transactionDate, startDate, endDate))
                        _transactionRepository.Delete(transaction.Id);
                }
                _transactionRepository.Save();
            }
            catch
            {
                Console.WriteLine("Error deletion all transaction in month");
                throw;
            }

        }

        public async Task DeleteAllTransactionInMonthAsync(int userId)
        {
            try
            {
                var dateNow = DateTime.Now;
                var startDate = StartDayOfMonth(dateNow);
                var endDate = EndDayOfMonth(dateNow);
                foreach (var transaction in GetUserTransactions(userId))
                {
                    var transactionDate = _transactionRepository.GetDate(transaction);
                    if (DateCompare(transactionDate, startDate, endDate))
                        _transactionRepository.Delete(transaction.Id);
                }
                await _transactionRepository.SaveAsync();
            }
            catch
            {
                Console.WriteLine("Error deletion all transaction in month");
                throw;
            }

        }

        private static IEnumerable<DateTime[]> GetDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dates = new List<DateTime[]>();
                while (startDate <= endDate)
                {
                    dates.Add(new DateTime[] { StartDayOfMonth(startDate), EndDayOfMonth(startDate) });
                    startDate = startDate.AddMonths(1);
                }
                return dates;
            }
            catch
            {
                Console.WriteLine("Error getting transactions");
                throw;
            }
        }

        private static DateTime StartDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private static DateTime EndDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);
        }
    }
}
