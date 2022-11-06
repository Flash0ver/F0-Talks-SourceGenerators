using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace F0.Gen.EqualityComparison;

[Generator(LanguageNames.CSharp)]
internal sealed partial class EqualityComparerGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(PostInitializationCallback);

        IncrementalValuesProvider<EqualityComparerContext> provider = context.SyntaxProvider
            .CreateSyntaxProvider(SyntacticPredicate, SemanticTransform)
            .Where(static ((INamedTypeSymbol, INamedTypeSymbol)? types) => types.HasValue)
            .Select(static ((INamedTypeSymbol, INamedTypeSymbol)? types, CancellationToken _) => TransformType(types!.Value))
            .WithComparer(EqualityComparerContextEqualityComparer.Instance);

        context.RegisterSourceOutput(provider, Execute);
    }

    private static void PostInitializationCallback(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource("EqualityComparerAttribute.g.cs", EqualityComparerAttribute);
    }

    private static bool SyntacticPredicate(SyntaxNode syntaxNode, CancellationToken cancellationToken)
    {
        return syntaxNode is ClassDeclarationSyntax
        {
            AttributeLists.Count: > 0,
        } candidate
            && candidate.Modifiers.Any(SyntaxKind.PartialKeyword)
            && !candidate.Modifiers.Any(SyntaxKind.StaticKeyword);
    }

    private static (INamedTypeSymbol, INamedTypeSymbol)? SemanticTransform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        Debug.Assert(context.Node is ClassDeclarationSyntax);
        var candidate = Unsafe.As<ClassDeclarationSyntax>(context.Node);

        INamedTypeSymbol? symbol = context.SemanticModel.GetDeclaredSymbol(candidate, cancellationToken);

        if (symbol is not null
            && !symbol.Interfaces.Any(static (INamedTypeSymbol @interface) => @interface.ConstructedFrom.ToDisplayString().Equals(EqualityComparerInterfaceName, StringComparison.Ordinal))
            && TryGetAttribute(candidate, EqualityComparerAttributeName, context.SemanticModel, cancellationToken, out AttributeSyntax? attribute)
            && TryGetType(attribute, context.SemanticModel, cancellationToken, out INamedTypeSymbol? type))
        {
            return (symbol, type);
        }

        return null;
    }

    private static bool TryGetAttribute(ClassDeclarationSyntax candidate, string attributeName, SemanticModel semanticModel, CancellationToken cancellationToken, [NotNullWhen(true)] out AttributeSyntax? value)
    {
        foreach (AttributeListSyntax attributeList in candidate.AttributeLists)
        {
            foreach (AttributeSyntax attribute in attributeList.Attributes)
            {
                SymbolInfo info = semanticModel.GetSymbolInfo(attribute, cancellationToken);
                ISymbol? symbol = info.Symbol;

                if (symbol is IMethodSymbol method
                    && method.ContainingType.ToDisplayString().Equals(attributeName, StringComparison.Ordinal))
                {
                    value = attribute;
                    return true;
                }
            }
        }

        value = null;
        return false;
    }

    private static bool TryGetType(AttributeSyntax attribute, SemanticModel semanticModel, CancellationToken cancellationToken, [NotNullWhen(true)] out INamedTypeSymbol? value)
    {
        if (attribute.ArgumentList is
            {
                Arguments.Count: 1,
            } argumentList)
        {
            AttributeArgumentSyntax argument = argumentList.Arguments[0];

            if (argument.Expression is TypeOfExpressionSyntax typeOf)
            {
                SymbolInfo info = semanticModel.GetSymbolInfo(typeOf.Type, cancellationToken);
                ISymbol? symbol = info.Symbol;

                if (symbol is INamedTypeSymbol type)
                {
                    value = type;
                    return true;
                }
            }
        }

        value = null;
        return false;
    }

    private static EqualityComparerContext TransformType((INamedTypeSymbol EqualityComparerType, INamedTypeSymbol CompareType) types)
    {
        string? @namespace = types.EqualityComparerType.ContainingNamespace.IsGlobalNamespace
            ? null
            : types.EqualityComparerType.ContainingNamespace.ToDisplayString();
        string name = types.EqualityComparerType.Name;

        bool isReferenceType = types.CompareType.IsReferenceType;
        string targetType = types.CompareType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        bool areInternalSymbolsAccessible = types.CompareType.ContainingAssembly.GivesAccessTo(types.EqualityComparerType.ContainingAssembly);
        ImmutableArray<PropertyContext> properties = types.CompareType.GetThisAndSubtypes()
            .Reverse()
            .SelectMany(static type => type.GetMembers())
            .Where(member => FilterProperty(member, areInternalSymbolsAccessible))
            .Select(static member => TransformProperty(member))
            .Distinct()
            .ToImmutableArray();

        return new EqualityComparerContext(@namespace, name, new CompareTypeContext(isReferenceType, targetType, properties));
    }

    private static bool FilterProperty(ISymbol member, bool areInternalSymbolsAccessible)
    {
        if (!member.IsStatic
            && member.Kind == SymbolKind.Property)
        {
            Debug.Assert(member is IPropertySymbol);
            var property = Unsafe.As<IPropertySymbol>(member);

            return property.GetMethod is { } get
                && (get.DeclaredAccessibility is Accessibility.Public
                || (areInternalSymbolsAccessible && (get.DeclaredAccessibility is Accessibility.Internal or Accessibility.ProtectedOrInternal)));
        }

        return false;
    }

    private static PropertyContext TransformProperty(ISymbol member)
    {
        Debug.Assert(member is IPropertySymbol);
        var property = Unsafe.As<IPropertySymbol>(member);

        string type = property.Type.ToDisplayString(Format);
        string name = property.Name;

        return new PropertyContext(type, name);
    }

    private static void Execute(SourceProductionContext context, EqualityComparerContext source)
    {
        string nullable = source.CompareType.IsReferenceType
            ? $"{source.CompareType.QualifiedName}?"
            : source.CompareType.QualifiedName;

        string equals = source.CompareType.IsReferenceType
            ? @"
        if ((object?)x == y)
        {
            return true;
        }

        if (x is null || y is null)
        {
            global::System.Diagnostics.Debug.Assert(x is null ^ y is null);
            return false;
        }
"
            : String.Empty;

        string getHashCode = source.CompareType.IsReferenceType
            ? @"
        if (obj is null)
        {
            return 0;
        }
"
            : String.Empty;

        string text = $@"// <auto-generated/>
#nullable enable

{(source.Namespace is null ? String.Empty : $"namespace {source.Namespace};{Environment.NewLine}")}
partial class {source.Name} : global::System.Collections.Generic.IEqualityComparer<{nullable}>
{{
    {GeneratedCodeAttribute}
    private {source.Name}() {{ }}

    {GeneratedCodeAttribute}
    public static {source.Name} Instance {{ get; }} = new {source.Name}();

    {GeneratedCodeAttribute}
    public bool Equals({nullable} x, {nullable} y)
    {{{equals}
        return {String.Join(" && ", source.CompareType.Properties.Select(static property => $"global::System.Collections.Generic.EqualityComparer<{property.Type}>.Default.Equals(x.{property.Name}, y.{property.Name})"))};
    }}

    {GeneratedCodeAttribute}
    public int GetHashCode({source.CompareType.QualifiedName} obj)
    {{{getHashCode}
        return global::System.HashCode.Combine({String.Join(", ", source.CompareType.Properties.Select(static property => $"obj.{property.Name}"))});
    }}
}}
";

        string qualifiedName = source.Namespace is null ? source.Name : $"{source.Namespace}.{source.Name}";
        context.AddSource($"{qualifiedName}.EqualityComparer.g.cs", text);
    }
}
