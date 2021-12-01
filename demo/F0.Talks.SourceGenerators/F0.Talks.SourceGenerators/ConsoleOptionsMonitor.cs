using F0.Primitives;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace F0.Talks.SourceGenerators;

internal sealed class ConsoleOptionsMonitor : IOptionsMonitor<ConsoleLoggerOptions>
{
    public static IOptionsMonitor<ConsoleLoggerOptions> Instance { get; } = new ConsoleOptionsMonitor();

    private readonly ConsoleLoggerOptions options = new();

    private ConsoleOptionsMonitor()
    {
    }

    public ConsoleLoggerOptions CurrentValue => options;

    public ConsoleLoggerOptions Get(string name)
    {
        return options;
    }

    public IDisposable OnChange(Action<ConsoleLoggerOptions, string> listener)
    {
        return NullDisposable.Instance;
    }
}