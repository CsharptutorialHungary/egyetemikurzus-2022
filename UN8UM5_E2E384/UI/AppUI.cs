using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szalloda.UI
{
    internal static class AppUI
    {
        public static void Welcome()
        {
            // Console.Clear();
            Console.Title = "Hotel application";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Hotel application!");

            Utility.PressEnterToContinue();
        }


    }
}
