using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class FolderFinder
    {
        private ILogger logger;

        public FolderFinder(ILogger _logger) 
        { 
            logger = _logger;
        }

        public string? getPath(string? filePath)
        {
            string? workingDirectory = null;

            try
            {

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException("The provided file path is null, empty, or only contains whitespace");
                }

                else if (filePath.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >=0)
                {
                    throw new ArgumentNullException("The provided file path contains invalid characters");
                }

                else if (filePath.Length >= 260)
                {
                    throw new PathTooLongException("File path cannot be longer than 260 characters.");
                }

                else
                {
                    workingDirectory = Path.GetDirectoryName(filePath.Trim());
                }

            }

            //NOTE: Handles when path has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                logger.logError($"Incorrectly formatted file path: {ex.Message} ");
            }
            //NOTE: Handles when path has more than 260 characters (the maximum length Windows supports for file paths)
            catch (PathTooLongException ex)
            {
                logger.logError($"Path has exceeded system's maximum length: {ex.Message} ");
            }
            catch (Exception ex)
            {
                logger.logError($"An unexpected error has occurred: {ex.Message}");
            }

            return workingDirectory;
        }

    }
}
