using Calculator.Calculations;
using Calculator.ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator
{
    public class InputNumbers
    {
        [XmlAttribute("Input szám")]
        public double number { get; set; }

        [XmlElement("Eddigi eredmény")]
        public double tmpResult { get; set; }
    }
    public class Calculator
    {
        static double lastResult;
        static async Task Main()
            {

            ConsoleTable.CreateConsoleTable();


            switch (ConsoleTable.chosenCalculation)
                {
                    case "add":
                    case "+":
                        AddTable.CreateConsoleTable();
                        AddCalculation ac = new AddCalculation();
                        lastResult = ac.Add(lastResult);
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                    return;

                    case "subtract":
                    case "-":
                        SubtractTable.CreateConsoleTable();
                        SubtractCalculation sc = new SubtractCalculation();
                        lastResult = sc.Subtract(lastResult);
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "multiply":
                    case "*":
                    case "x":
                        MultiplyTable.CreateConsoleTable();
                        MultiplyCalculation mc = new MultiplyCalculation();
                        lastResult = mc.Multiply(lastResult);
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "divide":
                    case "/":
                        DivideTable.CreateConsoleTable();
                        DivideCalculation dc = new DivideCalculation();
                        lastResult = dc.Divide(lastResult);
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "factorial":
                    case "!":
                        FactorialTable.CreateConsoleTable();
                        FactorialCalculation fc = new FactorialCalculation();
                        lastResult = fc.Factorial(Convert.ToInt32(lastResult));
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;
                    case "q":
                        System.Environment.Exit(1);
                        return;
                default:
                        break;
                }

            }
        private static async Task WaitForRefresh()
        {
            for (int i = 4; i > 0; i--)
            {
                Console.Write(" " + i);
                await Task.Delay(1000);
            }

        }
    }
}