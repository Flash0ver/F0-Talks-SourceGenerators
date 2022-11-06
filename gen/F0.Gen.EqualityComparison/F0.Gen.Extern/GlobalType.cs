using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "Demo")]
public sealed class GlobalType
{
    public int Number { get; init; }
    public string Text { get; init; }

    [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Demo")]
    public sealed class NestedType
    {
        public int Number { get; init; }
        public string Text { get; init; }
    }
}
