using Moq;
using name_sorter;
using System.Reflection.PortableExecutable;

namespace name_sorter_test;

public class TextFileWriterTest
{

   [Fact]
    public void WriteLines_Valid()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileWriter writer = new TextFileWriter(mockLogger.Object);

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

        try
        {
            writer.WriteLines(filePath, namesList);

            var writtenData = File.ReadAllLines(filePath);

            Assert.Equal(namesList, writtenData);

            mockLogger.Verify(
                logger => logger.logError(It.IsAny<string>())
                , Times.Never
            );
        }
        finally
        {
            File.Delete(filePath);
        }

    }

    [Fact]
    public void WriteLines_InvalidPath_handlesArgumentException() 
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileWriter writer = new TextFileWriter(mockLogger.Object);

        string nonExistentPath = "";
        List<string> namesList = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer"
        };

        writer.WriteLines(nonExistentPath, namesList);

        mockLogger.Verify(
           logger => logger.logError(It.Is<string>(
               msg => msg.Contains("Text File Writer has experienced an Argument Exception")
           ))
           , Times.Once
       );

    }

    [Fact]
    public void WriteLines_InvalidPath_HandlesPathTooLongException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileWriter writer = new TextFileWriter(mockLogger.Object);

        string baseDir = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDir, new string('a', 300), "test-doc.txt");


        List<string> namesList = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer"
        };

        writer.WriteLines(filePath, namesList);

        mockLogger.Verify(
           logger => logger.logError(It.Is<string>(
               msg => msg.Contains("Text File Writer has experienced a Path Too Long Exception")
           ))
           , Times.Once
       );

    }

    [Fact]
    public void WriteLines_HandlesIOException()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        TextFileWriter writer = new TextFileWriter(mockLogger.Object);

        string baseDir = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDir, "..", "..", "..", "Text", "sampleFile.txt");


        List<string> namesList = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer"
        };

        //NOTE: simulates attempting to open file that's being written to 
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            writer.WriteLines(filePath, namesList);
        }

        mockLogger.Verify(
           logger => logger.logError(It.Is<string>(
               msg => msg.Contains("Text File Writer has experienced an I/O Exception")
           ))
           , Times.Once
       );

    }

}