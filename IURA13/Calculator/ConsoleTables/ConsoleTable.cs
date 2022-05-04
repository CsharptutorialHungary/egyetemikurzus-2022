using System;

namespace Calculator
{
    public class FunctionsAndTheirNumberOfUses
    {
        public string functionName { get; set; }
        public int uses { get; set; }

    }
    internal class ConsoleTable
    {
        static int tableWidth = 110;
        internal static string chosenCalculation;

        internal static void CreateConsoleTable(UsedFunctions uf)
        {
            List<FunctionsAndTheirNumberOfUses> Usages = new List<FunctionsAndTheirNumberOfUses>
            {
                new FunctionsAndTheirNumberOfUses
                {
                    functionName = "Add",
                    uses = uf.Add,
                },

                new FunctionsAndTheirNumberOfUses
                {
                    functionName = "Subtract",
                    uses = uf.Subtract,
                },

                new FunctionsAndTheirNumberOfUses
                {
                    functionName = "Multiply",
                    uses = uf.Multiply,
                },

                new FunctionsAndTheirNumberOfUses
                {
                    functionName = "Divide",
                    uses = uf.Divide,
                },

                new FunctionsAndTheirNumberOfUses
                {
                    functionName = "Factorial",
                    uses = uf.Factorial,
                },
            };

            var max = Usages.Max(Use => Use.uses);

            var functionNameMax = from use in Usages
                                  where max == use.uses                   
                                  select use.functionName;

            var min = Usages.Min(Use => Use.uses);

            var functionNameMin = from use in Usages
                                  where min == use.uses
                                  select use.functionName;

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
            PrintRow("You can exit the program by typing 'q'");
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

