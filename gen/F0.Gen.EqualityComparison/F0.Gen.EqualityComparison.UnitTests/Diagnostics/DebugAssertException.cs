#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;

namespace F0.Gen.EqualityComparison.UnitTests.Diagnostics;

[SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Debug.Assert on .NET Framework")]
[SuppressMessage("Design", "CA1064:Exceptions should be public", Justification = "Debug.Assert on .NET Framework")]
internal sealed class DebugAssertException : Exception
{
    public DebugAssertException(string? message)
        : base(message)
    {
    }
}
#endif
