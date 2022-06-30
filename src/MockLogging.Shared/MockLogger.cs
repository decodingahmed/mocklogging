using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MockLogging
{
    public class MockLogger<T> : MockLogger, ILogger<T>
    {
    }

    public class MockLogger : ILogger
    {
        private readonly ConcurrentQueue<MockLogEntry> entries = new ConcurrentQueue<MockLogEntry>();

        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Trace;

        public MockLogEntry VerifyLogEntry()
        {
            if (entries.TryDequeue(out var entry))
                return entry;

            throw new InvalidOperationException("No more log entries to verify");
        }

        public void VerifyNoOtherLogEntries()
        {
            if (entries.Any())
                throw new InvalidOperationException($"There are {entries.Count} outstanding log entries.");
        }

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
            entries.Enqueue(new MockLogEntry
            {
                LogLevel = logLevel,
                EventId = eventId,
                Exception = exception,
                Message = formatter(state, exception)
            });
        }

        #endregion
    }
}
