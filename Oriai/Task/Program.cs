using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    internal class Program
    {
        public static async Task<long> Sum(int meddig, CancellationToken token)
        {
            long sum = 0;
            for (int i = 0; i < meddig; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return -1;
                }
                sum += i;
                await Task.Delay(1000, token);
            }
            return sum;
        }

        private static CancellationTokenSource _tokenSource;

        static async Task Main(string[] args)
        {
            try
            {
                _tokenSource = new CancellationTokenSource();
                Console.CancelKeyPress += OnCancelKey;


                long result = await Sum(18888888, _tokenSource.Token);
                Console.Write(result);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Türelmetlen voltál");
            }
            finally
            {
                _tokenSource.Dispose();
            }
        }

        private static void OnCancelKey(object sender, ConsoleCancelEventArgs e)
        {
            _tokenSource.Cancel();
            e.Cancel = true; //amúgy nem lépünk ki
        }
    }
}
