using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;

namespace F0.Talks.SourceGenerators.Demo.Roslyn3_8;

[Generator]
internal sealed class Roslyn3_8Generator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(static () => new SyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var receiver = context.SyntaxReceiver as SyntaxReceiver;
        Debug.Assert(receiver is not null);

        foreach (MethodDeclarationSyntax candidate in receiver.Candidates)
        {
            SemanticModel semanticModel = context.Compilation.GetSemanticModel(candidate.SyntaxTree);

            IMethodSymbol? method = semanticModel.GetDeclaredSymbol(candidate);
            Debug.Assert(method is not null);
            INamedTypeSymbol type = method.ContainingType;

            using StringWriter writer = new(CultureInfo.InvariantCulture);
            using IndentedTextWriter source = new(writer);

            source.WriteLine($"static partial class {type.Name}");
            source.WriteLine("{");
            source.Indent++;
            source.WriteLine($"{SyntaxFacts.GetText(method.DeclaredAccessibility)} static partial string {method.Name}()");
            source.WriteLine("{");
            source.Indent++;
            source.WriteLine(@"return ""From Generator"";");
            source.Indent--;
            source.WriteLine("}");
            source.Indent--;
            source.WriteLine("}");

            Debug.Assert(source.Indent == 0);
            context.AddSource("HintName.g.cs", writer.ToString());
        }
    }
}

internal sealed class SyntaxReceiver : ISyntaxReceiver
{
    public List<MethodDeclarationSyntax> Candidates { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is MethodDeclarationSyntax method
            && method.Modifiers.Any(static modifier => modifier.IsKind(SyntaxKind.PartialKeyword))
            && method.ReturnType is PredefinedTypeSyntax predefined && predefined.Keyword.IsKind(SyntaxKind.StringKeyword))
        {
            Candidates.Add(method);
        }
    }
}
