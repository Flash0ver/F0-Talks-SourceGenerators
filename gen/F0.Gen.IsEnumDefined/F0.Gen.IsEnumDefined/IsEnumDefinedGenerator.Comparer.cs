using System.Diagnostics;

namespace F0.Gen.IsEnumDefined;

internal sealed partial class IsEnumDefinedGenerator
{
    private static readonly IsEnumDefinedTypeEqualityComparer _comparer = IsEnumDefinedTypeEqualityComparer.Instance;

    private sealed class IsEnumDefinedTypeEqualityComparer : IEqualityComparer<IsEnumDefinedType>
    {
        private IsEnumDefinedTypeEqualityComparer() { }

        public static IsEnumDefinedTypeEqualityComparer Instance { get; } = new();

        public bool Equals(IsEnumDefinedType x, IsEnumDefinedType y)
        {
            return x.IsGlobalNamespace == y.IsGlobalNamespace
                && x.Namespace == y.Namespace
                && x.Name == y.Name
                && x.Methods.SequenceEqual(y.Methods, IsEnumDefinedMethodEqualityComparer.Instance);
        }

        public int GetHashCode(IsEnumDefinedType obj)
        {
            throw new UnreachableException();
        }
    }

    private sealed class IsEnumDefinedMethodEqualityComparer : IEqualityComparer<IsEnumDefinedMethod>
    {
        private IsEnumDefinedMethodEqualityComparer() { }

        public static IsEnumDefinedMethodEqualityComparer Instance { get; } = new();

        public bool Equals(IsEnumDefinedMethod x, IsEnumDefinedMethod y)
        {
            return x.EnumName == y.EnumName
                && x.EnumConstants.SequenceEqual(y.EnumConstants);
        }

        public int GetHashCode(IsEnumDefinedMethod obj)
        {
            throw new UnreachableException();
        }
    }
}
