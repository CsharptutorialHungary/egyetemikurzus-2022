using BudgetManager.Enum;
using BudgetManager.Model;
using BudgetManager.Provider;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BudgetManager.Service
{
    internal sealed class BudgetService : IBudgetService
    {
        private readonly IConsole _console;
        private readonly IExchangeRateProvider _exchangeRateProvider;

        private string BudgetJsonPath { get; }
        private Budget Budget { get; }

        public BudgetService(IConsole console, IExchangeRateProvider exchangeRateProvider)
        {
            _console = console;
            _exchangeRateProvider = exchangeRateProvider;
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

        public static string FormatCurrencyAmount(decimal amount, Currency currency)
        {
            return $"{amount} {currency}";
        }

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
            var exchangeRateTask = _exchangeRateProvider.GetExchangeRate(Currency.HUF, Currency.EUR);
            decimal? totalInEur = null;
            try
            {
                var rate = exchangeRateTask.Result;
                totalInEur = TotalBudget * Convert.ToDecimal(rate);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null)
                {
                    _console.WriteLine("[Error]: {0}", ex.InnerException.Message);
                }
            }

            _console.WriteLine("Your budget:");
            _console.WriteLine("Incomes: {0}", FormatCurrencyAmount(TotalIncome));
            _console.WriteLine("Costs: {0}", FormatCurrencyAmount(TotalCost));
            _console.WriteLine("Total: {0}", FormatCurrencyAmount(TotalBudget));
            if (totalInEur.HasValue)
            {
                _console.WriteLine("       {0}", FormatCurrencyAmount(totalInEur.Value, Currency.EUR));
            }
            if (TotalBudget < 0)
            {
                _console.WriteLine("[Warning]: It seems like you have a loan. Pay it back as soon as possible.");
            }
            _console.WriteLine();
            
            _console.WriteLine("==== Last 20 transaction ====");
            var lastTransactions = Budget.Incomes.Union(Budget.Costs)
                .OrderByDescending(transaction => transaction.AccountedDateTime)
                .Take(20);

            foreach (var transaction in lastTransactions)
            {
                _console.WriteLine("{0,-25} {1,14} - {2}",
                    transaction.AccountedDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    FormatCurrencyAmount(transaction.Amount),
                    transaction.Description
                );
            }

            _console.WriteLine("=============================");
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
