namespace name_sorter_test;

public class TextFileWriter
{
    private name_sorter.TextFileWriter writer = new name_sorter.TextFileWriter();


   [Fact]
    public void testReadValid()
    {
        //string filePath = "Text\\unsorted-names-list.txt";
        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times to reach "Text" folder
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "test-doc.txt");

        List<string> namesList = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer"
        };

        writer.WriteLines(filePath, namesList);

        var writtenData = File.ReadAllLines(filePath);

        Assert.Equal(namesList, writtenData);

        File.Delete(filePath);

    }
}