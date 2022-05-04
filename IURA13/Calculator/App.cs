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
    public record UsedFunctions
    {
        public int Add { get; init; }
        public int Subtract { get; init; }

        public int Multiply { get; init; }

        public int Divide { get; init; }

        public int Factorial { get; init; }
    }
    public class Calculator
    {

        static double lastResult;
        static async Task Main()
            {
            XmlSerializer xs = new XmlSerializer(typeof(UsedFunctions));
            UsedFunctions des = new UsedFunctions { };
            using (var f = File.OpenRead(@"../../../FunctionsUsed.xml"))
            {
                des = xs.Deserialize(f) as UsedFunctions;
                ConsoleTable.CreateConsoleTable(des);
            }

            switch (ConsoleTable.chosenCalculation)
                {
                    case "add":
                    case "+":
                        AddTable.CreateConsoleTable();
                        AddCalculation ac = new AddCalculation();
                        lastResult = ac.Add(lastResult);
                        var add = des.Add+1;
                        des = des with { Add = add };
                        Console.Write("Returning to menu in");
                        using (var f = File.Create(@"../../../FunctionsUsed.xml"))
                        {
                            xs.Serialize(f, des);
                        }
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "subtract":
                    case "-":
                        SubtractTable.CreateConsoleTable();
                        SubtractCalculation sc = new SubtractCalculation();
                        lastResult = sc.Subtract(lastResult);
                        var sub = des.Subtract + 1;
                        des = des with { Subtract = sub };
                        Console.Write("Returning to menu in");
                        using (var f = File.Create(@"../../../FunctionsUsed.xml"))
                        {
                            xs.Serialize(f, des);
                        }
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "multiply":
                    case "*":
                    case "x":
                        MultiplyTable.CreateConsoleTable();
                        MultiplyCalculation mc = new MultiplyCalculation();
                        lastResult = mc.Multiply(lastResult);
                        var multiply = des.Multiply + 1;
                        des = des with { Multiply = multiply };
                        Console.Write("Returning to menu in");
                        using (var f = File.Create(@"../../../FunctionsUsed.xml"))
                        {
                            xs.Serialize(f, des);
                        }
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "divide":
                    case "/":
                        DivideTable.CreateConsoleTable();
                        DivideCalculation dc = new DivideCalculation();
                        lastResult = dc.Divide(lastResult);
                        var div = des.Divide + 1;
                        des = des with { Divide = div };
                        Console.Write("Returning to menu in");
                        using (var f = File.Create(@"../../../FunctionsUsed.xml"))
                        {
                            xs.Serialize(f, des);
                        }
                        Console.Write("Returning to menu in");
                        await WaitForRefresh();
                        await Calculator.Main();
                        return;

                    case "factorial":
                    case "!":
                        FactorialTable.CreateConsoleTable();
                        FactorialCalculation fc = new FactorialCalculation();
                        lastResult = fc.Factorial(Convert.ToInt32(lastResult));
                        var fact = des.Factorial + 1;
                        des = des with { Factorial = fact };
                        Console.Write("Returning to menu in");
                        using (var f = File.Create(@"../../../FunctionsUsed.xml"))
                        {
                            xs.Serialize(f, des);
                        }
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