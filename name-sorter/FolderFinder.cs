using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class FolderFinder
    {

        public FolderFinder() { }

        public string? getFolderPath(string fileName)
        {
            string? workingDirectory = null;

            try
            {

                workingDirectory = Path.GetDirectoryName(fileName);

            }

            //NOTE: Handles when path has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Incorrectly formatted file path: {ex.Message} ");
            }
            //NOTE: Handles when path has more than 260 characters (the maximum length Windows supports for file paths)
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path has exceeded system's maximum length: {ex.Message} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return workingDirectory;
        }


    }
}
