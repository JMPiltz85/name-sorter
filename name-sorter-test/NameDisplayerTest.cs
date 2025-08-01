using name_sorter;
using Moq;

namespace name_sorter_test;
public class NameDisplayerTest
{

    [Fact]
    public void display_WithValidNames()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameDisplayer displayer = new NameDisplayer(mockLogger.Object);

        List<string> nameList = new List<string>
        {
            "Adam Parsons",
            "Adam Lewis",
            "Adam Gardner",
            "Adam Lopez"
        };

        displayer.display(nameList);

        //NOTE: Makes sure that all of the names were output to the Console
        foreach (string name in nameList)
        {
            mockLogger.Verify(logger => logger.logMessage(name), Times.Once);
        }

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void display_WithNullList_ThrowsArgumentNullException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameDisplayer displayer = new name_sorter.NameDisplayer(mockLogger.Object);

        displayer.display(null);

        //NOTE: Checks to make sure the exception is caught properly.
        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("List of names cannot be empty")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void display_WithEmptyList_ThrowsArgumentNullException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameDisplayer displayer = new NameDisplayer(mockLogger.Object);
        List<string> nameList = new List<string>();

        displayer.display(nameList);

        //NOTE: Checks to make sure the exception is caught properly.
        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("List of names cannot be empty")
            ))
            , Times.Once
        );

    }


}

