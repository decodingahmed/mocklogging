using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace MockLogging.Tests.Extensions
{
    internal static class MockLogEntryAssertionExtensions
    {
        public static void AssertExpectedValues(this MockLogEntry entry,
            LogLevel logLevel,
            string message)
        {
            AssertExpectedValues(entry, logLevel, message, 0, null);
        }
        public static void AssertExpectedValues(this MockLogEntry entry,
            LogLevel logLevel,
            string message,
            EventId eventId)
        {
            AssertExpectedValues(entry, logLevel, message, eventId, null);
        }

        public static void AssertExpectedValues(this MockLogEntry entry,
            LogLevel logLevel,
            string message,
            Exception exception)
        {
            AssertExpectedValues(entry, logLevel, message, 0, exception);
        }

        public static void AssertExpectedValues(this MockLogEntry entry,
            LogLevel logLevel,
            string message,
            EventId eventId,
            Exception? exception)
        {
            entry.LogLevel.Should().Be(logLevel);
            entry.EventId.Should().Be(eventId);
            entry.Exception.Should().BeEquivalentTo(exception);
            entry.Message.Should().Be(message);
        }
    }
}
