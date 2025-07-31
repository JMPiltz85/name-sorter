using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameDisplayer
    {

        public NameDisplayer() { }

        public void displayNames(List<string> nameList)
        {

            foreach (string name in nameList)
            {
                Console.WriteLine(name);
            }

        }
    }
}
