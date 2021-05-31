using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

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
                uof.MoneyManagerService.DeleteAllTransactionInMonth(2);

                //XmlRead readXmlFile = new ReadXmlFile();
                //var t = readXmlFile.Read<User>("users.xml");
                //foreach (var d in t)
                //    Console.WriteLine(d.Name);
               // XMLFile();
                Console.ReadLine();

            }

        }

        
    }
}