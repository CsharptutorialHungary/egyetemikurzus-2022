// Alkalmazasfejlesztes C# alapokon a modern fejlesztesi iranyelvek bemutatasaval Kotelezo program
// Felegyi Mihaly Patrik - CC0LRB
// 2022. aprilis-majus
using Microsoft.AspNetCore.Hosting; // Tipusokkal szolgal, amik segitenek konfiguralni es elinditani web alkalmazasokat (Peldaul: WebHostBuilder es annak UseStartup metodusa)
using Microsoft.Extensions.Hosting; // Osztalyokkal es interfeszekkel szolgal, amik segitenek konfiguralni es elinditani web alkalmazasokat (Peldaul: Host osztaly, IHostBuilder interfesz)

namespace Todo
{
    public class Program
    {
        // Az app belepesi pontja
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Startup peldanyositasa
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
