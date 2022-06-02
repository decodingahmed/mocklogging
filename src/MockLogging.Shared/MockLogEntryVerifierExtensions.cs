using Microsoft.Extensions.Logging;
using System;

namespace MockLogging
{
    public static class MockLogEntryVerifierExtensions
    {
        public static MockLogEntry HasLogLevel(this MockLogEntry entry, LogLevel expectedLogLevel)
        {
            if (entry.LogLevel != expectedLogLevel)
                throw new InvalidOperationException($"Expected LogLevel '{expectedLogLevel}' but found '{entry.LogLevel}'.");

            return entry;
        }

        public static MockLogEntry HasEventId(this MockLogEntry entry, EventId expectedEventId)
        {
            if (entry.EventId != expectedEventId)
                throw new InvalidOperationException($"Expected EventId '{expectedEventId}' but found '{entry.EventId}'.");

            return entry;
        }

        public static MockLogEntry HasExceptionOfType<TExpectedException>(this MockLogEntry entry) where TExpectedException : Exception
        {
            if (!(entry.Exception.GetType() == typeof(TExpectedException)))
                throw new InvalidOperationException($"Expected Exception to be typeof '{typeof(TExpectedException)}' but found '{entry.Exception.GetType().FullName}'.");

            return entry;
        }

        public static MockLogEntry HasMessage(this MockLogEntry entry, string expectedMessage)
        {
            if (entry.Message != expectedMessage)
                throw new InvalidOperationException($"Expected Message '{expectedMessage}' but found '{entry.Message}'.");

            return entry;
        }
    }
}
