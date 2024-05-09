using BenchmarkDotNet.Attributes;
using FlashOWare.Generators;

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
        return Enum.IsDefined(value);
    }

    [Benchmark]
    public bool Enum_IsDefined_Generated()
    {
        return EnumInfo.IsDefined(value);
    }
}

[GeneratedEnumIsDefined<StringComparison>]
internal partial class EnumInfo
{
}
