using BenchmarkDotNet.Attributes;
using F0.CodeAnalysis.CSharp.Benchmarking;

namespace F0.Gen.GetNameOfEnum.Benchmarks;

public class GetNameOfEnumGeneratorBenchmarks
{
    private readonly CSharpIncrementalGeneratorBenchmark<GetNameOfEnumGenerator> benchmark = new();

    [GlobalSetup]
    public void Setup()
    {
        string code = @"#nullable enable
using System;
using System.IO;
using Roslyn.Generated;

public readonly partial struct Global
{
    [GetNameOfEnum]
    public partial string? @GetName(FileAccess access);
}

namespace @MyNamespace.@Tests
{
    public partial class @EnumInfo
    {
        [GetNameOfEnum]
        public partial string? @GetName1(StringComparison value);
    }

    public sealed partial class @EnumInfo
    {
        [@GetNameOfEnumAttribute()]
        public static partial System.String @GetName2(DateTimeKind @val);
    }
}
";

        benchmark.Initialize(new CSharpIncrementalGeneratorBenchmarkInitializationContext
        {
            Source = code,
        });
    }

    [Benchmark]
    public object Generate()
    {
        return benchmark.Invoke();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        string attribute = @"// <auto-generated/>
#nullable enable

namespace Roslyn.Generated;

[global::System.CodeDom.Compiler.GeneratedCodeAttribute(""F0.Gen.GetNameOfEnum"", ""1.0.0.0"")]
[global::System.AttributeUsage(global::System.AttributeTargets.Method, AllowMultiple = false)]
internal sealed class GetNameOfEnumAttribute : global::System.Attribute
{
}
";

        string global = @"// <auto-generated/>
#nullable enable

partial struct Global
{
    public partial string? GetName(global::System.IO.FileAccess access)
    {
        return access switch
        {
            global::System.IO.FileAccess.Read => nameof(global::System.IO.FileAccess.Read),
            global::System.IO.FileAccess.Write => nameof(global::System.IO.FileAccess.Write),
            global::System.IO.FileAccess.ReadWrite => nameof(global::System.IO.FileAccess.ReadWrite),
            _ => null,
        };
    }
}
";

        string generated = @"// <auto-generated/>
#nullable enable

namespace MyNamespace.Tests;

partial class EnumInfo
{
    public partial string? GetName1(global::System.StringComparison value)
    {
        return value switch
        {
            global::System.StringComparison.CurrentCulture => nameof(global::System.StringComparison.CurrentCulture),
            global::System.StringComparison.CurrentCultureIgnoreCase => nameof(global::System.StringComparison.CurrentCultureIgnoreCase),
            global::System.StringComparison.InvariantCulture => nameof(global::System.StringComparison.InvariantCulture),
            global::System.StringComparison.InvariantCultureIgnoreCase => nameof(global::System.StringComparison.InvariantCultureIgnoreCase),
            global::System.StringComparison.Ordinal => nameof(global::System.StringComparison.Ordinal),
            global::System.StringComparison.OrdinalIgnoreCase => nameof(global::System.StringComparison.OrdinalIgnoreCase),
            _ => null,
        };
    }

    public static partial string GetName2(global::System.DateTimeKind val)
    {
        return val switch
        {
            global::System.DateTimeKind.Unspecified => nameof(global::System.DateTimeKind.Unspecified),
            global::System.DateTimeKind.Utc => nameof(global::System.DateTimeKind.Utc),
            global::System.DateTimeKind.Local => nameof(global::System.DateTimeKind.Local),
            _ => null!,
        };
    }
}
";

        benchmark.Inspect(new CSharpIncrementalGeneratorBenchmarkInspectionContext
        {
            Source = ("Roslyn.Generated.GetNameOfEnumAttribute.g.cs", attribute),
            AdditionalSources =
            {
                ("Global.GetNameOfEnum.g.cs", global),
                ("MyNamespace.Tests.EnumInfo.GetNameOfEnum.g.cs", generated),
            },
        });
    }
}
