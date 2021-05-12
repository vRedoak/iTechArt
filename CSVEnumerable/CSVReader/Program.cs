using System;

namespace EnumerableCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvEnumerable<string> csvRecords = new CsvEnumerable<string>(@"../../myFile.csv");
            foreach(var t in csvRecords)
            {
                Console.WriteLine(t.ToString());
            }
            Console.Read();
        }
    }
}
