using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Repositories;

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
