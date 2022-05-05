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

            try
            {
                var exchangeRate = exchangeRates.First(rate =>
                    rate.SourceCurrency == sourceCurrency && rate.TargetCurrency == targetCurrency);

                return exchangeRate.Rate;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Exchange Rate doesn't exists for {sourceCurrency}/{targetCurrency} pair.", ex);
            }
        }
    }
}
