# Performance

- Cancellation via `CancellationToken`
  - `ThrowIfCancellationRequested()`
  - forward the CancellationToken parameter to methods that take one
- many syntax nodes = many invocations
  - `ISyntaxReceiver.OnVisitSyntaxNode(SyntaxNode)`
  - `ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext)`
- large projects / solutions

---
#### [TOC](./Content.md)
