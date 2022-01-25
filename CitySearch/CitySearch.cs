namespace CitySearch;

public class CitySearch
{
    private readonly ICollection<string> _cityNames;

    public CitySearch(ICollection<string> cityNames)
    {
        this._cityNames = cityNames;
    }

    public IEnumerable<string> Search(string input)
    {
        if (input == "*") return _cityNames.ToArray();
        if (input.Length < 2) return Enumerable.Empty<string>();

        input = input.ToLower();
        return _cityNames.Where(name =>
        {
            name = name.ToLower();
            return name.StartsWith(input) || name.Contains(input);
        });
    }
}
