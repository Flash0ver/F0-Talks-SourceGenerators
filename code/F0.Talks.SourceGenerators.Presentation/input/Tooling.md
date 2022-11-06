# Tooling

- _Solution Explorer_ displays Roslyn generated sources
  - [Visual Studio 2019 16.9](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes-v16.9)
  - [Rider 2022.2](https://www.jetbrains.com/rider/whatsnew/2022-2/)
- _MSBuild_ properties: save the generated sources as files
  ```
  <PropertyGroup>
    <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
    <CompilerGeneratedFilesOutputPath>$(BaseIntermediateOutputPath)Generated</CompilerGeneratedFilesOutputPath>
  </PropertyGroup>
  ```
- [SharpLab (Syntax Tree)](https://sharplab.io/)
- [Visual Studio: Syntax Visualizer](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/syntax-visualizer)
  - [.NET Compiler Platform SDK](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/)
- [RoslynQuoter](https://roslynquoter.azurewebsites.net/)
- [Source Browser](https://sourceroslyn.io/)
- [Decompilation Differ](https://wengier.com/DecompilationDiffer/)

---
- [Saving source generator output in source control (Andrew Lock)](https://andrewlock.net/creating-a-source-generator-part-6-saving-source-generator-output-in-source-control/)

#### [TOC](./Content.md)
