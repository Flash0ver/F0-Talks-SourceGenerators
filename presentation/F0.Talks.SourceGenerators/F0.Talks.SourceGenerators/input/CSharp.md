# C# 9.0

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

---
#### References
- [partial method](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/partial-method)
- [ModuleInitializerAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.moduleinitializerattribute)

#### [TOC](./Content.html)
