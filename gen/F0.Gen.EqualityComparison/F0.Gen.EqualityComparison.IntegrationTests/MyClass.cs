namespace F0.Gen.EqualityComparison.IntegrationTests;

internal sealed record class MyClass
{
    public MyClass(int number, string text)
    {
        Number = number;
        Text = text;
    }

    public int Number { get; init; }
    public string Text { get; init; }
}
