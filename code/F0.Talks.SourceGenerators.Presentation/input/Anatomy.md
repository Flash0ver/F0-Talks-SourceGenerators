# Anatomy

```
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis.Analyzers" Version="3.3.3" PrivateAssets="all" />
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="3.8.0" PrivateAssets="all" />
  </ItemGroup>
</Project>
```

### ISourceGenerator (deprecated)
```
[Generator]
internal sealed class MyGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context);
    public void Execute(GeneratorExecutionContext context);
}

internal sealed class MySyntaxReceiver : ISyntaxReceiver
{
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode);
}
```

### IIncrementalGenerator
```
[Generator(LanguageNames.CSharp)]
internal sealed class MyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context);
}
```

---
#### References
- [ISourceGenerator Interface](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isourcegenerator)
  - [GeneratorInitializationContext Struct](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.generatorinitializationcontext)
    - [ISyntaxReceiver Interface](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxreceiver)
    - [ISyntaxContextReceiver Interface](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxcontextreceiver)
  - [GeneratorExecutionContext Struct](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.generatorexecutioncontext)
- [IIncrementalGenerator Interface](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.iincrementalgenerator)
  - [IncrementalGeneratorInitializationContext Struct](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.incrementalgeneratorinitializationcontext)

#### [TOC](./Content.md)
