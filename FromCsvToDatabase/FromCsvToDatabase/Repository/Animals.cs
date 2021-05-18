using FromCsvToDatabase.ReadCsv;

namespace FromCsvToDatabase.Repository
{
    public class Animals: ICanReadCsvFiles
    {
        public int id;
        public string name;
        public string type;
        public double speed;

        public Animals() { }

        public Animals(string name, string type, double speed)
        {
            this.name = name;
            this.type = type;
            this.speed = speed;
        }

        public void FieldsInitialization(string[] fields)
        {
            name = fields[0];
            type = fields[1];
            speed = double.Parse(fields[2]);
        }
    }
}
