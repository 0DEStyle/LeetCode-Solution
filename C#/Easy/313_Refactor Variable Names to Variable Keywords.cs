/*Challenge link:https://www.codewars.com/kata/670d95c03ad7c741c1099b83/train/csharp
Question:
Information
Define the following 13 variables:
bool, char, sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal

The type of each variable must be the same as the name.
The values don't matter.

Examples:
bool bool = false;
char char = '\0';
sbyte sbyte = 0;
...
*/

//***************Solution********************


public class VariableName{
    public bool @bool = false;
    public char @char = '\0';
    public sbyte @sbyte = 0;
    public byte @byte = 0;
    public short @short = 0;
    public ushort @ushort = 0;
    public int @int = 0;
    public uint @uint = 0;
    public long @long = 0;
    public ulong @ulong = 0;
    public float @float = 0;
    public double @double = 0;
    public decimal @decimal = 0;
}


//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class VariableNameExampleTests
{
    [Test]
    public void TestBoolVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "bool", typeof(bool)));
    }

    [Test]
    public void TestCharVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "char", typeof(char)));
    }

    [Test]
    public void TestSbyteVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "sbyte", typeof(sbyte)));
    }

    [Test]
    public void TestByteVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "byte", typeof(byte)));;
    }

    [Test]
    public void TestShortVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "short", typeof(short)));
    }

    [Test]
    public void TestUshortVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "ushort", typeof(ushort)));
    }

    [Test]
    public void TestIntVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "int", typeof(int)));
    }

    [Test]
    public void TestUintVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "uint", typeof(uint)));
    }

    [Test]
    public void TestLongVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "long", typeof(long)));
    }

    [Test]
    public void TestUlongVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "ulong", typeof(ulong)));
    }

    [Test]
    public void TestFloatVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "float", typeof(float)));
    }

    [Test]
    public void TestDoubleVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "double", typeof(double)));
    }

    [Test]
    public void TestDecimalVariable()
    {
        VariableName variables = new VariableName();
        Assert.IsTrue(CheckType(variables, "decimal", typeof(decimal)));
    }

    private bool CheckType(object obj, string fieldName, Type expectedType)
    {
        var field = obj.GetType().GetField(fieldName);
        if (field == null) return false;

        return field.FieldType == expectedType;
    }

}
