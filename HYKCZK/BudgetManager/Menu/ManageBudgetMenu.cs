using BudgetManager.Model;
using BudgetManager.Provider;
using BudgetManager.Service;

namespace BudgetManager.Menu
{
    internal class ManageBudgetMenu : IMenu
    {
        private readonly IBudgetService _budgetService;
        private readonly IConsole _console;

        public ManageBudgetMenu(IConsole console, IBudgetService budgetService)
        {
            _console = console;
            _budgetService = budgetService;

        }

        public void Open()
        {
            var options = new List<string>
            {
                "Add Income",
                "Add Cost",
                "Back"
            };

            bool error;
            do
            {
                error = false;
                var option = _console.SelectFromList(options);
                try
                {
                    if (option == "Add Income")
                    {
                        AddIncome();
                    }
                    else if (option == "Add Cost")
                    {
                        AddCost();
                    }
                    else
                    {
                        return;
                    }
                }
                catch (FormatException e)
                {
                    _console.WriteLine(e.ToString());
                }

            } while (!error);
        }

        private void AddIncome()
        {
            var income = GetTransactionInput("Income");
            _budgetService.AddIncome(income);
        }

        private void AddCost()
        {
            var cost = GetTransactionInput("Cost");
            _budgetService.AddCost(cost);
        }

        private Transaction GetTransactionInput(string type)
        {
            decimal amount;
            string? description;

            while (!_console.TryReadDecimal(out amount, $"{type} ({_budgetService.Currency}): ") &&
                  amount < 0)
            {
                WriteInvalidValueError();
            }

            while (true)
            {
                description = _console.ReadString("Description: ");
                if (!string.IsNullOrEmpty(description))
                {
                    break;
                }

                _console.WriteLine("Description can't be empty.");
            }

            // TODO: timestamp

            _console.WriteLine($"{type} successfully recorded: {_budgetService.FormatCurrencyAmount(amount, _budgetService.Currency)}");
            return new Transaction(amount, description, DateTimeProvider.Now);
        }

        private void WriteInvalidValueError()
        {
            _console.ForegroundColor = ConsoleColor.DarkRed;
            _console.WriteLine("Invalid value. Only positive numbers allowed. Try again!");
            _console.ResetColor();
        }
    }
}
