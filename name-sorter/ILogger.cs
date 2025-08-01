using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public interface ILogger
    {
        void logMessage(string message);
        void logError(string message);

    }
}
