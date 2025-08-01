using name_sorter;
using Moq;

namespace name_sorter_test;
public class FileFolderTest
{

    [Fact]
    public void getPath_folderPathValid()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        FolderFinder finder = new FolderFinder(mockLogger.Object);

        string filePath = "C:\\Users\\User1\\Documents\\Text\\unsorted-names-list.txt";
        string expectedDir = "C:\\Users\\User1\\Documents\\Text";
        string? fileDir = finder.getPath(filePath);

        Assert.Equal(expectedDir, fileDir);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void getPath_emptyFolderPath_ThrowsArgException(string? filePath)
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        FolderFinder finder = new FolderFinder(mockLogger.Object);
        string? fileDir = finder.getPath(filePath);

        Assert.Null(fileDir);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The provided file path is null") 
            ))
            ,  Times.Once
        );
    }

    [Fact]
    public void getPath_InvalidCharacters_ThrowsArgException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        FolderFinder finder = new FolderFinder(mockLogger.Object);

        string filePath = "C:\\Bad|Path\\unsorted-names-list.txt";
        string? fileDir = finder.getPath(filePath);

        Assert.Null(fileDir);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The provided file path contains invalid characters")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void getPath_ThrowsPathTooLongException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        FolderFinder finder = new FolderFinder(mockLogger.Object);

        string filePath = "C:\\" + new string('g', 9999999) +"\\unsorted-names-list.txt";
        string? fileDir = finder.getPath(filePath);

        Assert.Null(fileDir);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("Path has exceeded system's maximum length")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void getPath_UnexpectedException_ThrowNewException()
    {

        Mock<ILogger> mockLogger = new Mock<ILogger>();
        FolderFinder finder = new FolderFinder(mockLogger.Object);

        string filePath = "C:\\Users\\User1\\Documents\\Text\\unsorted-names-list.txt";

        var exception = Record.Exception(() => finder.getPath(filePath));

        Assert.Null(exception);

    }


}

