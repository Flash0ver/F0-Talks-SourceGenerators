# Laws of Source Generation

- retrieve compilation representing user code
  - with syntax trees
  - with semantic models
- new source code can be added to the compilation as additional source code
  - `0..n`
  - as strings
- additive only
- can produce diagnostics
- may access access additional files (non-C# source texts)
- un-ordered
  - no access to files created by other source generators
- are technically analyzers

## Use cases
- avoid tedious boilerplate (error-prone) code written manual
- avoid _Reflection_ with high-performance code

---
- [Source Generators](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview)
- [Design Document](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.md)
- [Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)

#### [TOC](./Content.html)
