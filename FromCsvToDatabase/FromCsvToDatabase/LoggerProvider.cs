using FromCsvToDatabase.SimpleLogger;

namespace FromCsvToDatabase
{
    public class LoggerProvider : ILoggerProvider
    {
        public ILogger GetLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.Console:
                    return ConsoleLogger.GetInstance();

                case LoggerType.File:
                    return FileLogger.GetInstance(Properties.Settings.Default.filePath);

                case LoggerType.DataBase:
                    return DataBaseLogger.GetInstance(Properties.Settings.Default.dataBaseConnection);

                default: return ConsoleLogger.GetInstance();
            }
        }
    }
}
