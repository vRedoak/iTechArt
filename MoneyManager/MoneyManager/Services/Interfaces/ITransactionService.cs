using MoneyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<Transaction> GetTransactionAsync(int id);
        Task<IEnumerable<Transaction>> GetListAsync();
        Task AddAsync(Transaction item);
        Task UpdateAsync(Transaction item);
        Task RemoveAsync(int id);
        Task SaveAsync();
    }
}
