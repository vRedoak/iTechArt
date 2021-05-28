using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    class TransactionRepository : IRepository<Transaction>, ITransactionRepository
    {
        private MoneyManagerContext db;

        public TransactionRepository(MoneyManagerContext context)
        {
            db = context;
        }

        public void Create(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction item)
        {
            throw new NotImplementedException();
        }
    }
}
