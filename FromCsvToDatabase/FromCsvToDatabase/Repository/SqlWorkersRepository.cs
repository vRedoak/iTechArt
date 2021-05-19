using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FromCsvToDatabase.Repository
{
    public class SqlWorkersRepository:SqlRepository<Workers>
    {
        public SqlWorkersRepository(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override void Create(Workers item)
        {
            try
            {
                _logger.Info("Request to add an worker object to the database");
                SendRequestNonQuery($"INSERT INTO Workers VALUES ('{item.name}', '{item.phone}')");
            }
            catch (Exception exception)
            {
                _logger.Error($"Error adding worker object: {exception.Message}");
            }
        }

        public override void Delete(int id)
        {
            try
            {
                _logger.Info("Request to detete an worker object from the database");
                SendRequestNonQuery($"DELETE Workers WHERE id={id}");
            }
            catch (Exception exception)
            {
                _logger.Error($"Worker object deletion error: {exception.Message}");
            }
        }

        public override Workers Get(int id)
        {
            try
            {
                _logger.Info("Request to get an worker object from the database");
                List<Workers> dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                _logger.Error($"Error getting worker object: {exception.Message}");
                return null;
            }
        }

        public override IEnumerable<Workers> GetList()
        {
            try
            {
                _logger.Info("Request to get worker objects from the database");
                List<Workers> dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers");
                return dataReader;
            }
            catch (Exception exception)
            {
                _logger.Error($"Error getting a list of workers: {exception.Message}");
                return null;
            }
        }

        public override void Update(Workers item)
        {
            try
            {
                _logger.Info("Request to change an worker object from the database");
                SendRequestNonQuery($"Update Workers SET name = '{item.name}', phone = '{item.phone}' WHERE id = {item.id}");
            }
            catch (Exception exception)
            {
                _logger.Error($"Worker object change error: {exception.Message}");
            }
        }
    }
}
