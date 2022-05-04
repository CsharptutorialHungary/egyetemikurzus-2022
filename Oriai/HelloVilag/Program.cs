using System;
using System.Collections.Generic;

namespace HelloVilag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 100_000_000;
            int y = 0xFF;
            uint z = 10000000;
            short f = 0;
            byte b = 255;
            sbyte s = -1;

            float fl = 0.0f;
            float exponent = 1E-3f;
            double dbl = 1.24;

            decimal money = 124.3453M;

            Half h = (Half)12.0d;

            char c = 'a';

            string str = "🐇";

            long lng = 0;

            var myVariable = "";

            dynamic asd = 12.0 + "Hello";

            long[] tomb = new long[3];
            long[] tomb2 = new[] { 2l, 1l, 3l };

            long[,] tomb2d = new long[2, 3];
            long[][] jagged = new long[2][]
            {
                new long[2],
                new long[4],
            };

            List<int> items = new List<int>();
            items.Add(1);
            items.Add(2);
            items.Add(3);

            LinkedList<int> linked = new LinkedList<int>();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Hot reload rulez");

            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }
}