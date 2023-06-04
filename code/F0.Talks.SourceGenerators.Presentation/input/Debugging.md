# Debugging

- Visual Studio 2019 [16.10](https://learn.microsoft.com/visualstudio/releases/2019/release-notes-v16.10) or greater
- Rider [2023.1](https://www.jetbrains.com/rider/whatsnew/2023-1/)

```
  <PropertyGroup>
    <IsRoslynComponent>true</IsRoslynComponent>
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
      PrivateAssets="all"
      ReferenceOutputAssembly="false"
      OutputItemType="Analyzer"
      SetTargetFramework="TargetFramework=netstandard2.0" />
  </ItemGroup>
```

---
- [Debugging C# Source Generators with Visual Studio 2019 16.10](https://stevetalkscode.co.uk/debug-source-generators-with-vs2019-1610)

#### [TOC](./Content.md)
