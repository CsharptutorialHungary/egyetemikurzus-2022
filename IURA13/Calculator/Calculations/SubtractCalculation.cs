using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculations
{
    internal class SubtractCalculation
    {
        internal double Subtract(double lastResult)
        {

            double result = 0;
            string input = Console.ReadLine().ToLower();
            if (input is "c") return lastResult;
            if (input is "last") result += lastResult;
            else result += Convert.ToDouble(input);
            try
            {
                Console.WriteLine("Numbers to subtract: ");
                Console.Write("- ");
                for (int i = 1; i < 10; i++)
                {
                    input = Console.ReadLine().ToLower();
                    if (input is "c") break;
                    if (input is "last")
                    {
                        Console.Write("- ");
                        result -= lastResult;
                    }
                    else
                    {
                        Console.Write("- ");
                        result -= Convert.ToDouble(input);
                    }
                }
                Console.WriteLine("The result is: " + result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Input was not a number or the input format was invalid");
            }
        }
    }
}
