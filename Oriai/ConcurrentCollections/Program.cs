using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ConcurrentCollections
{
    internal class Program
    {
        static ConcurrentBag<int> bag;

        private static void KulonSzal(object meddig)
        {
            int eddig = (int)(meddig);
            for (int i = 0; i < eddig; i++)
            {
                bag.Add(i);
            }
        }

        static void Main(string[] args)
        {
            bag = new ConcurrentBag<int>();

            Thread t = new Thread(KulonSzal);
            t.Start(10);
            Thread t2 = new Thread(KulonSzal);
            t2.Start(12);

            Thread.Sleep(1000);
        }
    }
}
