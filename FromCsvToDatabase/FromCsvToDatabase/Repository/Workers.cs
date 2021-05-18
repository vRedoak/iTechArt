using FromCsvToDatabase.ReadCsv;

namespace FromCsvToDatabase.Repository
{
    public class Workers : ICanReadCsvFiles
    {
        public int id;
        public string name;
        public string phone;

        public Workers() { }

        public Workers(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void FieldsInitialization(string[] fields)
        {
            name = fields[0];
            phone = fields[1];
        }
    }
}
