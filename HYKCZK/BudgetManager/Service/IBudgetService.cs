using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Enum;
using BudgetManager.Model;

namespace BudgetManager.Service
{
    internal interface IBudgetService
    {
        decimal TotalIncome { get; }
        decimal TotalCost { get; }
        decimal TotalBudget { get; }
        decimal AverageMonthlyCost { get; }
        Currency Currency { get; }

        void SaveBudget();
        string FormatCurrencyAmount(decimal value, Currency currency);
        void AddIncome(Transaction transaction);
        void AddCost(Transaction transaction);
        void WriteSummary();
    }
}
