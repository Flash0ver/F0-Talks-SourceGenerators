#if NETFRAMEWORK
using System.Diagnostics;

namespace F0.Gen.GetNameOfEnum.UnitTests.Diagnostics
{
    internal sealed class DebugTraceListener : TraceListener
    {
        public DebugTraceListener()
            : base(nameof(Debug))
        {
        }

        public DebugTraceListener(string? name)
            : base(name)
        {
        }

        public override void Write(string? message)
            => throw new NotImplementedException($"{nameof(DebugTraceListener)}.{nameof(Write)}({nameof(String)})");

        public override void WriteLine(string? message)
            => throw new DebugAssertException(message);
    }
}
#endif
