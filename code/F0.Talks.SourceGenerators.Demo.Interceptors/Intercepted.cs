using System.Diagnostics.CodeAnalysis;

namespace F0.Talks.SourceGenerators.Demo.Interceptors;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Demo")]
public sealed class Intercepted
{
    public static string Static(string text)
    {
        return $"Ordinary Method: {text}";
    }

    public string Instance(string text)
    {
        return $"Ordinary Method: {text}";
    }
}
