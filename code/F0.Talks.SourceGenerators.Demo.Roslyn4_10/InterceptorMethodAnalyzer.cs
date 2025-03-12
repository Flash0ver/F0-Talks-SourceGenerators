using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace F0.Talks.SourceGenerators.Demo.Roslyn4_10;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal sealed class InterceptorMethodAnalyzer : DiagnosticAnalyzer
{
    [SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking", Justification = "Demo")]
    private static readonly DiagnosticDescriptor Rule = new(
        "DEMO0001",
        "Interceptor-Method",
        "Invocation '{0}' is intercepted by Method '{1}'",
        "Demo",
        DiagnosticSeverity.Warning,
        true,
        ".NET 9.0.200 Interceptor found.",
        "https://github.com/Flash0ver/F0-Talks-SourceGenerators"
    );

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeInvocationExpression, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocationExpression(SyntaxNodeAnalysisContext context)
    {
        Debug.Assert(context.Node is InvocationExpressionSyntax);

        var node = Unsafe.As<InvocationExpressionSyntax>(context.Node);

#pragma warning disable RSEXPERIMENTAL002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        IMethodSymbol? symbol = context.SemanticModel.GetInterceptorMethod(node, context.CancellationToken);
#pragma warning restore RSEXPERIMENTAL002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

        if (symbol is null)
        {
            return;
        }

        SymbolInfo info = context.SemanticModel.GetSymbolInfo(node, context.CancellationToken);

        Location location = symbol.Locations[0];
        var diagnostic = Diagnostic.Create(Rule, location, info.Symbol?.Name, symbol.Name);
        context.ReportDiagnostic(diagnostic);
    }
}
