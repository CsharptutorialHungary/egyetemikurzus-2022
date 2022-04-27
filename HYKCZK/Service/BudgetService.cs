using BudgetManager.Model;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BudgetManager.Service
{
    internal sealed class BudgetService : IBudgetService
    {
        private readonly IConsole _console;

        private string BudgetJsonPath { get; }
        private Budget Budget { get; }

        public BudgetService(IConsole console)
        {
            _console = console;
            BudgetJsonPath = @"budget.json";

            var budget = LoadBudgetFromJson();
            if (budget == null)
            {
                Budget = new Budget();
                _console.WriteLine("Creating new budget.");
                WriteBudgetToJson();
            }
            else
            {
                Budget = budget;
            }
        }

        public decimal TotalIncome => Budget.Incomes.Sum(transaction => transaction.Amount);

        public decimal TotalCost => Budget.Costs.Sum(transaction => transaction.Amount);

        public decimal TotalBudget => TotalIncome - TotalCost;
        public decimal AverageMonthlyCost { get; }

        public void SaveBudget()
        {
            WriteBudgetToJson();
        }

        public void AddIncome(Transaction transaction)
        {
            Budget.Incomes.Add(transaction);
        }

        public void AddCost(Transaction transaction)
        {
            Budget.Costs.Add(transaction);
        }

        public string GetCurrency()
        {
            return Budget.Currency;
        }

        public string FormatCurrencyAmount(decimal amount)
        {
            return $"{amount} {Budget.Currency}";
        }

        public void WriteSummary()
        {
            _console.WriteLine("Your budget:");
            _console.WriteLine("Incomes: {0}", FormatCurrencyAmount(TotalIncome));
            _console.WriteLine("Costs: {0}", FormatCurrencyAmount(TotalCost));
            _console.WriteLine("Total: {0}", FormatCurrencyAmount(TotalBudget));
            if (TotalBudget < 0)
            {
                _console.WriteLine("[Warning]: It seems like you have a loan. Pay it back as soon as possible.");
            }
            _console.WriteLine();
        }

        private Budget? LoadBudgetFromJson()
        {
            Budget? budget = null;
            try
            {
                _console.WriteLine($"Reading JSON {BudgetJsonPath}");

                var jsonText = File.ReadAllText(BudgetJsonPath);
                budget = JsonSerializer.Deserialize<Budget>(jsonText);

                _console.WriteLine($"JSON {BudgetJsonPath} was read successfully");
            }
            catch (Exception ex)
                when (ex is IOException or JsonException)
            {
                _console.WriteLine($"[Error]: Could not read {BudgetJsonPath} file.");
            }

            return budget;
        }

        private void WriteBudgetToJson()
        {
            try
            {
                _console.WriteLine($"Writing JSON {BudgetJsonPath}");

                var jsonText = JsonSerializer.Serialize(Budget, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                File.WriteAllText(BudgetJsonPath, jsonText);

                _console.WriteLine($"JSON {BudgetJsonPath} was written successfully.");
            }
            catch (Exception ex)
                when (ex is IOException or JsonException)
            {
                _console.WriteLine($"[Error]: Could not write {BudgetJsonPath} file.");
            }
        }
    }
}
