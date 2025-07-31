using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameService
    {

        private TextFileReader reader;
        private TextFileWriter writer;
        private NameSorter sorter;
        private NameDisplayer displayer;
        private FolderFinder folderFinder;

        public NameService(TextFileReader _reader, TextFileWriter _writer, NameSorter _sorter, NameDisplayer _displayer, FolderFinder _folderFinder) 
        {
            reader = _reader;
            writer = _writer;
            sorter = _sorter;
            displayer = _displayer;
            folderFinder = _folderFinder;
        }

        public void runService(string filePath)
        {
            string? folderPath = folderFinder.getFolderPath(filePath);
            string writePath = folderPath + "\\sorted-names-list.txt";
            List<string> nameList = reader.ReadLines(filePath);
            List<string> sortedNameList = sorter.sortNameList(nameList);

            displayer.displayNames(sortedNameList);

            writer.WriteLines(writePath, sortedNameList);


        }

    }
}
