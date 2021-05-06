using System;
using Microsoft.Extensions.Logging;

namespace Logger.SimpleLogger
{
    public class ConsoleLogger : ILogger
    {
        private ConsoleLogger() { }

        private static ConsoleLogger _instance;

        public static ConsoleLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleLogger();
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

        public void Info(string message)
        {
            Log(LogLevel.Information, message);
        }

        public void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        private static void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{logLevel}: {message} Time: {DateTime.Now}");
        }
    }
}