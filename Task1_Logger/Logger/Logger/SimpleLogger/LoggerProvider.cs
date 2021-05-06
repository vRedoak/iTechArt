using Logger.SimpleLogger;

namespace Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        public ILogger GetLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.Console:
                    return new ConsoleLogger();

                case LoggerType.File:
                    return new FileLogger(Properties.Settings.Default.filePath);

                case LoggerType.DataBase:
                    return new DataBaseLogger(Properties.Settings.Default.dataBaseConnection);

                default: return new ConsoleLogger();
            }
        }
    }
}
