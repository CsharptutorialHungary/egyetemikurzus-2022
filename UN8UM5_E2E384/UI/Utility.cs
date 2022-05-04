using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szalloda.UI
{
    public static class Utility
    {
        public static string GetUserInput(string param)
        {
            Console.WriteLine($"Enter {param}");
            return Console.ReadLine();
        }

        public static int GetUserInputInt(string param)
        {
            Console.WriteLine($"Enter {param}");
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        public static DateTime GetUserInputDate(string param)
        {
            Console.WriteLine($"Enter {param}");
            try
            {
                return DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return new DateTime(9999, 12, 31);
            }
        }
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
            PressEnterToContinue();
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
