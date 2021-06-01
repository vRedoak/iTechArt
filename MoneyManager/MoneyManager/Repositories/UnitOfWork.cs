using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Services;
using MoneyManager.Repositories;

namespace MoneyManager
{
    public class UnitOfWork : IDisposable
    {
        private MoneyManagerContext db = new MoneyManagerContext();
        private IMoneyManagerService _moneyManagerService;
        private IUserService _userService;
        private IAssetService _assetService;
        private ICategoryService _categoryService;
        private ITransactionService _transactionService;
        private IUserRepository _userRepository;
        private IAssetRepository _assetRepository;
        private ITransactionRepository _transactionRepository;
        private ICategoryRepository _categoryRepository;
        private bool disposedValue;

        public IMoneyManagerService Service
        {
            get
            {
                if (_moneyManagerService == null)
                    _moneyManagerService = new MoneyManagerService(
                                                                    new UserRepository(db),
                                                                    new AssetRepository(db),
                                                                    new TransactionRepository(db),
                                                                    new CategoryRepository(db));
                return _moneyManagerService;
            }
        }

        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(userRepository);
                return _userService;
            }
        }

        public IAssetService AssetService
        {
            get
            {
                if (_assetService == null)
                    _assetService = new AssetService(assetRepository);
                return _assetService;
            }
        }

        public ITransactionService TransactionService
        {
            get
            {
                if (_transactionService == null)
                    _transactionService = new  TransactionService(transactionRepository);
                return _transactionService;
            }
        }

        public ICategoryService CategoryService
        {
            get
            {
                if (_categoryService == null)
                    _categoryService = new CategoryService(categoryRepository);
                return _categoryService;
            }
        }

        public IMoneyManagerService MoneyManagerService
        {
            get
            {
                if (_moneyManagerService == null)
                    _moneyManagerService = new MoneyManagerService(userRepository,assetRepository,transactionRepository, categoryRepository);
                return _moneyManagerService;
            }
        }

        private IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        private IAssetRepository assetRepository
        {
            get
            {
                if (_assetRepository == null)
                    _assetRepository = new AssetRepository(db);
                return _assetRepository;
            }
        }

        private ITransactionRepository transactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new TransactionRepository(db);
                return _transactionRepository;
            }
        }

        private ICategoryRepository categoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(db);
                return _categoryRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
