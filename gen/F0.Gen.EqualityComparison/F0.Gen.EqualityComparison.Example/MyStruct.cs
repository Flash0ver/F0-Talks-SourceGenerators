namespace F0.Gen.EqualityComparison.Example;

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
