using Microsoft.Extensions.Logging;

namespace F0.Gen.GetNameOfEnum.Example;

internal static class Program
{
	private static void Main(string[] args)
	{
        string? name = EnumInfo.GetName(LogLevel.None);
        Console.WriteLine(name);

#if !DEBUG
        _ = BenchmarkDotNet.Running.BenchmarkRunner.Run<GetNameOfEnumBenchmarks>();
#endif
    }
}
