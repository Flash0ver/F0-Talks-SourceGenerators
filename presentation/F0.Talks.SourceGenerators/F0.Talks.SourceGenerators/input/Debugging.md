# Debugging

```
  <PropertyGroup>
    <IsRoslynComponent>true</IsRoslynComponent>
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
    <CompilerGeneratedFilesOutputPath>$(BaseIntermediateOutputPath)Generated</CompilerGeneratedFilesOutputPath>
  </PropertyGroup>
```

```
{
  "profiles": {
    "LaunchSettings": {
      "commandName": "DebugRoslynComponent",
      "targetProject": "..\\..\\src\\ConsoleApp240\\Consoleapp240.csproj"
    }
  }
}
```

```
  <ItemGroup>
    <ProjectReference
      Include="..\..\gen\MyGenerator\MyGenerator.csproj"
      PrivateAssets="all" ReferenceOutputAssembly="false"
      OutputItemType="Analyzer"
      SetTargetFramework="TargetFramework=netstandard2.0" />
  </ItemGroup>
```

---
#### [TOC](./Content.html)
