using BenchmarkDotNet.Attributes;

namespace F0.Talks.SourceGenerators.Demo.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class EnumIsDefinedBenchmarks
{
    private StringComparison value;

    [GlobalSetup]
    public void Setup()
    {
        value = StringComparison.OrdinalIgnoreCase;
    }

    [Benchmark]
    public bool Enum_IsDefined_Bcl()
    {
        return SystemEnum.IsDefined(value);
    }

    [Benchmark]
    public bool Enum_IsDefined_Generated()
    {
        return InterceptedEnum.IsDefined(value);
    }

    private static class SystemEnum
    {
        internal static bool IsDefined<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            return Enum.IsDefined(value);
        }
    }

    private static class InterceptedEnum
    {
        internal static bool IsDefined(StringComparison value)
        {
            return Enum.IsDefined(value);
        }
    }
}
