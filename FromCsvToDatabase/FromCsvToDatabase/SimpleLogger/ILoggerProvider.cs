namespace FromCsvToDatabase.SimpleLogger
{
    public interface ILoggerProvider
    {
        ILogger GetLogger(LoggerType loggerType);
    }
}
