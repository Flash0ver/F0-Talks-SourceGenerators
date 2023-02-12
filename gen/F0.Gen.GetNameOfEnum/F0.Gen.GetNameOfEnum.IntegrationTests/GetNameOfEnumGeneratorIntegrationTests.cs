using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace F0.Gen.GetNameOfEnum.IntegrationTests;

public class GetNameOfEnumGeneratorIntegrationTests
{
    [Theory]
    [InlineData(LogLevel.Trace, nameof(LogLevel.Trace))]
    [InlineData(LogLevel.Debug, nameof(LogLevel.Debug))]
    [InlineData(LogLevel.Information, nameof(LogLevel.Information))]
    [InlineData(LogLevel.Warning, nameof(LogLevel.Warning))]
    [InlineData(LogLevel.Error, nameof(LogLevel.Error))]
    [InlineData(LogLevel.Critical, nameof(LogLevel.Critical))]
    [InlineData(LogLevel.None, nameof(LogLevel.None))]
    public void Generated_Enum_GetName(LogLevel logLevel, string? expected)
    {
        logLevel.ToString().Should().Be(expected);

#if NETFRAMEWORK
		Enum.GetName(typeof(LogLevel), logLevel).Should().Be(expected);
#else
        Enum.GetName(logLevel).Should().Be(expected);
#endif

        EnumInfo.GetName_HandRolled(logLevel).Should().Be(expected);
        EnumInfo.GetName_Generated(logLevel).Should().Be(expected);
    }

    [Theory]
    [InlineData((LogLevel)7, null, "7")]
    public void Generated_Enum_GetName_Null(LogLevel logLevel, string? getName, string toString)
    {
        logLevel.ToString().Should().Be(toString);

#if NETFRAMEWORK
		Enum.GetName(typeof(LogLevel), logLevel).Should().Be(getName);
#else
        Enum.GetName(logLevel).Should().Be(getName);
#endif

        EnumInfo.GetName_HandRolled(logLevel).Should().Be(getName);
        EnumInfo.GetName_Generated(logLevel).Should().Be(getName);
    }
}
