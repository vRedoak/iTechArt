using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Services
{

    public class MoneyManagerService : IMoneyManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

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

        public List<object> GetUserBalance(int userId)
        {
            var users = _userRepository.GetList().ToList<object>();
            var transactions = _transactionRepository.GetList();
            //some realization
            return users;
        }

        public void DeleteAllTransactionInMonth(int userID)
        {
            var usersList = _transactionRepository.GetList().ToList();
            var assetsList = _assetRepository.GetList().ToList();
            var transactionsList = _transactionRepository.GetList().ToList();

            var transactions = (from user in usersList
                                join asset in assetsList on user.Id equals asset.UserId
                                where user.Id == userID
                                join transaction in transactionsList on asset.Id equals transaction.AssetId into userTransaction
                                from result in userTransaction.DefaultIfEmpty()
                                select result).ToList();

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            transactions = transactions.FindAll(x => EF.Property<DateTime>(x, "Date") <= endDate && EF.Property<DateTime>(x, "Date") >= startDate).ToList();
            foreach (var transaction in transactions)
            {
                _transactionRepository.Delete(transaction.Id);
            }
            _transactionRepository.Save();
        }
    }
}
