using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace F0.Talks.SourceGenerators.Roslyn3_8;

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

            using StringWriter writer = new();
            using IndentedTextWriter source = new(writer);

            source.Write("static partial class ");
            source.WriteLine(type.Name);
            source.WriteLine("{");
            source.Indent++;
            source.Write(SyntaxFacts.GetText(method.DeclaredAccessibility));
            source.Write(" static partial string ");
            source.Write(method.Name);
            source.WriteLine("()");
            source.WriteLine("{");
            source.Indent++;
            source.WriteLine(@"return ""From Generator"";");
            source.Indent--;
            source.WriteLine("}");
            source.Indent--;
            source.WriteLine("}");

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
            && method.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword))
            && method.ReturnType is PredefinedTypeSyntax predefined && predefined.Keyword.IsKind(SyntaxKind.StringKeyword))
        {
            Candidates.Add(method);
        }
    }
}
