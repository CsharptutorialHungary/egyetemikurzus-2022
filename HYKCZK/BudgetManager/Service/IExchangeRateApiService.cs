using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;

namespace BudgetManager.Service
{
    internal interface IExchangeRateApiService
    {
        Task<List<ExchangeRate>> FetchExchangeRatesAsync();
    }
}
