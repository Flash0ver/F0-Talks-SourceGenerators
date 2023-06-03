using Microsoft.Extensions.Logging;
using Roslyn.Generated;

namespace F0.Gen.IsEnumDefined.Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        var level = ((LogLevel)(-1));

        bool isDefined = EnumInfo.IsDefined(level);

        Console.WriteLine(isDefined);
    }
}

[IsEnumDefined<LogLevel>]
[IsEnumDefined<StringComparison>]
internal static partial class EnumInfo
{
}
