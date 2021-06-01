using MoneyManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Services
{
    class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction GetTransaction(int id)
        {
            try
            {
                return _transactionRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch { throw; }
        }

        public void Add(Transaction transaction)
        {
            try
            {
                _transactionRepository.Create(transaction);
            }
            catch { throw; }
        }

        public void Remove(int id)
        {
            try
            {
                _transactionRepository.Delete(id);
            }
            catch { throw; }
        }

        public void Update(Transaction transaction)
        {
            try
            {
                _transactionRepository.Update(transaction);
            }
            catch { throw; }
        }

        public IEnumerable<Transaction> GetList()
        {
            try
            {
                return _transactionRepository.GetList();
            }
            catch { throw; }
        }

        public void Save()
        {
            try
            {
                _transactionRepository.Save();
            }
            catch { throw; }
        }
    }
}
