using FluentAssertions;
using Microsoft.Extensions.Logging;
using MockLogging.Tests.Extensions;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace MockLogging.Tests
{
    public abstract class BaseMockLoggerTests
    {
        private readonly MockLogger logger;

        protected BaseMockLoggerTests(MockLogger logger)
        {
            this.logger = logger;
        }

        [Fact]
        public void VerifyThatLogEntry_ShouldThrow_WhenLogsAreEmpty()
        {
            Action action = () => logger.VerifyThatLogEntry();
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void VerifyNoOtherLogEntries_ShouldNotThrow_WhenLogsAreEmpty()
        {
            logger.VerifyNoOtherLogEntries();
        }

        [Fact]
        public void VerifyNoOtherLogEntries_ShouldThrow_WhenLogsAreNotEmpty()
        {
            // Arrange
            logger.LogInformation("test information");
            logger.LogInformation("test information");
            Action action = () => logger.VerifyNoOtherLogEntries();

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("There are 2 outstanding log entries.");
        }

        [Fact]
        public void VerifyThatLogEntry_ShouldRecordMultipleEntries_WhenLogIsCalledMultipleTimes()
        {
            // Arrange and Act
            logger.Log(LogLevel.Trace, 100, new { Value = "tracing" }, null, (state, exception) => $"I am {state.Value}");
            logger.Log(LogLevel.Debug, 200, new { Value = "debugging" }, null, (state, exception) => $"I am {state.Value}");
            logger.Log(LogLevel.Information, 300, new { Value = "informing" }, null, (state, exception) => $"I am {state.Value}");
            logger.Log(LogLevel.Warning, 400, new { Value = "warning" }, null, (state, exception) => $"I am {state.Value}");
            logger.Log(LogLevel.Error, 500, new { Value = "erroring" }, new ArgumentException("invalid param value", "param"), (state, exception) => $"I am {state.Value}");
            logger.Log(LogLevel.Critical, 600, new { Value = "critically erroring" }, null, (state, exception) => $"I am {state.Value}");

            var first = logger.VerifyThatLogEntry();
            var second = logger.VerifyThatLogEntry();
            var third = logger.VerifyThatLogEntry();
            var fourth = logger.VerifyThatLogEntry();
            var fifth = logger.VerifyThatLogEntry();
            var sixth = logger.VerifyThatLogEntry();

            // Assert
            first.AssertExpectedValues(
                LogLevel.Trace,
                "I am tracing",
                100);

            second.AssertExpectedValues(
                LogLevel.Debug,
                "I am debugging",
                200);

            third.AssertExpectedValues(
                LogLevel.Information,
                "I am informing",
                300);

            fourth.AssertExpectedValues(
                LogLevel.Warning,
                "I am warning",
                400);

            fifth.AssertExpectedValues(
                LogLevel.Error,
                "I am erroring",
                500,
                new ArgumentException("invalid param value", "param"));

            sixth.AssertExpectedValues(
                LogLevel.Critical,
                "I am critically erroring",
                600);
        }

        [Theory]
        [InlineData(LogLevel.Critical, LogLevel.Critical)]
        [InlineData(LogLevel.Trace, LogLevel.Trace)]
        [InlineData(LogLevel.Information, LogLevel.Information)]
        [InlineData(LogLevel.Warning, LogLevel.Information)]
        public void IsEnabled_ShouldReturnTrue_WhenGivenLogLevelIsLessThanEqualToMinimumLogLevel(LogLevel logLevel, LogLevel minimumLogLevel)
        {
            logger.MinimumLogLevel = minimumLogLevel;

            logger.IsEnabled(logLevel).Should().BeTrue();
        }

        [Theory]
        [InlineData(LogLevel.None, true)]
        [InlineData(LogLevel.Critical, false)]
        public void IsEnabled_ShouldReturnExpectedResult_WhenMinimumLogLevelIsNone(LogLevel logLevel, bool expectedResult)
        {
            logger.MinimumLogLevel = LogLevel.None;

            logger.IsEnabled(logLevel).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(LogLevel.Trace)]
        [InlineData(LogLevel.Debug)]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.Critical)]
        public void IsEnabled_ShouldAlwaysReturnFalse_WhenMinimumLogLevelIsNone(LogLevel logLevel)
        {
            logger.MinimumLogLevel = LogLevel.None;

            logger.IsEnabled(logLevel).Should().BeFalse();
        }
    }
}