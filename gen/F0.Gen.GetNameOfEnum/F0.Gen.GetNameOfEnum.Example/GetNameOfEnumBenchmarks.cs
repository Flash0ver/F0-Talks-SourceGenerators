using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace F0.Gen.GetNameOfEnum.Example;

[MemoryDiagnoser]
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Benchmarks")]
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "BenchmarkDotNet")]
public class GetNameOfEnumBenchmarks
{
    private const LogLevel logLevel = LogLevel.None;

    [Benchmark(Baseline = true)]
    public string Enum_ToString()
        => logLevel.ToString();

    [Benchmark]
    public string? Enum_GetName()
#if NETFRAMEWORK
		=> Enum.GetName(typeof(LogLevel), logLevel);
#else
        => Enum.GetName(logLevel);
#endif

    [Benchmark]
    public string? Generated_GetName()
        => EnumInfo.GetName(logLevel);
}
