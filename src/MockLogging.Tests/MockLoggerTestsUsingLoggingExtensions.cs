using Microsoft.Extensions.Logging;
using MockLogging.Tests.Extensions;

namespace MockLogging.Tests
{
    public class MockLoggerTestsUsingLoggingExtensions
    {
        private readonly MockLogger logger = new MockLogger();

        #region LogTrace tests

        [Fact]
        public void LogTrace_ShouldRecordTraceAndMessage()
        {
            // Act
            logger.LogTrace("my trace message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Trace, "my trace message");
        }

        [Fact]
        public void LogTraceWithFormattedMessage_ShouldRecordTraceAndMessage()
        {
            // Act
            logger.LogTrace("my trace message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Trace, "my trace message with value");
        }

        [Fact]
        public void LogTraceWithFormattedMessageAndEventId_ShouldRecordTraceAndMessage()
        {
            // Act
            logger.LogTrace(100, "my trace message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Trace, "my trace message with value", new EventId(100));
        }

        [Fact]
        public void LogTraceWithFormattedMessageAndException_ShouldRecordTraceAndMessage()
        {
            // Act
            logger.LogTrace(new Exception("an error"), "my trace message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Trace, "my trace message with value", new Exception("an error"));
        }

        #endregion

        #region LogDebug tests

        [Fact]
        public void LogDebug_ShouldRecordDebugAndMessage()
        {
            // Act
            logger.LogDebug("my debug message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Debug, "my debug message");
        }

        [Fact]
        public void LogDebugWithFormattedMessage_ShouldRecordDebugAndMessage()
        {
            // Act
            logger.LogDebug("my debug message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Debug, "my debug message with value");
        }

        [Fact]
        public void LogDebugWithFormattedMessageAndEventId_ShouldRecordDebugAndMessage()
        {
            // Act
            logger.LogDebug(100, "my debug message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Debug, "my debug message with value", new EventId(100));
        }

        [Fact]
        public void LogDebugWithFormattedMessageAndException_ShouldRecordDebugAndMessage()
        {
            // Act
            logger.LogDebug(new Exception("an error"), "my debug message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Debug, "my debug message with value", new Exception("an error"));
        }

        #endregion

        #region LogInformation tests

        [Fact]
        public void LogInformation_ShouldRecordInformationAndMessage()
        {
            // Act
            logger.LogInformation("my informative message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Information, "my informative message");
        }

        [Fact]
        public void LogInformationWithFormattedMessage_ShouldRecordInformationAndMessage()
        {
            // Act
            logger.LogInformation("my informative message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Information, "my informative message with value");
        }

        [Fact]
        public void LogInformationWithFormattedMessageAndEventId_ShouldRecordInformationAndMessage()
        {
            // Act
            logger.LogInformation(100, "my informative message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Information, "my informative message with value", new EventId(100));
        }

        [Fact]
        public void LogInformationWithFormattedMessageAndException_ShouldRecordInformationAndMessage()
        {
            // Act
            logger.LogInformation(new Exception("an error"), "my informative message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Information, "my informative message with value", new Exception("an error"));
        }

        #endregion

        #region LogWarning tests

        [Fact]
        public void LogWarning_ShouldRecordWarningAndMessage()
        {
            // Act
            logger.LogWarning("my warning message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Warning, "my warning message");
        }

        [Fact]
        public void LogWarningWithFormattedMessage_ShouldRecordWarningAndMessage()
        {
            // Act
            logger.LogWarning("my warning message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Warning, "my warning message with value");
        }

        [Fact]
        public void LogWarningWithFormattedMessageAndEventId_ShouldRecordWarningAndMessage()
        {
            // Act
            logger.LogWarning(100, "my warning message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Warning, "my warning message with value", new EventId(100));
        }

        [Fact]
        public void LogWarningWithFormattedMessageAndException_ShouldRecordWarningAndMessage()
        {
            // Act
            logger.LogWarning(new Exception("an error"), "my warning message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Warning, "my warning message with value", new Exception("an error"));
        }

        #endregion

        #region LogError tests

        [Fact]
        public void LogError_ShouldRecordErrorAndMessage()
        {
            // Act
            logger.LogError("my error message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Error, "my error message");
        }

        [Fact]
        public void LogErrorWithFormattedMessage_ShouldRecordErrorAndMessage()
        {
            // Act
            logger.LogError("my error message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Error, "my error message with value");
        }

        [Fact]
        public void LogErrorWithFormattedMessageAndEventId_ShouldRecordErrorAndMessage()
        {
            // Act
            logger.LogError(100, "my error message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Error, "my error message with value", new EventId(100));
        }

        [Fact]
        public void LogErrorWithFormattedMessageAndException_ShouldRecordErrorAndMessage()
        {
            // Act
            logger.LogError(new Exception("an error"), "my error message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Error, "my error message with value", new Exception("an error"));
        }

        #endregion

        #region LogCritical tests

        [Fact]
        public void LogCritical_ShouldRecordCriticalAndMessage()
        {
            // Act
            logger.LogCritical("my critical message");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Critical, "my critical message");
        }

        [Fact]
        public void LogCriticalWithFormattedMessage_ShouldRecordCriticalAndMessage()
        {
            // Act
            logger.LogCritical("my critical message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Critical, "my critical message with value");
        }

        [Fact]
        public void LogCriticalWithFormattedMessageAndEventId_ShouldRecordCriticalAndMessage()
        {
            // Act
            logger.LogCritical(100, "my critical message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Critical, "my critical message with value", new EventId(100));
        }

        [Fact]
        public void LogCriticalWithFormattedMessageAndException_ShouldRecordCriticalAndMessage()
        {
            // Act
            logger.LogCritical(new Exception("an critical"), "my critical message with {0}", "value");
            var entry = logger.VerifyLogEntry();

            // Assert
            entry.AssertExpectedValues(LogLevel.Critical, "my critical message with value", new Exception("an critical"));
        }

        #endregion

        //[Fact]
        //public void LogInformation_ShouldRecordInformationAndMessage()
        //{
        //    // Act
        //    logger.LogTrace("my trace message");
        //    var entry = logger.VerifyThatLogEntry();

        //    // Assert
        //    entry.AssertExpectedValues(LogLevel.Trace, new EventId(0), "my informative message");
        //}
    }
}
