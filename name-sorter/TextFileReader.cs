using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class TextFileReader:IFileReader
    {
        private ILogger logger;

        public TextFileReader(ILogger _logger)
        { 
            logger = _logger;
        }

        public List<string> ReadLines(string filePath)
        {
            List<string> nameList = new List<string>();
            string? line = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    //NOTE: loops through text file until null is read, which indicates end of file
                    while ((line = sr.ReadLine()) != null)
                    {
                        nameList.Add(line);
                    }
                }
            }

            catch (FileNotFoundException ex)
            {
                logger.logError($"The specified file couldn't be found: {ex.Message}");
            }
            catch (IOException ex)
            {
                logger.logError($"An I/O error has occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.logError($"An unexpected error has occurred: {ex.Message}");
            }

            return nameList;
        }
    }
}
