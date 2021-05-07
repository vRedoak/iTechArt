using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace MyLogger.SimpleLogger
{
    public class DataBaseLogger : ILogger
    {
        private readonly string _connectionString;
        private const string _defaultConnectionString = @"Data Source = WSA-112-21\SQL_EXPRESS; Initial Catalog = ForLogs; Integrated Security = True; User Id = ICX\V.Krasnadubskaya";

        private DataBaseLogger(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static DataBaseLogger _instance;

        public static DataBaseLogger GetInstance(string connectionString = _defaultConnectionString)
        {
            if (_instance == null)
            {
                _instance = new DataBaseLogger(connectionString);
            }
            return _instance;
        }

        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void Error(Exception exception)
        {
            Log(LogLevel.Error, exception.Message);
        }

        public void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void Info(string message)
        {
            Log(LogLevel.Information, message);
        }

        private void Log(LogLevel logLevel, string message)
        {
            try
            {
                using var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand($"INSERT INTO Messages VALUES ('{logLevel}', '{message}  Time: { DateTime.Now }')", sqlConnection);
                var dataReader = sqlCommand.ExecuteReader();
                dataReader.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"DataBase write error: {exception.Message}  Time: { DateTime.Now }");
            }
        }
    }
}
