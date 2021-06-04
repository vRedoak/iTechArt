using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;

namespace MoneyManager.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly MoneyManagerContext _db;

        public TransactionRepository(MoneyManagerContext context)
        {
            _db = context;
        }

        public void Create(Transaction item)
        {
            _db.Transactions.Add(item);
        }

        public async Task CreateAsync(Transaction item)
        {
            await _db.Transactions.AddAsync(item);
        }

        public void Delete(int id)
        {
            var transaction = _db.Transactions.Find(id);
            if (transaction != null)
                _db.Transactions.Remove(transaction);
        }

        public IEnumerable<Transaction> GetList()
        {
            return _db.Transactions;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(Transaction item)
        {
            _db.Transactions.Update(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public DateTime GetDate(Transaction item)
        {
            return (DateTime)_db.Entry(item).Property("Date").CurrentValue;
        }
    }
}
