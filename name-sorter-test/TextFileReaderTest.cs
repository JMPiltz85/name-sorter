namespace name_sorter_test;

public class TextFileReader
{
    private name_sorter.TextFileReader reader = new name_sorter.TextFileReader();


   [Fact]
    public void testReadValid()
    {
        //string filePath = "Text\\unsorted-names-list.txt";
        string baseDir = AppContext.BaseDirectory;
        //NOTE: Xunit test thinks that base directory is "\bin\Debug\net8.0", so need to go up folder 3 times
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "unsorted-names-list.txt");

        List<string> namesList = new List<string>();

        namesList = reader.ReadLines(filePath);

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

    }
}