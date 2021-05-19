using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FromCsvToDatabase.Repository
{
    public class SqlAnimalsRepository : SqlRepository<Animals>
    {
        public SqlAnimalsRepository(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override void Create(Animals item)
        {
            try
            {
                _logger.Info("Request to add an animal object to the database");
                SendRequestNonQuery($"INSERT INTO Animals VALUES ('{item.name}', '{item.type}', {item.speed})");
            }
            catch (Exception exception)
            {
                _logger.Error($"Error adding animal object: {exception.Message}");
            }
        }

        public override void Delete(int id)
        {
            try
            {
                _logger.Info("Request to detete an animal object from the database");
                SendRequestNonQuery($"DELETE Animals WHERE id={id}");
            }
            catch (Exception exception)
            {
                _logger.Error($"Animal object deletion error: {exception.Message}");
            }
        }

        public override Animals Get(int id)
        {
            try
            {
                _logger.Info("Request to get an animal object from the database");
                List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                _logger.Error($"Error getting animal object: {exception.Message}");
                return null;
            }
        }

        public override IEnumerable<Animals> GetList()
        {
            try
            {
                _logger.Info("Request to get animal objects from the database");
                List<Animals> dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals");
                return dataReader;
            }
            catch (Exception exception)
            {
                _logger.Error($"Error getting a list of animals: {exception.Message}");
                return null;
            }
        }

        public override void Update(Animals item)
        {
            try
            {
                _logger.Info("Request to change an animal object from the database");
                SendRequestNonQuery($"Update Animals SET name = '{item.name}', type = '{item.type}', speed = {item.speed} WHERE id = {item.id}");
            }
            catch (Exception exception)
            {
                _logger.Error($"Animal object change error: {exception.Message}");
            }
        }
    }
}
