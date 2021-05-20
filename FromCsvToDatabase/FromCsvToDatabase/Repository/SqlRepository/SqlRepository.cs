using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    public abstract class SqlRepository<T> : IRepository<T>
    {
        protected SqlConnection SqlConnection;
        private SqlDataReader _dataReader;
        protected Logger Logger = new Logger(new LoggerProvider(), LoggerType.File);
        private bool _disposedValue = false;

        protected SqlRepository(SqlConnection sqlConnection) => SqlConnection = sqlConnection;

        public abstract void Create(T item);

        public abstract void Delete(int id);

        public abstract T Get(int id);

        public abstract IEnumerable<T> GetList();

        public abstract void Update(T item);

        public abstract Task<T> GetAsync(int id);

        public abstract Task<IEnumerable<T>> GetListAsync();

        public abstract Task CreateAsync(T item);

        public abstract Task UpdateAsync(T item);

        public abstract Task DeleteAsync(int id);

        protected void SendRequestNonQuery(string command)
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, SqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Logger.Error($"Error while executing the request: {exception.Message}");
            }
        }

        protected async Task SendRequestNonQueryAsync(string command)
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, SqlConnection);
                await sqlCommand.ExecuteNonQueryAsync();
                return;
            }
            catch (Exception exception)
            {
                Logger.Error($"Error while executing the request: {exception.Message}");
            }
        }

        protected List<TRecords> SendRequestReader<TRecords>(string command) where TRecords : new()
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, SqlConnection);
                _dataReader = sqlCommand.ExecuteReader();
                return CreateListOfObject<TRecords>();
            }
            catch (Exception exception)
            {
                Logger.Error($"Error while executing the request: {exception.Message}");
                throw new Exception(exception.Message);
            }
            finally
            {
                _dataReader.Close();
            }
        }

        protected async Task<List<TRecords>> SendRequestReaderAsync<TRecords>(string command) where TRecords : new()
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, SqlConnection);
                _dataReader = await sqlCommand.ExecuteReaderAsync();
                return CreateListOfObject<TRecords>();
            }
            catch(Exception exception)
            {
                Logger.Error($"Error while executing the request: {exception.Message}");
                throw new Exception(exception.Message);
            }
            finally
            {
                _dataReader.Close();
            }
        }

        private List<TRecords> CreateListOfObject<TRecords>() where TRecords : new()
        {
            var result = new List<TRecords>();
            if (_dataReader.HasRows)
            {
                while (_dataReader.Read())
                {
                    var records = new TRecords();
                    var properties = typeof(TRecords).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                    for (var i = 0; i < properties.Length; i++)
                    {
                        if (_dataReader[properties[i].Name] != null)
                        {
                            properties[i].SetValue(records, _dataReader.GetValue(i));
                        }
                    }
                    result.Add(records);
                }
            }
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dataReader.DisposeAsync();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
