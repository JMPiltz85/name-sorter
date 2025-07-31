using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameParser
    {

        public string getFirstName(string fullName)
        {
            string firstName = "";

            try
            {
                string[] nameList = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (nameList.Length > 0 && !string.IsNullOrEmpty(nameList[0]))
                    firstName = nameList[0];
                else
                    firstName = "";
            }

            //NOTE: Catches when doing a split doesn't return any values (count of substrings is negative value)
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            //NOTE: Handles when fullName has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return firstName;
        }

        public string getLastName(string fullName)
        {
            string lastName = "";

            try
            {
                string[] nameList = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (nameList.Length > 0 && !string.IsNullOrEmpty(nameList[nameList.Length - 1]))
                    lastName = nameList[nameList.Length - 1];
                else
                    lastName = "";
            }

            //NOTE: Catches when doing a split doesn't return any values (count of substrings is negative value)
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            //NOTE: Handles when fullName has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return lastName;
        }

        public string getMiddleNames(string fullName)
        {
            string middleNames = "";

            try
            {
                string[] nameList = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //NOTE: IF there's more than two entries in the split line, that means they have one or more middle names
                if (nameList.Length > 0 && nameList.Length > 2 && !string.IsNullOrEmpty(nameList[nameList.Length - 1]))
                    middleNames = string.Join(" ", nameList.Skip(1).Take(nameList.Length - 2));
                else
                    middleNames = "";

            }

            //NOTE: Catches when doing a split doesn't return any values (count of substrings is negative value)
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            //NOTE: Handles when fullName has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Full Name String is invalid: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error has occurred: {ex.Message}");
            }

            return middleNames;
        }


    }
}
