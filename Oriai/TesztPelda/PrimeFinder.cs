using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztPelda
{
    public static class PrimeFinder
    {
        public static bool IsPrime(int input)
        {
            if (input == 2) return true;
            if (input < 3) return false;
            for (int i=2; i<=Math.Sqrt(input); i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
