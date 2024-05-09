using BenchmarkDotNet.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace F0.Talks.SourceGenerators.Demo.Benchmarks;

/// <summary>
/// <see href="https://learn.microsoft.com/dotnet/standard/base-types/regular-expression-source-generators">.NET regular expression source generators</see>
/// </summary>
[ShortRunJob]
[MemoryDiagnoser(false)]
[SuppressMessage("Performance", "SYSLIB1045:Convert to 'GeneratedRegexAttribute'.", Justification = "Demo")]
public partial class RegexBenchmarks
{
    // lang=regex
    private const string Pattern = @".+\.(cs|vb)";

    private static readonly Regex s_regex = new(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private string _text = null!;

    [GlobalSetup]
    public void Setup()
    {
        _text = "Document.generated.cs";
    }

    [Benchmark]
    public bool Interpreted_New()
    {
        Regex regex = new(Pattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(_text);
    }

    [Benchmark]
    public bool Compiled_New()
    {
        Regex regex = new(Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        return regex.IsMatch(_text);
    }

    [Benchmark]
    public bool Compiled_Cached()
    {
        return s_regex.IsMatch(_text);
    }

    [Benchmark]
    public bool Generated()
    {
        Regex regex = GetGenerated();
        return regex.IsMatch(_text);
    }

    [GeneratedRegex(Pattern, RegexOptions.IgnoreCase)]
    private static partial Regex GetGenerated();
}
