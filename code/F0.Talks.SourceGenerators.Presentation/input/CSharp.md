# C# language features

## C# 9.0

> "Support for code generators"

- extensions to partial method syntax
  - allow explicit access modifier
  - may be non-`private`
  - may have a non-`void` return type
  - may have `out` parameters
- module initializers
  - must be static
  - must be parameterless
  - must return void
  - must not be a generic method
  - must not be contained in a generic class
  - must be accessible from the containing module
    - `internal` or `public`
    - no local function

## C# 11.0

> "Avoid name collisions"

- file-scoped types
  - `file` access modifier
  - on top-level types
  - accessibility is scoped to the declaring source file
    - also for nested types
  - enables shadowing of a non-`file`-local type by a `file`-local type
  - cannot be used in a member signature in non-`file`-local types
  - may implicitly implement a `file`-scoped interface type
    - see implementing less-accessible interfaces
  - `global using static` not permitted

---
#### References
- [partial method](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/partial-method)
- [ModuleInitializerAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.moduleinitializerattribute)
- [file keyword](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/file)
- [File-local types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/file-local-types)

#### [TOC](./Content.md)
