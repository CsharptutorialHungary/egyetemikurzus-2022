using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator.Calculations
{
    internal class FactorialCalculation
    {
       internal double Factorial(int lastResult)
        {
            List<InputNumbers> numbers = new List<InputNumbers>() { };
            XmlSerializer xs = new XmlSerializer(typeof(List<InputNumbers>));
            double result = 1;
            string input = Console.ReadLine().ToLower();
            try
            {
                if (input is "c" || input is "0" || (input is "last" && lastResult is 0)) {
                    Console.WriteLine("The result is: " + result);
                    return result;                   
                }
                if (input is "last" && lastResult >= 1)
                {
                    for (int i = 1; i <= lastResult; i++)
                    {
                        result *= i;
                        numbers.Add(new InputNumbers { number = i, tmpResult = result });
                    }
                }
                if(Convert.ToInt32(input) >= 1)
                {
                    for (int i = 1; i <= Convert.ToInt32(input); i++)
                    {
                        result *= i;
                        numbers.Add(new InputNumbers { number = i, tmpResult = result });
                    }
                }
                else
                {
                    Console.WriteLine("The programme is not able to calculate the factorial of negative or decimal numbers");
                    return result;
                }

                Console.WriteLine("The result is: " + result);
                using (var f = File.Create(@"../../../LastFactorialCalculation.xml"))
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
