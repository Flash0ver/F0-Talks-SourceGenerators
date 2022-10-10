using BenchmarkDotNet.Attributes;

namespace F0.Gen.ValueTypeEquality.IntegrationBenchmarks;

/// <summary>
/// <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type">How to define value equality for a class or struct (C# Programming Guide)</see>
/// <seealso href="https://devblogs.microsoft.com/premier-developer/performance-implications-of-default-struct-equality-in-c/">Performance implications of default struct equality in C#</seealso>
/// </summary>
[MemoryDiagnoser]
public class ValueTypeBenchmarks
{
    private HashSet<MyStruct> defaultEqualitySet = null!;
    private HashSet<MyRecordStruct> recordEqualitySet = null!;

    private MyStruct defaultEqualityValue;
    private MyRecordStruct recordEqualityValue;

    [GlobalSetup]
    public void Setup()
    {
        defaultEqualitySet = new HashSet<MyStruct>();
        recordEqualitySet = new HashSet<MyRecordStruct>();

        defaultEqualitySet.Add(new MyStruct(1, "1"));
        recordEqualitySet.Add(new MyRecordStruct(1, "1"));

        defaultEqualityValue = new MyStruct(1, "2");
        recordEqualityValue = new MyRecordStruct(1, "2");
    }

    [Benchmark]
    public bool Implicit()
    {
        return defaultEqualitySet.Contains(defaultEqualityValue);
    }

    [Benchmark]
    public bool Explicit()
    {
        return recordEqualitySet.Contains(recordEqualityValue);
    }
}

internal readonly struct MyStruct
{
    public MyStruct(int number, string text)
    {
        Number = number;
        Text = text;
    }

    public int Number { get; init; }
    public string Text { get; init; }
}

internal readonly record struct MyRecordStruct(int Number, string Text);
