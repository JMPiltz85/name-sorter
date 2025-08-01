using name_sorter;
using Moq;

namespace name_sorter_test;
public class ConsoleLoggerTests
{
    private ConsoleLogger logger;

    public ConsoleLoggerTests()
    {
        logger = new ConsoleLogger();
    }

    [Fact]
    public void logMessage_Valid()
    {
        string testMsg = "Hello World!";
        string result = "";


        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            logger.logMessage(testMsg);
            result = sw.ToString().Trim();
        }

        Assert.Equal(testMsg, result);

    }

    [Fact]
    public void logError_Valid()
    {
        string testMsg = "A sample error has occurred.";
        string result = "";


        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            logger.logError(testMsg);
            result = sw.ToString().Trim();
        }

        Assert.Equal(testMsg, result);

    }


}

