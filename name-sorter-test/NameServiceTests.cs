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

        var mockReader = new Mock<TextFileReader>(MockBehavior.Strict, new ConsoleLogger());
        var mockWriter = new Mock<TextFileWriter>(MockBehavior.Strict, new ConsoleLogger());
        var mockSorter = new Mock<NameSorter>(new NameParser(new ConsoleLogger()), new ConsoleLogger());
        var mockDisplayer = new Mock<NameDisplayer>(MockBehavior.Strict, new ConsoleLogger());
        var mockFolderFinder = new Mock<FolderFinder>(MockBehavior.Strict, new ConsoleLogger());

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

        NameService service = new NameService(
            mockReader.Object, 
            mockWriter.Object, 
            mockSorter.Object, 
            mockDisplayer.Object, 
            mockFolderFinder.Object
        );

        //NOTE: Sets up Mocks so they return values to check
        //mockFolderFinder.Setup(ff => ff.getPath(unsortedFilePath)).Returns(folderPath);
        //mockReader.Setup(r => r.ReadLines(unsortedFilePath)).Returns(unsortedNames);
        //mockSorter.Setup(s => s.sortList(unsortedNames)).Returns(sortedNames);
        //mockDisplayer.Setup(d => d.display(sortedNames));
        //mockWriter.Setup(w => w.WriteLines(expectedOutputPath, sortedNames));


        service.runService(unsortedFilePath);


        //NOTE: Does all of the verification that everything worked as expected.
        var writtenData = File.ReadAllLines(sortedFilePath);

        Assert.Equal(expectedSortedNameList, writtenData);

    }

    [Fact]
    public void fullServiceProcess_SuccessfulWithEmptyList()
    {
        string baseDir = AppContext.BaseDirectory;
        string unsortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "empty.txt");
        string sortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "sorted-names-list.txt");
        string folderPath = "";
        string expectedOutputPath = Path.Combine(baseDir, "..", "..", "..", "Text");

        var mockReader = new Mock<TextFileReader>(MockBehavior.Strict, new ConsoleLogger());
        var mockWriter = new Mock<TextFileWriter>(MockBehavior.Strict, new ConsoleLogger());
        var mockSorter = new Mock<NameSorter>(new NameParser(new ConsoleLogger()), new ConsoleLogger());
        var mockDisplayer = new Mock<NameDisplayer>(MockBehavior.Strict, new ConsoleLogger());
        var mockFolderFinder = new Mock<FolderFinder>(MockBehavior.Strict, new ConsoleLogger());

        List<string> unsortedNames = new List<string>();
        List<string> sortedNames = new List<string>();
        List<string> expectedSortedNameList = new List<string>();

        NameService service = new NameService(
            mockReader.Object,
            mockWriter.Object,
            mockSorter.Object,
            mockDisplayer.Object,
            mockFolderFinder.Object
        );

        //NOTE: Sets up Mocks so they return values to check
        //mockFolderFinder.Setup(ff => ff.getPath(unsortedFilePath)).Returns(folderPath);
        //mockReader.Setup(r => r.ReadLines(unsortedFilePath)).Returns(unsortedNames);
        //mockSorter.Setup(s => s.sortList(unsortedNames)).Returns(sortedNames);
        //mockDisplayer.Setup(d => d.display(sortedNames));
        //mockWriter.Setup(w => w.WriteLines(expectedOutputPath, sortedNames));


        service.runService(unsortedFilePath);


        //NOTE: Does all of the verification that everything worked as expected.
        var writtenData = File.ReadAllLines(sortedFilePath);

        Assert.Equal(expectedSortedNameList, writtenData);

    }
}