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
                "Budget Summary",
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

                if (option == "Budget Summary")
                {
                    _budgetService.WriteSummary();
                }
                else if (option == "Manage Budget")
                {
                    ManageBudget();
                }
            }

            _console.WriteLine("Quitting from the application...");
            _budgetService.SaveBudget();
        }

        private void ManageBudget()
        {
            _manageBudgetMenu.Open();
        }
    }
}
