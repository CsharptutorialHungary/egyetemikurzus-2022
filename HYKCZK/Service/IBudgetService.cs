using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Service
{
    internal interface IBudgetService
    {
        void SaveBudget();

        List<decimal> GetIncomes();
        List<decimal> GetCosts();
        string GetCurrency();
        string FormatCurrencyAmount(decimal amount);
    }
}
