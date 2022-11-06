using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Roslyn.Generated;
using Xunit;

namespace F0.Gen.EqualityComparison.IntegrationTests;

public class EqualityComparerGeneratorIntegrationTests
{
    private readonly MyClass reference1 = new(1, "1");
    private readonly MyClass reference2 = new(1, "1");
    private readonly MyClass reference3 = new(2, "2");

    private readonly MyStruct value1 = new(1, "1");
    private readonly MyStruct value2 = new(1, "1");
    private readonly MyStruct value3 = new(2, "2");

    [Fact]
    public void EqualityComparer_Equals()
    {
        EqualityComparer<MyClass>.Default.Equals(reference1, reference2).Should().BeTrue();
        EqualityComparer<MyClass>.Default.Equals(reference1, reference3).Should().BeFalse();
        MyClassEqualityComparer.Instance.Equals(reference1, reference2).Should().BeTrue();
        MyClassEqualityComparer.Instance.Equals(reference1, reference3).Should().BeFalse();

        EqualityComparer<MyStruct>.Default.Equals(value1, value2).Should().BeTrue();
        EqualityComparer<MyStruct>.Default.Equals(value1, value3).Should().BeFalse();
        MyStructEqualityComparer.Instance.Equals(value1, value2).Should().BeTrue();
        MyStructEqualityComparer.Instance.Equals(value1, value3).Should().BeFalse();
    }

    [Fact]
    [SuppressMessage("BestPractice", "F01001:Prefer is pattern to check for null", Justification = "EqualityComparer`1")]
    public void EqualityComparer_Equals_Null()
    {
        (null == null).Should().BeTrue();

        EqualityComparer<MyClass>.Default.Equals(reference1, null).Should().BeFalse();
        EqualityComparer<MyClass>.Default.Equals(null, reference2).Should().BeFalse();
        EqualityComparer<MyClass>.Default.Equals(null, null).Should().BeTrue();
        MyClassEqualityComparer.Instance.Equals(reference1, null).Should().BeFalse();
        MyClassEqualityComparer.Instance.Equals(null, reference2).Should().BeFalse();
        MyClassEqualityComparer.Instance.Equals(null, null).Should().BeTrue();
    }

    [Fact]
    public void EqualityComparer_GetHashCode()
    {
        EqualityComparer<MyClass>.Default.GetHashCode(reference1).Should().Be(EqualityComparer<MyClass>.Default.GetHashCode(reference2));
        EqualityComparer<MyClass>.Default.GetHashCode(reference1).Should().NotBe(EqualityComparer<MyClass>.Default.GetHashCode(reference3));
        MyClassEqualityComparer.Instance.GetHashCode(reference1).Should().Be(MyClassEqualityComparer.Instance.GetHashCode(reference2));
        MyClassEqualityComparer.Instance.GetHashCode(reference1).Should().NotBe(MyClassEqualityComparer.Instance.GetHashCode(reference3));

        EqualityComparer<MyStruct>.Default.GetHashCode(value1).Should().Be(EqualityComparer<MyStruct>.Default.GetHashCode(value2));
        EqualityComparer<MyStruct>.Default.GetHashCode(value1).Should().NotBe(EqualityComparer<MyStruct>.Default.GetHashCode(value3));
        MyStructEqualityComparer.Instance.GetHashCode(value1).Should().Be(MyStructEqualityComparer.Instance.GetHashCode(value2));
        MyStructEqualityComparer.Instance.GetHashCode(value1).Should().NotBe(MyStructEqualityComparer.Instance.GetHashCode(value3));
    }

    [Fact]
    public void EqualityComparer_GetHashCode_Null()
    {
        EqualityComparer<MyClass>.Default.GetHashCode(null!).Should().Be(0);
        MyClassEqualityComparer.Instance.GetHashCode(null!).Should().Be(0);
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
