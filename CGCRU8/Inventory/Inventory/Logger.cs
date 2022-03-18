using System.Configuration;

namespace Inventory
{
    internal class Logger
    {
        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(ConfigurationManager.AppSettings["logFile"], DateTime.Now + " - " + message + "\n");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
