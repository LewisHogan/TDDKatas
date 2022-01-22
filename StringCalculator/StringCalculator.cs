namespace StringCalculator;
public class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.Empty == numbers) return 0;

        var delimiters = new string[] { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            // If a custom delimiter is specified it means we don't use the default options anymore, and it also means we need
            // to preprocess the input string a bit
            var endOfCustomDelimiter = numbers.IndexOf("\n");
            delimiters = new string[] { numbers[2..endOfCustomDelimiter] };
            numbers = numbers[(endOfCustomDelimiter + 1)..];
        }

        var splitTokens = numbers.Split(delimiters.ToArray(), StringSplitOptions.TrimEntries);
        if (splitTokens.Any(token => token == string.Empty))
        {
            throw new ArgumentException("Multiple consecutive delimiters not allowed");
        }

        // Remove all non integers see if we have anything left, in which case we had invalid delimiters
        var invalidTokens = splitTokens.Where(token => !int.TryParse(token, out _));
        if (invalidTokens.Any())
        {
            throw new ArgumentException($"Invalid delimiters not allowed: { string.Join(", ", invalidTokens) }");
        }
        

        var integers = splitTokens.Select(number => int.Parse(number));
        var invalidNumbers = integers.Where(number => number < 0);
        if (invalidNumbers.Any())
        {
            throw new ArgumentException($"Negative number not allowed: { string.Join(", ", invalidNumbers) }");
        }

        return integers.Where(number => number <= 1000).Sum();
    }
}
