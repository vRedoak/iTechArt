﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            db.Transactions.Add(item);
        }

        public void Delete(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction != null)
                db.Transactions.Remove(transaction);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetList()
        {
            return db.Transactions;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Transaction item)
        {
            db.Transactions.Update(item);
            db.Entry(item).State = EntityState.Modified;
        }
    }
}