using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Repositories;

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

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository;
            }
        }

        public IAssetRepository AssetRepository
        {
            get
            {
                return _assetRepository;
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                return _transactionRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository;
            }
        }

        public List<object> GetUserBalance(int userId)
        {
            var users = _userRepository.GetList().ToList<object>() ;
            var transactions = _transactionRepository.GetList();
            //some realization
            return users;
        }
    }
}
