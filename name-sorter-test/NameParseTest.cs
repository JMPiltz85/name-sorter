using Moq;
using name_sorter;

namespace name_sorter_test;

public class NameParserTest
{
    [Theory]
    [InlineData("Burt", "Burt")]
    [InlineData("Vaughn Lewis", "Vaughn")]
    [InlineData("Adonis Julius Archer", "Adonis")]
    [InlineData("Hunter Uriah Mathew Clarke", "Hunter")]
    public void getFirstName_ReturnCorrectNames(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string firstName = parser.getFirstName(fullName);
        Assert.Equal(expected, firstName);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Theory]
    [InlineData("Adonis Julius Archer", "Julius")]
    [InlineData("Hunter Uriah Mathew Clarke", "Uriah Mathew")]
    public void getMiddleNames_ReturnCorrectNames(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string middleNames = parser.getMiddleNames(fullName);
        Assert.Equal(expected, middleNames);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Theory]
    [InlineData("Vaughn Lewis", "Lewis")]
    [InlineData("Adonis Julius Archer", "Archer")]
    [InlineData("Hunter Uriah Mathew Clarke", "Clarke")]
    public void getLastName_ReturnCorrectNames(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string lastName = parser.getLastName(fullName);
        Assert.Equal(expected, lastName);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    public void getFirstName_EmptyOrWhitespace_Throws(string fullName)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string firstName = parser.getFirstName(fullName);

        Assert.Equal(firstName, "");

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The full name cannot be empty")
            ))
            , Times.Once
        );

    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    public void getMiddleName_EmptyOrWhitespace_Throws(string fullName)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string middleNames = parser.getMiddleNames(fullName);

        Assert.Equal(middleNames, "");

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The full name cannot be empty")
            ))
            , Times.Once
        );

    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    public void getLastName_EmptyOrWhitespace_Throws(string fullName)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string lastName = parser.getLastName(fullName);

        Assert.Equal(lastName, "");

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The full name cannot be empty")
            ))
            , Times.Once
        );

    }

    [Theory]
    [InlineData("Burt", "")]
    [InlineData("Vaughn Lewis", "")]
    public void getMiddleNames_HandleNoMiddleName(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string middleNames = parser.getMiddleNames(fullName);
        Assert.Equal(expected, middleNames);
    }

    [Theory]
    [InlineData("Burt", "")]
    public void getLastName_HandleNoLastName(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string lastName = parser.getLastName(fullName);

        Assert.Equal(expected, lastName);

    }

    [Theory]
    [InlineData("  John Deere", "John")]

    public void getFirstName_HandlesLeadingWhitespace(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string firstName = parser.getFirstName(fullName);

        Assert.Equal(expected, firstName);

    }

    [Theory]
    [InlineData("John Deere   ", "Deere")]

    public void getLastName_HandlesTrailingWhitespace(string fullName, string expected)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);

        string lastName = parser.getLastName(fullName);

        Assert.Equal(expected, lastName);

    }


}