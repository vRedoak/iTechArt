using MoneyManager.Repositories;
using MoneyManager.Services;
using System;

namespace MoneyManager
{
    public class UnitOfWork : IDisposable
    {
        private readonly MoneyManagerContext db = new();
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

        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(UserRepository);
                return _userService;
            }
        }

        public IAssetService AssetService
        {
            get
            {
                if (_assetService == null)
                    _assetService = new AssetService(AssetRepository);
                return _assetService;
            }
        }

        public ITransactionService TransactionService
        {
            get
            {
                if (_transactionService == null)
                    _transactionService = new TransactionService(TransactionRepository);
                return _transactionService;
            }
        }

        public ICategoryService CategoryService
        {
            get
            {
                if (_categoryService == null)
                    _categoryService = new CategoryService(CategoryRepository);
                return _categoryService;
            }
        }

        public IMoneyManagerService MoneyManagerService
        {
            get
            {
                if (_moneyManagerService == null)
                    _moneyManagerService = new MoneyManagerService(UserRepository, AssetRepository, TransactionRepository, CategoryRepository);
                return _moneyManagerService;
            }
        }

        private IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        private IAssetRepository AssetRepository
        {
            get
            {
                if (_assetRepository == null)
                    _assetRepository = new AssetRepository(db);
                return _assetRepository;
            }
        }

        private ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new TransactionRepository(db);
                return _transactionRepository;
            }
        }

        private ICategoryRepository CategoryRepository
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
                    db.Dispose();
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
