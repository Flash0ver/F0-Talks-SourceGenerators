# Performance

- Cancellation via `CancellationToken`
- many syntax nodes = many invocations
  - `ISyntaxReceiver.OnVisitSyntaxNode(SyntaxNode)`
  - `ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext)`
- large projects / solutions

---
#### [TOC](./Content.html)
