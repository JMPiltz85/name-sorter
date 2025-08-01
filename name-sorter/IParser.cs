using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public interface IParser
    {
        public string getFirstName(string fullName);

        public string getLastName(string fullName);

        public string getMiddleNames(string fullName);

    }
}
