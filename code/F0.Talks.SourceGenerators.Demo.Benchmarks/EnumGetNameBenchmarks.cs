using BenchmarkDotNet.Attributes;
using FlashOWare.Generators;

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
        return Enum.GetName(value);
    }

    [Benchmark]
    public string? Enum_GetName_Generated()
    {
        return EnumInfo.GetName(value);
    }
}

[GeneratedEnumGetName<StringComparison>]
internal partial class EnumInfo
{
}
