using MoneyManager.Models;
using System.Collections.Generic;

namespace MoneyManager.Services
{
    public interface ITransactionService
    {
        Transaction GetTransaction(int id);
        IEnumerable<Transaction> GetList();
        void Add(Transaction item);
        void Update(Transaction item);
        void Remove(int id);
        void Save();
    }
}
