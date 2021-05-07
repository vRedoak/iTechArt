namespace MyLogger.SimpleLogger
{
    public interface ILoggerProvider
    {
        ILogger GetLogger(LoggerType loggerType);
    }
}
