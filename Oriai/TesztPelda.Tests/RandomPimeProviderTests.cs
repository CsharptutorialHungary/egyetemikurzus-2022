using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztPelda.Tests
{
    internal class TestRandomProvider : IRandomProvider
    {
        public int GetNumber(int minimum, int maximum)
        {
            return 3;
        }
    }

    [TestFixture]
    internal class RandomPimeProviderTests
    {
        [Test]
        public void EnsureThat_Random_PrimeProviderWorks()
        {
            //Arrage
            RandomPrimeProvider sut = new RandomPrimeProvider(new TestRandomProvider());
            //Act
            int result = sut.GetNumber(0, 100);
            //Assert
            Assert.AreEqual(3, result);
        }
    }
}
