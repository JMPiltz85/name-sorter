using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameDisplayer: IDisplay
    {
        private ILogger logger;

        public NameDisplayer(ILogger _logger) 
        { 
            logger = _logger;
        }

        public void display(List<string> list)
        {
            try
            {
                if(list == null || list.Count <=0 )
                {
                    throw new ArgumentNullException("List of names cannot be empty");
                }

                foreach (string name in list)
                {
                    logger.logMessage(name);
                }
            }

            catch (ArgumentNullException ex)
            {
                logger.logError($"Argument Null Exeption has occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                logger.logError($"Invalid Operation Exception has occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.logMessage($"Unexpected error has occurred: {ex.Message}");
            }
        }
    }
}
