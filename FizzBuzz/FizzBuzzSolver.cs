namespace FizzBuzz;
public class FizzBuzzSolver
{
    /// <summary>
    /// Calculates the result of FizzBuzz for the particular number provided.
    /// </summary>
    /// <returns>"Fizz" if the number is a multiple of three, "Buzz" if the number is a multiple of five and "FizzBuzz" if the number is a multiple of both three and five, otherwise returns the number.</returns>
    public static string FizzBuzz(int number)
    {
        if (number == 0) return "0";

        bool isMultipleOfThree = number % 3 == 0;
        bool isMultipleOfFive = number % 5 == 0;

        if (isMultipleOfThree && isMultipleOfFive) return "FizzBuzz";

        if (isMultipleOfThree) return "Fizz";
        else if (isMultipleOfFive) return "Buzz";

        return number.ToString();
    }
}
