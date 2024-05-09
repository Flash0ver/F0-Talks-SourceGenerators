# .NET Generators

## .NET 6.0

- System.Text.Json | [Source](https://source.dot.net/#q=System.Text.Json.SourceGeneration.JsonSourceGenerator) | [Documentation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)
- Microsoft.Extensions.Logging.Abstractions | [Source](https://source.dot.net/#q=Microsoft.Extensions.Logging.Generators.LoggerMessageGenerator) | [Documentation](https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator)
- Blazor | [Blog](https://andrewlock.net/using-source-generators-with-blazor-in-dotnet-6/)

## .NET 7.0

- System.Text.RegularExpressions | [Source](https://source.dot.net/#q=System.Text.RegularExpressions.Generator.RegexGenerator) | [Documentation](https://learn.microsoft.com/dotnet/standard/base-types/regular-expression-source-generators)
- System.Runtime.InteropServices | [Source](https://source.dot.net/#q=Microsoft.Interop.LibraryImportGenerator) | [Documentation](https://learn.microsoft.com/dotnet/standard/native-interop/pinvoke-source-generation)
- System.Runtime.InteropServices.JavaScript
  - JSImportGenerator | [Source](https://source.dot.net/#q=Microsoft.Interop.JavaScript.JSImportGenerator)
  - JSExportGenerator | [Source](https://source.dot.net/#q=Microsoft.Interop.JavaScript.JSExportGenerator)

## .NET 8.0
- Microsoft.AspNetCore.Http.RequestDelegateGenerator | [Source](https://source.dot.net/#q=Microsoft.AspNetCore.Http.RequestDelegateGenerator.RequestDelegateGenerator)
- Configuration-binding source generator | [Source](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Configuration.Binder/gen/ConfigurationBindingGenerator.cs)
  - `<EnableConfigurationBindingGenerator>true</EnableConfigurationBindingGenerator>`
- Source-generated COM interop | [YouTube](https://www.youtube.com/watch?v=DZd1SGd7dSU)

---
#### [TOC](./Content.md)
