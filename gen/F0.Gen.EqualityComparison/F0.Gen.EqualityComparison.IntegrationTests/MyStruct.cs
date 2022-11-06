namespace F0.Gen.EqualityComparison.IntegrationTests;

internal readonly record struct MyStruct
{
    public MyStruct(int number, string text)
    {
        Number = number;
        Text = text;
    }

    public int Number { get; init; }
    public string Text { get; init; }
}
