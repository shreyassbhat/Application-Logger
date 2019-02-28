using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Logging;

namespace ApplicationLogger
{
    public static class Log4netExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        public static void Critical(this ILog log, object message, Exception exception)
            => log.Logger.Log(null, log4net.Core.Level.Critical, message, exception);

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
        {
            factory.AddProvider(new Log4NetProvider("log4net.config"));
            return factory;
        }
    }
}
