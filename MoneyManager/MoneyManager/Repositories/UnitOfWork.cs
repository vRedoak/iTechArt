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
