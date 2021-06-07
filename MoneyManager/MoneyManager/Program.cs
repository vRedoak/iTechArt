using System;
using MoneyManager.Services;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uof = new UnitOfWork())
            {
                MoneyManagerService moneyManager = new MoneyManagerService(uof);
                var t = moneyManager.GetUserTransactions(2);
                foreach (var tf in t)
                {
                    Console.WriteLine(tf.Category + " ; " + tf.Amount);
                }
                Console.ReadLine();
            }
        }
    }
}