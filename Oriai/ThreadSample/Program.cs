using System;
using System.Threading;

namespace ThreadSample
{
    internal class Program
    {
        private static int _meddig;

        static void Main(string[] args)
        {
            Thread thread = new Thread(KulonSzal);
            thread.Start(10);
            Thread thread2 = new Thread(KulonSzal);
            thread2.Start(100);
        }

        private static void KulonSzal(object meddig)
        {
            int eddig = (int)(meddig);
            for (int i = 0; i < eddig; i++)
            {
                Console.WriteLine("{0}. : {1}", i, DateTime.Now.Millisecond);
                Thread.Sleep(1000);
            }
        }
    }
}
