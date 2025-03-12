# Versioning

- Roslyn 3.8
  - [Microsoft.CodeAnalysis 3.8.0][roslyn-3.8] ([C# 9.0][csharp-9.0])
  - added [ISourceGenerator][isourcegenerator] and [ISyntaxReceiver][isyntaxreceiver]
  - [.NET SDK 5.0.100][dotnet-5.0.0]
  - [Visual Studio v16.8.0][vs-16.8] / [Rider 2020.3][rider-2020.3]
- Roslyn 3.9
  - [Microsoft.CodeAnalysis 3.9.0][roslyn-3.9] ([C# 9.0][csharp-9.0])
  - added [ISyntaxContextReceiver][isyntaxcontextreceiver] and [RegisterForPostInitialization][registerforpostinitialization] and support for _Visual Basic_
  - [.NET SDK 5.0.200][dotnet-5.0.3]
  - [Visual Studio v16.9.0][vs-16.9] / [Rider 2021.2][rider-2021.2]
- Roslyn 4.0
  - [Microsoft.CodeAnalysis 4.0.1][roslyn-4.0] ([C# 10.0][csharp-10.0])
  - added [IIncrementalGenerator][iincrementalgenerator]
  - [.NET SDK 6.0.100][dotnet-6.0.0]
  - [Visual Studio v17.0.0][vs-17.0] / [Rider 2021.3][rider-2021.3]
- Roslyn 4.1
  - [Microsoft.CodeAnalysis 4.1.0][roslyn-4.1] ([C# 10.0][csharp-10.0])
  - added [WithTrackingName<TSource>][withtrackingname]
  - [.NET SDK 6.0.200][dotnet-6.0.2]
  - [Visual Studio v17.1.0][vs-17.1] / [Rider 2022.1][rider-2022.1]
- Roslyn 4.2
  - [Microsoft.CodeAnalysis 4.2.0][roslyn-4.2] ([C# 10.0][csharp-10.0])
  - fixed [MetadataReferencesProvider][metadatareferencesprovider] (see [dotnet/roslyn#58059][gh-58059])
  - [.NET SDK 6.0.300][dotnet-6.0.5]
  - [Visual Studio v17.2.0][vs-17.2] / [Rider 2022.3][rider-2022.3]
- Roslyn 4.3
  - [Microsoft.CodeAnalysis 4.3.1][roslyn-4.3] ([C# 10.0][csharp-10.0])
  - added [ForAttributeWithMetadataName<T>][forattributewithmetadataname] (see [dotnet/roslyn#54725][gh-54725])
  - [.NET SDK 6.0.400][dotnet-6.0.8]
  - [Visual Studio v17.3.0][vs-17.3] / [Rider 2022.3][rider-2022.3]
- Roslyn 4.10
  - [Microsoft.CodeAnalysis 4.10.0][roslyn-4.10] ([C# 12.0][csharp-12.0])
  - [.NET SDK 8.0.300][dotnet-8.0.5]
  - [Visual Studio v17.10.0][vs-17.10]
```CSharp
namespace Microsoft.CodeAnalysis.CSharp
{
  public static class CSharpExtensions
  {
    [Experimental("RSEXPERIMENTAL002", UrlFormat = "https://github.com/dotnet/csharplang/issues/7009")]
    public static IMethodSymbol? GetInterceptorMethod(this SemanticModel? semanticModel, InvocationExpressionSyntax node, CancellationToken cancellationToken = default);
  }
}
```
- Roslyn 4.11
  - [Microsoft.CodeAnalysis 4.11.0][roslyn-4.11] ([C# 12.0][csharp-12.0])
  - [.NET SDK 8.0.400][dotnet-8.0.8]
  - [Visual Studio v17.11.0][vs-17.11]
```CSharp
namespace Microsoft.CodeAnalysis.CSharp
{
  [Experimental("RSEXPERIMENTAL002", UrlFormat = "https://github.com/dotnet/csharplang/issues/7009")]
  public abstract class InterceptableLocation
  {
    private protected InterceptableLocation() { }

    public abstract int Version { get; }
    public abstract string Data { get; }

    public abstract string GetDisplayLocation();

    public abstract override bool Equals(object? obj);
    public abstract override int GetHashCode();
  }

  public static class CSharpExtensions
  {
    [Experimental("RSEXPERIMENTAL002", UrlFormat = "https://github.com/dotnet/csharplang/issues/7009")]
    public static InterceptableLocation? GetInterceptableLocation(this SemanticModel? semanticModel, InvocationExpressionSyntax node, CancellationToken cancellationToken = default);

    [Experimental("RSEXPERIMENTAL002", UrlFormat = "https://github.com/dotnet/csharplang/issues/7009")]
    public static string GetInterceptsLocationAttributeSyntax(this InterceptableLocation location);
  }
}
```
- Roslyn 4.13
  - [Microsoft.CodeAnalysis 4.13.0][roslyn-4.13] ([C# 13.0][csharp-13.0])
  - [.NET SDK 9.0.200][dotnet-9.0.2]
  - [Visual Studio v17.13.0][vs-17.13]
  - remove `System.Diagnostics.CodeAnalysis.ExperimentalAttribute` from
    - `Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetInterceptableLocation(this SemanticModel? semanticModel, InvocationExpressionSyntax node, CancellationToken cancellationToken = default)`
    - `Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetInterceptsLocationAttributeSyntax(this InterceptableLocation location)`
    - `Microsoft.CodeAnalysis.CSharp.CSharpExtensions.GetInterceptorMethod(this SemanticModel? semanticModel, InvocationExpressionSyntax node, CancellationToken cancellationToken = default)`
    - `Microsoft.CodeAnalysis.CSharp.InterceptableLocation`
  - see also
    - https://github.com/dotnet/csharplang/issues/7009
    - https://github.com/dotnet/roslyn/issues/72093
    - https://github.com/dotnet/roslyn/issues/72133

[isourcegenerator]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isourcegenerator
[isyntaxreceiver]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxreceiver
[isyntaxcontextreceiver]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxcontextreceiver
[registerforpostinitialization]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.generatorinitializationcontext.registerforpostinitialization
[iincrementalgenerator]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.iincrementalgenerator
[withtrackingname]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.incrementalvalueproviderextensions.withtrackingname
[metadatareferencesprovider]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.incrementalgeneratorinitializationcontext.metadatareferencesprovider
[forattributewithmetadataname]: https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.syntaxvalueprovider.forattributewithmetadataname

[roslyn-3.8]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/3.8.0
[roslyn-3.9]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/3.9.0
[roslyn-4.0]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.0.1
[roslyn-4.1]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.1.0
[roslyn-4.2]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.2.0
[roslyn-4.3]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.3.1
[roslyn-4.10]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.10.0
[roslyn-4.11]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.11.0
[roslyn-4.13]: https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp/4.13.0

[csharp-9.0]: https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-9
[csharp-10.0]: https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-10
[csharp-12.0]: https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12
[csharp-13.0]: https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-13

[dotnet-5.0.0]: https://github.com/dotnet/core/blob/main/release-notes/5.0/5.0.0/5.0.0.md
[dotnet-5.0.3]: https://github.com/dotnet/core/blob/main/release-notes/5.0/5.0.3/5.0.200-sdk.md
[dotnet-6.0.0]: https://github.com/dotnet/core/blob/main/release-notes/6.0/6.0.0/6.0.0.md
[dotnet-6.0.2]: https://github.com/dotnet/core/blob/main/release-notes/6.0/6.0.2/6.0.2.md
[dotnet-6.0.5]: https://github.com/dotnet/core/blob/main/release-notes/6.0/6.0.5/6.0.5.md
[dotnet-6.0.8]: https://github.com/dotnet/core/blob/main/release-notes/6.0/6.0.8/6.0.8.md
[dotnet-8.0.5]: https://github.com/dotnet/core/blob/main/release-notes/8.0/8.0.5/8.0.5.md
[dotnet-8.0.8]: https://github.com/dotnet/core/blob/main/release-notes/8.0/8.0.8/8.0.8.md
[dotnet-9.0.2]: https://github.com/dotnet/core/blob/main/release-notes/9.0/9.0.2/9.0.2.md

[vs-16.8]: https://learn.microsoft.com/visualstudio/releases/2019/release-notes-v16.8
[vs-16.9]: https://learn.microsoft.com/visualstudio/releases/2019/release-notes-v16.9
[vs-17.0]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.0
[vs-17.1]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.1
[vs-17.2]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.2
[vs-17.3]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.3
[vs-17.10]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.10
[vs-17.11]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.11
[vs-17.13]: https://learn.microsoft.com/visualstudio/releases/2022/release-notes-v17.13

[rider-2020.3]: https://www.jetbrains.com/rider/whatsnew/2020-3
[rider-2021.2]: https://www.jetbrains.com/rider/whatsnew/2021-2
[rider-2021.3]: https://www.jetbrains.com/rider/whatsnew/2021-3
[rider-2022.1]: https://www.jetbrains.com/rider/whatsnew/2022-1
[rider-2022.3]: https://www.jetbrains.com/rider/whatsnew/2022-3

[gh-58059]: https://github.com/dotnet/roslyn/pull/58059
[gh-54725]: https://github.com/dotnet/roslyn/issues/54725

---
- [Microsoft.CodeAnalysis.Common 3.8](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/3.8.0)
- [Microsoft.CodeAnalysis.Common 3.9 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/3.9.0/lib/netstandard2.0/diff/3.8.0)
- [Microsoft.CodeAnalysis.Common 4.0 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.0.1/lib/netstandard2.0/diff/3.11.0)
- [Microsoft.CodeAnalysis.Common 4.1 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.1.0/lib/netstandard2.0/diff/4.0.1)
- [Microsoft.CodeAnalysis.Common 4.2 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.2.0/lib/netstandard2.0/diff/4.1.0)
  - [Fix metadata references declaration #58059](https://github.com/dotnet/roslyn/pull/58059)
- [Microsoft.CodeAnalysis.Common 4.3 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.3.1/lib/netstandard2.0/diff/4.2.0)
  - [Higher Level SyntaxProvider APIs for incremental generators #54725](https://github.com/dotnet/roslyn/issues/54725)

#### [TOC](./Content.md)
