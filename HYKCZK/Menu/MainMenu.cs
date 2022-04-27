using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Service;

namespace BudgetManager.Menu
{
    internal class MainMenu : IMenu
    {
        private readonly IBudgetService _budgetService;
        private readonly IConsole _console;
        private readonly IMenu _manageBudgetMenu;

        public MainMenu(IConsole console, IBudgetService budgetService, ManageBudgetMenu manageBudgetMenu)
        {
            _console = console;
            _budgetService = budgetService;
            _manageBudgetMenu = manageBudgetMenu;

        }

        public void Open()
        {
            // TODO: refactor to delegates or something
            var options = new List<string>
            {
                "Statistics",
                "Manage Budget",
                "Quit"
            };

            while (true)
            {
                _console.WriteLine("Select from the list with the arrow keys:");
                var option = _console.SelectFromList(options);

                if (option == "Quit")
                {
                    break;
                }

                if (option == "Statistics")
                {
                    Statistics();
                }
                else if (option == "Manage Budget")
                {
                    ManageBudget();
                }
            }
        }

        private void Statistics()
        {
            _console.WriteLine("Your budget:");
            decimal incomeSum = _budgetService.GetIncomes().Sum();
            decimal costSum = _budgetService.GetCosts().Sum();
            _console.WriteLine("Incomes: {0}", _budgetService.FormatCurrencyAmount(incomeSum));
            _console.WriteLine("Costs: {0}", _budgetService.FormatCurrencyAmount(costSum));
            _console.WriteLine("Total: {0}", _budgetService.FormatCurrencyAmount(incomeSum - costSum));
            _console.WriteLine();
        }

        private void ManageBudget()
        {
            _manageBudgetMenu.Open();
        }
    }
}
