using F0.Talks.SourceGenerators;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

internal partial class Program
{
    private static ILogger CreateLogger(LogLevel minLevel)
    {
        ConsoleLoggerProvider provider = new(ConsoleOptionsMonitor.Instance);

        LoggerFilterOptions options = new()
        {
            MinLevel = minLevel,
        };
        ILoggerFactory factory = new LoggerFactory(new[] { provider }, options);

        ILogger logger = factory.CreateLogger("Console");
        return logger;
    }
}
