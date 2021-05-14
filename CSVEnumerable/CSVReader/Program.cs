using System;

namespace EnumerableCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvRecords = new CsvEnumerable<string>(@"../../myFile.csv");
            foreach (var csvRecord in csvRecords)
            {
                Console.WriteLine(csvRecord);
            }
            Console.Read();
        }
    }
}
