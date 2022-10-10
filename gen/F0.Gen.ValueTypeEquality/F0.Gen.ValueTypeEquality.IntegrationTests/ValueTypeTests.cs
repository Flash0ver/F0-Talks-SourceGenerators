using System.Runtime.InteropServices;
using FluentAssertions;
using Xunit;

namespace F0.Gen.ValueTypeEquality.IntegrationTests;

/// <summary>
/// <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type">How to define value equality for a class or struct (C# Programming Guide)</see>
/// <seealso href="https://devblogs.microsoft.com/premier-developer/performance-implications-of-default-struct-equality-in-c/">Performance implications of default struct equality in C#</seealso>
/// </summary>
public class ValueTypeTests
{
    [Fact]
    public void StructureTypes_ImplicitlyInheritFrom_SystemValueType()
    {
        typeof(MyStruct).BaseType.Should().Be(typeof(ValueType));
        typeof(MyStruct).BaseType!.BaseType.Should().Be(typeof(object));
        typeof(MyStruct).BaseType!.BaseType!.BaseType.Should().BeNull();
    }

    [Fact]
    public void ValueEquality_UsesReflection()
    {
        MyStruct value1 = new(1, "1");
        MyStruct value2 = new(1, "2");

        value1.Equals(value2).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_HashCodeOfFirstNonStaticField()
    {
        MyStruct value1 = new(1, "1");
        MyStruct value2 = new(1, "2");

        int hashCode1 = value1.GetHashCode();
        int hashCode2 = value2.GetHashCode();

        hashCode1.Should().NotBe(hashCode2);
    }

    [Fact]
    public void GetHashCode_HashCollision()
    {
        MyStruct value1 = new(1, "1");
        MyStruct value2 = new(1, "2");

        HashSet<MyStruct> set = new();

        set.Add(value1).Should().BeTrue();
        set.Add(value2).Should().BeTrue();

        set.Should().HaveCount(2);
    }

    [Fact]
    public void SizeOf()
    {
        Marshal.SizeOf<MyStruct>().Should().Be(16);
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
