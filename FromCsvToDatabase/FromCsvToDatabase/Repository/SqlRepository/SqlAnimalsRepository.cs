using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    public class SqlAnimalsRepository : SqlRepository<Animals>
    {
        public SqlAnimalsRepository(SqlConnection sqlConnection) : base(sqlConnection) { }

        public override void Create(Animals item)
        {
            try
            {
                Logger.Info("Request to add an animal object to the database");
                SendRequestNonQuery($"INSERT INTO Animals VALUES ('{item.Name}', '{item.Type}', {item.Speed})");
            }
            catch (Exception exception)
            {
                Logger.Error($"Error adding animal object: {exception.Message}");
            }
        }

        public async override Task CreateAsync(Animals item)
        {
            try
            {
                Logger.Info("Request to add an animal object to the database");
                await SendRequestNonQueryAsync($"INSERT INTO Animals VALUES ('{item.Name}', '{item.Type}', {item.Speed})");
            }
            catch (Exception exception)
            {
                Logger.Error($"Error adding animal object: {exception.Message}");
            }
        }

        public override void Delete(int id)
        {
            try
            {
                Logger.Info("Request to detete an animal object from the database");
                SendRequestNonQuery($"DELETE Animals WHERE id={id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Animal object deletion error: {exception.Message}");
            }
        }

        public async override Task DeleteAsync(int id)
        {
            try
            {
                Logger.Info("Request to detete an animal object from the database");
                await SendRequestNonQueryAsync($"DELETE Animals WHERE id={id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Animal object deletion error: {exception.Message}");
            }
        }

        public override Animals Get(int id)
        {
            try
            {
                Logger.Info("Request to get an animal object from the database");
                var dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting animal object: {exception.Message}");
                throw new Exception(exception.Message);
            }
        }

        public async override Task<Animals> GetAsync(int id)
        {
            try
            {
                Logger.Info("Request to get an animal object from the database");
                var dataReader = await SendRequestReaderAsync<Animals>($"SELECT * FROM Animals WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting animal object: {exception.Message}");
                throw new Exception(exception.Message);
            }
        }

        public override IEnumerable<Animals> GetList()
        {
            try
            {
                Logger.Info("Request to get animal objects from the database");
                var dataReader = SendRequestReader<Animals>($"SELECT * FROM Animals");
                return dataReader;
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting a list of animals: {exception.Message}");
                throw new Exception($"Error getting a list of animals:{exception.Message}");
            }
        }

        public async override Task<IEnumerable<Animals>> GetListAsync()
        {
            try
            {
                Logger.Info("Request to get animal objects from the database");
                var dataReader = await SendRequestReaderAsync<Animals>($"SELECT * FROM Animals");
                return dataReader;
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting a list of animals: {exception.Message}");
                throw new Exception($"Error getting a list of animals:{exception.Message}");
            }
        }

        public override void Update(Animals item)
        {
            try
            {
                Logger.Info("Request to change an animal object from the database");
                SendRequestNonQuery($"Update Animals SET name = '{item.Name}', type = '{item.Type}', speed = {item.Speed} WHERE id = {item.Id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Animal object change error: {exception.Message}");
            }
        }

        public async override Task UpdateAsync(Animals item)
        {
            try
            {
                Logger.Info("Request to change an animal object from the database");
                await SendRequestNonQueryAsync($"Update Animals SET name = '{item.Name}', type = '{item.Type}', speed = {item.Speed} WHERE id = {item.Id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Animal object change error: {exception.Message}");
            }
        }
    }
}
