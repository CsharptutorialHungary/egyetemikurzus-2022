using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleTables
{
    internal class MultiplyTable: ConsoleTable
    {
        internal static void CreateConsoleTable()
        {
            Console.Clear();
            PrintLine();
            PrintRow("Type in the numbers you want to multiply with eachother");
            PrintLine();
            PrintRow("Type 'last' to add the last gotten result to the calculation");
            PrintLine();
            PrintRow("Press 'Enter' after each one to add to the calculation");
            PrintLine();
            PrintRow("Type 'c' and press 'Enter' to finish calculation");
            PrintLine();
            Console.Write("Numbers to multiply: ");

        }
    }
}
