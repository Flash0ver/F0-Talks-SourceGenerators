# Nullable reference types

- C# 8.0 vs .NET Standard 2.0
  - [C# language versioning](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version)

```
  <PropertyGroup>
    <TargetFrameworks>net6.0;netstandard2.0</TargetFrameworks>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
  </PropertyGroup>
```

```
  <ItemGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
    <PackageReference Include="Nullable" Version="1.3.1" PrivateAssets="all" />
  </ItemGroup>
```

```
  <PropertyGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
    <NoWarn>$(NoWarn);nullable</NoWarn>
  </PropertyGroup>
```

---
- [Nullable Reference Types](https://learn.microsoft.com/dotnet/csharp/nullable-references)
- [Nullable Attributes](https://learn.microsoft.com/dotnet/csharp/language-reference/attributes/nullable-analysis)
- [Package: Nullable](https://www.nuget.org/packages/Nullable/)

#### [TOC](./Content.md)
