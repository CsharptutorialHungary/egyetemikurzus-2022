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

        public void SaveBudget()
        {
            WriteBudgetToJson();
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
