using System;
using BudgetManager.Enum;
using BudgetManager.Model;
using BudgetManager.Provider;
using BudgetManager.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetManager.Tests.Provider.Tests
{
    [TestFixture]
    internal class ExchangeRateProviderTests
    {
        private const double HUF_EUR_RATE = 0.03d;
        private const double HUF_USD_RATE = 0.037d;

        private Mock<IExchangeRateApiService> _exchangeRateApiServiceMock;

        private List<ExchangeRate> _exchangeRates;

        [SetUp]
        public void SetUp()
        {
            _exchangeRates = new List<ExchangeRate>
            {
                new (Currency.HUF, Currency.EUR, HUF_EUR_RATE),
                new (Currency.HUF, Currency.USD, HUF_USD_RATE)
            };

            _exchangeRateApiServiceMock = new Mock<IExchangeRateApiService>(MockBehavior.Strict);
            _exchangeRateApiServiceMock.Setup(m => m.FetchExchangeRatesAsync())
                .Returns(() => Task.FromResult(_exchangeRates));
        }

        [Test]
        [TestCase(Currency.HUF, Currency.EUR, HUF_EUR_RATE)]
        [TestCase(Currency.HUF, Currency.USD, HUF_USD_RATE)]
        public async Task GetExchangeRate_ExistingRates_ReturnsCorrectRate(Currency sourceCurrency, Currency targetCurrency, double expectedRate)
        {
            var sut = new ExchangeRateProvider(_exchangeRateApiServiceMock.Object);

            var result = await sut.GetExchangeRate(sourceCurrency, targetCurrency);

            Assert.That(result, Is.EqualTo(expectedRate));
        }

        [Test]
        public void GetExchangeRate_ApiError_ThrowsInvalidOperationException()
        {
            _exchangeRateApiServiceMock.Setup(m => m.FetchExchangeRatesAsync())
                .Returns(() => Task.FromResult(new List<ExchangeRate>()));

            var sut = new ExchangeRateProvider(_exchangeRateApiServiceMock.Object);

            async Task Actual()
            {
                await sut.GetExchangeRate(Currency.HUF, Currency.EUR);
            }

            Assert.ThrowsAsync<InvalidOperationException>(Actual);
        }
    }
}
