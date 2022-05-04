using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztPelda
{
    public interface IRandomProvider
    {
        int GetNumber(int minimum, int maximum);
    }

    public class RandomNumberProvider : IRandomProvider
    {
        private Random _rng = new Random();

        public int GetNumber(int minimum, int maximum)
        {
            return _rng.Next(minimum, maximum);
        }
    }

    public class RandomPrimeProvider
    {
        private readonly IRandomProvider _randomProvider;

        public RandomPrimeProvider(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
        }

        public int GetNumber(int minimum, int maximum)
        {
            bool isPime = false;
            do
            {
                int candidate = _randomProvider.GetNumber(minimum, maximum);
                isPime = PrimeFinder.IsPrime(candidate);
                if (isPime)
                    return candidate;
            }
            while (!isPime);

            throw new InvalidOperationException("This shouldn't happen...");
        }
    }
}
