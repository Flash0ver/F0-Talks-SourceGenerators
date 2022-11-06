namespace F0.Gen.Extern;

internal class InternalClass
{
    private string writeOnlyProperty;

    public InternalClass(string value)
    {
        (PublicProperty, ProtectedProperty, InternalProperty, ProtectedInternalProperty, PrivateProperty, PrivateProtectedProperty) = (value, value, value, value, value, value);
        writeOnlyProperty = nameof(WriteOnlyProperty);
    }

    public static string StaticProperty { get; }
    public string PublicProperty { get; init; }
    protected string ProtectedProperty { get; init; }
    internal string InternalProperty { get; init; }
    protected internal string ProtectedInternalProperty { get; init; }
    private string PrivateProperty { get; init; }
    private protected string PrivateProtectedProperty { get; init; }
    public string WriteOnlyProperty { init => writeOnlyProperty = value; }
}
