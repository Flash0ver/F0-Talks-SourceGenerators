namespace F0.Gen.Extern;

public readonly record struct PublicStruct
{
    public PublicStruct(int number, string text)
    {
        Number = number;
        Text = text;
    }

    public int Number { get; init; }
    public string Text { get; init; }
}
