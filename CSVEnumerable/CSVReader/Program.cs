using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvEnumerable<string> se = new CsvEnumerable<string>(@"D:\ITechArt\CSVEnumerable\CSVReader\myFile.csv");
            foreach(var t in se)
            {
                Console.WriteLine(t.ToString());
            }
            Console.Read();
        }
    }
}
