using Microsoft.Extensions.Logging;
using Roslyn.Generated;

namespace F0.Gen.GetNameOfEnum.IntegrationTests;

internal partial class EnumInfo
{
    public static string? GetName_HandRolled(LogLevel value)
    {
        return value switch
        {
            LogLevel.Trace => nameof(LogLevel.Trace),
            LogLevel.Debug => nameof(LogLevel.Debug),
            LogLevel.Information => nameof(LogLevel.Information),
            LogLevel.Warning => nameof(LogLevel.Warning),
            LogLevel.Error => nameof(LogLevel.Error),
            LogLevel.Critical => nameof(LogLevel.Critical),
            LogLevel.None => nameof(LogLevel.None),
            _ => null,
        };
    }

    [GetNameOfEnum]
    public static partial string? GetName_Generated(LogLevel value);
}
