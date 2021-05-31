using System;
using System.Collections.Generic;
using System.Linq;
using MoneyManager.Repositories;
using System.Threading.Tasks;

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
            return _transactionRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Transaction transaction)
        {
            _transactionRepository.Create(transaction);
        }

        public void Remove(int id)
        {
            _transactionRepository.Delete(id);
        }

        public void Update(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
        }

        public IEnumerable<Transaction> GetList()
        {
            return _transactionRepository.GetList();
        }

        public void Save()
        {
            _transactionRepository.Save();
        }
    }
}
