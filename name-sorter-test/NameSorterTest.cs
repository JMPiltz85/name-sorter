using Microsoft.VisualBasic;
using name_sorter;
using System;
using System.Diagnostics.Metrics;

namespace name_sorter_test;

public class NameSorterTest
{
    private name_sorter.NameParser parser = new name_sorter.NameParser();
    private NameSorter sorter = null;

    [Fact]
    public void shouldSortByLastName()
    {
        sorter = new NameSorter(parser);

        var unsortedList = new List<string>
            {
                "Adam Parsons",
                "Adam Lewis",
                "Adam Gardner",
                "Adam Lopez"
            };

        var sortedList = sorter.sortNameList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam Gardner",
                "Adam Lewis",
                "Adam Lopez",
                "Adam Parsons"
            };

        Assert.Equal(expectedList, sortedList);

    }

    [Fact]
    public void shouldSortByFirstName()
    {
        sorter = new NameSorter(parser);

        var unsortedList = new List<string>
            {
                "Ryan Clarke",
                "Adam Clarke",
                "Brett Clarke",
                "Samuel Clarke"
            };

        var sortedList = sorter.sortNameList(unsortedList);

        var expectedList = new List<string>
            {
                "Adam Clarke",
                "Brett Clarke",
                "Ryan Clarke",
                "Samuel Clarke"
            };

        Assert.Equal(expectedList, sortedList);
    }

    [Fact]
    public void shouldSortByMiddleName()
    {
        sorter = new NameSorter(parser);

        var unsortedList = new List<string>
            {
                "Ryan Nathan Clarke",
                "Ryan Cylde Clarke",
                "Ryan Roger Clarke",
                "Ryan Albert Drew Clarke"
            };

        var sortedList = sorter.sortNameList(unsortedList);

        var expectedList = new List<string>
            {
                "Ryan Albert Drew Clarke",
                "Ryan Cylde Clarke",
                "Ryan Nathan Clarke",
                "Ryan Roger Clarke"
            };

        Assert.Equal(expectedList, sortedList);
    }

    [Fact]
    public void fullExampleTest()
    {
        sorter = new NameSorter(parser);

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

        var sortedList = sorter.sortNameList(unsortedList);

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
    }

}