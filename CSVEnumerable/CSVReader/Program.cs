using System;

namespace EnumerableCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvRecords = new CsvEnumerable<UserModel>(@"../../myFile.csv",';');
            foreach (var csvRecord in csvRecords)
            {
                Console.WriteLine($"Id: {csvRecord.id}  Name: {csvRecord.name}");
            }
            Console.Read();
        }
    }

    class UserModel : ICanReadCsvFiles
    {
        public int id;
        public string name;

        public UserModel() { }

        public void FieldsInitialization(string[] fields)
        {
            id = Convert.ToInt32(fields[0]);
            name = fields[1];
        }
    }
}
