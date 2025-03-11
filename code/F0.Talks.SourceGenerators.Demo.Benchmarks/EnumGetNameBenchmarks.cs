using BenchmarkDotNet.Attributes;

namespace F0.Talks.SourceGenerators.Demo.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class EnumGetNameBenchmarks
{
    private StringComparison value;

    [GlobalSetup]
    public void Setup()
    {
        value = StringComparison.OrdinalIgnoreCase;
    }

    [Benchmark]
    public string? Enum_GetName_Bcl()
    {
        return SystemEnum.GetName(value);
    }

    [Benchmark]
    public string? Enum_GetName_Generated()
    {
        return InterceptedEnum.GetName(value);
    }

    private static class SystemEnum
    {
        internal static string? GetName<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            return Enum.GetName(value);
        }
    }

    private static class InterceptedEnum
    {
        internal static string? GetName(StringComparison value)
        {
            return Enum.GetName(value);
        }
    }
}
