using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TesztPelda.Tests
{
   
    [TestFixture]
    internal class PrimeFinderTests
    {
        //3A
        //Arrange, Act, Assert
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(11)]
        [TestCase(13)]
        public void EnsureThat_PrimeFinder_IsPrime_ReturnsTrue_WhenPrime(int input)
        {
            //Arrange + Act
            bool result = PrimeFinder.IsPrime(input);
            Assert.IsTrue(result);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(8)]
        [TestCase(49)]
        public void EnsureThat_PrimeFinder_IsPrime_ReturnsFalse_WhenNotPrime(int input)
        {
            //Arrange + Act
            bool result = PrimeFinder.IsPrime(input);
            Assert.IsFalse(result);
        }
    }
}
