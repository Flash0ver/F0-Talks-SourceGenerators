namespace F0.Gen.Extern;

public sealed class SealedType : DerivedType
{
}

public class DerivedType : AbstractType
{
    public override int AbstractProperty { get; init; }
    public override int VirtualProperty { get; init; }
}

public abstract class AbstractType
{
    public abstract int AbstractProperty { get; init; }
    public virtual int VirtualProperty { get; init; }
}
