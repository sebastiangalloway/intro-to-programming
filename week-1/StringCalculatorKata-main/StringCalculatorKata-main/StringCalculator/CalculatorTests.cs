

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
    [InlineData("-100000", -100000)]
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
    [InlineData("-10,20,30", 40)]
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
}
