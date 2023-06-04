using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace F0.Talks.SourceGenerators.Demo.Roslyn4_3;

[Generator(LanguageNames.CSharp)]
internal sealed class Roslyn4_3Generator : IIncrementalGenerator
{
    private static readonly string generatedCodeAttribute = $@"[global::System.CodeDom.Compiler.GeneratedCodeAttribute(""{typeof(Roslyn4_3Generator).Assembly.GetName().Name}"", ""{typeof(Roslyn4_3Generator).Assembly.GetName().Version}"")]";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static void (IncrementalGeneratorPostInitializationContext context) =>
        {
            const string hintName = "F0.GeneratedNamespace.GeneratedAttribute.g.cs";
            //language=c#
            string source = $$"""
                namespace F0.GeneratedNamespace;

                {{generatedCodeAttribute}}
                [global::System.AttributeUsage(global::System.AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
                internal sealed class GeneratedAttribute : global::System.Attribute
                {
                }

                """;

            context.AddSource(hintName, source);
        });

        IncrementalValuesProvider<(string TypeName, Accessibility MethodAccessibility, string MethodName)> provider =
            context.SyntaxProvider.ForAttributeWithMetadataName("F0.GeneratedNamespace.GeneratedAttribute",
                static bool (SyntaxNode node, CancellationToken cancellationToken) =>
                {
                    return node is MethodDeclarationSyntax method
                        && method.Modifiers.Any(SyntaxKind.StaticKeyword)
                        && method.Modifiers.Any(SyntaxKind.PartialKeyword)
                        && method.ReturnType is PredefinedTypeSyntax predefined
                        && predefined.Keyword.IsKind(SyntaxKind.IntKeyword);
                },
                static (string TypeName, Accessibility MethodAccessibility, string MethodName) (GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken) =>
                {
                    Debug.Assert(context.TargetNode is MethodDeclarationSyntax);
                    Debug.Assert(context.TargetSymbol is IMethodSymbol);
                    Debug.Assert(!context.Attributes.IsEmpty);

                    var symbol = Unsafe.As<IMethodSymbol>(context.TargetSymbol);

                    return (symbol.ContainingType.Name, symbol.DeclaredAccessibility, symbol.Name);
                });

        context.RegisterSourceOutput(provider, static void (SourceProductionContext context, (string TypeName, Accessibility MethodAccessibility, string MethodName) info) =>
        {
            using StringWriter writer = new(CultureInfo.InvariantCulture);
            using IndentedTextWriter source = new(writer);

            source.WriteLine($"static partial class {info.TypeName}");
            source.WriteLine("{");
            source.Indent++;
            source.WriteLine($"{SyntaxFacts.GetText(info.MethodAccessibility)} static partial int {info.MethodName}()");
            source.WriteLine("{");
            source.Indent++;
            source.WriteLine("return 0x_F0;");
            source.Indent--;
            source.WriteLine("}");
            source.Indent--;
            source.WriteLine("}");

            Debug.Assert(source.Indent == 0);
            context.AddSource($"{info.TypeName}.g.cs", writer.ToString());
        });
    }
}
