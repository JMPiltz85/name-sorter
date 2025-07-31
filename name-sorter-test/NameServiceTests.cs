using name_sorter;

namespace name_sorter_test;

public class NameServiceTests
{
    private name_sorter.TextFileReader reader = new name_sorter.TextFileReader();
    private name_sorter.TextFileWriter writer = new name_sorter.TextFileWriter();
    private name_sorter.NameParser parser = new name_sorter.NameParser();
    private name_sorter.NameDisplayer displayer = new name_sorter.NameDisplayer();
    private name_sorter.FolderFinder folderFinder = new name_sorter.FolderFinder();

    

    [Fact]
    public void fullServiceProcess_Successful()
    {
        NameSorter sorter = new NameSorter(parser);
        NameService service = new NameService(reader, writer, sorter, displayer, folderFinder);

        string baseDir = AppContext.BaseDirectory;
        string unsortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "unsorted-names-list.txt");
        string sortedFilePath = Path.Combine(baseDir, "..", "..", "..", "Text", "sorted-names-list.txt");

        service.runService(unsortedFilePath);

        var sortedNameList = new List<string>
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

        var writtenData = File.ReadAllLines(sortedFilePath);


        Assert.Equal(sortedNameList, writtenData);

    }
}