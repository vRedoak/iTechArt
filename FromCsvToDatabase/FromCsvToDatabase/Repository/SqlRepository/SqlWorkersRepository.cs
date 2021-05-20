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
            try
            {
                Logger.Info("Request to add an worker object to the database");
                SendRequestNonQuery($"INSERT INTO Workers VALUES ('{item.Name}', '{item.Phone}')");
            }
            catch (Exception exception)
            {
                Logger.Error($"Error adding worker object: {exception.Message}");
            }
        }

        public async override Task CreateAsync(Workers item)
        {
            try
            {
                Logger.Info("Request to add an worker object to the database");
                await SendRequestNonQueryAsync($"INSERT INTO Workers VALUES ('{item.Name}', '{item.Phone}')");
            }
            catch (Exception exception)
            {
                Logger.Error($"Error adding worker object: {exception.Message}");
            }
        }

        public override void Delete(int id)
        {
            try
            {
                Logger.Info("Request to detete an worker object from the database");
                SendRequestNonQuery($"DELETE Workers WHERE id={id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Worker object deletion error: {exception.Message}");
            }
        }

        public async override Task DeleteAsync(int id)
        {
            try
            {
                Logger.Info("Request to detete an worker object from the database");
                await SendRequestNonQueryAsync($"DELETE Workers WHERE id={id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Worker object deletion error: {exception.Message}");
            }
        }

        public override Workers Get(int id)
        {
            try
            {
                Logger.Info("Request to get an worker object from the database");
                var dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting worker object: {exception.Message}");
                return null;
            }
        }

        public async override Task<Workers> GetAsync(int id)
        {
            try
            {
                Logger.Info("Request to get an worker object from the database");
                var dataReader = await SendRequestReaderAsync<Workers>($"SELECT * FROM Workers WHERE id = {id}");
                return dataReader[0];
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting worker object: {exception.Message}");
                return null;
            }
        }

        public override IEnumerable<Workers> GetList()
        {
            try
            {
                Logger.Info("Request to get worker objects from the database");
                var dataReader = SendRequestReader<Workers>($"SELECT * FROM Workers");
                return dataReader;
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting a list of workers: {exception.Message}");
                throw new Exception($"Error getting a list of workers:{exception.Message}");
            }
        }

        public async override Task<IEnumerable<Workers>> GetListAsync()
        {
            try
            {
                Logger.Info("Request to get worker objects from the database");
                var dataReader = await SendRequestReaderAsync<Workers>($"SELECT * FROM Workers");
                return dataReader;
            }
            catch (Exception exception)
            {
                Logger.Error($"Error getting a list of workers: {exception.Message}");
                throw new Exception($"Error getting a list of workers:{exception.Message}");
            }
        }

        public override void Update(Workers item)
        {
            try
            {
                Logger.Info("Request to change an worker object from the database");
                SendRequestNonQuery($"Update Workers SET name = '{item.Name}', phone = '{item.Phone}' WHERE id = {item.Id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Worker object change error: {exception.Message}");
            }
        }

        public async override Task UpdateAsync(Workers item)
        {
            try
            {
                Logger.Info("Request to change an worker object from the database");
                await SendRequestNonQueryAsync($"Update Workers SET name = '{item.Name}', phone = '{item.Phone}' WHERE id = {item.Id}");
            }
            catch (Exception exception)
            {
                Logger.Error($"Worker object change error: {exception.Message}");
            }
        }
    }
}
