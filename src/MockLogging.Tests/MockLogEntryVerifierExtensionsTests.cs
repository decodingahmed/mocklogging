using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace MockLogging.Tests
{
    public class MockLogEntryVerifierExtensionsTests
    {
        private readonly MockLogEntry entry = new MockLogEntry
        {
            LogLevel = LogLevel.Warning,
            EventId = 400,
            Exception = new InvalidOperationException("something went wrong"),
            Message = "an important message"
        };

        [Fact]
        public void HasLogLevel_ShouldThrow_WhenGivenLogLevelIsNotExpected()
        {
            var expectedLogLevel = LogLevel.Debug;
            Action action = () => entry.HasLogLevel(expectedLogLevel);

            action.Should()
                .Throw<InvalidOperationException>()
                .And.Message.Should().Be($"Expected LogLevel '{expectedLogLevel}' but found '{entry.LogLevel}'.");
        }

        [Fact]
        public void HasEventId_ShouldThrow_WhenGivenEventIdIsNotExpected()
        {
            var expectedEventId = 70;
            Action action = () => entry.HasEventId(expectedEventId);

            action.Should()
                .Throw<InvalidOperationException>()
                .And.Message.Should().Be($"Expected EventId '{expectedEventId}' but found '{entry.EventId}'.");
        }

        [Fact]
        public void HasExceptionOfType_ShouldThrow_WhenGivenExceptionTypeIsNotExpected()
        {
            Action action = () => entry.HasExceptionOfType<Exception>();

            action.Should()
                .Throw<InvalidOperationException>()
                .And.Message.Should().Be($"Expected Exception to be typeof '{typeof(Exception)}' but found '{typeof(InvalidOperationException)}'.");
        }

        [Fact]
        public void HasMessage_ShouldThrow_WhenGivenMessageIsNotExpected()
        {
            var expectedMessage = "something very wrong";
            Action action = () => entry.HasMessage(expectedMessage);

            action.Should()
                .Throw<InvalidOperationException>()
                .And.Message.Should().Be($"Expected Message '{expectedMessage}' but found '{entry.Message}'.");
        }

        [Fact]
        public void HasLogLevel_ShouldReturnTheGivenObject_WhenGivenLogLevelIsExpected()
        {
            Func<MockLogEntry> func = () => entry.HasLogLevel(LogLevel.Warning);

            func.Should().NotThrow()
                .And.Subject()
                .Should().BeSameAs(entry);
        }

        [Fact]
        public void HasEventId_ShouldReturnTheGivenObject_WhenGivenEventIdIsExpected()
        {
            Func<MockLogEntry> func = () => entry.HasEventId(400);

            func.Should().NotThrow()
                .And.Subject()
                .Should().BeSameAs(entry);
        }

        [Fact]
        public void HasException_ShouldReturnTheGivenObject_WhenGivenExceptionIsOfExpectedType()
        {
            Func<MockLogEntry> func = () => entry.HasExceptionOfType<InvalidOperationException>();

            func.Should().NotThrow()
                .And.Subject()
                .Should().BeSameAs(entry);
        }

        [Fact]
        public void HasMessage_ShouldReturnTheGivenObject_WhenGivenMessageIsExpected()
        {
            Func<MockLogEntry> func = () => entry.HasMessage("an important message");

            func.Should().NotThrow()
                .And.Subject()
                .Should().BeSameAs(entry);
        }
    }
}
