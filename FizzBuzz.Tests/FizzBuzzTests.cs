using Xunit;

namespace FizzBuzz.Tests;

public class FizzBuzzTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(23)]
    [InlineData(23482)]
    [InlineData(-23482)]
    [InlineData(-482)]
    [InlineData(-391)]
    public void FizzBuzz_NonThreeOrFiveNumber_ReturnsNumberAsString(int number)
        => Assert.Equal(number.ToString(), FizzBuzzSolver.FizzBuzz(number));

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    [InlineData(18)]
    [InlineData(21)]
    [InlineData(333)]
    [InlineData(-3)]
    [InlineData(-9)]
    public void FizzBuzz_MultipleOfThreeNotFiveNumber_ReturnsFizz(int number)
        => Assert.Equal("Fizz", FizzBuzzSolver.FizzBuzz(number));

    [Theory]
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(25)]
    [InlineData(35)]
    [InlineData(55)]
    [InlineData(395)]
    [InlineData(-5)]
    [InlineData(-523235)]
    public void FizzBuzz_MultipleOfFiveButNotThreeNumber_ReturnsBuzz(int number)
        => Assert.Equal("Buzz", FizzBuzzSolver.FizzBuzz(number));

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    [InlineData(-90)]
    [InlineData(-3090)]
    public void FizzBuzz_MultipleOfThreeAndFiveNumber_ReturnsFizzBuzz(int number)
        => Assert.Equal("FizzBuzz", FizzBuzzSolver.FizzBuzz(number));
}