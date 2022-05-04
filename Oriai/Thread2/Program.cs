using System;
using System.Collections.Generic;
using System.Threading;

namespace Thread2
{
    internal class Program
    {
        private static object _lock = new();

        private static void KulonSzal(object meddig)
        {
            int eddig = (int)(meddig);
            for (int i = 0; i < eddig; i++)
            {
                lock (list)
                {
                    list.Add(i);
                }
            }
        }

        private static List<int> list = new List<int>();

        static void Main(string[] args)
        {
            Thread t = new Thread(KulonSzal);
            t.Start(10);
            Thread t2 = new Thread(KulonSzal);
            t2.Start(12);

            Thread.Sleep(1000);
        }
    }
}
