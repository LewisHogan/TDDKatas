using Xunit;
using System.Collections.Generic;
using System.Linq;
namespace CitySearch.Tests;

public class CitySearchTests
{

    private readonly string[] _cityNames = {
        "Paris", "Budapest", "Skopje", "Rotterdamn", "Valencia", "Vancouver",
        "Amsterdamn", "Vienna", "Sydney", "New York City", "London", "Bangkok",
        "Hong Kong", "Dubai", "Rome", "Istanbul"
    };

    private readonly CitySearch _citySearch;

    public CitySearchTests()
        => _citySearch = new CitySearch(_cityNames);

    [Fact]
    public void CitySearchCtor_ValidCityNames_IsNotNull()
    {
        var citySearch = new CitySearch(_cityNames);
        Assert.NotNull(citySearch);
    }

    [Theory]
    [InlineData("p")]
    [InlineData("z")]
    [InlineData("r")]
    public void CitySearch_SearchFewerThen2Chars_ReturnNothing(string searchString)
        => Assert.Empty(_citySearch.Search(searchString));

    [Theory]
    [InlineData("Va", new string[] { "Valencia", "Vancouver" })]
    [InlineData("Lon", new string[] { "London" })]
    public void CitySearch_SearchEnoughChars_ReturnCityNames(string searchString, string[] expectedResults)
        => Assert.Equal(expectedResults, _citySearch.Search(searchString));
    
    [Theory]
    [InlineData("va", new string[] { "Valencia", "Vancouver" })]
    [InlineData("LONd", new string[] { "London" })]
    public void CitySearch_IncorrectlyCasedNames_ReturnCityNames(string searchString, string[] expectedResults)
        => Assert.Equal(expectedResults, _citySearch.Search(searchString));

    [Theory]
    [InlineData("Va", new string[] { "Valencia", "Vancouver" })]
    [InlineData("London", new string[] { "London" })]
    public void CitySearch_CorrectlyCasedNames_ReturnCityNames(string searchString, string[] expectedResults)
        => Assert.Equal(expectedResults, _citySearch.Search(searchString));
    
    [Theory]
    [InlineData("lenc", new string[] { "Valencia" })]
    [InlineData("ndo", new string[] { "London" })]
    [InlineData("er", new string[] { "Rotterdamn", "Vancouver", "Amsterdamn" })]
    public void CitySearch_MiddleOfName_ReturnCityNames(string searchString, string[] expectedResults)
        => Assert.Equal(expectedResults, _citySearch.Search(searchString));

    [Fact]
    public void CitySearch_Asterisk_ReturnAllCityNames()
        => Assert.Equal(_cityNames, _citySearch.Search("*"));
}