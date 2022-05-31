using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace MockLogging
{
    public class MockLogger<T> : MockLogger, ILogger<T>
    {
    }

    public class MockLogger : ILogger
    {
        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Trace;

        #region ILogger implementation

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= MinimumLogLevel;
        }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
