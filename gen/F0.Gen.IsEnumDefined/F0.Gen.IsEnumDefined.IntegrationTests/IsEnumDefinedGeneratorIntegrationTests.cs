using FluentAssertions;
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
        bool generated = EnumInfo.IsDefined(logLevel);

        bcl.Should().Be(expected);
        generated.Should().Be(expected);

        static bool Bcl(LogLevel logLevel)
        {
#if NET472
            return Enum.IsDefined(typeof(LogLevel), logLevel);
#else
            return Enum.IsDefined(logLevel);
#endif
        }
    }

    [Fact]
    public void Are_All_Values_Defined()
    {
        foreach (LogLevel value in GetValues())
        {
            var actual = EnumInfo.IsDefined(value);

            actual.Should().BeTrue();
        }

        static Array GetValues()
        {
#if NET472
            return Enum.GetValues(typeof(LogLevel));
#else
            return Enum.GetValues<LogLevel>();
#endif
        }
    }
}

[IsEnumDefined<LogLevel>]
internal static partial class EnumInfo
{
}
