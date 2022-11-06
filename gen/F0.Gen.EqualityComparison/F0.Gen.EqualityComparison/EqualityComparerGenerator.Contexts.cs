using System.Collections.Immutable;

namespace F0.Gen.EqualityComparison;

internal sealed partial class EqualityComparerGenerator
{
    private readonly record struct EqualityComparerContext(string? Namespace, string Name, CompareTypeContext CompareType);
    private readonly record struct CompareTypeContext(bool IsReferenceType, string QualifiedName, ImmutableArray<PropertyContext> Properties);
    private readonly record struct PropertyContext(string Type, string Name);

    private sealed class EqualityComparerContextEqualityComparer : IEqualityComparer<EqualityComparerContext>
    {
        private EqualityComparerContextEqualityComparer() { }

        public static EqualityComparerContextEqualityComparer Instance { get; } = new EqualityComparerContextEqualityComparer();

        public bool Equals(EqualityComparerContext x, EqualityComparerContext y)
        {
            return x.Namespace == y.Namespace
                && x.Name == y.Name
                && CompareTypeContextEqualityComparer.Instance.Equals(x.CompareType, y.CompareType);
        }

        public int GetHashCode(EqualityComparerContext obj)
        {
            throw new NotImplementedException();
        }
    }

    private sealed class CompareTypeContextEqualityComparer : IEqualityComparer<CompareTypeContext>
    {
        private CompareTypeContextEqualityComparer() { }

        public static CompareTypeContextEqualityComparer Instance { get; } = new CompareTypeContextEqualityComparer();

        public bool Equals(CompareTypeContext x, CompareTypeContext y)
        {
            return x.IsReferenceType == y.IsReferenceType
                && x.QualifiedName == y.QualifiedName
                && x.Properties.SequenceEqual(y.Properties, PropertyContextEqualityComparer.Instance);
        }

        public int GetHashCode(CompareTypeContext obj)
        {
            throw new NotImplementedException();
        }
    }

    private sealed class PropertyContextEqualityComparer : IEqualityComparer<PropertyContext>
    {
        private PropertyContextEqualityComparer() { }

        public static PropertyContextEqualityComparer Instance { get; } = new PropertyContextEqualityComparer();

        public bool Equals(PropertyContext x, PropertyContext y)
        {
            return x.Type == y.Type
                && x.Name == y.Name;
        }

        public int GetHashCode(PropertyContext obj)
        {
            throw new NotImplementedException();
        }
    }
}
