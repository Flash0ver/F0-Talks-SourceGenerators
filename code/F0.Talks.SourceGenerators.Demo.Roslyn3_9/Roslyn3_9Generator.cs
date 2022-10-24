using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace F0.Talks.SourceGenerators.Demo.Roslyn3_9;

[Generator(LanguageNames.CSharp)]
internal sealed class Roslyn3_9Generator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization(PostInitialization);
        context.RegisterForSyntaxNotifications(static () => new SyntaxContextReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        Debug.Assert(context.SyntaxReceiver is null);
        Debug.Assert(context.SyntaxContextReceiver is SyntaxContextReceiver);
        var receiver = Unsafe.As<SyntaxContextReceiver>(context.SyntaxContextReceiver);

        INamedTypeSymbol? type = context.Compilation.GetTypeByMetadataName("PostInitialization.Roslyn3_9");
        bool hasPostInitialization = type is not null;

        StringBuilder source = new();
        source.AppendLine($"// PostInitialization found: {hasPostInitialization}");
        source.AppendLine($"// {nameof(receiver.NodesVisited)}: {receiver.NodesVisited}");
        source.AppendLine($"// Generated on {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
        source.AppendLine();

        context.AddSource("Generated.g.cs", source.ToString());
    }

    private static void PostInitialization(GeneratorPostInitializationContext context)
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

internal sealed class SyntaxContextReceiver : ISyntaxContextReceiver
{
    public int NodesVisited { get; private set; }

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        NodesVisited++;
    }
}
