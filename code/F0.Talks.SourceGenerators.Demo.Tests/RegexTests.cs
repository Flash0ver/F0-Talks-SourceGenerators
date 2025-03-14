﻿using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace F0.Talks.SourceGenerators.Demo.Tests;

/// <summary>
/// <see href="https://learn.microsoft.com/dotnet/standard/base-types/regular-expression-source-generators">.NET regular expression source generators</see>
/// </summary>
[SuppressMessage("GeneratedRegex", "SYSLIB1045:Convert to 'GeneratedRegexAttribute'.", Justification = "Demo")]
public partial class RegexTests
{
    private static readonly Regex _regex = new("Flash(Over|0ver|OWare)", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

    [GeneratedRegex("Flash(Over|0ver|OWare)", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture, "en-US")]
    private static partial Regex GeneratedRegex { get; }

    [Theory]
    [InlineData("FlashOver")]
    [InlineData("flashover")]
    [InlineData("Flash0ver")]
    [InlineData("flash0ver")]
    [InlineData("FlashOWare")]
    [InlineData("flashoware")]
    public void IsMatch_Match_ReturnTrue(string text)
    {
        _regex.IsMatch(text).Should().BeTrue();
        GeneratedRegex.IsMatch(text).Should().BeTrue();
    }

    [Theory]
    [InlineData("0x_F0")]
    [InlineData("Backdraft")]
    [InlineData("Techorama 2024")]
    public void IsMatch_Mismatch_ReturnFalse(string text)
    {
        _regex.IsMatch(text).Should().BeFalse();
        GeneratedRegex.IsMatch(text).Should().BeFalse();
    }
}
