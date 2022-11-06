using Microsoft.CodeAnalysis;

namespace F0.Gen.EqualityComparison;

internal sealed partial class EqualityComparerGenerator
{
    private static readonly SymbolDisplayFormat Format = SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.UseSpecialTypes | SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);
}
