using Microsoft.CodeAnalysis;

namespace F0.Gen.GetNameOfEnum;

internal partial class GetNameOfEnumGenerator
{
    private static class Formats
    {
        internal static readonly SymbolDisplayFormat GlobalAlias = SymbolDisplayFormat.FullyQualifiedFormat
            .WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.UseSpecialTypes | SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)
            .WithMemberOptions(SymbolDisplayMemberOptions.IncludeContainingType);
    }
}
