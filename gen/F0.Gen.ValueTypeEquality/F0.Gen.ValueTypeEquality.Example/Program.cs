namespace F0.Gen.ValueTypeEquality.Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        HashSet<MyStruct> set = new();

        MyStruct value1 = new(2022, "2022");
        MyStruct value2 = new(2022, "2022");

        set.Add(value1);
        set.Add(value2);

        Console.WriteLine($"{nameof(set.Count)}: {set.Count}");
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
