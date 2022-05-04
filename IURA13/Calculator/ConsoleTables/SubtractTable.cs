using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleTables
{
    internal class SubtractTable : ConsoleTable
    {
        internal static void CreateConsoleTable()
        {
            Console.Clear();
            PrintLine();
            PrintRow("Type in the numbers you want to subtract from eachother");
            PrintLine();
            PrintRow("Type 'last' to add the last gotten result to the calculation");
            PrintLine();
            PrintRow("Press 'Enter' after each one to add to the calculation");
            PrintLine();
            PrintRow("Type 'c' and press 'Enter' to finish calculation");
            PrintLine();
            Console.Write("Number to subtract from: ");

        }
    }
}
