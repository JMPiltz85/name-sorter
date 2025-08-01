using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameParser: IParser
    {
        private ILogger logger;

        public NameParser(ILogger _logger)
        {
            logger = _logger;
        }

        public string getFirstName(string fullName)
        {
            string firstName = tryParse(fullName, (namesList) => namesList.FirstOrDefault() ?? "");

            
            return firstName;
        }

        public string getLastName(string fullName)
        {
            string lastName = tryParse(fullName, 
                (namesList) => 
                {
                    if (namesList.Length > 1)
                        return namesList.LastOrDefault() ?? "";
                    else
                        return "";
                }
            );
            
            return lastName;
        }

        public string getMiddleNames(string fullName)
        {
            string middleNames = tryParse(fullName, 
                (namesList) => 
                {
                    if (namesList.Length > 2)
                        return string.Join(" ", namesList.Skip(1).Take(namesList.Length - 2));
                    else
                        return "";
                }
            );

            return middleNames;
        }

        private string tryParse(string fullName, Func<string[], string> worker)
        {
            string name = "";


            try
            {
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    throw new ArgumentNullException("The full name cannot be empty");
                }
                else
                {
                    string[] nameList = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    name = worker(nameList);
                }
            }

            //NOTE: Catches when name is null or only contains whitespaces
            catch (ArgumentNullException ex)
            {
                logger.logError($"Full Name String is invalid: {ex.Message}");
            }

            //NOTE: Catches when doing a split doesn't return any values (count of substrings is negative value)
            catch (ArgumentOutOfRangeException ex)
            {
                logger.logError($"Full Name String is invalid: {ex.Message}");
            }
            //NOTE: Handles when fullName has invalid characters, is empty, or only has whitespaces
            catch (ArgumentException ex)
            {
                logger.logError($"Full Name String is invalid: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.logError($"An unexpected error has occurred: {ex.Message}");
            }


            return name;
        }


    }
}
