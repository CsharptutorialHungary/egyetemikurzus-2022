using System.Diagnostics.CodeAnalysis;
using BudgetManager.Model;

namespace BudgetManager.Service
{
    internal sealed class BudgetService : IBudgetService
    {
        //private static BudgetService? _instance;

        //public static BudgetService Instance
        //{
        //    get { return _instance ??= new BudgetService(); }
        //}

        private Budget Budget { get; }

        public BudgetService()
        {
            Budget = new Budget()
            {
                Incomes = new List<decimal>
                {
                    400_000M,
                    400_000M
                },
                Costs = new List<decimal>
                {
                    50_000M
                },
                Currency = "HUF"
            };

            // LoadBudgetFromJSON();
        }

        private void LoadBudgetFromJSON()
        {
            // TODO: Load from JSON
            throw new NotImplementedException();
        }

        public List<decimal> GetIncomes()
        {
            return Budget.Incomes;
        }

        public List<decimal> GetCosts()
        {
            return Budget.Costs;
        }

        public string GetCurrency()
        {
            return Budget.Currency;
        }

        public string FormatCurrencyAmount(decimal amount)
        {
            return $"{amount} {Budget.Currency}";
        }
    }
}
