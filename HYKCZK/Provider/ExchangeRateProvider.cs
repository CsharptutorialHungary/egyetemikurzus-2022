using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Enum;
using BudgetManager.Service;

namespace BudgetManager.Provider
{
    internal class ExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IExchangeRateApiService _exchangeRateApiService;

        public ExchangeRateProvider(IExchangeRateApiService exchangeRateApiService)
        {
            _exchangeRateApiService = exchangeRateApiService;
        }

        public async Task<double> GetExchangeRate(Currency sourceCurrency, Currency targetCurrency)
        {
            // TODO: Cache
            var exchangeRates = await _exchangeRateApiService.FetchExchangeRatesAsync();

            var exchangeRate = exchangeRates.First(rate =>
                rate.SourceCurrency == sourceCurrency && rate.TargetCurrency == targetCurrency);

            if (exchangeRate == null)
            {
                throw new InvalidOperationException($"Exchange Rate doesn't exists for {sourceCurrency}/{targetCurrency} pair.");
            }
            return exchangeRate.Rate;
        }
    }
}
