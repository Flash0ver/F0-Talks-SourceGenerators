# NuGet

- .NET Standard 2.0
- .NET Analyzers

```
  <PropertyGroup>
    <IncludeBuildOutput>false</IncludeBuildOutput>
    <SuppressDependenciesWhenPacking>true</SuppressDependenciesWhenPacking>
    <DevelopmentDependency>true</DevelopmentDependency>
  </PropertyGroup>
```

```
  <ItemGroup>
    <None Include="$(OutputPath)\netstandard2.0\$(AssemblyName).dll" Pack="true" PackagePath="analyzers/dotnet/cs" Visible="false" />
  </ItemGroup>
```

---
#### [TOC](./Content.md)
