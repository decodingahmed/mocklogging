namespace MockLogging.Tests
{
    public class GenericMockLoggerTests : BaseMockLoggerTests
    {
        public GenericMockLoggerTests() : base(new MockLogger<ITestService>())
        {
        }
    }
}
