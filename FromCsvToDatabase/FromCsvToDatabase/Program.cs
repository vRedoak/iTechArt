using FromCsvToDatabase.ReadCsv;
using FromCsvToDatabase.Repository;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace FromCsvToDatabase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string connectionString = @"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = Zoo; Integrated Security = True; User Id = ICX\V.Krasnadubskaya";
            const string filePath = @"../../../Animals.csv";
            using (var unitOfWork = new UnitOfWork(connectionString))
            {
                // WriteAnimalsFromCsvToDataBase(filePath, unitOfWork);

                var t= Task.Factory.StartNew(()=> GetWorkersFromDataBaseToConsole(unitOfWork));
                // I am using Sleep because I cannot make the Main method asynchronous
                Thread.Sleep(1000);
            }
            Console.WriteLine("complite");
            Console.Read();
        }

        // a couple of methods to test work
        static void WriteAnimalsFromCsvToDataBase(string csvFilePath, UnitOfWork unitOfWork)
        {
            foreach (var record in new CsvEnumerable<Animals>(csvFilePath, ';'))
            {
                unitOfWork.Animals.Create(record);
            }
        }

        static async Task  GetWorkersFromDataBaseToConsole(UnitOfWork unitOfWork)
        {
            var allWorkers = await unitOfWork.Workers.GetListAsync();
            foreach (var worker in allWorkers)
                Console.WriteLine(worker.Name);
        }
    }
}
