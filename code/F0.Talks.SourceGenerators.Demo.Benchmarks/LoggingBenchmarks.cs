using BenchmarkDotNet.Attributes;
using F0.Generated;
using F0.Primitives;
using Microsoft.Extensions.Logging;

namespace F0.Talks.SourceGenerators.Demo.Benchmarks;

/// <summary>
/// <see href="https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator">Compile-time logging source generation</see>
/// <seealso href="https://learn.microsoft.com/dotnet/core/extensions/high-performance-logging">High-performance logging in .NET</seealso>
/// <seealso href="https://learn.microsoft.com/aspnet/core/fundamentals/logging/loggermessage">High-performance logging with LoggerMessage in ASP.NET Core</seealso>
/// </summary>
[MemoryDiagnoser]
public class LoggingBenchmarks
{
    private readonly string name = "NDC London";
    private readonly int number = 2023;

    [ParamsSource(nameof(Loggers))]
    public ILogger Logger { get; set; } = null!;

    public static IEnumerable<ILogger> Loggers()
    {
        return new[]
        {
            new MyLogger(LogLevel.Information),
            new MyLogger(LogLevel.Warning),
        };
    }

    [Benchmark(Baseline = true)]
    public void LoggerExtensions()
    {
        Logger.LogInformation(240, "Hello, {name} {number}!", name, number);
    }

    [Benchmark]
    public void LoggerExtensionsIsEnabled()
    {
        if (Logger.IsEnabled(LogLevel.Information))
        {
            Logger.LogInformation(240, "Hello, {name} {number}!", name, number);
        }
    }

    [Benchmark]
    public void LoggerMessageGenerator()
    {
        Logger.Hello(name, number);
    }
}

public static partial class Log
{
    [LoggerMessage(240, LogLevel.Information, "Hello, {name} {number}!")]
    public static partial void Hello(this ILogger logger, string name, int number);
}

internal sealed class MyLogger : ILogger
{
    private readonly LogLevel minLevel;

    public MyLogger(LogLevel minLevel)
    {
        this.minLevel = minLevel;
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        return NullDisposable.Instance;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None
            && logLevel >= minLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        // no-op
    }

    public override string ToString()
    {
        return $"Min: {EnumInfo.GetName(minLevel)}";
    }
}
