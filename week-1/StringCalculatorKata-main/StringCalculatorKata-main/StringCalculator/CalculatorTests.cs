

using NSubstitute.Core;

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    public void CanAddSingleNumber(string value, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,", 1)]
    [InlineData("10,20,30", 60)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void CanAddMultipleNumbers(string values, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(values);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    [InlineData("//#\n1#2#3", 6)]
    public void CanUseMultipleDelimiters(string values, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(values);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,-2,3")]
    [InlineData("-1,2,-3")]

    public void ThrowsWhenNegative(string values)
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.Add(values));
    }


    [Theory]
    [InlineData("1,-2,3", "-2")]
    [InlineData("-1,2,-3", "-1, -3")]
    [InlineData("//;\n1;-2", "-2")]
    public void ThrowsMessageWhenNegative(string values, string expectedMessage)
    {
        var calculator = new Calculator();
        var exception = Assert.Throws<ArgumentException>(() => calculator.Add(values));
        Assert.Equal(expectedMessage, exception.Message);
    }


    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,", 1)]
    [InlineData("10,2000,30", 40)]
    [InlineData("1000,2", 1002)]
    [InlineData("1,2,3,4,5,6,7,8,9000", 36)]
    public void IgnoreOver1000(string values, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(values);
        Assert.Equal(expected, result);
    }



    [Theory]
    [InlineData("\"//[***]", 3)]
    [InlineData("//#\n1#2,3\n1", 7)]
    [InlineData("//#\n1#2#3", 6)]
    public void CanUseStringDelimiters(string values, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(values);
        Assert.Equal(expected, result);
    }
}