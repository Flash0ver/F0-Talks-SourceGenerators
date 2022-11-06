using BenchmarkDotNet.Attributes;
using Roslyn.Generated;

namespace F0.Gen.EqualityComparison.Example;

[MemoryDiagnoser]
public class EqualityComparisonBenchmarks
{
    private Dictionary<MyClass, string> referenceDictionary = null!;
    private Dictionary<MyStruct, string> valueDictionary = null!;

    private MyClass reference = null!;
    private MyStruct value = default!;

    [GlobalSetup]
    public void Setup()
    {
        referenceDictionary = new Dictionary<MyClass, string>();
        valueDictionary = new Dictionary<MyStruct, string>();

        referenceDictionary.Add(new MyClass(1, "1"), "Hello, World!");
        valueDictionary.Add(new MyStruct(1, "1"), "Hello, World!");

        reference = new MyClass(1, "1");
        value = new MyStruct(1, "1");
    }

    [Benchmark]
    public bool ReferenceType()
    {
        return referenceDictionary.TryGetValue(reference, out _);
    }

    [Benchmark]
    public bool ValueType()
    {
        return valueDictionary.TryGetValue(value, out _);
    }
}

[EqualityComparer(typeof(MyClass))]
internal partial class MyClassEqualityComparer
{
}

[EqualityComparer(typeof(MyStruct))]
internal partial class MyStructEqualityComparer
{
}
