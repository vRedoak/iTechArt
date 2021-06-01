using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Globalization;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uof = new UnitOfWork())
            {
                //   uof.Service.GetUserBalance(5);
                // uof.Service.UserRepository.Delete(5);
                //  uof.UserService.GetUser(3);
                //uof.Service.TransactionRepository.GetList();
                //uof.MoneyManagerService.DeleteAllTransactionInMonth(2);
                //Console.WriteLine( uof.UserService.GetUser("u1@mail.ru").Name);
                //XmlRead readXmlFile = new ReadXmlFile();
                //var t = readXmlFile.Read<User>("users.xml");
                //foreach (var d in t)
                //    Console.WriteLine(d.Name);
                // XMLFile();
                //var y = uof.MoneyManagerService.GetUserTransactions(2);
                //var o = uof.MoneyManagerService.GetCategoryBalance(2, Services.OperationType.Expenses);
                var q = uof.MoneyManagerService.GetUserIncomeAndExpenses(2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now.AddMonths(2));
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now.AddMonths(3);
                DateTime ij = start;
                while (start <= end)
                {
                    if (ij == start)
                        Console.WriteLine();
                    Console.WriteLine(start.ToString("MMMM", new CultureInfo("ru-RU")));
                   start = start.AddMonths(1);
                }
                
                Console.WriteLine(DateTime.Today.AddMonths(3).ToString("MMMM", new CultureInfo("ru-RU")));

                var d = uof.MoneyManagerService.GetUserAssetWithSort(2);
                var ed = uof.MoneyManagerService.GetUserBalance(2);
               
                var t = uof.UserService.SortByName();
                foreach(var k in t)
                {
                    Console.WriteLine(k.ToString());
                }    
                Console.ReadLine();

            }

        }

        
    }
}