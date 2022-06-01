using Microsoft.Extensions.Logging;
using System;

namespace MockLogging
{
    public static class MockLogEntryVerifierExtensions
    {
        public static MockLogEntry HasLogLevel(this MockLogEntry entry, LogLevel logLevel)
        {
            if (entry.LogLevel != logLevel)
                throw new InvalidOperationException($"Expected LogLevel '{logLevel}' but found '{entry.LogLevel}'.");

            return entry;
        }

        public static MockLogEntry HasEventId(this MockLogEntry entry, EventId eventId)
        {
            if (entry.EventId != eventId)
                throw new InvalidOperationException($"Expected EventId '{eventId}' but found '{entry.EventId}'.");

            return entry;
        }

        public static MockLogEntry HasExceptionOfType<TException>(this MockLogEntry entry) where TException : Exception
        {
            if (entry.Exception is TException)
                throw new InvalidOperationException($"Expected Exception to be typeof '{typeof(TException)}' but found '{entry.Exception.GetType().Name}'.");

            return entry;
        }

        public static MockLogEntry HasMessage(this MockLogEntry entry, string message)
        {
            if (entry.Message != message)
                throw new InvalidOperationException($"Expected LogLevel '{message}' but found '{entry.Message}'.");

            return entry;
        }
    }
}
