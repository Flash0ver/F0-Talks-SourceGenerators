# Nullable reference types

- C# 8.0 vs .NET Standard 2.0
  - [C# language versioning](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version)

```
  <PropertyGroup>
    <TargetFrameworks>net6.0;netstandard2.0</TargetFrameworks>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
  </PropertyGroup>
```

```
  <ItemGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
    <PackageReference Include="Nullable" Version="1.3.0" PrivateAssets="all" />
  </ItemGroup>
```

```
  <PropertyGroup Condition="'$(TargetFramework)' == 'netstandard2.0'">
    <NoWarn>$(NoWarn);nullable</NoWarn>
  </PropertyGroup>
```

---
#### [TOC](./Content.html)
