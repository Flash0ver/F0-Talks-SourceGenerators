using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

namespace F0.Gen.GetNameOfEnum.UnitTests.Verifiers
{
    internal static partial class CSharpSourceGeneratorVerifier<TSourceGenerator>
        where TSourceGenerator : IIncrementalGenerator, new()
    {
        internal static readonly (string filename, string content)[] EmptyGeneratedSources = Array.Empty<(string filename, string content)>();

        public static DiagnosticResult Diagnostic()
            => new DiagnosticResult();

        public static DiagnosticResult Diagnostic(string id, DiagnosticSeverity severity)
            => new DiagnosticResult(id, severity);

        public static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
            => new DiagnosticResult(descriptor);

        public static async Task VerifyGeneratorAsync(string source, (string filename, string content) generatedSource)
            => await VerifyGeneratorAsync(source, DiagnosticResult.EmptyDiagnosticResults, new[] { generatedSource });

        public static async Task VerifyGeneratorAsync(string source, params (string filename, string content)[] generatedSources)
            => await VerifyGeneratorAsync(source, DiagnosticResult.EmptyDiagnosticResults, generatedSources);

        public static async Task VerifyGeneratorAsync(string source, DiagnosticResult diagnostic)
            => await VerifyGeneratorAsync(source, new[] { diagnostic }, EmptyGeneratedSources);

        public static async Task VerifyGeneratorAsync(string source, params DiagnosticResult[] diagnostics)
            => await VerifyGeneratorAsync(source, diagnostics, EmptyGeneratedSources);

        public static async Task VerifyGeneratorAsync(string source, DiagnosticResult diagnostic, (string filename, string content) generatedSource)
            => await VerifyGeneratorAsync(source, new[] { diagnostic }, new[] { generatedSource });

        public static async Task VerifyGeneratorAsync(string source, DiagnosticResult[] diagnostics, (string filename, string content) generatedSource)
            => await VerifyGeneratorAsync(source, diagnostics, new[] { generatedSource });

        public static async Task VerifyGeneratorAsync(string source, DiagnosticResult diagnostic, params (string filename, string content)[] generatedSources)
            => await VerifyGeneratorAsync(source, new[] { diagnostic }, generatedSources);

        public static async Task VerifyGeneratorAsync(string source, DiagnosticResult[] diagnostics, params (string filename, string content)[] generatedSources)
        {
            CSharpSourceGeneratorVerifier<TSourceGenerator>.Test test = new()
            {
                TestState =
                {
                    Sources = { source },
                },
            };

            foreach ((string filename, string content) generatedSource in generatedSources)
            {
                test.TestState.GeneratedSources.Add((typeof(TSourceGenerator), generatedSource.filename, SourceText.From(generatedSource.content, Encoding.UTF8)));
            }

            test.ExpectedDiagnostics.AddRange(diagnostics);

            await test.RunAsync(CancellationToken.None);
        }
    }
}
