using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleTables
{
    internal class FactorialTable: ConsoleTable
    {
        internal static void CreateConsoleTable()
        {
            Console.Clear();
            PrintLine();
            PrintRow("Type in the number you wish to get the factorial of, then press 'Enter'");
            PrintRow("Type 'last' and then press 'Enter' to get the factorial of the last calculation's result");
            PrintRow("The programme is only able to calculate the factorial of whole numbers larger or equal to 0");
            PrintLine();
            PrintRow("Type 'c' and press 'Enter' to return to the menu");
            PrintLine();
            Console.Write("Number to get the factorial of: ");

        }
    }
}
