using MoneyManager.Repositories;
using MoneyManager.Services;
using System;

namespace MoneyManager
{
    public class UnitOfWork : IDisposable
    {
        private readonly MoneyManagerContext _db = new();
        private IUserRepository _userRepository;
        private IAssetRepository _assetRepository;
        private ITransactionRepository _transactionRepository;
        private ICategoryRepository _categoryRepository;
        private bool disposedValue;

        private IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_db); }
        }

        private IAssetRepository AssetRepository
        {
            get { return _assetRepository ??= new AssetRepository(_db); }
        }

        private ITransactionRepository TransactionRepository
        {
            get { return _transactionRepository ??= new TransactionRepository(_db); }
        }

        private ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ??= new CategoryRepository(_db); }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
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
