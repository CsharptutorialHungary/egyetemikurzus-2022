using BudgetManager.Menu;
using BudgetManager.Provider;
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
                .AddSingleton<HttpClient>()
                .AddSingleton<IExchangeRateApiService, ExchangeRateApiService>()
                .AddSingleton<IExchangeRateProvider, ExchangeRateProvider>()
                .BuildServiceProvider();

            try
            {
                var mainMenu = serviceProvider.GetService<MainMenu>();
                if (mainMenu == null)
                {
                    Console.WriteLine("Application Could not start.");
                    return;
                }
                mainMenu.Open();

                serviceProvider.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Critical Error]: {0}", ex.Message);
                Console.WriteLine("Application shut down.");
            }
        }
    }
}
