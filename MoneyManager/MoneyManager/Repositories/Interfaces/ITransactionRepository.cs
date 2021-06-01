using System;

namespace MoneyManager.Repositories
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        DateTime GetDate(Transaction transaction);
    }
}
