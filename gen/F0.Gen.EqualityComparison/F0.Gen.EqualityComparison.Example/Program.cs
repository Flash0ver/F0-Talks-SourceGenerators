using System.Globalization;

namespace F0.Gen.EqualityComparison.Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(args);
        Console.WriteLine(DateTime.UtcNow.ToString(DateTimeFormatInfo.InvariantInfo));

#if !DEBUG
        _ = BenchmarkDotNet.Running.BenchmarkRunner.Run<EqualityComparisonBenchmarks>();
#endif
    }
}
