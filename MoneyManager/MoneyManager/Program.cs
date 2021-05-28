using System;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uof = new UnitOfWork())
            {
                uof.Service.GetUserBalance(5);
                uof.Service.UserRepository.Delete(5);
                uof.Service.TransactionRepository.GetList();
            }
            
        }
    }
}
