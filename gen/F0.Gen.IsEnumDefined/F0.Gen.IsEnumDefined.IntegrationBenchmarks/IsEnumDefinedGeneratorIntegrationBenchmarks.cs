using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Roslyn.Generated;

namespace F0.Gen.IsEnumDefined.IntegrationBenchmarks;

public class IsEnumDefinedGeneratorIntegrationBenchmarks
{
    private const LogLevel _logLevel = LogLevel.Trace;

    [Benchmark(Baseline = true)]
    public bool Bcl()
    {
#if NET472
        return Enum.IsDefined(typeof(LogLevel), _logLevel);
#else
        return Enum.IsDefined(_logLevel);
#endif
    }

    [Benchmark]
    public bool HandRolled()
    {
        return IsDefined(_logLevel);

        static bool IsDefined(LogLevel value)
        {
            return value is
                LogLevel.Trace or
                LogLevel.Debug or
                LogLevel.Information or
                LogLevel.Warning or
                LogLevel.Error or
                LogLevel.Critical or
                LogLevel.None;
        }
    }

    [Benchmark]
    public bool Generated()
    {
        return EnumInfo.IsDefined(_logLevel);
    }
}

[IsEnumDefined<LogLevel>]
internal static partial class EnumInfo
{
}
