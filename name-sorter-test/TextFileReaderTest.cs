using Moq;
using name_sorter;

namespace name_sorter_test;

public class TextFileReaderTest
{
    
   [Fact]
    public void ReadLines_Valid()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileReader reader = new TextFileReader(mockLogger.Object);

        //string filePath = "Text\\unsorted-names-list.txt";
        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "unsorted-names-list.txt");

        List<string> namesList = reader.ReadLines(filePath);

        var expectedList = new List<string>
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };

        Assert.Equal(expectedList, namesList);

        mockLogger.Verify(
            logger => logger.logError(It.IsAny<string>())
            , Times.Never
        );
    }

    [Fact]
    public void ReadLines_ReadEmptyFile()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileReader reader = new TextFileReader(mockLogger.Object);

        //string filePath = "Text\\unsorted-names-list.txt";
        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "empty.txt");

        List<string> namesList = reader.ReadLines(filePath);

        Assert.Empty(namesList);

        mockLogger.Verify(
            logger => logger.logError(It.IsAny<string>())
            , Times.Never
        );

    }

    [Fact]
    public void ReadLines_Throw_FileNotFoundException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileReader reader = new TextFileReader(mockLogger.Object);

        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times
        string nonExistentFile = Path.Combine(baseDir, "..", "..", "..", "Text", "phantomListtxt");

        List<string> namesList = reader.ReadLines(nonExistentFile);

        Assert.Empty(namesList);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("Text File Reader has experienced a File Not Found Exception")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void ReadLines_Throw_IOException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileReader reader = new TextFileReader(mockLogger.Object);

        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "sampleFile.txt");

        List<string> namesList = new List<string>();

        //NOTE: simulates attempting to open file that's being written to 
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            namesList = reader.ReadLines(filePath);
        }

        Assert.Empty(namesList);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("Text File Reader has experienced an I/O Exception")
            ))
            , Times.Once
        );

    }
}