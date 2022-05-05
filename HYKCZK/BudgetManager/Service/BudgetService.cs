using BudgetManager.Enum;
using BudgetManager.Model;
using BudgetManager.Provider;
using System.IO.Abstractions;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BudgetManager.Service
{
    internal sealed class BudgetService : IBudgetService
    {
        private readonly IFileSystem _fileSystem;
        private readonly IConsole _console;
        private readonly IExchangeRateProvider _exchangeRateProvider;

        private string BudgetJsonPath { get; }
        private Budget Budget { get; }

        public BudgetService(IFileSystem fileSystem, IConsole console, IExchangeRateProvider exchangeRateProvider)
        {
            _fileSystem = fileSystem;
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
        public Currency Currency => Budget.Currency;

        public string FormatCurrencyAmount(decimal amount, Currency currency)
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
            _console.WriteLine("Incomes: {0}", FormatCurrencyAmount(TotalIncome, Budget.Currency));
            _console.WriteLine("Costs: {0}", FormatCurrencyAmount(TotalCost, Budget.Currency));
            _console.WriteLine("Total: {0}", FormatCurrencyAmount(TotalBudget, Budget.Currency));
            if (totalInEur.HasValue)
            {
                _console.WriteLine("       {0}", FormatCurrencyAmount(totalInEur.Value, Currency.EUR));
            }
            if (TotalBudget < 0)
            {
                _console.WriteLine("[Warning]: It seems like you have a loan. Pay it back as soon as possible.");
            }
            _console.WriteLine();

            var lastIncomes = Budget.Incomes
                .OrderByDescending(transaction => transaction.AccountedDateTime)
                .Take(10);

            var lastCosts = Budget.Costs
                .OrderByDescending(transaction => transaction.AccountedDateTime)
                .Take(10);

            _console.WriteLine("==== Last 10 Income ====");
            WriteTransactions(lastIncomes.ToList());
            _console.WriteLine("========================");

            _console.WriteLine();

            _console.WriteLine("====  Last 10 Cost  ====");
            WriteTransactions(lastCosts.ToList());
            _console.WriteLine("========================");

            _console.WriteLine();
        }

        public void SearchIncomes()
        {
            SearchIn(Budget.Incomes);
        }

        public void SearchCosts()
        {
            SearchIn(Budget.Costs);
        }

        private void SearchIn(List<Transaction> transactions)
        {
            string search;
            while(string.IsNullOrEmpty(search = _console.ReadString("Search for: ")))
            {
                _console.WriteLine("Empty search is not allowed.");
            }

            var results = (from transaction in transactions
                           where transaction.Description.Contains(search, StringComparison.CurrentCultureIgnoreCase)
                           select transaction).ToList();


            _console.WriteLine($"==== Found {results.Count} Transaction ====");
            WriteTransactions(results);
        }

        private void WriteTransactions(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                _console.WriteLine("{0,-25} {1,14} - {2}",
                    transaction.AccountedDateTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    FormatCurrencyAmount(transaction.Amount, Budget.Currency),
                    transaction.Description
                );
            };
        }

        private Budget? LoadBudgetFromJson()
        {
            Budget? budget = null;
            try
            {
                _console.WriteLine($"Reading JSON {BudgetJsonPath}");

                var jsonText = _fileSystem.File.ReadAllText(BudgetJsonPath);
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

                _fileSystem.File.WriteAllText(BudgetJsonPath, jsonText);

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
