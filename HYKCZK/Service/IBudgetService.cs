using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;

namespace BudgetManager.Service
{
    internal interface IBudgetService
    {
        decimal TotalIncome { get; }
        decimal TotalCost { get; }
        decimal TotalBudget { get; }
        decimal AverageMonthlyCost { get; }

        void SaveBudget();

        void AddIncome(Transaction transaction);
        void AddCost(Transaction transaction);
        string GetCurrency();
        string FormatCurrencyAmount(decimal amount);
        void WriteSummary();
    }
}
