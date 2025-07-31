using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class TextFileReader:IFileReader
    {


        public TextFileReader() { }

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
                Console.WriteLine($"The specified file couldn't be found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error has occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return nameList;
        }
    }
}
