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
            decimal amount;
            bool success;
            do
            {
                success = _console.TryReadDecimal(out amount, "Income ({0}): ", _budgetService.GetCurrency());
                if (!success)
                {
                    WriteInvalidValueError();
                }
            } while (!success);

            _budgetService.GetIncomes().Add(amount);
            _console.WriteLine("Income successfully recorded: {0}", _budgetService.FormatCurrencyAmount(amount));
        }

        private void AddCost()
        {
            decimal amount;
            bool success;
            do
            {
                success = _console.TryReadDecimal(out amount, "Cost ({0}): ", _budgetService.GetCurrency());
                if (!success)
                {
                    WriteInvalidValueError();
                }
            } while (!success);

            _budgetService.GetCosts().Add(amount);
            _console.WriteLine("Cost successfully recorded: {0}", _budgetService.FormatCurrencyAmount(amount));
        }

        private void WriteInvalidValueError()
        {
            _console.ForegroundColor = ConsoleColor.DarkRed;
            _console.WriteLine("Invalid value. Try again!");
            _console.ResetColor();
        }
    }
}
