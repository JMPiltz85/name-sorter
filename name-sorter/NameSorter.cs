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
                sortedNameList = list
                    .OrderBy(name => parser.getLastName(name))
                    .ThenBy(name => parser.getMiddleNames(name))
                    .ThenBy(name => parser.getFirstName(name))
                    .ToList();

            }

            catch (Exception ex)
            {
                logger.logError($"An unexpected error has occurred: {ex.Message}");
            }


            return sortedNameList;

        }

    }
}
