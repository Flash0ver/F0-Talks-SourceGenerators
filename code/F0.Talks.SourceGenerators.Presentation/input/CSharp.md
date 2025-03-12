# C# language features

## C# 2.0

- partial types

## C# 3.0

- partial methods
  - no accessibility modifiers
  - return `void`
  - no `out` parameters

## C# 9.0

> "Support for code generators"

- extended partial methods
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

## C# 12.0

- experimental Interceptors
  - `[InterceptsLocation]`
    ```CSharp
    namespace System.Runtime.CompilerServices
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
        {
        }
    }
    ```
  - ordinary Methods only
  - contained in non-generic type
  - one or more `[InterceptsLocation]` attributes
  - requires matching signatures
  - Static Methods or Extension Methods

## C# 13.0

- GA Interceptors
  - `[InterceptsLocation]`
    ```CSharp
    namespace System.Runtime.CompilerServices
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public sealed class InterceptsLocationAttribute(int version, string data) : Attribute
        {
        }
    }
    ```
- partial properties
  - must have a matching implementation part
- partial indexers
  - must have a matching implementation part

---
#### References
- [partial member](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/partial-member)
- [ModuleInitializerAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.moduleinitializerattribute)
- [file keyword](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/file)
- [File-local types](https://learn.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-11.0/file-local-types)
- [Interceptors](https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md)

#### [TOC](./Content.md)
