using BudgetManager.Enum;
using BudgetManager.Model;
using System.Text.Json;

namespace BudgetManager.Service
{
    internal class ExchangeRateApiService : IExchangeRateApiService
    {
        private readonly HttpClient _httpClient;

        private class ApiResponseObject
        {
            public string result { get; set; }
            public ConversionRates conversion_rates { get; set; }
        }

        private class ConversionRates
        {
            public double EUR { get; set; }
            public double USD { get; set; }
        }

        private string ApiKey => "e991c86c8554306f05aed7d7";
        private string ApiUrl => $"https://v6.exchangerate-api.com/v6/{ApiKey}";

        public ExchangeRateApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExchangeRate>> FetchExchangeRatesAsync()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync($"{ApiUrl}/latest/HUF");

                var json = await responseMessage.Content.ReadAsStringAsync();

                var responseObject = JsonSerializer.Deserialize<ApiResponseObject>(json);

                if (responseObject == null)
                {
                    return new List<ExchangeRate>();
                }

                return new List<ExchangeRate>
                {
                    new(Currency.HUF, Currency.EUR, responseObject.conversion_rates.EUR),
                    new(Currency.HUF, Currency.USD, responseObject.conversion_rates.USD)
                };
            }
            catch (Exception)
            {
                // TODO
                return new List<ExchangeRate>();
            }
        }
    }
}