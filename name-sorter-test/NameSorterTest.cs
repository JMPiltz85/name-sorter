using Microsoft.VisualBasic;
using Moq;
using name_sorter;
using System;
using System.Diagnostics.Metrics;

namespace name_sorter_test;

public class NameSorterTest
{

    [Fact]
    public void sortList_ByLastName()
    {

        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Adam Parsons",
                "Adam Lewis",
                "Adam Gardner",
                "Adam Lopez"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam Gardner",
                "Adam Lewis",
                "Adam Lopez",
                "Adam Parsons"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);

    }

    [Fact]
    public void sortList_ByFirstName()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Ryan Clarke",
                "Adam Clarke",
                "Brett Clarke",
                "Samuel Clarke"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam Clarke",
                "Brett Clarke",
                "Ryan Clarke",
                "Samuel Clarke"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void sortList_ByMiddleName()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Ryan Nathan Clarke",
                "Ryan Cylde Clarke",
                "Ryan Roger Clarke",
                "Ryan Albert Drew Clarke"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Ryan Albert Drew Clarke",
                "Ryan Cylde Clarke",
                "Ryan Nathan Clarke",
                "Ryan Roger Clarke"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void sortList_fullNameSortingTest()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
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

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
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

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }


    [Fact]
    public void sortList_handleNullList()
    {

        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var sortedList = sorter.sortList(null);

        Assert.Empty(sortedList);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The list of strings must contain at least one element")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void sortList_handleEmptyList()
    {

        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>();

        var sortedList = sorter.sortList(unsortedList);

        Assert.Empty(sortedList);

        mockLogger.Verify(
            logger => logger.logError(It.Is<string>(
                msg => msg.Contains("The list of strings must contain at least one element")
            ))
            , Times.Once
        );

    }

    [Fact]
    public void sortList_FirstNameWithNumbers()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Adam8",
                "Adam5",
                "Adam2",
                "Adam1"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam1",
                "Adam2",
                "Adam5",
                "Adam8"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void sortList_LastNameWithNumbers()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Adam Smith8",
                "Adam Smith5",
                "Adam Smith2",
                "Adam Smith1"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam Smith1",
                "Adam Smith2",
                "Adam Smith5",
                "Adam Smith8"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void sortList_MiddleNameWithNumbers()
    {
        Mock<ILogger> mockLogger = new Mock<ILogger>();
        NameParser parser = new NameParser(mockLogger.Object);
        NameSorter sorter = new NameSorter(parser, mockLogger.Object);

        var unsortedList = new List<string>
            {
                "Adam John8 Smith",
                "Adam John5 Smith",
                "Adam John2 Smith",
                "Adam John1 Smith"
            };

        var sortedList = sorter.sortList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam John1 Smith",
                "Adam John2 Smith",
                "Adam John5 Smith",
                "Adam John8 Smith"
            };

        Assert.Equal(expectedList, sortedList);

        // NOTE: Checks to make sure no error logs were called
        mockLogger.Verify(logger => logger.logError(It.IsAny<string>()), Times.Never);
    }

}