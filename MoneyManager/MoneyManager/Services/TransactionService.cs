using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using MoneyManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(UnitOfWork unitOfWork)
        {
            _transactionRepository = unitOfWork.TransactionRepository;
        }

        public Transaction GetTransaction(int id)
        {
            try
            {
                return _transactionRepository.GetList().Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                Console.WriteLine("Error getting transaction");
                throw;
            }
        }
        public async Task<Transaction> GetTransactionAsync(int id)
        {
            try
            {
                return await _transactionRepository.GetList().AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                Console.WriteLine("Error getting transaction");
                throw;
            }
        }

        public void Add(Transaction item)
        {
            try
            {
                _transactionRepository.Create(item);
            }
            catch
            {
                Console.WriteLine("Error adding transaction");
                throw;
            }
        }

        public async Task AddAsync(Transaction item)
        {
            try
            {
                await _transactionRepository.CreateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error adding transaction");
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _transactionRepository.Delete(id);
            }
            catch
            {
                Console.WriteLine("Error deletion transaction");
                throw;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                await _transactionRepository.DeleteAsync(id);
            }
            catch
            {
                Console.WriteLine("Error deletion transaction");
                throw;
            }
        }

        public void Update(Transaction item)
        {
            try
            {
                _transactionRepository.Update(item);
            }
            catch
            {
                Console.WriteLine("Error update transaction");
                throw;
            }
        }

        public async Task UpdateAsync(Transaction item)
        {
            try
            {
                await _transactionRepository.UpdateAsync(item);
            }
            catch
            {
                Console.WriteLine("Error update transaction");
                throw;
            }
        }

        public IEnumerable<Transaction> GetList()
        {
            try
            {
                return _transactionRepository.GetList();
            }
            catch
            {
                Console.WriteLine("Error getting transactions");
                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> GetListAsync()
        {
            try
            {
                return await _transactionRepository.GetListAsync();
            }
            catch
            {
                Console.WriteLine("Error getting transactions");
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _transactionRepository.Save();
            }
            catch
            {
                Console.WriteLine("Save error");
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
               await _transactionRepository.SaveAsync();
            }
            catch
            {
                Console.WriteLine("Save error");
                throw;
            }
        }
    }
}
