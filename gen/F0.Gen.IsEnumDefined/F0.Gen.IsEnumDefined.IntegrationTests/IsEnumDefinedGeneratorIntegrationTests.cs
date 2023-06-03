using Microsoft.Extensions.Logging;
using Roslyn.Generated;
using Xunit;

namespace F0.Gen.IsEnumDefined.IntegrationTests;

public class IsEnumDefinedGeneratorIntegrationTests
{
    [Theory]
    [InlineData(-1, false)]
    [InlineData(0, true)]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, true)]
    [InlineData(6, true)]
    [InlineData(7, false)]
    public void Generated_Enum_IsDefined(int underlying, bool expected)
    {
        var logLevel = (LogLevel)underlying;

        bool bcl = Bcl(logLevel);
        bool actual = EnumInfo.IsDefined(logLevel);

        Assert.Equal(expected, bcl);
        Assert.Equal(expected, actual);

        static bool Bcl(LogLevel logLevel)
        {
#if NET472
            return Enum.IsDefined(typeof(LogLevel), logLevel);
#else
            return Enum.IsDefined(logLevel);
#endif
        }
    }
}

[IsEnumDefined<LogLevel>]
internal static partial class EnumInfo
{
}
