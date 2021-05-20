using FromCsvToDatabase.ReadCsv;
using System;

namespace FromCsvToDatabase.Repository
{
    public class Animals : ICanReadCsvFiles
    {
        private int id;
        private string name;
        private string type;
        private double speed;

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

        public string Type 
        {
            get => type;
            set => type = value;
        }

        public double Speed 
        {
            get => speed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Speed can not be negative");
                speed = value;
            }
        }

        public void FieldsInitialization(string[] fields)
        {
            Name = fields[0];
            Type = fields[1];
            Speed = double.Parse(fields[2]);
        }
    }
}
