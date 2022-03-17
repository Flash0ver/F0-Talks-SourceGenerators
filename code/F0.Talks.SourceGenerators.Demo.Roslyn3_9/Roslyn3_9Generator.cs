using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Text;

namespace F0.Talks.SourceGenerators.Roslyn3_9;

[Generator]
internal sealed class Roslyn3_9Generator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization(PostInitialization);
        context.RegisterForSyntaxNotifications(static () => new SyntaxContextReceiver());

        static void PostInitialization(GeneratorPostInitializationContext context)
        {
            const string source = @"namespace PostInitialization;

internal static class Roslyn3_9
{
    internal static string Get()
    {
        return ""PostInitialization"";
    }
}
";
            context.AddSource("PostInitialization.g.cs", source);
        }
    }

    public void Execute(GeneratorExecutionContext context)
    {
        Debug.Assert(context.SyntaxReceiver is null);
        var receiver = context.SyntaxContextReceiver as SyntaxContextReceiver;
        Debug.Assert(receiver is not null);

        INamedTypeSymbol? type = context.Compilation.GetTypeByMetadataName("PostInitialization.Roslyn3_9");
        bool hasPostInitialization = type is not null;

        StringBuilder source = new();
        source.Append("// PostInitialization found: ");
        source.AppendLine(hasPostInitialization.ToString());
        source.Append("// ");
        source.Append(nameof(receiver.NodesVisited));
        source.Append(": ");
        source.Append(receiver.NodesVisited);
        source.AppendLine();

        context.AddSource("Generated.g.cs", source.ToString());
    }
}

internal sealed class SyntaxContextReceiver : ISyntaxContextReceiver
{
    public int NodesVisited { get; private set; }

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        NodesVisited++;
    }
}
