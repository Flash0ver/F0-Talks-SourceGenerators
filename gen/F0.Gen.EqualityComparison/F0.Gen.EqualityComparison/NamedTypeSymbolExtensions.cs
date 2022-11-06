using Microsoft.CodeAnalysis;

namespace F0.Gen.EqualityComparison;

internal static class NamedTypeSymbolExtensions
{
    public static IEnumerable<INamedTypeSymbol> GetThisAndSubtypes(this INamedTypeSymbol? type)
    {
        INamedTypeSymbol? current = type;
        while (current is not null)
        {
            yield return current;
            current = current.BaseType;
        }
    }
}
