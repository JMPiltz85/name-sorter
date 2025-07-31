namespace name_sorter_test;

public class NameParserTest
{
    private name_sorter.NameParser parser = new name_sorter.NameParser();

    [Theory]
    [InlineData("Vaughn Lewis", "Vaughn")]
    [InlineData("Adonis Julius Archer", "Adonis")]
    [InlineData("Hunter Uriah Mathew Clarke", "Hunter")]
    public void getFirstName_ReturnCorrectNames(string fullName, string expected)
    {
        string firstName = parser.getFirstName(fullName);
        Assert.Equal(expected, firstName);
    }

    [Theory]
    [InlineData("Vaughn Lewis", "")]
    [InlineData("Adonis Julius Archer", "Julius")]
    [InlineData("Hunter Uriah Mathew Clarke", "Uriah Mathew")]
    public void getMiddleNames_ReturnCorrectNames(string fullName, string expected)
    {
        string middleNames = parser.getMiddleNames(fullName);
        Assert.Equal(expected, middleNames);
    }

    [Theory]
    [InlineData("Vaughn Lewis", "Lewis")]
    [InlineData("Adonis Julius Archer", "Archer")]
    [InlineData("Hunter Uriah Mathew Clarke", "Clarke")]
    public void getLastName_ReturnCorrectNames(string fullName, string expected)
    {
        string lastName = parser.getLastName(fullName);
        Assert.Equal(expected, lastName);
    }

    [Fact]
    public void handleEmptyName()
    {
        string fullName = "    ";

        string firstName = parser.getFirstName(fullName);

        Assert.Equal("", firstName);

    }


}