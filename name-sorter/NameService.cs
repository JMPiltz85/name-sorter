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
        private ILogger logger;

        public NameService(TextFileReader _reader, TextFileWriter _writer, NameSorter _sorter, NameDisplayer _displayer, FolderFinder _folderFinder, ILogger _logger) 
        {
            reader = _reader;
            writer = _writer;
            sorter = _sorter;
            displayer = _displayer;
            folderFinder = _folderFinder;
            logger = _logger;
        }

        public void runService(string filePath)
        {
            string? folderPath;
            string writePath;
            List<string> nameList;
            List<string> sortedNameList;        

            try
            {
                folderPath = folderFinder.getPath(filePath);
                if (string.IsNullOrEmpty(folderPath))
                {
                    throw new InvalidOperationException("The folder path couldn't be extrapolated.");
                }

                writePath = folderPath + "\\sorted-names-list.txt";
                nameList = reader.ReadLines(filePath);

                if (nameList == null || nameList.Count == 0)
                {
                    throw new InvalidOperationException("The input file doesn't contain any names.");
                }

                sortedNameList = sorter.sortList(nameList);


                displayer.display(sortedNameList);

                writer.WriteLines(writePath, sortedNameList);
            }

            catch (FileNotFoundException ex)
            {
                logger.logError($"Name Service has experienced a File Not Found Exception: {ex.Message}");
            }

            catch (IOException ex)
            {
                logger.logError($"Name Service has experienced an I/O Exception: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.logError($"Name Service has experienced an Unauthorized Access Exception: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                logger.logError($"Name Service has experienced an Invalid Operation Exception: {ex.Message}");
            }

            catch (Exception ex)
            {
                logger.logError($"Name Service has experienced an unexpected exception: {ex.Message}");
            }

        }

    }
}
