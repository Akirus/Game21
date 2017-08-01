using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;

namespace Game21.Utils
{
    public static class LoggerExtensions
    {
        public static void LogError(this ILogger logger, Exception e)
        {
            logger.Log<object>(LogLevel.Error, 0, 
                new FormattedLogValues("exception occured: {0}", e.ToString()), 
                e, 
                (o, exception) => o.ToString());
        }
        
    }
}