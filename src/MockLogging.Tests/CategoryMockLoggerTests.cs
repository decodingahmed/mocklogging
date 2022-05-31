namespace MockLogging.Tests
{
    public class CategoryMockLoggerTests : BaseMockLoggerTests
    {
        public CategoryMockLoggerTests() : base(new MockLogger<ITestService>())
        {
        }
    }
}
