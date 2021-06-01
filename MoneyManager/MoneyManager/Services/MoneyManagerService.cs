using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        delegate IEnumerable<Transaction> GetTransactions(int userId);

        public MoneyManagerService(IUserRepository userRepository,
                                   IAssetRepository assetRepository,
                                   ITransactionRepository transactionRepository,
                                   ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _assetRepository = assetRepository;
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }



        public object GetUserBalance(int userId)
        {
            var income = GetUserIncomeTransactions(userId).Sum(inc => inc.Amount);
            var expenses = GetUserExpensesTransactions(userId).Sum(exp => exp.Amount);
            var user = _userRepository.GetUser(userId);
            return new { UserId = userId, UserEmail = user.Email, UserName = user.Name, Balance = income - expenses };
        }

        public IEnumerable<object> GetUserAssetWithSort(int userId)
        {
            var w = (from asset in _assetRepository.GetList().ToList()
                     join user in _userRepository.GetList().ToList() on asset.UserId equals user.Id
                     where user.Id == userId
                     select new
                     {
                         AssetId = asset.Id,
                         AssetName = asset.Name,
                         Balance = (from transaction in GetUserIncomeTransactions(userId)
                                    where transaction.AssetId == asset.Id
                                    select transaction
                                    ).ToList().Sum(x => x.Amount) -
                                    (from transaction in GetUserExpensesTransactions(userId)
                                     where transaction.AssetId == asset.Id
                                     select transaction
                                    ).ToList().Sum(x => x.Amount)

                     }).ToList();
            return w;
        }

        private IEnumerable<Transaction> GetUserIncomeTransactions(int userId)
        {
            return (from transaction in GetUserTransactions(userId)
                    join category in _categoryRepository.GetList().ToList() on transaction.CategoryId equals category.Id
                    where category.Type == 1
                    select transaction).ToList();
        }

        private IEnumerable<Transaction> GetUserExpensesTransactions(int userId)
        {
            return (from transaction in GetUserTransactions(userId)
                    join category in _categoryRepository.GetList().ToList() on transaction.CategoryId equals category.Id
                    where category.Type == 0
                    select transaction).ToList();
        }

        public IEnumerable<Transaction> GetUserTransactions(int userId)
        {
            return (from tran in _transactionRepository.GetList().ToList()
                    join asset in _assetRepository.GetList().ToList() on tran.AssetId equals asset.Id
                    where asset.UserId == userId
                    select tran).ToList();
        }

        public IEnumerable<object> GetUserTransactionWithSort(int userId)
        {
            var t = (from transaction in _transactionRepository.GetList().ToList()
                     join asset in _assetRepository.GetList().ToList() on transaction.AssetId equals asset.Id
                     where asset.UserId == userId
                     join category in _categoryRepository.GetList().ToList() on transaction.CategoryId equals category.Id
                     orderby _transactionRepository.GetDate(transaction) descending
                     orderby asset.Name, category.Name
                     select new { AssetName = asset.Name, CategoryName = category.Name, CategoryParentName = category.Parent?.Name, TransactionAmount = transaction.Amount, TransactionDate = _transactionRepository.GetDate(transaction), TransactionComment = transaction.Comment }).ToList();
            return t;
        }

        public object GetUserIncomeAndExpenses(int userId, DateTime startDate, DateTime endDate)
        {
            var dates = GetDates(startDate, endDate);
            return new
            {
                TotalIncome = GetUserIncomeTransactions(userId).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).ToList().Sum(x => x.Amount),
                TotalExpenses = GetUserExpensesTransactions(userId).Where(x => DateCompare(_transactionRepository.GetDate(x), startDate, endDate)).ToList().Sum(x => x.Amount),
                Month = from date in dates
                        select new
                        {
                            MonthName = date[0].ToString("MMMM", new CultureInfo("ru-RU")),
                            TotalIncome = GetUserIncomeTransactions(userId).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).ToList().Sum(x => x.Amount),
                            TotalExpenses = GetUserExpensesTransactions(userId).Where(x => DateCompare(_transactionRepository.GetDate(x), date[0], date[1])).ToList().Sum(x => x.Amount),
                        }
            };
        }

        public IEnumerable<object> GetCategoryBalance(int userId, OperationType operationType)
        {
            if (operationType == OperationType.Income)
                return GetCategoryBalance(userId, GetUserIncomeTransactions);
            else
                return GetCategoryBalance(userId, GetUserExpensesTransactions);
        }

        private IEnumerable<object> GetCategoryBalance(int userId, GetTransactions getTransactions)
        {
            return (from category in _categoryRepository.GetList().ToList()
                    where category.ParentId == null
                    select new
                    {
                        CategoryName = category.Name,
                        Amount = (category.Categories.Count == 0) ? GetTransactionSum(userId, category, getTransactions) : category.Categories.Sum(x => GetTransactionSum(userId, x, getTransactions)),
                    }).OrderByDescending(x => x.Amount).OrderBy(y => y.CategoryName).ToList();
        }

        private decimal GetTransactionSum(int userId, Category category, GetTransactions getTransactions)
        {
            return (from transaction in getTransactions(userId).ToList()
                    where transaction.CategoryId == category.Id
                    select transaction).ToList().Sum(x => x.Amount);
        }

        private bool DateCompare(DateTime date, DateTime minDate, DateTime maxDate)
        {
            return date >= minDate && date <= maxDate;
        }

        public void DeleteAllTransactionInMonth(int userId)
        {
            var dateNow = DateTime.Now;
            var startDate = new DateTime(dateNow.Year, dateNow.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            foreach (var transaction in GetUserTransactions(userId))
            {
                var transactionDate = _transactionRepository.GetDate(transaction);
                if (transactionDate <= endDate && transactionDate >= startDate)
                    _transactionRepository.Delete(transaction.Id);
            }
            _transactionRepository.Save();
        }

        private IEnumerable<DateTime[]> GetDates(DateTime startDate, DateTime endDate)
        {
            List<DateTime[]> dates = new List<DateTime[]>();
            while (startDate <= endDate)
            {
                dates.Add(new DateTime[] { startDayOfMonth(startDate), endDayOfMonth(startDate) });
                startDate = startDate.AddMonths(1);
            }

            return dates;
        }

        private DateTime startDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private DateTime endDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);
        }
    }
}
