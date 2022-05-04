using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculations
{
    internal class MultiplyCalculation
    {
        internal double Multiply(double lastResult)
        {
            double result = 1;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string input = Console.ReadLine().ToLower();
                    if (input is "c") break;
                    if (input is "last")
                    {
                        Console.Write("* ");
                        result *= lastResult;
                    }
                    else
                    {
                        Console.Write("* ");
                        result *= Convert.ToDouble(input);
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
