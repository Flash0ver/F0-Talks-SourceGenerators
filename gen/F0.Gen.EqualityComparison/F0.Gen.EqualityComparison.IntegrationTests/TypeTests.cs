using FluentAssertions;
using Xunit;

namespace F0.Gen.EqualityComparison.IntegrationTests;

public class TypeTests
{
    [Fact]
    public void Type_BaseType()
    {
        typeof(MyClass).BaseType.Should().Be(typeof(object));
        typeof(MyClass).BaseType!.BaseType.Should().BeNull();

        typeof(MyStruct).BaseType.Should().Be(typeof(ValueType));
        typeof(MyStruct).BaseType!.BaseType.Should().Be(typeof(object));
        typeof(MyStruct).BaseType!.BaseType!.BaseType.Should().BeNull();
    }
}
