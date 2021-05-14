using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace FromCsvToDatabase.Repository
{
    public abstract class SqlRepository<T> : IRepository<T> where T : ContextObject
    {
        protected readonly string _connectionString;
        protected SqlConnection _sqlConnection;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        public abstract void Create(T item);

        public abstract void Delete(int id);

        public abstract T Get(int id);

        public abstract IEnumerable<T> GetList();

        public abstract void Update(T item);

        protected void SendRequestNonQuery(string command)
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, _sqlConnection);
                var dataReader = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"DataBase write error: {exception.Message}  Time: { DateTime.Now }");
            }
        }

        protected List<TRecords> SendRequestReader<TRecords>(string command) where TRecords : new()
        {
            try
            {
                using var sqlCommand = new SqlCommand(command, _sqlConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                List<TRecords> result = new List<TRecords>();
                if (dr.HasRows)
                {
                    var type = (new TRecords()).GetType();
                    FieldInfo[] fields = type.GetFields();
                    while (dr.Read())
                    {
                        TRecords records = new TRecords();
                        var properties = typeof(TRecords).GetFields(BindingFlags.Public | BindingFlags.Instance);
                        for (int i = 0; i < properties.Length; i++)
                        {
                            if (dr[properties[i].Name] != null)
                            {
                                properties[i].SetValue(records, dr.GetValue(i)); 
                            }
                        }
                        result.Add(records);
                    }
                }
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"DataBase write error: {exception.Message}  Time: { DateTime.Now }");
                return null;
            }
        }



        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _sqlConnection.Close();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
