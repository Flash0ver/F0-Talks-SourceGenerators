using Microsoft.Extensions.Logging;
using Roslyn.Generated;

namespace F0.Gen.GetNameOfEnum.Example;

internal static partial class EnumInfo
{
    [GetNameOfEnum]
    public static partial string? GetName(LogLevel hello);
}
