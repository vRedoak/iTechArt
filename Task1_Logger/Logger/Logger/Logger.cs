using MyLogger.SimpleLogger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLogger
{

    public enum LoggerType
    {
        Console,
        File,
        DataBase
    }

    public class Logger : ILogger
    {
        private readonly List<ILogger> _loggersList = new List<ILogger>();

        public Logger(ILoggerProvider loggerProvider, params LoggerType[] loggerType)
        {
            if (loggerType.Length != 0)
            {
                _loggersList.AddRange(loggerType.Select(loggerProvider.GetLogger));
            }
            else
            {
                _loggersList.Add(loggerProvider.GetLogger(LoggerType.Console));
            }
        }

        public void Error(string message)
        {
            _loggersList.ForEach(x => x.Error(message));
        }

        public void Error(Exception ex)
        {
            _loggersList.ForEach(x => x.Error(ex));
        }

        public void Info(string message)
        {
            _loggersList.ForEach(x => x.Info(message));
        }

        public void Warning(string message)
        {
            _loggersList.ForEach(x => x.Warning(message));
        }
    }
}
