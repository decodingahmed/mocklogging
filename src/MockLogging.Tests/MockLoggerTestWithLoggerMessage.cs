using Microsoft.Extensions.Logging;
using MockLogging.Tests.Extensions;

namespace MockLogging.Tests
{
    public class MockLoggerTestWithLoggerMessage
    {
        private static readonly Action<ILogger, string, Exception?> SingleValueInformationLog =
            LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(1000, "OneValueInfoLog"),
                "Informative message with {One}.");

        private static readonly Action<ILogger, string, string, Exception?> TwoValueDebugLog =
            LoggerMessage.Define<string, string>(
                LogLevel.Debug,
                new EventId(2000, "TwoValueInfoLog"),
                "Debug message with {First} and {Second} values.");

        private static readonly Action<ILogger, Exception?> ErrorLog =
            LoggerMessage.Define(
                LogLevel.Error,
                new EventId(3000, "ErrorLog"),
                "Erroneous message.");

        private static readonly Action<ILogger, string, Exception?> SingleValueCriticalLog =
            LoggerMessage.Define<string>(
                LogLevel.Critical,
                new EventId(4000, "ErrorLog"),
                "Critical message with {One}.");

        private readonly MockLogger logger = new MockLogger();

        [Fact]
        public void LoggerShouldLog_SingleValueInformationLogCorrectly()
        {
            // Act
            SingleValueInformationLog(logger, "some information", null);
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Information, "Informative message with some information.", 1000);
        }

        [Fact]
        public void LoggerShouldLog_TwoValueDebugLogCorrectly()
        {
            // Act
            TwoValueDebugLog(logger, "foo", "bar", null);
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Debug, "Debug message with foo and bar values.", 2000);
        }

        [Fact]
        public void LoggerShouldLog_SingleValueCriticalLogCorrectly()
        {
            // Act
            SingleValueCriticalLog(logger, "important information", new Exception("something went wrong"));
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Critical, "Critical message with important information.", 4000, new Exception("something went wrong"));
        }

        [Fact]
        public void LoggerShouldLog_ErrorLogCorrectly()
        {
            // Act
            ErrorLog(logger, new KeyNotFoundException("a key was not found"));
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Error, "Erroneous message.", 3000, new KeyNotFoundException("a key was not found"));
        }
    }
}
