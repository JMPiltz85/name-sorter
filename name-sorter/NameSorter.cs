using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameSorter
    {
        private readonly NameParser parser;

        public NameSorter(NameParser _parser)
        {
            parser = _parser;
        }

        public List<string> sortNameList(List<string> nameList)
        {
            List<string> sortedNameList = new List<string>();

            sortedNameList = nameList
                .OrderBy(name => parser.getLastName(name))
                .ThenBy(name => parser.getMiddleNames(name))
                .ThenBy(name => parser.getFirstName(name))
                .ToList();


            return sortedNameList;

        }


    }
}
