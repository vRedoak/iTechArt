using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace MyLogger.SimpleLogger
{
    public interface ILoggerProvider
    {
        ILogger GetLogger(LoggerType loggerType);
    }
}
