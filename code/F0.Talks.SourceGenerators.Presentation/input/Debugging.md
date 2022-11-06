# Debugging

Visual Studio 2019 [16.10](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes-v16.10) or greater

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
#### [TOC](./Content.md)
