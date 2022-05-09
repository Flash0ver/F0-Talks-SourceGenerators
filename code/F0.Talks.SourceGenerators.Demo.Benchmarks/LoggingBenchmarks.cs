using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace F0.Talks.SourceGenerators.Demo.Benchmarks;

[MemoryDiagnoser]
public class LoggingBenchmarks
{
    private readonly string name = "NDC London";
    private readonly int number = 2022;

    private readonly ILogger logger;

    public LoggingBenchmarks()
    {
        logger = NullLogger.Instance;
    }

    [Benchmark]
    public object? LoggerExtensions()
    {
        logger.LogInformation("Hello, {name} {number}!", name, number);

        return null;
    }

    [Benchmark]
    public object? LoggerMessageGenerator()
    {
        logger.Hello(name, number);

        return null;
    }
}

public static partial class Log
{
    [LoggerMessage(240, LogLevel.Information, "Hello, {name} {number}!")]
    public static partial void Hello(this ILogger logger, string name, int number);
}
