namespace StringCalculator;
public class StringCalculator
{
    public static int Add(string input)
    {
        if (string.Empty == input) return 0;

        var delimiters = new string[] { ",", "\n" };
        if (input.StartsWith("//"))
        {
            // If we have a custom delimiter we want to replace the default delimiters
            // We also need to remove the initial input string portion that defines the delimiter from the processed string of numbers.
            delimiters = new string[] { ExtractDelimiter(ref input) };
        }

        var splitTokens = input.Split(delimiters, StringSplitOptions.TrimEntries);
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
    
    private static string ExtractDelimiter(ref string input)
    {
        var endOfCustomDelimiter = input.IndexOf('\n');
        var delimiter = input[2..endOfCustomDelimiter];
        if (delimiter == string.Empty)
        {
            delimiter = "\n";
            endOfCustomDelimiter++;
        }

        // Everything that remains after the last delimiter character is actual input we want to process elsewhere
        input = input[(endOfCustomDelimiter + 1)..];

        return (delimiter);
    }
}
