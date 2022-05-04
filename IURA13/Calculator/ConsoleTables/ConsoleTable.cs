using System;

namespace Calculator
{
    internal class ConsoleTable
    {
        static int tableWidth = 85;
        internal static string chosenCalculation;

        internal static void CreateConsoleTable()
        {
            Console.Clear();
            PrintLine();
            PrintRow("Choose the calculation you want to do by typing its name or symbol");
            PrintLine();
            PrintRow("Each calculation, except factorial can take up to 10 values");
            PrintRow("For decimal numbers, use ',' instead of '.'");
            PrintLine();
            PrintRow("Add", "Subtract", "Multiply", "Divide", "Factorial");
            PrintRow("+", "-", "* or X", "/", "!");
            PrintLine();
            PrintRow("You can exit the program by typing 'q'");
            PrintLine();

            Console.Write("Chosen calculation: ");
            chosenCalculation = Console.ReadLine().ToLower();
        }

        internal static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        internal static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        internal static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

