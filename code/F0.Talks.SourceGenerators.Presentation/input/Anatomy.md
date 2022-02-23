# Anatomy

```
  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis.Analyzers" Version="3.3.3" PrivateAssets="all" />
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="3.8.0" PrivateAssets="all" />
  </ItemGroup>
```

```
[Generator]
internal sealed class MyGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context);
    public void Execute(GeneratorExecutionContext context);
}
```

```
internal sealed class MySyntaxReceiver : ISyntaxReceiver
{
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode);
}
```

---
#### [TOC](./Content.md)
