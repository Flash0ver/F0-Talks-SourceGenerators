using Microsoft.CodeAnalysis;

namespace F0.Gen.IsEnumDefined;

internal sealed partial class IsEnumDefinedGenerator
{
    private static readonly SymbolDisplayFormat _format = SymbolDisplayFormat.FullyQualifiedFormat
        .WithMemberOptions(SymbolDisplayMemberOptions.IncludeContainingType);
}
