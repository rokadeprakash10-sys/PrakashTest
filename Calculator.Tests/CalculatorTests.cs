using Xunit;
using PrakashTest.Calculator;

namespace PrakashTest.Calculator.Tests;

public class CalculatorTests
{
    private readonly Calculator _calc = new();

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Add_ReturnsCorrectSum(double a, double b, double expected)
        => Assert.Equal(expected, _calc.Add(a, b));

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 5, -5)]
    [InlineData(-4, -4, 0)]
    public void Subtract_ReturnsCorrectDifference(double a, double b, double expected)
        => Assert.Equal(expected, _calc.Subtract(a, b));

    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(-2, 5, -10)]
    [InlineData(0, 100, 0)]
    public void Multiply_ReturnsCorrectProduct(double a, double b, double expected)
        => Assert.Equal(expected, _calc.Multiply(a, b));

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(-9, 3, -3)]
    [InlineData(7, 2, 3.5)]
    public void Divide_ReturnsCorrectQuotient(double a, double b, double expected)
        => Assert.Equal(expected, _calc.Divide(a, b));

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));

    [Theory]
    [InlineData(10, 3, 1)]
    [InlineData(9, 3, 0)]
    public void Modulo_ReturnsCorrectRemainder(double a, double b, double expected)
        => Assert.Equal(expected, _calc.Modulo(a, b));

    [Fact]
    public void Modulo_ByZero_ThrowsDivideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => _calc.Modulo(10, 0));
}
