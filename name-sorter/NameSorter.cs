using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameSorter: ISorter
    {
        private ILogger logger;
        private IParser parser;

        public NameSorter(IParser _parser, ILogger _logger)
        {
            parser = _parser;
            logger = _logger;
        }

        public List<string> sortList(List<string> list)
        {
            List<string> sortedNameList = new List<string>();

            try
            {
                if (list == null || list.Count == 0)
                {
                    throw new ArgumentNullException("The list of strings must contain at least one element.");
                }

                else
                {
                    sortedNameList = list
                        .OrderBy(name => parser.getLastName(name))
                        .ThenBy(name => parser.getMiddleNames(name))
                        .ThenBy(name => parser.getFirstName(name))
                        .ToList();
                }
                

            }

            catch (ArgumentNullException ex)
            {
                logger.logError($"List of strings passed is invalid: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.logError($"An unexpected error has occurred: {ex.Message}");
            }


            return sortedNameList;

        }

    }
}
