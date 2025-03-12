using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace F0.Talks.SourceGenerators.Demo;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Demo")]
internal sealed class Intercepted
{
    [Interceptable]
    public static string Static(string text)
    {
        return $"Ordinary Method: {text}";
    }

    [Interceptable]
    public string Instance(string text)
    {
        return $"Ordinary Method: {text}";
    }
}
