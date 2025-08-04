using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class TextFileWriter
    {
        private ILogger logger;
        public TextFileWriter(ILogger _logger) 
        {
            logger = _logger;
        }

        public void WriteLines(string writePath, List<string> nameList)
        {

            try
            {
                if(writePath.Length> 260)
                {
                    throw new PathTooLongException("Write Path is over 260 characters");
                }


                using (StreamWriter sw = new StreamWriter(writePath, false))
                {
                    foreach (string name in nameList)
                    {
                        sw.WriteLine(name);
                    }
                }

            }

            //NOTE: Handles when path has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                logger.logError($"Text File Writer has experienced an Argument Exception: {ex.Message}");
            }
            //NOTE: Handles when path has more than 260 characters (the maximum length Windows supports for file paths)
            catch (PathTooLongException ex)
            {
                logger.logError($"Text File Writer has experienced a Path Too Long Exception: {ex.Message}");
            }
            catch (IOException ex)
            {
                logger.logError($"Text File Writer has experienced an I/O Exception: {ex.Message}");
            }

            catch (Exception ex)
            {
                logger.logError($"Text File Writer has experienced an unexpected exception: {ex.Message}");
            }
        }

    }
}
