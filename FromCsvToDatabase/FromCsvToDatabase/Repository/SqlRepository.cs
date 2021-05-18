using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace FromCsvToDatabase.Repository
{
    public abstract class SqlRepository<T> : IRepository<T>
    {
        protected SqlConnection _sqlConnection;
        private SqlDataReader _dataReader;
        protected Logger _logger = new Logger(new LoggerProvider(), LoggerType.File);
        private bool _disposedValue = false;

        public SqlRepository(SqlConnection sqlConnection) => _sqlConnection = sqlConnection;

        public abstract void Create(T item);

        public async void CreateAsync(T item) => await Task.Factory.StartNew(() => Create(item));

        public abstract void Delete(int id);

        public async void DeleteAsync(int id) => await Task.Factory.StartNew(() => Delete(id));

        public abstract T Get(int id);

        public async Task<T> GetAsync(int id) => await Task.Factory.StartNew(() => Get(id));

        public abstract IEnumerable<T> GetList();

        public async Task<IEnumerable<T>> GetListAsync() => await Task.Factory.StartNew(() => GetList());

        public abstract void Update(T item);

        public async void UpdateAsync(T item) => await Task.Factory.StartNew(() => Update(item));

        protected void SendRequestNonQuery(string command)
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, _sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                _logger.Error($"Error while executing the request: {exception.Message}");
            }
        }

        protected List<TRecords> SendRequestReader<TRecords>(string command) where TRecords : new()
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, _sqlConnection);
                _dataReader = sqlCommand.ExecuteReader();
                var result = new List<TRecords>();
                if (_dataReader.HasRows)
                {
                    var type = (new TRecords()).GetType();
                    FieldInfo[] fields = type.GetFields();
                    while (_dataReader.Read())
                    {
                        TRecords records = new TRecords();
                        var properties = typeof(TRecords).GetFields(BindingFlags.Public | BindingFlags.Instance);
                        for (int i = 0; i < properties.Length; i++)
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
            catch (Exception exception)
            {
                _logger.Error($"Error while executing the request: {exception.Message}");
                return null;
            }
            finally
            {
                _dataReader.Close();
            }
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
