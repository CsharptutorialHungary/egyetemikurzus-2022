using System;

namespace RefErtek
{
    internal class Program
    {
        public class Pont
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Pont pont &&
                       X == pont.X &&
                       Y == pont.Y;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            public override string ToString()
            {
                return $"x: {X}; y: {Y}";
            }
        }

        public record ImmutablePont
        {
            public int X { get; init; }
            public int Y { get; init; }
        }

        static void Main(string[] args)
        {
            //object initializer
            Pont p = new Pont
            {
                Y = 20,
                X = 10,
            };
            Console.WriteLine(p); //y = 20, x = 10
            Pont p2 = p;
            p2.X = 100;
            Console.WriteLine(p); //y = 20, x = 100
            Console.WriteLine(p == p2); //true

            var p3 = new Pont
            {
                X = 100,
                Y = 20
            };

            Console.WriteLine(p == p3); //False
            Console.WriteLine(p.Equals(p3)); //True

            ImmutablePont ip = new ImmutablePont
            {
                Y = 20,
                X = 10,
            };

            Console.WriteLine(ip); //y = 20, x = 10
            ImmutablePont ip2 = ip with 
            {
                X = 100
            };
            Console.WriteLine(ip); //y = 20, x = 100
            Console.WriteLine(ip == ip2);

            int[] tmb1 = { 1, 2, 3, 4 }; //a tömb referencia
            int[] tmb2 = { 1, 2, 3, 4 };

            Console.WriteLine(tmb1 == tmb2); //false

        }
    }
}
