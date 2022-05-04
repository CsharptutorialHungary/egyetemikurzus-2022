using System;

namespace Calculator
{
    internal class ConsoleTable
    {
        static int tableWidth = 110;
        internal static string chosenCalculation;

        internal static void CreateConsoleTable(UsedFunctions uf)
        {
            Dictionary<string, int> functionUsages= new Dictionary<string, int>()
            {
                { "Add", uf.Add},
                { "Subtract", uf.Subtract},
                { "Multiply", uf.Multiply },
                { "Divide", uf.Divide},
                { "Factorial", uf.Factorial }
            };

            var max = functionUsages.Max(Use => Use.Value);

            var functionNameMax = from use in functionUsages
                                  where max == use.Value                   
                                  select use.Key;

            var min = functionUsages.Min(Use => Use.Value);

            var functionNameMin = from use in functionUsages
                                  where min == use.Value
                                  select use.Key;

            static string fMax(IEnumerable<string>? funcMax)
            {
                var str = "";
                foreach (var maximum in funcMax)
                {
                    str += maximum + ", ";
                }
                return str;
            };

            static string fMin(IEnumerable<string>? funcMin)
            {
                var str = "";
                foreach (var minimum in funcMin)
                {
                    str += minimum + ", ";
                }
                return str;
            };

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
            PrintRow("You can exit the program by typing 'q' and pressing 'Enter'");
            PrintLine();
            PrintRow($"Most used function(s) is/are " + fMin(functionNameMax) + "and has/have been ran: "+ Convert.ToString(max) + " times");
            PrintLine();
            PrintRow($"Least used function(s) is/are " + fMin(functionNameMin) +"and has/have been ran: "+ Convert.ToString(min) + " times");

            PrintLine();
            Console.WriteLine("\n");
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

