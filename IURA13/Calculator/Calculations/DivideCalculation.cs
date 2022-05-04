using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Calculations
{
    internal class DivideCalculation
    {
        internal double Divide(double lastResult)
        {
            List<InputNumbers> numbers = new List<InputNumbers>() { };
            XmlSerializer xs = new XmlSerializer(typeof(List<InputNumbers>));
            double result = 1;
            try
            {
                string input = Console.ReadLine().ToLower();
                if (input is "last") result = lastResult;
                else if (input is "c") return lastResult;
                else result = Convert.ToDouble(input);
                numbers.Add(new InputNumbers { number = result, tmpResult = result });
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
                        numbers.Add(new InputNumbers { number = lastResult, tmpResult = result });
                    }
                    else
                    {
                        Console.Write("/ ");
                        result /= Convert.ToDouble(input);
                        numbers.Add(new InputNumbers { number = Convert.ToDouble(input), tmpResult = result });
                    }
                }
                Console.WriteLine("The result is: " + result);
                using (var f = File.Create(@"../../../LastDivideCalculation.xml"))
                {
                    xs.Serialize(f, numbers);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Input was not a number or the input format was invalid");
            }
        }
    }
}
