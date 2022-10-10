﻿using System.Diagnostics;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace F0.Gen.ValueTypeEquality;

// [Generator(LanguageNames.CSharp)]
internal sealed class IncrementalValueTypeEqualityGenerator : IIncrementalGenerator
{
    private static readonly AssemblyName assembly = typeof(ValueTypeEqualityGenerator).Assembly.GetName();
    private static readonly string generatedCodeAttribute = $@"[global::System.CodeDom.Compiler.GeneratedCodeAttribute(""{assembly.Name}"", ""{assembly.Version}"")]";
    
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<INamedTypeSymbol> syntaxProvider = context.SyntaxProvider
            .CreateSyntaxProvider(SyntacticPredicate, SemanticTransform)
            .Where(static (INamedTypeSymbol? type) => type is not null)!;

        context.RegisterSourceOutput(syntaxProvider, Execute);
    }

    private static bool SyntacticPredicate(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is StructDeclarationSyntax @struct
            && @struct.Modifiers.Any(static modifier => modifier.IsKind(SyntaxKind.PartialKeyword));
    }

    private static INamedTypeSymbol? SemanticTransform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        var @struct = context.Node as StructDeclarationSyntax;
        Debug.Assert(@struct is not null);

        ISymbol? symbol = context.SemanticModel.GetDeclaredSymbol(@struct);
        
        if (symbol is INamedTypeSymbol type)
        {
            INamedTypeSymbol? iEquatable = context.SemanticModel.Compilation.GetTypeByMetadataName("System.IEquatable`1");

            if (!type.Interfaces.Any(@interface => @interface.Equals(iEquatable, SymbolEqualityComparer.Default)))
            {
                return type;
            }
        }

        return null;
    }

    private static void Execute(SourceProductionContext context, INamedTypeSymbol @struct)
    {
        IPropertySymbol[] properties = @struct.GetMembers()
            .Where(static member => member.Kind == SymbolKind.Property)
            .Cast<IPropertySymbol>()
            .ToArray();

        string source = $@"// <auto-generated/>
#nullable enable

{(@struct.ContainingNamespace.IsGlobalNamespace ? string.Empty : $"namespace {@struct.ContainingNamespace};{Environment.NewLine}")}
partial struct {@struct.Name} : global::System.IEquatable<{@struct.Name}>
{{
    {generatedCodeAttribute}
    public static bool operator ==({@struct.Name} left, {@struct.Name} right)
    {{
        return left.Equals(right);
    }}

    {generatedCodeAttribute}
    public static bool operator !=({@struct.Name} left, {@struct.Name} right)
    {{
        return !(left == right);
    }}

    {generatedCodeAttribute}
    public override int GetHashCode()
    {{
        return global::System.HashCode.Combine({string.Join(", ", properties.Select(static property => property.Name))});
    }}

    {generatedCodeAttribute}
    public override bool Equals([global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? obj)
    {{
        return obj is {@struct.Name} && Equals(({@struct.Name})obj);
    }}

    {generatedCodeAttribute}
    public bool Equals({@struct.Name} other)
    {{
        return {string.Join(" && ", properties.Select(static property => $"global::System.Collections.Generic.EqualityComparer<{property.Type}>.Default.Equals({property.Name}, other.{property.Name})"))};
    }}
}}
";

        context.AddSource($"{@struct.Name}.ValueTypeEquality.g.cs", source);
    }
}
