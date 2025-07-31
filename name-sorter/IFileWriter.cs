using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public interface IFileWriter
    {
        public void WriteLines(string writePath, List<string> nameList);
    }
}
