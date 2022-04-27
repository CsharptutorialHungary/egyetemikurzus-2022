using BudgetManager.Menu;
using BudgetManager.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<MainMenu>()
                .AddSingleton<ManageBudgetMenu>()
                .AddSingleton<IConsole, SystemConsole>()
                .AddSingleton<IBudgetService, BudgetService>()
                .BuildServiceProvider();

            var mainMenu = serviceProvider.GetService<MainMenu>();
            if (mainMenu == null)
            {
                Console.WriteLine("Application Could not start.");
                return;
            }
            mainMenu.Open();
        }
    }
}
