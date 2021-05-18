using System.Collections.Generic;
using System.Data.SqlClient;

namespace FromCsvToDatabase.Repository
{
    public class SqlAnimalsRepository : SqlRepository<Animals>
    {
        public SqlAnimalsRepository(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override void Create(Animals item)
        {
            _logger.Info("Request to add an animal object to the database");
            SendRequestNonQuery($"INSERT INTO Animals VALUES ('{item.name}', '{item.type}', {item.speed})");
        }

        public override void Delete(int id)
        {
            _logger.Info("Request to detete an animal object from the database");
            SendRequestNonQuery($"DELETE Animals WHERE id={id}");
        }

        public override Animals Get(int id)
        {
            _logger.Info("Request to get an animal object from the database");
            List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals WHERE id = {id}");
            return dataReader[0];
        }

        public override IEnumerable<Animals> GetList()
        {
            _logger.Info("Request to get animal objects from the database");
            List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals");
            return dataReader;
        }

        public override void Update(Animals item)
        {
            _logger.Info("Request to change an animal object from the database");
            SendRequestNonQuery($"Update Animals SET name = '{item.name}', type = '{item.type}', speed = {item.speed} WHERE id = {item.id}");
        }
    }
}
