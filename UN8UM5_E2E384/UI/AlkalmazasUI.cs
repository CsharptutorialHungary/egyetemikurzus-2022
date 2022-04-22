using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szalloda.UI
{
    public static class AlkalmazasUI
    {
        internal static void Welcome()
        {
            // Console.Clear();
            Console.Title = "Szálloda alkalmazás";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Üdv a szálloda alkalmazásban!");

            Console.WriteLine("Írd be a felhasználónevet:");

            Console.WriteLine("\nNyomj Enter-t a folytatáshoz...");
            Console.ReadLine();
        }
    }
}
