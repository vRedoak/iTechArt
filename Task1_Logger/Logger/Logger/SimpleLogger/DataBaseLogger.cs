using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Logger.SimpleLogger
{
    public class DataBaseLogger : ILogger
    {
        private readonly string _connectionString;

        private DataBaseLogger(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static DataBaseLogger _instance;

        public DataBaseLogger Create(string connectionString)
        {
            _instance = new DataBaseLogger(connectionString);
            return _instance;
        }

        public static DataBaseLogger GetInstance()
        {
            if (_instance == null)
            {
                throw new Exception("Object not created.");
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
