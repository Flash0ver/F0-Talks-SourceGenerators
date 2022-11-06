using System.Diagnostics.CodeAnalysis;

namespace F0.Gen.Extern;

public sealed class TopLevelType
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
