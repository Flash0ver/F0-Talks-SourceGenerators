# Versioning

- Roslyn 3.8
  - `Microsoft.CodeAnalysis 3.8.0`
  - added [ISourceGenerator][isourcegenerator] and [ISyntaxReceiver][isyntaxreceiver]
  - .NET SDK 5.0.100
  - Visual Studio v16.8.0
  - Rider 2020.3
- Roslyn 3.9
  - `Microsoft.CodeAnalysis 3.9.0`
  - added [ISyntaxContextReceiver][isyntaxcontextreceiver] and PostInitialization
  - .NET SDK 5.0.200
  - Visual Studio v16.9.0
  - Rider 2021.2
- Roslyn 4.0
  - `Microsoft.CodeAnalysis 4.0.1`
  - added [IIncrementalGenerator][iincrementalgenerator]
  - .NET SDK 6.0.100
  - Visual Studio v17.0.0
  - Rider 2021.3
- Roslyn 4.2
  - `Microsoft.CodeAnalysis 4.2.0`
  - fixed [MetadataReferencesProvider][metadatareferencesprovider]
  - .NET SDK 6.0.300
  - Visual Studio v17.2.0
  - C# for Visual Studio Code v1.25.0
- Roslyn 4.3
  - `Microsoft.CodeAnalysis 4.3.1`
  - added [ForAttributeWithMetadataName][forattributewithmetadataname]
  - .NET SDK 6.0.400
  - Visual Studio v17.3.0
  - C# for Visual Studio Code v1.25.0

---
- [Microsoft.CodeAnalysis.Common 3.8](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/3.8.0)
- [Microsoft.CodeAnalysis.Common 3.9 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/3.9.0/lib/netstandard2.0/diff/3.8.0/)
- [Microsoft.CodeAnalysis.Common 4.0 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.0.1/lib/netstandard2.0/diff/3.11.0/)
- [Microsoft.CodeAnalysis.Common 4.2 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.2.0/lib/netstandard2.0/diff/4.1.0/)
  - [Fix metadata references declaration #58059](https://github.com/dotnet/roslyn/pull/58059)
- [Microsoft.CodeAnalysis.Common 4.3 API Diff](https://www.fuget.org/packages/Microsoft.CodeAnalysis.Common/4.3.1/lib/netstandard2.0/diff/4.2.0/)
  - [Higher Level SyntaxProvider APIs for incremental generators #54725](https://github.com/dotnet/roslyn/issues/54725)

#### [TOC](./Content.md)

[isourcegenerator]: https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.isourcegenerator
[isyntaxreceiver]: https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.isyntaxreceiver
[isyntaxcontextreceiver]: https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.isyntaxcontextreceiver
[iincrementalgenerator]: https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.iincrementalgenerator
[metadatareferencesprovider]: https://learn.microsoft.com/sr-latn-rs/dotnet/api/microsoft.codeanalysis.incrementalgeneratorinitializationcontext.metadatareferencesprovider
[forattributewithmetadataname]: https://learn.microsoft.com/sr-latn-rs/dotnet/api/microsoft.codeanalysis.syntaxvalueprovider.forattributewithmetadataname
