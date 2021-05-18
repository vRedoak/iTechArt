using System;
using System.Data.SqlClient;

namespace FromCsvToDatabase.Repository
{
    public class UnitOfWork: IDisposable
    {
        private SqlAnimalsRepository _sqlAnimalsRepository;
        private SqlWorkersRepository _sqlWorkersRepository;
        private readonly SqlConnection _sqlConnection;
        private bool _disposedValue;

        public UnitOfWork(string connectionString)
        {
            try
            {
                _sqlConnection = new SqlConnection(connectionString);
                _sqlConnection.Open();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public SqlAnimalsRepository Animals
        {
            get
            {
                if (_sqlAnimalsRepository == null)
                    _sqlAnimalsRepository = new SqlAnimalsRepository(_sqlConnection);
                return _sqlAnimalsRepository;
            }
        }

        public SqlWorkersRepository Workers
        {
            get
            {
                if (_sqlWorkersRepository == null)
                    _sqlWorkersRepository = new SqlWorkersRepository(_sqlConnection);
                return _sqlWorkersRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _sqlConnection.Dispose();
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
