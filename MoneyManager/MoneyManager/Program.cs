using System;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uof = new UnitOfWork())
            {
                uof.MoneyManagerService.DeleteAllTransactionInMonth(1);
                Console.WriteLine(uof.UserService.GetUser("u1@mail.ru").Name);
                var request1 = uof.UserService.SortByName();
                var request2 = uof.MoneyManagerService.GetUserBalance(2);
                var request3 = uof.MoneyManagerService.GetUserAssetWithSort(2);
                var request4 = uof.MoneyManagerService.GetUserTransactionWithSort(2);
                var request5 = uof.MoneyManagerService.GetUserIncomeAndExpenses(2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now.AddMonths(2));
                var request6 = uof.MoneyManagerService.GetCategoryBalance(2, Services.OperationType.Expenses);
                Console.ReadLine();
            }
        }
    }
}