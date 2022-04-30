using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Enum;

namespace BudgetManager.Model
{
    internal class ExchangeRate
    {
        public Currency SourceCurrency { get; set; }
        public Currency TargetCurrency { get; set; }
        public double Rate { get; set; }

        public ExchangeRate(Currency sourceCurrency, Currency targetCurrency, double rate)
        {
            SourceCurrency = sourceCurrency;
            TargetCurrency = targetCurrency;
            Rate = rate;
        }
    }
}
