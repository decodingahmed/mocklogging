namespace MockLogging.Tests
{
    public class MockLoggerTests : BaseMockLoggerTests
    {
        public MockLoggerTests() : base(new MockLogger())
        {
        }
    }
}
