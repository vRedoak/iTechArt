using System;
using FromCsvToDatabase.Repository;
using FromCsvToDatabase.ReadCsv;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FromCsvToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = Zoo; Integrated Security = True; User Id = ICX\V.Krasnadubskaya";
            string filePath = @"../../../Animals.csv";

           WriteAnimalsFromCsvToDataBase(filePath, connectionString);

            GetWorkersFromDataBaseToConsole(connectionString);
            Console.WriteLine("loading...");

            Console.Read();
        }


        // a couple of methods to test work
        static void WriteAnimalsFromCsvToDataBase(string csvFilePath, string connectionString)
        {
            using var unitOfWork = new UnitOfWork(connectionString);
            foreach (var record in new CsvEnumerable<Animals>(csvFilePath, ';'))
            {
                unitOfWork.Animals.Create(record);
            }
        }

        static async void GetWorkersFromDataBaseToConsole(string connectionString)
        {
            IEnumerable<Workers> allWorkers;
            using (var unitOfWork = new UnitOfWork(connectionString))
            {
                allWorkers = await unitOfWork.Workers.GetListAsync();
            }
            foreach (var worker in allWorkers)
                Console.WriteLine(worker.name);
        }
    }
}
