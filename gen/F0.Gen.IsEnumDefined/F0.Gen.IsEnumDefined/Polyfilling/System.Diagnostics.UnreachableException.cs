using System.Diagnostics.CodeAnalysis;

#if NETSTANDARD2_0
// ReSharper disable once CheckNamespace
namespace System.Diagnostics;

[SuppressMessage("Design", "CA1064:Exceptions should be public")]
internal sealed class UnreachableException : Exception
{
    public UnreachableException()
        : base("The program executed an instruction that was thought to be unreachable.")
    {
    }

    public UnreachableException(string? message)
        : base(message)
    {
    }

    public UnreachableException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
#endif
