using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Logger.SimpleLogger
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private const string _defaultFilePath = "../../../logs.txt";

        private FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        private static FileLogger _instance;

        public static FileLogger GetInstance(string filePath = _defaultFilePath)
        {
            if (_instance == null)
            {
                _instance = new FileLogger(filePath);
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
                using var streamWriter = new StreamWriter(_filePath, true, System.Text.Encoding.Default);
                streamWriter.WriteLine($"{logLevel}: {message} Time: {DateTime.Now}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"File write error {exception.Message} Time: {DateTime.Now}");
            }
        }
    }
}
