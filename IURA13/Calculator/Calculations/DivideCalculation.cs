using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculations
{
    internal class DivideCalculation
    {
        internal double Divide(double lastResult)
        {
            double result = 1;
            try
            {
                string input = Console.ReadLine().ToLower();
                if (input is "last") result = lastResult;
                else if (input is "c") return lastResult;
                else result = Convert.ToDouble(input);
                Console.WriteLine("Numbers to divide with: ");
                for (int i = 0; i < 10; i++)
                {
                    input = Console.ReadLine().ToLower();
                    if (input is "c") break;
                    if (input is "0") throw new ArgumentException("Dividing by 0 is not allowed");
                    if (input is "last")
                    {
                        Console.Write("/ ");
                        result /= lastResult;
                    }
                    else
                    {
                        Console.Write("/ ");
                        result /= Convert.ToDouble(input);
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
