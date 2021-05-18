using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    public class SqlWorkersRepository:SqlRepository<Workers>
    {
        public SqlWorkersRepository(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override void Create(Workers item)
        {
            _logger.Info("Request to add an worker object to the database");
            SendRequestNonQuery($"INSERT INTO Workers VALUES ('{item.name}', '{item.phone}')");
        }

        public override void Delete(int id)
        {
            _logger.Info("Request to detete an worker object from the database");
            SendRequestNonQuery($"DELETE Workers WHERE id={id}");
        }

        public override Workers Get(int id)
        {
            _logger.Info("Request to get an worker object from the database");
            List<Workers> dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers WHERE id = {id}");
            return dataReader[0];
        }

        public override IEnumerable<Workers> GetList()
        {
            _logger.Info("Request to get animal objects from the database");
            List<Workers> dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers");
            return dataReader;
        }

        public override void Update(Workers item)
        {
            _logger.Info("Request to change an animal object from the database");
            SendRequestNonQuery($"Update Workers SET name = '{item.name}', phone = '{item.phone}' WHERE id = {item.id}");
        }
    }
}
