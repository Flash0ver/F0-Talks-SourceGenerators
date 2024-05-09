# Laws of Source Generation

- retrieve compilation representing user code
  - with syntax trees
  - with semantic models
- new source code can be added to the compilation as additional source code
  - `0..n`
  - as strings
- additive only
- can produce diagnostics
- may access additional files (non-C# source texts)
- oblivious
  - no access to documents created by other source generators
- are technically analyzers

## Use cases
- avoid tedious boilerplate (error-prone) code written manual
- avoid _Reflection_ with high-performance code
- facilitate _Trimming_ and _Native AOT_

---
- [Source Generators Documentation](https://learn.microsoft.com/dotnet/csharp/roslyn-sdk/source-generators-overview)
- [Source Generators Design Document](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.md)
- [Source Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)
- [Incremental Generators Design Document](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)
- [Incremental Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md)

#### [TOC](./Content.md)
