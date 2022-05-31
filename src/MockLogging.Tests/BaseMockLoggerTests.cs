using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace MockLogging.Tests
{
    public abstract class BaseMockLoggerTests
    {
        private readonly MockLogger logger;

        protected BaseMockLoggerTests(MockLogger logger)
        {
            this.logger = logger;
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