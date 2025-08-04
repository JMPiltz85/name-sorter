using Moq;
using name_sorter;

namespace name_sorter_test;

public class NameServiceTests
{

    [Fact]
    public void fullServiceProcess_Successful()
    {
        string baseDir = AppContext.BaseDirectory;
        string unsortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "unsorted-names-list.txt");
        string sortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "sorted-names-list.txt");
        string folderPath = "";
        string expectedOutputPath = Path.Combine(baseDir, "..", "..", "..", "Text");
        Mock<ILogger> mockLogger = new Mock<ILogger>();


        NameService service = createNameService(mockLogger.Object);

        List<string> unsortedNames = new List<string>();
        List<string> sortedNames = new List<string>();
        var expectedSortedNameList = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            };

        service.runService(unsortedFilePath);


        //NOTE: Does all of the verification that everything worked as expected.
        var writtenData = File.ReadAllLines(sortedFilePath);

        Assert.Equal(expectedSortedNameList, writtenData);

        mockLogger.Verify(
            logger => logger.logError(It.IsAny<string>())
            , Times.Never
        );

    }


    [Fact]
    public void fullServiceProcess_HandlesInvalidFilePath()
    {
        string baseDir = AppContext.BaseDirectory;
        string unsortedFilePath = "asdklfnjkasdfnjsfn";

        Mock<ILogger> mockLogger = new Mock<ILogger>();

        NameService service = createNameService(mockLogger.Object);

        service.runService(unsortedFilePath);


        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("Name Service has experienced an Invalid Operation Exception")
            ))
            , Times.Once
        );

    }


    [Fact]
    public void fullServiceProcess_HandlesEmptyFile()
    {
        string baseDir = AppContext.BaseDirectory;
        string unsortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "empty.txt");

        Mock<ILogger> mockLogger = new Mock<ILogger>();

        NameService service = createNameService(mockLogger.Object);

        service.runService(unsortedFilePath);


        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("Name Service has experienced an Invalid Operation Exception")
            ))
            , Times.Once
        );

    }

    private static NameService createNameService(ILogger logger)
    {
        TextFileReader reader = new TextFileReader(logger);
        TextFileWriter writer = new TextFileWriter(logger);
        NameParser parser = new NameParser(logger);
        NameSorter sorter = new NameSorter(parser, logger);
        NameDisplayer displayer = new NameDisplayer(logger);
        FolderFinder folderFinder = new FolderFinder(logger);

        NameService service = new NameService(reader, writer, sorter, displayer, folderFinder, logger);

        return service;
    }
}