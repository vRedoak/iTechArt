using FromCsvToDatabase.ReadCsv;
using System;

namespace FromCsvToDatabase
{
    public class Workers : ICanReadCsvFiles
    {
        private int id;
        private string name;
        private string phone;

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Id can not be negative");
                id = value;
            }
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Phone 
        {
            get => phone;
            set => phone = value;
        }

        public void FieldsInitialization(string[] fields)
        {
            Name = fields[0];
            Phone = fields[1];
        }
    }
}
