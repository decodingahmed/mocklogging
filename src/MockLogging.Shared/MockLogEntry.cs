using Microsoft.Extensions.Logging;
using System;

namespace MockLogging
{
    public class MockLogEntry
    {
        public LogLevel LogLevel { get; internal set; }
        public EventId EventId { get; internal set; }
        public Exception Exception { get; internal set; }
        public string Message { get; internal set; }
    }
}
