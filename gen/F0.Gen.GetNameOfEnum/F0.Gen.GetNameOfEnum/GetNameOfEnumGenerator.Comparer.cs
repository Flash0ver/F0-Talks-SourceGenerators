using System.Collections.Immutable;

namespace F0.Gen.GetNameOfEnum;

internal partial class GetNameOfEnumGenerator
{
    private sealed class MyEqualityComparer : IEqualityComparer<(string methodName, string modifiers, string enumType, string paramName, string keyword, bool isNullable, ImmutableArray<string> constants, string typeName, string nameSpace, bool isGlobal)>
    {
        public static MyEqualityComparer Instance { get; } = new MyEqualityComparer();

        private MyEqualityComparer() { }

        public bool Equals((string methodName, string modifiers, string enumType, string paramName, string keyword, bool isNullable, ImmutableArray<string> constants, string typeName, string nameSpace, bool isGlobal) x, (string methodName, string modifiers, string enumType, string paramName, string keyword, bool isNullable, ImmutableArray<string> constants, string typeName, string nameSpace, bool isGlobal) y)
        {
            return x.Item1 == y.Item1 && x.Item2 == y.Item2 && x.Item3 == y.Item3 && x.Item4 == y.Item4 && x.Item5 == y.Item5 && x.Item6 == y.Item6 && x.Item7.SequenceEqual(y.Item7) && x.Rest.Equals(y.Rest);
        }

        public int GetHashCode((string methodName, string modifiers, string enumType, string paramName, string keyword, bool isNullable, ImmutableArray<string> constants, string typeName, string nameSpace, bool isGlobal) obj)
        {
            return HashCode.Combine(obj.Item1, obj.Item2, obj.Item3, obj.Item4, obj.Item5, obj.Item6, obj.Item7, obj.Rest);
        }
    }
}
