using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class ConsoleLogger:ILogger
    {
        public ConsoleLogger() { }

        public void logMessage(string message)
        {
            writeToConsole(message, "message");
        }

        public void logError(string message)
        {
            writeToConsole(message, "error");
        }

        private void writeToConsole(string message, string messageType)
        {
            try
            {
                Console.WriteLine(message);
            }

            catch (IOException ex)
            {
                Console.Error.WriteLine($"IO error occurred while logging {messageType}: {ex.Message}");
            }
            catch (ObjectDisposedException ex)
            {
                Console.Error.WriteLine($"Console output was closed while logging {messageType}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error has occurred while logging {messageType}: {ex.Message}");
            }

        }

    }
}
