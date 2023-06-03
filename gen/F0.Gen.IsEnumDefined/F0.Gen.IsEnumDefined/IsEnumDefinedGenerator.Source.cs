using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace F0.Gen.IsEnumDefined;

internal sealed partial class IsEnumDefinedGenerator
{
    private readonly record struct IsEnumDefinedSource(
        ClassDeclarationSyntax Node,
        INamedTypeSymbol Symbol,
        ImmutableArray<AttributeData> Attributes)
    {
    }
}
