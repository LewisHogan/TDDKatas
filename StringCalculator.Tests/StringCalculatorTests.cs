using System;

using Xunit;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_EmptyString_ReturnsZero()
        => Assert.Equal(0, StringCalculator.Add(""));

    [Theory]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(41)]
    [InlineData(912)]
    [InlineData(234)]
    public void Add_SingleNumber_ReturnsNumber(int number)
        => Assert.Equal(number, StringCalculator.Add(number.ToString()));

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("3,4", 7)]
    [InlineData("5,6", 11)]
    [InlineData("5,10", 15)]
    public void Add_TwoNumbers_ReturnsSumNumber(string input, int expectedOutput)
        => Assert.Equal(expectedOutput, StringCalculator.Add(input));

    [Theory]
    [InlineData("1;2", "Invalid delimiters not allowed: 1;2")]
    public void Add_InvalidDelimiter_ThrowsException(string input, string exceptionMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
        Assert.Equal(exceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4", 10)]
    [InlineData("1,2,3,4,5", 15)]
    public void Add_VaryingAmountsOfNumbers_ReturnsSumNumber(string input, int expectedOutput)
        => Assert.Equal(expectedOutput, StringCalculator.Add(input));

    [Theory]
    [InlineData("1", 1)]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2\n3", 6)]
    [InlineData("1\n2\n3\n4", 10)]
    [InlineData("1\n2\n3\n4\n5", 15)]
    public void Add_NumbersWithNewlineDelimiter_ReturnsSumNumber(string input, int expectedOutput)
        => Assert.Equal(expectedOutput, StringCalculator.Add(input));

    [Theory]
    [InlineData("1,\n3")]
    [InlineData("0\n,1")]
    public void Add_ConsecutiveDelimiters_ThrowsException(string input)
    {
        var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
        Assert.Equal("Multiple consecutive delimiters not allowed", exception.Message);
    }

    [Theory]
    [InlineData("//;\n1;3", 4)]
    [InlineData("//|\n1|2|3", 6)]
    [InlineData("//sep\n2sep5", 7)]
    public void Add_CustomDelimiter_ReturnsSumNumber(string input, int expectedOutput)
        => Assert.Equal(expectedOutput, StringCalculator.Add(input));

    [Theory]
    [InlineData("-1,3,4", "Negative number not allowed: -1")]
    [InlineData("0,-3,4", "Negative number not allowed: -3")]
    [InlineData("0\n-6,-4", "Negative number not allowed: -6, -4")]
    public void Add_NegativeNumbers_ThrowsException(string input, string exceptionMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
        Assert.Equal(exceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData("1100,2", 2)]
    [InlineData("3,4,1003", 7)]
    [InlineData("5,6, 9999", 11)]
    [InlineData("5,2310", 5)]
    public void Add_LargerThan1000Numbers_ReturnsSumIgnoringLargeNumbers(string input, int expectedOutput)
        => Assert.Equal(expectedOutput, StringCalculator.Add(input));
}