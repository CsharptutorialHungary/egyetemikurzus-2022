using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Enum;

namespace BudgetManager.Provider
{
    internal interface IExchangeRateProvider
    {
        Task<double> GetExchangeRate(Currency sourceCurrency, Currency targetCurrency);
    }
}
