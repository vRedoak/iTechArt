using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    public class SqlAnimalsRepository : SqlRepository<Animals>
    {
        public SqlAnimalsRepository(string _connectionString) : base(_connectionString) { }

        public override void Create(Animals item)
        {
            SendRequestNonQuery($"INSERT INTO Animals VALUES ('{item.name}', '{item.type}', {item.speed})");
        }

        public async void CreateAsync(Animals item)
        {
            await Task.Factory.StartNew(() => Create(item));
        }

        public override void Delete(int id)
        {
            SendRequestNonQuery($"DELETE Animals WHERE id={id}");
        }

        public override Animals Get(int id)
        {
            List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals WHERE id = {id}");
            return dataReader[0];
        }

        public override IEnumerable<Animals> GetList()
        {
            List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals");
            return dataReader;
        }

        public override void Update(Animals item)
        {
            SendRequestNonQuery($"Update Animals SET name = '{item.name}', type = '{item.type}', speed = {item.speed} WHERE id = {item.id}");
        }
    }
}
